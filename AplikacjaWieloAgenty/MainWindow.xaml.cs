using AplikacjaWieloAgenty.Agenci;
using AplikacjaWieloAgenty.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplikacjaWieloAgenty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Data();
            Proponowane = new ObservableCollection<Propozycja>();
            wynik.ItemsSource = Proponowane;
        }
        Game gra = new Game();
        
        Poszukiwacz poszukiwacz = new Poszukiwacz();
        Sprzedajacy sprzedawca1 = new Sprzedajacy();
        Sprzedajacy sprzedawca2 = new Sprzedajacy();

        public string Gra { get; set; }
        public string SklepString { get; set; }
        private ObservableCollection<Propozycja> proponowane;
        public ObservableCollection<Propozycja> Proponowane
        {
            get { return proponowane; }
            set
            {
                proponowane = value;
                OnPropertyChanged("Proponowane");
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Proponowane.Clear();
            SzukajProduktow();
        }

        private Game zbierzDaneOGrze()
        {
            Game dane = new Game();
            IEnumerable<ComboBox> listObj2 = grid.Children.OfType<ComboBox>();

            foreach (ComboBox combo in grid.Children.OfType<ComboBox>())
            {
                IEnumerable<ComboBox> listObj = grid.Children.OfType<ComboBox>();
                var obj = listObj.FirstOrDefault(n => n.Name == combo.Name+"Waga");
                if(obj != null)
                {
                    int waga = Convert.ToInt32(obj.Text.ToString());
                    dane.GetType().GetProperty(combo.Text).SetValue(dane,waga);
                }
                
            }
            return dane;
            
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void DodajPropozycje(List<Propozycje> propozycje)
        {
            foreach(Propozycje propozycja in propozycje)
            {
                Proponowane.Add(new Propozycja
                {
                    Nazwa = propozycja.Propozycja.Nazwa,
                    Cena = propozycja.Propozycja.Cena,
                    Sklep = propozycja.NazwaSklepu,
                });
            }
        }

        public void SzukajProduktow()
        {
            poszukiwacz = new Poszukiwacz();

            gra = zbierzDaneOGrze();

            Dane dane = new Dane();
            dane.Gra = gra;
            dane.Kwota = Convert.ToInt32(cena.Text);

            poszukiwacz.DodajDane(dane);

            sprzedawca1.przyjmiDane(poszukiwacz.dane);
            sprzedawca1.ZnajdzProponowane();

            sprzedawca2.przyjmiDane(poszukiwacz.dane);
            sprzedawca2.ZnajdzProponowane();

            var prop = poszukiwacz.ZdobadzProdukty(sprzedawca1);
            var prop1 = poszukiwacz.ZdobadzProdukty(sprzedawca2);

            poszukiwacz.WybierzNajlepsze();
            DodajPropozycje(poszukiwacz.NajlepszePropozycje);

            /*DodajPropozycje(prop);
            DodajPropozycje(prop1);*/
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Kupiles: " + Gra);
            var lista = poszukiwacz.NajlepszePropozycje.Where(p => p.Propozycja.Nazwa == Gra).ToList();
            Propozycja wybrany = lista.First().Propozycja;

            if(sprzedawca1.magazyn.Nazwa == SklepString)
            {
                if (wybrany != null)
                    poszukiwacz.DokonajZakupu(wybrany,sprzedawca1);
            }
            if (sprzedawca2.magazyn.Nazwa == SklepString)
            {
                if (wybrany != null)
                    poszukiwacz.DokonajZakupu(wybrany, sprzedawca2);
            }
            /*if (sprzedawca3.magazyn.Nazwa == SklepString)
            {
                if (wybrany != null)
                    poszukiwacz.DokonajZakupu(wybrany, sprzedawca3);
            }*/
        }

        private void wynik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string CellValue = ((TextBlock)RowColumn.Content).Text;
            Gra = CellValue;
            RowColumn = dataGrid.Columns[2].GetCellContent(row).Parent as DataGridCell;
            CellValue = ((TextBlock)RowColumn.Content).Text;
            SklepString = CellValue;
        }
    }
}

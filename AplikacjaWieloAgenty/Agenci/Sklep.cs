using AplikacjaWieloAgenty.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaWieloAgenty.Agenci
{
    public class Sklep
    {
        /*List<Produkt> produkty = new List<Produkt>();*/
        public List<Produkt> produkty { get; set; }
        public string Nazwa { get; set; }

        public Sklep()
        {
            Random rnd = new Random();
            produkty = new List<Produkt>();
            Data dane = new Data();
            produkty = dane.Produkty;
            Nazwa = "Sklep: " + Convert.ToString(rnd.Next(0, 100));
            UzupelniProdukty();
        }

        private void UzupelniProdukty()
        {
            using (GameConext context = new GameConext())
            {
                var list = context.Games.ToList();
                HashSet<int> losowe = new HashSet<int>();
                Random rand = new Random();

                do
                {
                    losowe.Add(rand.Next(0, 21));
                }
                while (losowe.Count < 16);

                List<int> num = new List<int>();
                num = losowe.ToList();

                foreach(int i in num)
                {
                    double procent = (rand.NextDouble()/10)+(rand.Next(0,2));
                    int c = produkty[i].Cena;
                    /*double cena = (double)c * procent;*/
                    c += rand.Next(0, 30) - 10;

                    produkty[i].Ilosc = rand.Next(1, 50);
                    produkty[i].Cena = c;
                    produkty[i].SprzedanoWTygodniu = rand.Next(0, 50);
                }
            }
        }
    }
}

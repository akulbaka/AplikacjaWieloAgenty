using AplikacjaWieloAgenty.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectsComparer;

namespace AplikacjaWieloAgenty.Agenci
{
    public class Poszukiwacz
    {
        public Dane dane { get; set; }
        public List<Propozycje> WszystkiePropozycje { get; set; }
        public List<Propozycje> NajlepszePropozycje { get; set; }
        public Poszukiwacz()
        {
            WszystkiePropozycje = new List<Propozycje>();
            NajlepszePropozycje = new List<Propozycje>();
        }

        public void DodajDane(Dane dn)
        {
            dane = dn;
        }

        public List<Propozycje> ZdobadzProdukty(Sprzedajacy sprzedajacy)
        {
            List<Produkt> proponowane = new List<Produkt>();
            proponowane = sprzedajacy.ZwrocProdukty();

            proponowane = Negocjuj(sprzedajacy, proponowane);

            List<Propozycje> propozycje = new List<Propozycje>();
            List<Propozycja> listaPropozycja = new List<Propozycja>();

            foreach (var item in proponowane)
            {
                listaPropozycja.Add(new Propozycja
                {
                    Nazwa = item.Nazwa,
                    Cena = item.Cena,
                });
            }

            foreach(var item in listaPropozycja)
            {
                propozycje.Add(new Propozycje
                {
                    Propozycja = item,
                    NazwaSklepu = sprzedajacy.magazyn.Nazwa,
                });
            }

            WszystkiePropozycje.AddRange(propozycje.ToList());

            return propozycje;
        }

        public void WybierzNajlepsze()
        {
            foreach(var item in WszystkiePropozycje)
            {
                var podobne = WszystkiePropozycje.Where(p => p.Propozycja.Nazwa == item.Propozycja.Nazwa);
                var p = podobne.OrderBy(p => p.Propozycja.Cena).ToList();
                if(!NajlepszePropozycje.Contains(p.First()))
                    NajlepszePropozycje.Add(p.First());
            }
        }

        private List<Produkt> Negocjuj(Sprzedajacy sprzedajacy, List<Produkt> produkty)
        {
            List<Produkt> result = new List<Produkt>();
            foreach(Produkt produkt in produkty)
            {
                Produkt nowy = new Produkt();
                do
                {
                    nowy = sprzedajacy.Negocjuj(produkt);
                    if(produkt.Cena <= dane.Kwota)
                    {
                        break;
                    }
                    if(nowy == null)
                    {
                        break;
                    }
                }
                while(nowy.Cena >= dane.Kwota);
                
                if(nowy != null && nowy.Cena <= dane.Kwota)
                {
                    result.Add(nowy);
                }
                if(produkt.Cena <= dane.Kwota)
                    result.Add((Produkt)produkt);
            }

            return result;
        }

        public bool DokonajZakupu(Propozycja produkt, Sprzedajacy sprzedawca)
        {
            var gra = sprzedawca.magazyn.produkty.Where(p => p.Nazwa == produkt.Nazwa).ToList().First();

            if(gra == null)
                return false;

            sprzedawca.SprzedajGre(gra);

            return true;
        }
    }
}

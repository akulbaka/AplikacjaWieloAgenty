using AplikacjaWieloAgenty.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaWieloAgenty.Agenci
{
    public class Sprzedajacy
    {
        private List<Produkt> ObnizPoSprzedazy { get; set; }
        private List<Produkt> ObnizPoProdukcji2 { get; set; }
        private List<Produkt> ObnizPoProdukcji5 { get; set; }
        private List<Produkt> ObnizPoIlosci { get; set; }
        private List<Sprzedane> Sprzedane { get; set; }

        public Sklep magazyn { get; set; }
        public Dane dane { get; set; }

        private List<Game> proponowane;
        public List<Game> Proponowane { get => proponowane; set => proponowane = value; }
        public List<Produkt> porpozycjaSklepu { get; set; }

        public Sprzedajacy()
        {
            magazyn = new Sklep();  
            ObnizPoSprzedazy = new List<Produkt>();
            ObnizPoProdukcji2 = new List<Produkt>();
            ObnizPoProdukcji5 = new List<Produkt>();
            ObnizPoSprzedazy = new List<Produkt>();
            ObnizPoIlosci = new List<Produkt>();
            Sprzedane = new List<Sprzedane>();
        }

        public void przyjmiDane(Dane dn)
        {
            dane = dn;
        }

        public void ZnajdzProponowane()
        {
            HashSet<Game> list;
            using (GameConext context = new GameConext())
            {
                list = context.Games.ToHashSet();
            }

            //przejscie przez wszystkie poperties w danych ktore podalismy
            foreach (var prop in dane.Gra.GetType().GetProperties())
            {
                var lsa = prop;
                var val = lsa.GetValue(dane.Gra, null);
                int wartosc = Convert.ToInt32(val);

                HashSet<Game> item = ZnajdzWBazie(prop.Name, wartosc);
                if (item.Count() > 0)
                {
                    list = PorownajListy(list, item);
                }
            }
            if (list.Count() > 0)
                Proponowane = list.ToList();

            ZnajdzWSklepie();
        }

        private HashSet<Game> ZnajdzWBazie(string columna, int wartosc)
        {
            HashSet<Game> pasujace = new HashSet<Game>();
            using (GameConext context = new GameConext())
            {
                var lista = context.Games.ToList();

                foreach (var item in lista)
                {
                    foreach (var prop in item.GetType().GetProperties())
                    {
                        if (!columna.Equals("Name") && !columna.Equals("Id"))
                        {
                            if (prop.Name == columna)
                            {
                                if (Convert.ToInt32(item.GetType().GetProperty(columna).GetValue(item)) >= wartosc)
                                    pasujace.Add(item);
                                else
                                    pasujace.Remove(item);
                            }
                        }
                    }
                }
            }
            return pasujace;
        }

        private HashSet<Game> PorownajListy(HashSet<Game> lista1, HashSet<Game> lista2)
        {
            var comparer = new ObjectsComparer.Comparer<Game>();
            HashSet<Game> zwort = new HashSet<Game>();
            foreach (Game item in lista1)
            {
                foreach (Game game in lista2)
                {
                    if (comparer.Compare(item, game))
                    {
                        zwort.Add(item);
                        break;
                    }
                }
            }

            return zwort;
        }

        private void ZnajdzWSklepie()
        {
            var k = dane.Kwota * 1.30;
            int kwota = Convert.ToInt32(k);

            List<Produkt> lista = new List<Produkt>();
            if (Proponowane != null)
            {
                foreach (var item in Proponowane)
                    lista.AddRange(magazyn.produkty.Where(p => p.Nazwa == item.Name && p.Cena <= kwota && p.Ilosc > 0));
            }

            porpozycjaSklepu = lista;
        }

        public List<Produkt> ZwrocProdukty()
        {
            return porpozycjaSklepu;
        }

        public Produkt Negocjuj(Produkt produkt)
        {
            if(produkt.SprzedanoWTygodniu < 5 && !ObnizPoSprzedazy.Contains(produkt))
            {
                ObnizCene(produkt);
                ObnizPoSprzedazy.Add(produkt);

                if (produkt.DataProdukcji < 2020 && !ObnizPoProdukcji2.Contains(produkt))
                {
                    ObnizCene(produkt);
                    ObnizPoProdukcji2.Add(produkt);

                    if (produkt.DataProdukcji < 2018 && !ObnizPoProdukcji5.Contains(produkt))
                    {
                        ObnizCene(produkt);
                        ObnizPoProdukcji5.Add(produkt);

                        if (produkt.Ilosc > 40 && produkt.SprzedanoWTygodniu < 10 && !ObnizPoIlosci.Contains(produkt))
                        {
                            ObnizCene(produkt);
                            ObnizPoIlosci.Add(produkt);

                            return produkt;
                        }

                        return produkt;
                    }

                    return produkt;
                }

                return produkt;
            }
            
            return null;
        }

        public void ObnizCene(Produkt produkt)
        {
            double cena = (double)produkt.Cena;
            cena -= cena * 0.05;

            var c = Convert.ToInt32(cena);
            produkt.Cena = c;
        }

        public void SprzedajGre(Produkt produkt)
        {
            var gra = magazyn.produkty.Where(p => p.Nazwa == produkt.Nazwa).First();
            gra.Ilosc--;
            gra.SprzedanoWTygodniu++;

            Sprzedane.Add(new Model.Sprzedane
            {
                produkt = gra,
                dane = dane,
            });

        }
    }
}

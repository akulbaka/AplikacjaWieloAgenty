using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaWieloAgenty.Model
{
    internal class Data
    {
        public List<string> ListaRealizm { get; set; }
        public List<string> ListaUrzadzen{ get; set; }
        public List<string> ListaSamochodow { get; set; }
        public List<string> ListaKonkurencji { get; set; }
        public List<string> ListaCzasu { get; set; }
        public List<int> Waga { get; set; }
        public List<Produkt> Produkty { get; set; }

        public Data()
        {
            ListaRealizm = new List<string>()
            {
                "Niski",
                "Sredni",
                "Trudny",
                "BardzoTrudny",
            };

            ListaUrzadzen = new List<string>()
            {
                "Klawiatura",
                "Pad",
                "Kierownica",
            };

            ListaSamochodow = new List<string>()
            {
                "Rally",
                "Sportowe",
                "OpenWheel",
            };

            ListaKonkurencji = new List<string>()
            {
                "Brak",
                "AI",
                "Online",
            };

            ListaCzasu = new List<string>()
            {
                "Tak",
                "Nie",
            };

            Waga = new List<int>()
            {
                0,
                1,
                2,
                3,
            };

            Produkty = new List<Produkt>()
            {
                new Produkt
                {
                    Nazwa = "F1 2021",
                    Cena = 200,
                    Ilosc = 0,
                    DataProdukcji = 2020,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "Assetto Corsa",
                    Cena = 80,
                    Ilosc = 0,
                    DataProdukcji = 2014,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "Grid 2",
                    Cena = 60,
                    Ilosc = 0,
                    DataProdukcji = 2016,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "Forza Horizon 5",
                    Cena = 200,
                    Ilosc = 0,
                    DataProdukcji = 2020,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "Iracing",
                    Cena = 450,
                    Ilosc = 0,
                    DataProdukcji = 2008,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "Dirt Rally 2.0",
                    Cena = 100,
                    Ilosc = 0,
                    DataProdukcji = 2018,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "Assetto Corsa Competitzione",
                    Cena = 120,
                    Ilosc = 0,
                    DataProdukcji = 2018,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "Forza Motosport 7",
                    Cena = 80,
                    Ilosc = 0,
                    DataProdukcji = 2016,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "WRC 10",
                    Cena = 220,
                    Ilosc = 0,
                    DataProdukcji = 2021,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "BeamNG",
                    Cena = 90,
                    Ilosc = 0,
                    DataProdukcji = 2022,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "Automobilista 2",
                    Cena = 130,
                    Ilosc = 0,
                    DataProdukcji = 2017,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "rFactor 2",
                    Cena = 180,
                    Ilosc = 0,
                    DataProdukcji = 2016,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "RaceRoom",
                    Cena = 40,
                    Ilosc = 0,
                    DataProdukcji = 2014,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "Project Cars 3",
                    Cena = 190,
                    Ilosc = 0,
                    DataProdukcji = 2020,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "Need for Speed",
                    Cena = 60,
                    Ilosc = 0,
                    DataProdukcji = 2018,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "Wreckfest",
                    Cena = 70,
                    Ilosc = 0,
                    DataProdukcji = 2018,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "The Crew 2",
                    Cena = 140,
                    Ilosc = 0,
                    DataProdukcji = 2019,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "Dirt 5",
                    Cena = 140,
                    Ilosc = 0,
                    DataProdukcji = 2021,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "NASCRAC Heat 5",
                    Cena = 150,
                    Ilosc = 0,
                    DataProdukcji = 2020,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "Art of Rally",
                    Cena = 60,
                    Ilosc = 0,
                    DataProdukcji = 2020,
                    SprzedanoWTygodniu = 0,
                },
                new Produkt
                {
                    Nazwa = "Richard Burns Rally",
                    Cena = 120,
                    Ilosc = 0,
                    DataProdukcji = 2004,
                    SprzedanoWTygodniu = 0,
                },
            };
        }
    }
}

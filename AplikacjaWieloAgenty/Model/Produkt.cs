using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaWieloAgenty.Model
{
    public class Produkt
    {
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public int Ilosc { get; set; }
        public int DataProdukcji { get; set; }
        public int SprzedanoWTygodniu { get; set; }
    }
}

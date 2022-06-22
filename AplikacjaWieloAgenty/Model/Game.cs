using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaWieloAgenty.Model
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Klawiatura { get; set; }
        public int Pad { get; set; }
        public int Kierownica { get; set; }
        public int Niski { get; set; }
        public int Sredni { get; set; }
        public int Trudny { get; set; }
        public int BardzoTrudny { get; set; }
        public int Rally { get; set; }
        public int Sportowe { get; set; }
        public int OpenWheel { get; set; }
        public int Brak { get; set; }
        public int AI { get; set; }
        public int Online { get; set; }
        public int Nie { get; set; }
        public int Tak { get; set; }

        public int CompareTo(Game? other)
        {
            throw new NotImplementedException();
        }
    }
}

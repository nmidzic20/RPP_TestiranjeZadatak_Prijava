using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prijava
{
    public enum TipKorisnika
    {
        Obicni,
        Gost,
        Administrator
    }

    public class Korisnik
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public TipKorisnika Tip { get; set; }
        public bool Aktivan { get; set; } = true;

    }
}

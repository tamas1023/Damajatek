using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damajatek
{
    class Dama
    {
        private string szin;
        private bool damae;

        public Dama(string szin, bool damae)
        {
            Szin = szin;
            Damae = damae;
        }

        public string Szin { get => szin; set => szin = value; }
        public bool Damae { get => damae; set => damae = value; }

    }
}

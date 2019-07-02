using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakturyZakupuMetody
{
    class Csv
    {
        
        private string Nazwa { get; set; }
        private decimal Objetosc { get; set; }
        private string Procent { get; set; }
        private string CN { get; set; }
        private decimal Ilosc { get; set; }

        public Csv(string nazwa, decimal objetosc, string procent, string cn, decimal ilosc)
        {
            this.Nazwa = nazwa;
            this.Objetosc = objetosc;
            this.Procent = procent;
            this.CN = cn;
            this.Ilosc = ilosc;
        }
    }
}

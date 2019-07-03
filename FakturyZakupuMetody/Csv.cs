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

        
        public void SetNazwa(string nazwa)
        {
            this.Nazwa = nazwa;
        }

        public void SetObjetosc(decimal objetosc)
        {
            this.Objetosc = objetosc;
        }

        public void SetProcent(string procent)
        {
            this.Procent = procent;
        }

        public void SetCN(string cn)
        {
            this.CN = cn;
        }

        public void SetIlosc(decimal ilosc)
        {
            this.Ilosc = ilosc;
        }

        public string GetNazwa()
        {
            return this.Nazwa;
        }
        public decimal GetObjetosc()
        {
            return this.Objetosc;
        }
        public string GetProcent()
        {
            return this.Procent;
        }
        public string GetCN()
        {
            return this.CN;
        }
        public decimal GetIlosc()
        {
            return this.Ilosc;
        }
    }
}

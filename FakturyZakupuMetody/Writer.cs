using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakturyZakupuMetody
{
    class Writer
    {

        private static string strFilePath2 = @"C:\Users\Dominika\Desktop\faktury.csv";

        public void WriterHeading(List<Csv> d)
        {
            if (d.Count > 0)
            {
                using (StreamWriter str = new StreamWriter((strFilePath2), true, System.Text.Encoding.GetEncoding(1252)))
                {
                    str.WriteLine(@"Nazwa;Objetość;Procent;CN;Ilość;");

                    str.Close();
                }
                MessageBox.Show("Dane zostały zapisane do pliku..");
            }
            else
                MessageBox.Show("Nie wybrałeś żadnej faktury.");

        }

        public void FileDelete()
        {
            if (File.Exists(strFilePath2))
            {
                File.Delete(strFilePath2);
            }
        }


        public void WriterRows(List<Csv> d)
        {
            foreach (Csv v in d)
            {
                using (StreamWriter str = new StreamWriter((strFilePath2), true, System.Text.Encoding.GetEncoding(1252)))
                {
                    str.WriteLine(v.GetNazwa()+";" + v.GetObjetosc()+";"+ v.GetProcent()+";"+ v.GetCN()+";"+v.GetIlosc());
                    str.Close();
                }
            }
        }

    }
}

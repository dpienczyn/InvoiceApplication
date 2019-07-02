using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakturyZakupuMetody
{
    public partial class Form1 : Form
    {

        DataBase d = new DataBase();



        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public int Magazyn()
        {
            int M = 0;

            if (checkBox1.Checked == true)
            {
                M = 1;
            }
            if (checkBox2.Checked == true)
            {

                M = 10;
            }
            if (checkBox1.Checked == false && checkBox2.Checked == false && M == 0)
            {
                MessageBox.Show("Nie wybrałeś żadnego z magazynów..");
            }
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                MessageBox.Show("Wybierz tylko jeden magazyn..");
            }

            return M;
        }



        public void TableDataRow(DataTable dtbl)
        {
            dataGridView1.AutoGenerateColumns = false;

            foreach (DataRow row in dtbl.Rows)
            {
                dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10);
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = row["NumerID_Faktury"];
                dataGridView1.Rows[i].Cells[1].Value = row["Nazwa_Kontrahenta"];
                dataGridView1.Rows[i].Cells[2].Value = row["Numer_Faktury"];
                dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Rows[i].Cells[3].Value = row["Data_Wystawienia"];
            }

        }

        public List<int> Find()
        {
            List<int> IDList = new List<int>();

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                if (Convert.ToBoolean(r.Cells[4].Value) == true)
                {
                    int NumerID_Faktury = Convert.ToInt32(r.Cells[0].Value);

                    IDList.Add(NumerID_Faktury);
                }
            }
            return IDList;
        }

        public void ClearDataGirdViewRows()
        {
            dataGridView1.Rows.Clear();
        }


        public void ClearDataTable(DataTable dtbl)
        {
            dtbl.Clear();
        }

        public string DownloadTimeOne()
        {
            string dataOne = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            return dataOne;
        }

        public string DownloadTimeTwo()
        {
            string dataTwo = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            return dataTwo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data_od = DownloadTimeOne();
            string data_do = DownloadTimeTwo();
            int mag_Id = Magazyn();
            DataBase NewDataBase = new DataBase();
            DataTable dtbl = NewDataBase.SelectCommodity(mag_Id, data_od, data_do);
            //ClearDataTable(dtbl);
            //ClearDataGirdViewRows();
            TableDataRow(dtbl);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBase datab = new DataBase();
            Writer w = new Writer();
            List<int> IDList = Find();
            //MessageBox.Show(IDList.ToString());
            List<Csv> d = datab.SelectCom(IDList);
            //w.FileDelete();
            w.WriterHeading(d);
            w.WriterRows(d);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

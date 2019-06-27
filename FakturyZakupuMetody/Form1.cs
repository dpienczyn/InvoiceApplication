﻿using System;
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

        public void Find()
        {
            List<int> IDList = new List<int>();

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                
                    if (Convert.ToBoolean(r.Cells[4].Value) == true)
                    {
                        int NumerID_Faktury = Convert.ToInt32(r.Cells[4].Value);

                        IDList.Add(NumerID_Faktury);
                    }
            }
        }

        public void ClearDataGirdViewRows()
        {
            dataGridView1.Rows.Clear();
        }


        public void ClearDataTable(DataTable dtbl)
        {
            dtbl.Clear();
        }

    }
}

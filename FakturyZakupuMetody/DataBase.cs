﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakturyZakupuMetody
{
    class DataBase
    {
        Form1 f = new Form1();

        private static string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        private SqlConnection sqlCon;

        public DataBase()
        {
            this.sqlCon = new SqlConnection(con);
        }

        public void ConnectCBMAX()
        {
            if (this.sqlCon.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    this.sqlCon.Open();
                }
                catch (Exception ex)
                {

                }
            }
        }
        public void DisconnectCBMAX()
        {
            if (this.sqlCon.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    this.sqlCon.Close();
                }
                catch (Exception ex)
                {

                }
            }

        }

        public DataTable SelectCommodity(int M)
        {
            this.ConnectCBMAX();
            DataTable dtbl = new DataTable();
            
            if (this.sqlCon.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("select dok_Id as NumerID_Faktury, adr_Nazwa as Nazwa_Kontrahenta, dok_NrPelnyOryg as Numer_Faktury, dok_DataWyst as Data_Wystawienia from dok__Dokument d left join adr__Ewid a on a.adr_IdObiektu = d.dok_PlatnikId where d.dok_MagId = @M and dok_DataWyst between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and '" + f.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and dok_Typ = 1 and d.dok_RodzajOperacjiVat = 2 and a.adr_TypAdresu = 1; ", this.sqlCon);
                cmd.Parameters.AddWithValue("@M", M);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dtbl);
            }
            return dtbl;
        }

        public List<Csv> SelectCom(int NumerID_Faktury)
        {
            this.ConnectCBMAX();
            List<Csv> d = new List<Csv>();

            if (this.sqlCon.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("select t.tw_Nazwa as Nazwa, t.tw_Objetosc as Objetosc, t.tw_Pole4 as Procent, t.tw_KodTowaru as CN, c.ob_Ilosc as Ilosc from dok_Pozycja c right join tw__Towar t on c.ob_TowId=t.tw_Id left join tw_Cena ce on c.ob_TowId = ce.tc_IdTowar left join dok__Dokument dk on c.ob_DokHanId = dk.dok_Id where dk.dok_Id=@NumerID_Faktury;", this.sqlCon);
                cmd.Parameters.AddWithValue("@NumerID_Faktury", NumerID_Faktury);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string nazwa = reader.GetString(0);
                        float objetosc = reader.GetFloat(1);
                        string procent = reader.GetString(2);
                        string cn = reader.GetString(3);
                        int ilosc = reader.GetInt32(4);
                        d.Add(new Csv(nazwa, objetosc, procent, cn, ilosc));
                    }
                }
            }
           return d;
        }
    }
}
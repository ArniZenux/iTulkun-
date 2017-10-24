using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace iTulkun
{
    class clsVidskiptavinur : Global 
    {
        #region "Class" 
        clsDatabase clsDbase = new clsDatabase();
        #endregion

        #region "Variables"
        public string kennitala, nafn, simi, heimilisfang, netfang, numer, kyn;
        public ListViewItem list;
        /*DataTable table;
        DataView dv;
        */
        #endregion

        #region "Properties"
        public void setNumer(string numer)
        {
            this.numer = numer; 
        }

        public void setKennitala(string kennitala)
        {
            this.kennitala = kennitala;
        }

        public void setNafn(string nafn)
        {
            this.nafn = nafn;
        }

        public void setSimi(string simi)
        {
            this.simi = simi;
        }

        public void setHeimilsfang(string heimili)
        {
            this.heimilisfang = heimili;
        }

        public void setNetfang(string netfang)
        {
            this.netfang = netfang;
        }

        public void setKyn(string kyn)
        {
            this.kyn = kyn; 
        }

        public string getNumer()
        {
            return numer;
        }

        public string getKennitala()
        {
            return kennitala;
        }

        public string getNafn()
        {
            return nafn;
        }

        public string getSimi()
        {
            return simi;
        }

        public string getHeimili()
        {
            return heimilisfang;
        }

        public string getNetfang()
        {
            return netfang;
        }

        public string getKyn()
        {
            return kyn; 
        }
        #endregion

        #region "Functions"

        #region "Nýr viðskiptavinur"
        //---------------------------//
        //Nýr viðskiptavinur - menu  //
        //---------------------------//
        public void skraNyrVidskiptavinur() {
            string sqlString = "INSERT INTO tblVidskiptavinir(KT, NAFN, SIMI, GATA, NETFANG, KYN) VALUES('" + kennitala + "','" + nafn + "','" + simi + "', '" + heimilisfang + "','" + netfang + "','" + kyn + "' ) ;";
            clsDbase.ExcuteQuery(sqlString); 
        }
        #endregion 

        #region "Hlaða viðskiptavinir"
        //-----------------------------------------//
        //Hlaða viðskiptavinir - pöntun/menu       //
        //-----------------------------------------//
        public void hladaVidskiptavinur(ListView listView1)
        {
           listView1.Items.Clear();

           string sqlString = "SELECT * FROM tblVidskiptavinir;";
           clsDbase.GetRecord(sqlString); 
             
           while(reader.Read())
           {
                list = new ListViewItem(reader[0].ToString());
                list.SubItems.Add(reader[1].ToString());
                listView1.Items.Add(list); 
            }
        }

        //-----------------------------------------//
        //Hlaða viðskiptavinir - Listbox           //
        //-----------------------------------------//
        public void hladaVidskiptavinurListBox(ListBox listBox1)
        {
            listBox1.Items.Clear();

            string sqlString = "SELECT * FROM tblVidskiptavinir;";
            clsDbase.GetRecord(sqlString);

            while (reader.Read())
            {
                listBox1.Items.Add(reader[1].ToString());
            }
            reader.Close();
        }
        #endregion

        #region "Velja einn viðskiptavin - Uppfæra"
        public void VeljaEinnVidskiptavin(string nafn, TextBox textBox1, TextBox textBox3, TextBox textBox4, TextBox textBox2, Label label6)
        {
            string sqlString = "SELECT * FROM tblVidskiptavinir WHERE NAFN = '" + nafn + "'; ";
            clsDbase.GetRecord(sqlString);

            while (reader.Read())
            {
                setKennitala(reader[0].ToString());
                textBox1.Text = reader[1].ToString();
                textBox3.Text = reader[2].ToString();
                textBox4.Text = reader[3].ToString();
                textBox2.Text = reader[4].ToString();
                label6.Text = reader[5].ToString();
            }
            reader.Close();
        }
        #endregion

        #region "Breyta viðskiptavin"
        //------------------------------//
        // Breyta Túlk - Form           //
        //------------------------------//
        public void BreytaVidskiptavin()
        {
            string sqlString = "UPDATE tblVidskiptavinir SET NAFN = '" + nafn + "' ,  SIMI = '" + simi + "', NETFANG = '" + netfang + "', GATA = '" + heimilisfang + "', KYN = '" + kyn + "' WHERE KT = '" + kennitala + "' ;";
            clsDbase.ExcuteQuery(sqlString);
        }
        #endregion 

        #region "Leita"
        //---------------------------//
        //Leita einstakling - menu   //
        //---------------------------//
        public void leitaVidskiptavinur(ListView listView1, string nafn_vid) 
        {
            if( nafn_vid != string.Empty)
            {
                string sqlString = "SELECT * FROM tblVidskiptavinir WHERE NAFN = '" + nafn_vid + "'; ";
                clsDbase.GetRecord(sqlString); 
            }

            else
            {
                string sqlString = "SELECT * FROM tblVidskiptavinir;";
                clsDbase.GetRecord(sqlString);
            }

            listView1.Items.Clear(); 

            while (reader.Read())
            {
                list = listView1.Items.Add(reader[2].ToString());
                list.SubItems.Add(reader[1].ToString());
            }

            reader.Close();
        }

        //@
        //  Leita starfsfólk í gagnagrunn
        //@
       /* public void leitaVidskiptavinur(string nafn, DataGridView dataGridView1)
        {
            dv = table.DefaultView;
            dv.RowFilter = string.Format("Nafn like '%{0}%'", nafn);
            dataGridView1.DataSource = dv.ToTable();
        }

        public void hladaVidskiptavinurDataGridView(DataGridView dataGridView1)
        {
            string sqlString = "SELECT * FROM tblVidskiptavinir";
            clsDbase.GetRecord(sqlString);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        */
        #endregion

        #region "panta túlk"
        public void pantaTulkur()
        {
            string sqlString = "INSERT INTO tblPanta(KT) VALUES('" + kennitala + "'); ";
            clsDbase.ExcuteQuery(sqlString); 
        }
        #endregion
               
        #region "telja fjöldi viðskiptavina"
        //-------------------------------//
        // Telja fjöldi viðskiptavina    //
        //-------------------------------//
        public void fjoldiVidskiptavina(Label label10)
        {
            string sqlString = "SELECT count(*) FROM tblVidskiptavinir";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label10.Text = reader[0].ToString();
            }
            reader.Close();
        }
        #endregion

        #region "Nota þetta seinna"
        public void skiptaUmPontun(string numer)
        {
            naKennitalaVidskiptavinur(numer);
            afritaPontun();
        }

        public void naKennitalaVidskiptavinur(string numer)
        {
            string sqlString = "SELECT KT FROM tblPanta WHERE NR = '" + numer + "'; ";
            clsDbase.GetRecord(sqlString);

            while (reader.Read())
            {
                kennitala = reader[0].ToString();
            }
            reader.Close();
        }

        public void afritaPontun()
        {
            string sqlString = "INSERT INTO tblPanta(KT) VALUES('" + kennitala + "'); ";
            clsDbase.ExcuteQuery(sqlString);
        }

        /*public void breytaVidskiptavinur() { }
        public void eydaVidskiptavinur() { }
        */
        #endregion 

        #endregion
    }
}

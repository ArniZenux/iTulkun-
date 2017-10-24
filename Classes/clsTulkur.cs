using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTulkun
{
    class clsTulkur : Global
    {
        #region "Class"
        clsDatabase clsDbase = new clsDatabase();
        #endregion

        #region "VARIABLES"
        public string kennitala, nafn, simi, netfang, vettvangur, numer; 
        public int vinna, maeta, fell;
        public ListViewItem list; 
        #endregion 
                
        #region "PROPERTIES"
        public void setNumer(string numer)
        {
            this.numer = numer; 
        }

        public void setKennitala(string kennitala)
        {
            this.kennitala = kennitala;
        }

        public void setNafn(string nafn){
            this.nafn = nafn; 
        }

        public void setSimi(string simi)
        {
            this.simi = simi;
        }
        
        public void setNetfang(string netfang)
        {
            this.netfang = netfang;
        }
       
        public void setVettvangur(string vettvangur)
        {
            this.vettvangur = vettvangur;
        }

        public void setVinna(int vinna)
        {
            this.vinna = vinna;
        }

        public void setMaeta(int maeta)
        {
            this.maeta = maeta;
        }
         
        public void setFell(int fell)
        {
            this.fell = fell;
        }

        public string getNr()
        {
            return numer; 
        }

        public string getKennitala()
        {
            return kennitala;
        }

        public string getNafn(){
            return nafn; 
        }
        
        public string getSimi()
        {
            return simi;
        }

        public string getNetfang()
        {
            return netfang;
        }

        public string getVettvangur()
        {
            return vettvangur;
        }

        public int getVinna()
        {
            return vinna;
        }

        public int getMaeta()
        {
            return maeta;
        }

        public int getFell()
        {
            return fell; 
        }

        #endregion

        #region "Functions"

        #region "Hlaða túlk"
        //-------------------------------------------------------//
        //Uppfæra && Aðalgluggi í listView1 (tab:túlkur) - Form  //
        //-------------------------------------------------------//
        public void hladaTulkur(ListBox listBox1)
        {
            listBox1.Items.Clear();
           
            string sqlString = "SELECT * FROM tblTulkur;";
            clsDbase.GetRecord(sqlString);

            while (reader.Read())
            {
                listBox1.Items.Add(reader[1].ToString());
            }
            reader.Close(); 
        }
        
        public void hladaTulkurListView(ListView listView2)
        {
            listView2.Items.Clear(); 

            string sqlString = "SELECT KT, NAFN FROM tblTulkur; ";
            clsDbase.GetRecord(sqlString);

            while (reader.Read())
            {
                list = new ListViewItem(reader[0].ToString());
                list.SubItems.Add(reader[1].ToString());
                listView2.Items.Add(list); 
            }
        }
        #endregion

        #region "Skrá nýr túlkur í tblTulkur"
        //------------------------------//    
        //  Nýr Túlkur - Form           //
        //------------------------------//
        public void skraNyrTulkur()
        {
            string sqlString = "INSERT INTO tblTulkur(KT, NAFN, SIMI, NETFANG) VALUES('" + kennitala + "','" + nafn + "','" + simi + "','" + netfang + "' ) ;";
            clsDbase.ExcuteQuery(sqlString); 
        }
        #endregion

        #region "Skrá ný pöntun - skrá vinna í tblVinna"
        //------------------------------//
        // Ný Pöntun - Form             //
        // Túlkur vinnur á verkefni     //
        //------------------------------//
        public void skraVinnaVerkefni()
        {
            string sqlString = "INSERT INTO tblVinna(KT,VINNA,MAETA,FELL,VETTVANGUR) VALUES('" + kennitala + "','" + vinna + "', '" + maeta + "','" + fell + "','" + vettvangur + "'); ";
            clsDbase.ExcuteQuery(sqlString);
        }
        #endregion

        #region "Uppfæra túlkur"
        //------------------------------//
        //  Uppfæra túlk - Form         // 
        //------------------------------//
        public void VeljaEinnTulkur(string nafn, TextBox textBox1, TextBox textBox3, TextBox textBox4)
        {
            string sqlString = "SELECT * FROM tblTulkur WHERE NAFN = '" + nafn + "'; ";
            clsDbase.GetRecord(sqlString);

            while (reader.Read())
            {
                setKennitala(reader[0].ToString());
                textBox1.Text = reader[1].ToString();
                textBox3.Text = reader[2].ToString();
                textBox4.Text = reader[3].ToString();
            }
            reader.Close();
        }

        //------------------------------//
        // Breyta Túlk - Form           //
        //------------------------------//
        public void BreytaTulkur()
        {
            string sqlString = "UPDATE tblTulkur SET NAFN = '" + nafn  + "' ,  SIMI = '" + simi +"', NETFANG = '" + netfang + "' WHERE KT = '" + kennitala + "' ;";
            clsDbase.ExcuteQuery(sqlString);
        }

        //------------------------------//
        // Eyða túlk - Form             //
        //------------------------------//
        public void EydaTulkur()
        {
            string sqlString = "DELETE FROM tblTulkur WHERE KT = '" + kennitala + "' ;";
            clsDbase.ExcuteQuery(sqlString); 
        }
        #endregion
        
        #region "Telja fjöldi túlka"
        //------------------------------//
        // Telja fjöldi túlka           //
        //------------------------------//
        public void fjoldiTulka(Label label9)
        {
            string sqlString = "SELECT count(*) FROM tblTulkur";
            clsDbase.GetRecord(sqlString);
                while (reader.Read())
                {
                label9.Text = reader[0].ToString();
                }
            reader.Close();
        }
        #endregion

        #region "Skipta um túlk"
        //------------------------------//
        // Skipta um túlk               // 
        // frmSkiptaTulk.cs             // 
        //------------------------------//
        public void skiptaUmTulk()
        {
            //afskraVinna();
            //skraVinnaVerkefni();
            skiptaTulkur();
        }

        /*public void afskraVinna()
        {
            string sqlString = "UPDATE tblVinna SET VINNA = '" + 0 + "'  WHERE NR = '" + numer + "' ;";
            clsDbase.ExcuteQuery(sqlString);
        }*/

        public void skiptaTulkur()
        {
            string sqlString = "UPDATE tblVinna SET KT = '" + kennitala + "'  WHERE NR = '" + numer + "' ;";
            clsDbase.ExcuteQuery(sqlString);
        }


        //------------------------------//
        // Skipta um túlk               // 
        // frmSkiptaTulk.cs             //
        //------------------------------//
        public void HladaKennitala(string nafn)
        {
            string sqlString = "SELECT KT FROM tblTulkur WHERE NAFN = '" + nafn + "'; ";
            clsDbase.GetRecord(sqlString);

            while (reader.Read())
            {
                kennitala = reader[0].ToString();
            }
            reader.Close();
        }

        public void erTulkurSkipta()
        {

        }
        #endregion

        #region "Viðskiptavinur hættur við"
        //------------------------------//
        // Viðskiptavinur hættur við    // 
        //------------------------------//
        /*public void finnaNrVinna(int nr)
        {
            string sqlString = "SELECT NR FROM tblVinna WHERE  NR = '" + nr + "';";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                setNumer( Int32.Parse( reader[0].ToString() ) );
            }
        } */  
        
       
        #endregion 

        /*public void HladaKennitala(string nafn)
         {
             string sqlString = "SELECT * FROM TULKUR WHERE NAFN = '" + nafn + "'; ";
             clsDbase.GetRecord(sqlString);

             while (reader.Read())
                 {
                     kennitala = reader[0].ToString();
                 }
                 reader.Close();
         }*/
        #endregion
    }
}

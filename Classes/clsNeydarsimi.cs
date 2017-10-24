using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTulkun
{
    class clsNeydarsimi : Global 
    {
        #region "Class"
        clsDatabase clsDbase = new clsDatabase(); 
        #endregion

        #region "VARIABLES"
        public string kennitala;
        public string byrja;
        public string endir;
        public string tima_byrja;
        public string tima_endir;
        public ListViewItem list;
        #endregion

        #region "PROPERTIES"
        public void setKennitala(string kennitala)
        {
            this.kennitala = kennitala;
        }

        public void setByrja(string byrja)
        {
            this.byrja = byrja;
        }

        public void setEndir(string endir)
        {
            this.endir = endir;
        }

        public void setTimaByrja(string tima_byrja)
        {
            this.tima_byrja = tima_byrja;
        }

        public void setTimaEndir(string tima_endir)
        {
            this.tima_endir = tima_endir;
        }

        public string getKennitala()
        {
            return kennitala; 
        }

        public string getByrja()
        {
            return byrja;
        }

        public string getEndir()
        {
            return endir;
        }

        public string getTimaByrja()
        {
            return tima_byrja;
        }

        public string getTimaEndir()
        {
            return tima_endir;
        }
        #endregion
        
        #region "Functions"
        public void SkraNeydarsimi()
        {
            string sqlString = "INSERT INTO neydarsimi(Kennitala,FRA_Dagssetningur,TIL_Dagssetningur,Byrjun_Timasetningur,Endir_Timasetningur) VALUES('" + kennitala + "','" + byrja + "','" + endir + "','" + tima_byrja + "','" + tima_endir + "') ;";
            clsDbase.ExcuteQuery(sqlString);
        }

        public void HladaNeydarsimi(ListView listView1)
        {
            listView1.Items.Clear();
            string sqlString = "SELECT Nafn, FRA_dagssetningur, TIL_dagssetningur, Byrjun_Timasetningur, Endir_Timasetningur FROM Taknmalstulkur, neydarsimi WHERE Taknmalstulkur.Kennitala = neydarsimi.Kennitala;";
            clsDbase.GetRecord(sqlString);

            while (reader.Read())
            {
                list = new ListViewItem(reader[0].ToString());
                list.SubItems.Add(reader[1].ToString());
                list.SubItems.Add(reader[2].ToString());
                list.SubItems.Add(reader[3].ToString());
                list.SubItems.Add(reader[4].ToString());
                listView1.Items.Add(list);
            }
            reader.Close();
        }
         
        #endregion
    }
}

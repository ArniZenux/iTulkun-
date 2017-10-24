using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTulkun
{
    class clsGreidsla : Global
    {
        #region "Class"
        clsDatabase clsDbase = new clsDatabase();
        #endregion

        #region "Variables"
        public string numer;
        public string heiti;
        public string upphaed;
        #endregion

        #region "Properties"
        public void setNr(string numer)
        {
            this.numer = numer; 
        }

        public void setHeiti(string heiti)
        {
            this.heiti = heiti;
        }

        public void setUpphaed(string upphaed)
        {
            this.upphaed = upphaed;
        }

        public string getNr()
        {
            return numer;
        }

        public string getHeiti()
        {
            return heiti;
        }

        public string getUpphaed()
        {
            return upphaed;
        }
        #endregion

        #region "Functions"
        #region "Skrá greiðsla"
        public void skraGreidsla()
        {
            string sqlString = "INSERT INTO tblGreidsla(HEITI, UPPHAED) VALUES('" + heiti + "', '" + upphaed + "'); ";
            clsDbase.ExcuteQuery(sqlString);
        }
        #endregion

        #region "Breyta greiðsla"
        public void breytaHeitiGreidsla()
        {
            string sqlString = "UPDATE tblGreidsla SET HEITI = '" + heiti + "' WHERE NR = '" + numer + "' ;";
            clsDbase.ExcuteQuery(sqlString);
        }
        #endregion

        #region "Afrita greiðsla vegna túlks skipta"
        public void afritaGreidsla(string numer)
        {
            naGreidsla(numer);
            skraGreidsla();
        }

        public void naGreidsla(string numer)
        {
            string sqlString = "SELECT tblGreidsla.HEITI, tblGreidsla.UPPHAED FROM tblGreidsla WHERE NR = '" + numer + "'; ";
            clsDbase.GetRecord(sqlString);

            while (reader.Read())
            {
                setHeiti(reader["HEITI"].ToString());
                setUpphaed(reader["UPPHAED"].ToString());
            }

            reader.Close();
        }
        #endregion 
        #endregion
    }
}

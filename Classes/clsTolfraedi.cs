using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace iTulkun
{
    class clsTolfraedi : Global
    {
        #region "Class"
        clsDatabase clsDbase = new clsDatabase();
        #endregion

        #region "Variables"
        #endregion

        #region "Functions"

        #region "Staða túlks"
        public void hladaStadaTulkur(string nafn, Label label4, Label label8,Label label10,Label label12,Label label14, Label label22,Label label28,Label label16,Label label18,Label label20,Label label26,Label label30,Label label25, Label label3, Label label6)
        {
            string sqlString = "SELECT count(*) FROM tblTulkur, tblVinna WHERE tblTulkur.KT = tblVinna.KT AND tblTulkur.NAFN = '" + nafn + "'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label4.Text = reader[0].ToString(); 
            }
                     
            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.MAETA = 0 AND tblTulkur.NAFN = '" + nafn + "'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label6.Text = reader[0].ToString(); 
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna WHERE  tblTulkur.KT = tblVinna.KT AND tblVinna.FELL = 0 AND tblTulkur.NAFN = '" + nafn + "'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label3.Text = reader[0].ToString();
            }

            //--------------------------------------------------------
            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblTulkur.NAFN = '" + nafn + "' AND tblVerkefni.VETTVANGUR = 'Fjármál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label10.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblTulkur.NAFN = '" + nafn + "' AND tblVerkefni.VETTVANGUR = 'Heilbriðarmál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label8.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblTulkur.NAFN = '" + nafn + "' AND tblVerkefni.VETTVANGUR = 'Menntamál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label18.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblTulkur.NAFN = '" + nafn + "' AND tblVerkefni.VETTVANGUR = 'Sálfræðiþjóunsta'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label22.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblTulkur.NAFN = '" + nafn + "' AND tblVerkefni.VETTVANGUR = 'Húsnæðismál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label12.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblTulkur.NAFN = '" + nafn + "' AND tblVerkefni.VETTVANGUR = 'Ráðgjöf og þjónusta'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label16.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblTulkur.NAFN = '" + nafn + "' AND tblVerkefni.VETTVANGUR = 'Bifreiðarmál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label14.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblTulkur.NAFN = '" + nafn + "' AND tblVerkefni.VETTVANGUR = 'Dómaramál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label20.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblTulkur.NAFN = '" + nafn + "' AND tblVerkefni.VETTVANGUR = 'Kirkjumál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label26.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblTulkur.NAFN = '" + nafn + "' AND tblVerkefni.VETTVANGUR = 'Hátíð og veisla'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label30.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblTulkur.NAFN = '" + nafn + "' AND tblVerkefni.VETTVANGUR = 'Atvinnumál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label28.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblTulkur.NAFN = '" + nafn + "' AND tblVerkefni.VETTVANGUR = 'Annað'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label25.Text = reader[0].ToString();
            }
            reader.Close();
                        
        }
        #endregion

        #region "Staða verkefna"
        public void hladaVettvangir(Label label4, Label label3, Label label8, Label label10, Label label12, Label label14, Label label22, Label label28, Label label16, Label label18, Label label20, Label label26, Label label30, Label label25)
        {
            string sqlString = "SELECT count(*) FROM tblVerkefni; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label4.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblVinna WHERE tblVinna.FELL = 0; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label3.Text = reader[0].ToString();
            }

            //--------------------------------------------------------
            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblVerkefni.VETTVANGUR = 'Fjármál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label10.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblVerkefni.VETTVANGUR = 'Heilbriðarmál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label8.Text =reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblVerkefni.VETTVANGUR = 'Menntamál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label18.Text =reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblVerkefni.VETTVANGUR = 'Sálfræðiþjóunsta'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label22.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblVerkefni.VETTVANGUR = 'Húsnæðismál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label12.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblVerkefni.VETTVANGUR = 'Ráðgjöf og þjónusta'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label16.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND  tblVerkefni.VETTVANGUR = 'Bifreiðarmál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label14.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblVerkefni.VETTVANGUR = 'Dómaramál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label20.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblVerkefni.VETTVANGUR = 'Kirkjumál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label26.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblVerkefni.VETTVANGUR = 'Hátíð og veisla'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label30.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblVerkefni.VETTVANGUR = 'Atvinnumál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label28.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblTulkur, tblVinna, tblVerkefni WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblVerkefni.VETTVANGUR = 'Annað'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label25.Text = reader[0].ToString();
            }

            reader.Close();
        }
        #endregion

        #region "Staða viðskiptavina"
        public void hladaStadaVidskiptavina(Label label4, Label label3, Label label8, Label label10, Label label12, Label label14, Label label22, Label label28, Label label16, Label label18, Label label20, Label label26, Label label30, Label label25)
        {
            string sqlString = "SELECT count(*) FROM tblVidskiptavinir WHERE tblVidskiptavinir.KYN = 'Karl' ; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label4.Text = reader[0].ToString();
            }
            
            sqlString = "SELECT count(*) FROM tblVidskiptavinir WHERE tblVidskiptavinir.KYN = 'Kona' ;  ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label3.Text = reader[0].ToString();
            }

            //--------------------------------------------------------
            sqlString = "SELECT count(*) FROM tblPanta WHERE tblPanta.VETTVANGUR = 'Fjármál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label10.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblPanta WHERE tblPanta.VETTVANGUR = 'Heilbriðarmál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label8.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblPanta WHERE tblPanta.VETTVANGUR = 'Menntamál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label18.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblPanta WHERE tblPanta.VETTVANGUR = 'Sálfræðiþjóunsta'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label22.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblPanta WHERE tblPanta.VETTVANGUR = 'Húsnæðismál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label12.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblPanta WHERE tblPanta.VETTVANGUR = 'Ráðgjöf og þjónusta'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label16.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblPanta WHERE tblPanta.VETTVANGUR = 'Bifreiðarmál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label14.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblPanta WHERE tblPanta.VETTVANGUR = 'Dómaramál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label20.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblPanta WHERE tblPanta.VETTVANGUR = 'Kirkjumál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label26.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblPanta WHERE tblPanta.VETTVANGUR = 'Hátíð og veisla'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label30.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblPanta WHERE tblPanta.VETTVANGUR = 'Atvinnumál'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label28.Text = reader[0].ToString();
            }

            sqlString = "SELECT count(*) FROM tblPanta WHERE tblPanta.VETTVANGUR = 'Annað'; ";
            clsDbase.GetRecord(sqlString);
            while (reader.Read())
            {
                label25.Text = reader[0].ToString();
            }
            
            reader.Close();
        }
        #endregion

        #endregion 
    }
}
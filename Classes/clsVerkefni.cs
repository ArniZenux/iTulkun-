using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.Windows.Forms;

namespace cdrom_wpf
{
    class clsVerkefni : Global
    {
        #region "Class"
        clsDatabase clsDbase = new clsDatabase();
        #endregion

        #region "Variables"
        public string Kennitala;
        public string Id;
        public string titill;
        public string dagur;
        public string stadsetningur;
        public string tima_byrja;
        public string tima_endir;
        public string vettvangur;
        public string greidsla;

        public int olokid_verkefni;
        public int lokid_verkefni; 
       
        public string[] dagir;
        public int day;
        public string month;
        public int year;
        public int month_string;

        public int fell = 1;
        public int fell_check; 
        public int maeta = 1;
        public int maeta_check;
        public int vinna = 1;
        public int vinna_check;

        public int day_DateTime_Now;
        public int month_DateTime_Now;
        public int year_DateTime_Now;

        public ListViewItem list, list2;
        public DateTime dt;
        #endregion

        #region "Properties"
        public void setId(string Id)
        {
            this.Id = Id;
        }

        public void setKennitala(string Kennitala)
        {
            this.Kennitala = Kennitala;
        }

        public void setTitill(string titill)
        {
            this.titill = titill;
        }
        public void setDagur(string dagur)
        {
            this.dagur = dagur;
        }

        public void setStadur(string stadur)
        {
            this.stadsetningur = stadur;
        }

        public void setTima_Byrja(string tima_byrja)
        {
            this.tima_byrja = tima_byrja;
        }

        public void setTima_Endir(string tima_endir)
        {
            this.tima_endir = tima_endir;
        }

        public void setVettvangur(string vettvangur)
        {
            this.vettvangur = vettvangur;
        }

        public void setGreidsla(string greidsla)
        {
            this.greidsla = greidsla;
        }

        public string getId()
        {
            return Id;
        }

        public string getKennitala()
        {
            return Kennitala;
        }

        public string getTilill()
        {
            return titill;
        }

        public string getDagur()
        {
            return dagur;
        }

        public string getStadur()
        {
            return stadsetningur;
        }

        public string getTima_Byrja()
        {
            return tima_byrja;
        }

        public string getTima_Endir()
        {
            return tima_endir;
        }

        public string getVettvangur()
        {
            return vettvangur;
        }

        public string getGreidsla()
        {
            return greidsla;
        }
        #endregion

        #region "Functions"

        #region "Virkar og stilla á dagssetning og mánaðar" 
        public void virkjaDagur()
        {
            dt = DateTime.Now;
            day_DateTime_Now = dt.Day;
            month_DateTime_Now = dt.Month;
            year_DateTime_Now = dt.Year;
            Console.WriteLine("Year_now: " + year_DateTime_Now);
        }

        public void skiptaDagurInteger(string byrja_)
        {
            dagir = byrja_.Split('.');
            day = Int32.Parse(dagir[0]);
            month = dagir[1];
            year = Int32.Parse(dagir[2]);
            Console.WriteLine("Month: " + month + "Year: " + year); 
        }

        public void writeMonthInInteger()
        {
            if (month.Equals("janúar")) { month_string = 1; }
            if (month.Equals("febrúar")) { month_string = 2; }
            if (month.Equals("mars")) { month_string = 3; }
            if (month.Equals("apríl")) { month_string = 4; }
            if (month.Equals("maí")) { month_string = 5; }
            if (month.Equals("júní")) { month_string = 6; }
            if (month.Equals("júlí")) { month_string = 7; }
            if (month.Equals("ágúst")) { month_string = 8; }
            if (month.Equals("september")) { month_string = 9; }
            if (month.Equals("október")) { month_string = 10; }
            if (month.Equals("nóvember")) { month_string = 11; }
            if (month.Equals("desember")) { month_string = 12; }
        }
        #endregion

        #region "Hlaða verkefnalisti í tab" 
        //------------------------------------------//
        //Túlka verkefna - Tab (táknmálstúlkur)     //
        //------------------------------------------//
        public void hladaTulkurVerkefni(ListView listView1)
        {
            listView1.Items.Clear();

            string sqlString = "SELECT tblVerkefni.NR, tblVerkefni.HEITI, tblVerkefni.STADUR, tblVinna.FEll, tblVinna.MAETA, tblVerkefni.DAGUR, tblVerkefni.TIMI_BYRJA, tblVerkefni.TIMI_ENDIR, tblGreidsla.HEITI, tblVerkefni.VETTVANGUR, tblVidskiptavinir.NAFN FROM tblTulkur, tblVinna, tblVerkefni, tblGreidsla, tblPanta, tblVidskiptavinir WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblGreidsla.NR = tblVerkefni.NR AND tblVerkefni.NR = tblPanta.NR AND tblPanta.KT = tblVidskiptavinir.KT AND tblTulkur.KT = '" + Kennitala + "' ORDER BY tblVerkefni.NR DESC ;";

            clsDbase.GetRecord(sqlString);

            while (reader.Read())
            {
                list = new ListViewItem(reader[0].ToString());
                list.SubItems.Add(reader[1].ToString());
                list.SubItems.Add(reader[2].ToString());
                fell = Int32.Parse(reader[3].ToString());
                maeta = Int32.Parse(reader[4].ToString());
                //list.SubItems.Add(reader["DAGUR"].ToString());
                skiptaDagurInteger(reader["DAGUR"].ToString());
                writeMonthInInteger();
                //--------------------------------------------------------------------------------

                if (fell == 1)
                {
                    if (maeta == 1)
                    {
                        if (year_DateTime_Now < year)
                        {
                            list.BackColor = System.Drawing.Color.Beige;
                            list.SubItems.Add(reader["DAGUR"].ToString());
                            olokid_verkefni++;
                        }
                        else if (year_DateTime_Now == year)
                        {
                            if (month_DateTime_Now < month_string)
                            {
                                list.BackColor = System.Drawing.Color.Beige;
                                list.SubItems.Add(reader["DAGUR"].ToString());
                                olokid_verkefni++;
                            }
                            else if (month_DateTime_Now == month_string)
                            {
                                if (day_DateTime_Now <= day)
                                {
                                    if (day_DateTime_Now == day)
                                    {
                                        list.BackColor = System.Drawing.Color.LightGreen;
                                        list.SubItems.Add(reader["DAGUR"].ToString());
                                        olokid_verkefni++;
                                    }
                                    else
                                    {
                                        list.BackColor = System.Drawing.Color.Beige;
                                        list.SubItems.Add(reader["DAGUR"].ToString());
                                        olokid_verkefni++;
                                    }
                                }
                                else
                                {
                                    list.BackColor = System.Drawing.Color.LightCoral;
                                    list.SubItems.Add(reader["DAGUR"].ToString());
                                    lokid_verkefni++;
                                }
                            }
                            else
                            {
                                list.BackColor = System.Drawing.Color.LightCoral;
                                list2.SubItems.Add(reader["DAGUR"].ToString());
                                lokid_verkefni++;
                            }
                        }
                        else if (year_DateTime_Now > year)
                        {
                            list.BackColor = System.Drawing.Color.LightCoral;
                            list.SubItems.Add(reader["DAGUR"].ToString());
                            lokid_verkefni++;
                        }
                    }
                    else
                    {
                        list.BackColor = System.Drawing.Color.LightSkyBlue;
                        list.SubItems.Add(reader["DAGUR"].ToString());
                    }
                }
                else
                {
                    list.BackColor = System.Drawing.Color.LightSlateGray;
                    list.SubItems.Add(reader["DAGUR"].ToString());
                }
                 
                //--------------------------------------------------------------------------------
                list.SubItems.Add(reader[6].ToString());
                list.SubItems.Add(reader[7].ToString());
                list.SubItems.Add(reader[8].ToString());
                list.SubItems.Add(reader[9].ToString());
                list.SubItems.Add(reader[10].ToString());

                listView1.Items.Add(list);
            }
            reader.Close();
        }

        //--------------------------------//
        //Verkefnalisti - Tab (verkefni)  //  
        //--------------------------------//
        public void hladaVerkefni(ListView listView3, Label label11, Label label12)
        {
            listView3.Items.Clear();
            virkjaDagur();
            lokid_verkefni = 0;
            olokid_verkefni = 0; 

            string sqlString = "SELECT tblVerkefni.NR, tblVerkefni.HEITI, tblVerkefni.STADUR, tblVinna.FELL, tblVinna.MAETA, tblVerkefni.DAGUR, tblVerkefni.TIMI_BYRJA, tblVerkefni.TIMI_ENDIR, tblGreidsla.HEITI, tblVerkefni.VETTVANGUR, tblVidskiptavinir.NAFN, tblTulkur.NAFN FROM tblTulkur, tblVinna, tblVerkefni, tblGreidsla, tblPanta, tblVidskiptavinir WHERE tblTulkur.KT = tblVinna.KT AND tblVinna.NR = tblVerkefni.NR AND tblVerkefni.NR = tblGreidsla.NR AND tblVerkefni.NR = tblPanta.NR AND tblPanta.KT = tblVidskiptavinir.KT ORDER BY tblVerkefni.NR DESC;";

            clsDbase.GetRecord(sqlString);

            while (reader.Read())
            {
                list2 = new ListViewItem(reader[0].ToString());
                list2.SubItems.Add(reader[1].ToString());
                list2.SubItems.Add(reader[2].ToString());
                fell = Int32.Parse(reader[3].ToString());
                maeta = Int32.Parse(reader[4].ToString());
                skiptaDagurInteger(reader["DAGUR"].ToString());
                writeMonthInInteger();

                //--------------------------------------------------------------------------------

                if (fell == 1)
                {
                    if (maeta == 1)
                    {
                        if (year_DateTime_Now < year)
                        {
                            list2.BackColor = System.Drawing.Color.Beige;
                            list2.SubItems.Add(reader["DAGUR"].ToString());
                            olokid_verkefni++;
                        }
                        else if (year_DateTime_Now == year)
                        {
                            if (month_DateTime_Now < month_string)
                            {
                                list2.BackColor = System.Drawing.Color.Beige;
                                list2.SubItems.Add(reader["DAGUR"].ToString());
                                olokid_verkefni++;
                            }
                            else if (month_DateTime_Now == month_string)
                            {
                                if (day_DateTime_Now <= day)
                                {
                                    if (day_DateTime_Now == day)
                                    {
                                        list2.BackColor = System.Drawing.Color.LightGreen;
                                        list2.SubItems.Add(reader["DAGUR"].ToString());
                                        olokid_verkefni++;
                                    }
                                    else
                                    {
                                        list2.BackColor = System.Drawing.Color.Beige;
                                        list2.SubItems.Add(reader["DAGUR"].ToString());
                                        olokid_verkefni++;
                                    }
                                }
                                else
                                {
                                    list2.BackColor = System.Drawing.Color.LightCoral;
                                    list2.SubItems.Add(reader["DAGUR"].ToString());
                                    lokid_verkefni++;
                                }
                            }
                            else
                            {
                                list2.BackColor = System.Drawing.Color.LightCoral;
                                list2.SubItems.Add(reader["DAGUR"].ToString());
                                lokid_verkefni++;
                            }
                        }
                        else if (year_DateTime_Now > year)
                        {
                            list2.BackColor = System.Drawing.Color.LightCoral;
                            list2.SubItems.Add(reader["DAGUR"].ToString());
                            lokid_verkefni++;
                        }
                    }
                    else
                    {
                        list2.BackColor = System.Drawing.Color.LightSkyBlue;
                        list2.SubItems.Add(reader["DAGUR"].ToString());
                    }
                }
                else
                {
                    list2.BackColor = System.Drawing.Color.LightSlateGray;
                    list2.SubItems.Add(reader["DAGUR"].ToString());
                }
               
                //--------------------------------------------------------------------------------
                //list2.SubItems.Add(reader["DAGUR"].ToString());
                list2.SubItems.Add(reader[6].ToString());
                list2.SubItems.Add(reader[7].ToString());
                list2.SubItems.Add(reader[8].ToString());
                list2.SubItems.Add(reader[9].ToString());
                list2.SubItems.Add(reader[10].ToString());
                list2.SubItems.Add(reader[11].ToString());

                listView3.Items.Add(list2);
                label11.Text = lokid_verkefni.ToString();
                label12.Text = olokid_verkefni.ToString(); 
            }
            reader.Close();
        }
        #endregion

        #region "Opna verkefni í Listview"
        //--------------------------//
        //  Er verkefni fell?       //
        //--------------------------//
        public int erVerkefniFell(int nr)
        {
            string sqlString = "SELECT tblVinna.FELL FROM tblVinna WHERE NR = '" + nr + "';";
            clsDbase.GetRecord(sqlString);

            while (reader.Read())
            {
                fell_check = Int32.Parse(reader["FELL"].ToString());
            }

            return fell_check;
        }

        //--------------------------//
        // Athugun hvort mæta ekki  //
        //--------------------------//
        public int maetaVidskiptavinurEkki(int nr)
        {
            string sqlString = "SELECT tblVinna.MAETA FROM tblVinna WHERE NR = '" + nr + "';";
            clsDbase.GetRecord(sqlString);

            while (reader.Read())
            {
                maeta_check = Int32.Parse(reader["MAETA"].ToString());
            }

            return maeta_check;
        }

        //--------------------------//
        // Athugun hvort túlkur skita  //
        //--------------------------//
        public int erTulkurSkipta(int nr)
        {
            string sqlString = "SELECT tblVinna.VINNA FROM tblVinna WHERE NR = '" + nr + "';";
            clsDbase.GetRecord(sqlString);

            while (reader.Read())
            {
                vinna_check = Int32.Parse(reader["VINNA"].ToString());
            }

            return vinna_check;
        }
        #endregion

        #region "Pöntun og uppfæra FORM"
        //-------------------//
        // Pöntun - Form     //
        //-------------------//
        public void skraVerkefni()
        {
            string sqlString = "INSERT INTO tblVerkefni(HEITI, STADUR, DAGUR, TIMI_BYRJA, TIMI_ENDIR, VETTVANGUR) VALUES('" + titill + "','" + stadsetningur + "','" + dagur + "','" + tima_byrja + "','" + tima_endir + "','" + vettvangur + "'); ";
            clsDbase.ExcuteQuery(sqlString);
        }

        //----------------------------//
        // Uppfæra verkefni - Form    //
        //----------------------------//
        public void breytaVerkefni()
        {
            string sqlString = "UPDATE tblVerkefni SET HEITI = '" + titill + "' , STADUR = '" + stadsetningur + "' , DAGUR = '" + dagur + "' , TIMI_BYRJA = '" + tima_byrja + "', TIMI_ENDIR = '" + tima_endir + "', VETTVANGUR = '" + vettvangur + "'  WHERE NR = '" + Id + "' ;";
            clsDbase.ExcuteQuery(sqlString);
        }
        #endregion

        #region "Verkefni fell"
        //---------------------------------------//
        // Verkefni fell                         //
        // -Select_ListView1.cs: Fell verkefni?  //
        //---------------------------------------//
        public void fellVerkefni()
        {
            string sqlString = "UPDATE tblVinna SET FELL = '" + 0 + "' WHERE NR = '" + Id + "' ;";
            clsDbase.ExcuteQuery(sqlString);
        }
        #endregion

        #region "Viðtaskiptavinur hættur við"
        //---------------------------------------//
        //  Viðskiptavinur hættur við            //
        // -Select_ListView1.cs: Fell verkefni?  // 
        //---------------------------------------//
        public void skraVidskiptavinurKomaEkki()
        {
            string sqlString = "UPDATE tblVinna SET MAETA = '" + 0 + "'  WHERE NR = '" + Id + "' ;";
            clsDbase.ExcuteQuery(sqlString);
        }
        #endregion

        #region "Skitpa um túlk" 
        //-------------------------------------------//
        // Skipta um túlk                            //
        // -Skrá nýtt verkefni niður í database      //
        // -frmSkiptaTulkur.cs : Skipta túlk - Form  //
        //-------------------------------------------//
        public void skiptaUmVerkefni()
        {
            skraAfritaVerkefni();
        }

        public void skraAfritaVerkefni()
        {
            string sqlString = "INSERT INTO tblVerkefni(HEITI, STADUR, DAGUR, TIMI_BYRJA, TIMI_ENDIR, VETTVANGUR) VALUES('" + titill + "','" + stadsetningur + "','" + dagur + "','" + tima_byrja + "','" + tima_endir + "','" + vettvangur + "'); ";
            clsDbase.ExcuteQuery(sqlString);
        }
        #endregion

        #endregion 

    }
}
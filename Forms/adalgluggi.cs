using iTulkun.Forms;
using System;
using System.Collections; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTulkun
{
    public partial class adalgluggi : Form
    {
        #region "Classes"
        clsTulkur tulkur = new clsTulkur();
        clsVerkefni verk = new clsVerkefni();
        clsVidskiptavinur vidskipta = new clsVidskiptavinur();
        #endregion

        #region "Variables"
        public ListViewItem items, item, item2;
        public string Kennitala;
        public string[] List = new string[9];
        #endregion

        #region "Form - Adalgluggi"
        public adalgluggi()
        {
            InitializeComponent();
            label1.Text = " ";
        }
        #endregion

        #region "Endurhlaða-Túlkur"
        public void endurhladaTulkur()
        {
            tulkur.hladaTulkurListView(listView2);
        }
        #endregion

        #region "Endurhlaða-Verkefni"
        public void endurhladaVerkefni()
        {
            verk.hladaTulkurVerkefni(listView1);
            verk.hladaVerkefni(listView3, label11, label12);
        }
        #endregion

        #region "Load Form"
        private void Form1_Load(object sender, EventArgs e)
        {
            verk.hladaVerkefni(listView3, label11, label12);

            tulkur.hladaTulkurListView(listView2);
            
            hladaListView1();
            hladaListView2();
            hladaListView3();

            tulkur.fjoldiTulka(label9);
            vidskipta.fjoldiVidskiptavina(label10); 

        }
        #endregion

        #region "ListView1"
        public void hladaListView1()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
        }
        #endregion 

        #region "ListView2"
        public void hladaListView2()
        {
            listView2.View = View.Details;
            listView2.GridLines = true;
            listView2.FullRowSelect = true;
        }
        #endregion

        #region "ListView3"
        public void hladaListView3()
        {
            listView3.View = View.Details;
            listView3.GridLines = true;
            listView3.FullRowSelect = true;
        }
        #endregion 

        #region "ListView1_Select - Verkefni"
        //-------------------------//
        // Verkefnalisti túlka-tab //
        //-------------------------//
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                items = listView1.SelectedItems[0];

                //verk.setId(items.SubItems[0].Text);
                List[0] = items.SubItems[0].Text;
                List[1] = items.SubItems[1].Text;
                List[2] = items.SubItems[2].Text;
                List[3] = items.SubItems[3].Text;
                List[4] = items.SubItems[4].Text;
                List[5] = items.SubItems[5].Text;
                List[6] = items.SubItems[6].Text;
                List[7] = items.SubItems[7].Text;

                if (verk.erTulkurSkipta(Int32.Parse(List[0])) == 1)
                {
                    if (verk.erVerkefniFell(Int32.Parse(List[0])) == 1)
                    {
                        if (verk.maetaVidskiptavinurEkki(Int32.Parse(List[0])) == 1)
                        {
                            select_Listview1 sList = new select_Listview1(List, this);
                            sList.Show();
                        }
                        else
                        {
                            MessageBox.Show("Þvi miður að viðskiptavinur mæta ekki", "Tilkynning");
                            //Viltu að afrita verkefni -> framhald 
                        }
                    }
                    else
                    {
                        MessageBox.Show("Þvi miður að verkefni er fell niður.", "Tilkynning");
                        //Viltu að afrita verkefni -> framhald
                    }
                }
                else
                {
                    MessageBox.Show("Þvi miður að túlkur skipta!.", "Tilkynning");
                }
            }
        }

        //--------------------------//
        // Verkefnalisti-tab        //
        //--------------------------//
        private void listView3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                items = listView3.SelectedItems[0];

                //verk.setId(items.SubItems[0].Text);
                List[0] = items.SubItems[0].Text;
                List[1] = items.SubItems[1].Text;
                List[2] = items.SubItems[2].Text;
                List[3] = items.SubItems[3].Text;
                List[4] = items.SubItems[4].Text;
                List[5] = items.SubItems[5].Text;
                List[6] = items.SubItems[6].Text;
                List[7] = items.SubItems[7].Text;

                if (verk.erTulkurSkipta(Int32.Parse(List[0])) == 1)
                { 
                    if (verk.erVerkefniFell(Int32.Parse(List[0])) == 1)
                    {
                        if (verk.maetaVidskiptavinurEkki(Int32.Parse(List[0])) == 1)
                        {
                            select_Listview1 sList = new select_Listview1(List, this);
                            sList.Show();
                        }
                        else
                        {
                            MessageBox.Show("Þvi miður að viðskiptavinur mæta ekki", "Tilkynning");
                            //Viltu að afrita verkefni -> framhald 
                        }
                    }
                    else
                    {
                        MessageBox.Show("Þvi miður að verkefni er fell niður.", "Tilkynning");
                        //Viltu að afrita verkefni -> framhald
                    }
                }
                else
                {
                    MessageBox.Show("Þvi miður að túlkur skipta!.", "Tilkynning");
                }
                
            }
        }
        #endregion

        #region "ListView2_Select - Túlkur"
        //------------//
        // Túlkalisti //
        //------------//
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                item2 = listView2.SelectedItems[0];

                label1.Text = item2.SubItems[1].Text;
                List[8] = label1.Text;

                Kennitala = item2.SubItems[0].Text;

                verk.setKennitala(Kennitala); 
                verk.hladaTulkurVerkefni(listView1); 
            }           
        }
        #endregion

        #region "Buttons"
        
        #region "Prenta - Button"
        private void button4_Click(object sender, EventArgs e)
        {    
            /*//if (verk.getId() != null)
            //{
                prenta form6 = new prenta(List);
                form6.Visible = true;
            //}
            /*else
            {
                MessageBox.Show("Vinsamlegast veldu pöntun");
            }*/
        }
        #endregion

        #region "Eyða - Button"
       /*private void button3_Click(object sender, EventArgs e)
        {
            if (verk.getId() != null)
            {
                string verkefni_fellur = "Er " + List[1] + " fellur niður ?";
                string verkefni_fellur_stadfest = "Fellur verkefni niður?";

                DialogResult result = MessageBox.Show(verkefni_fellur, verkefni_fellur_stadfest, MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    verk.
                        eydaVerkefni();
                    endurhladaVerkefni(); 
                }

                else
                {
                    MessageBox.Show("Verkefni hafa ekki verið eyðið");
                }

            }
            else
            {
                MessageBox.Show("Vinsamlegast veldu pöntun");
            }
        }*/
        #endregion

        #region "Uppfæra pöntun - Button"
        private void button2_Click(object sender, EventArgs e)
        {
             /*//if (verk.getId() != null)
             {
                 uppfaeraPontun form12 = new uppfaeraPontun(List, this);
                 form12.Visible = true;
             }
             else
             {
                 MessageBox.Show("Vinsamlegast veldu pöntun");
             }*/
        }
        #endregion

        #region "Flýtileiðir"
        #region "Pöntun - Button"
        private void button5_Click(object sender, EventArgs e)
        {
            pontun form5 = new pontun(this);
            form5.Show();
        }
        #endregion

        #region "Nýr túlkur - Button"
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this);
            form3.Visible = true;
        }
        #endregion

        #region "Nýr viðskiptavinur - Button"
        private void button2_Click_1(object sender, EventArgs e)
        {
            nyrVidskiptavinur form10 = new nyrVidskiptavinur();
            form10.Visible = true;
        }
        #endregion
        #endregion 

        #endregion

        #region "Úti Exit - Menu"
        private void útiExitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        #endregion 

        #region "Nýr Túlkur - Menu"
        private void nýrTúlkurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this);
            form3.Visible = true;
        }
        #endregion

        #region "Nýr Viðskiptavinur - Menu"
        private void nýrViðskiptavinurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nyrVidskiptavinur form10 = new nyrVidskiptavinur();
            form10.Visible = true;
        }
        #endregion      

        #region "Uppfæra Túlkur - Menu"
        private void breytaTúlkurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uppfaeraTulkur form4 = new uppfaeraTulkur(this);
            form4.Visible = true;
        }
        #endregion

        #region "Uppfæra viðskiptavinur"
        private void uppfæraViðskiptaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uppfaereVidskiptavin vid_form = new uppfaereVidskiptavin(this);
            vid_form.Visible = true;
        }
        #endregion
        
        #region "Leita Viðskiptavini - Menu"
        private void uppfæraViðskiptavinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Leita_vid form11 = new Leita_vid();
            form11.Visible = true; 
            */    
         }
        #endregion 

        #region "Um Forritun - Menu"
        private void umForritunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            umForritun form2 = new umForritun();
            form2.Visible = true;
        }
        #endregion

        #region "Tölfræði - Menu og Button - Túlkur"
        private void tölfræðiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tolfraedi form13 = new tolfraedi();
            form13.Visible = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            tolfraedi form13 = new tolfraedi();
            form13.Visible = true;
        }       
        #endregion

        #region "Tölfræði verkefna - menu og Button"
        private void button3_Click(object sender, EventArgs e)
        {
            frmTolfraediVerkefna frmTolVerk = new frmTolfraediVerkefna();
            frmTolVerk.Visible = true; 
        }
        
        private void tölfræðiToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmTolfraediVerkefna frmTolVerk = new frmTolfraediVerkefna();
            frmTolVerk.Visible = true;
        }
        #endregion

        #region "Tölfræði viðskiptavina - menu og Button"
        private void button6_Click(object sender, EventArgs e)
        {
            frmTolfraediVidskipta frmTolVid = new frmTolfraediVidskipta();
            frmTolVid.Visible = true;
        }

        private void tölfræðiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTolfraediVidskipta frmTolVid = new frmTolfraediVidskipta();
            frmTolVid.Visible = true;
        }
        #endregion

    }
}

using System;
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
    public partial class frmSkiptaTulk : Form
    {
        #region "Classes"
        clsTulkur tulkur = new clsTulkur();
        clsVerkefni verk = new clsVerkefni();
        clsVidskiptavinur vidskipta = new clsVidskiptavinur();
        clsGreidsla greidsla = new clsGreidsla();         
        #endregion

        #region "Variable"
        string nafn;
        string kennitala;
        public string[] List = new string[9];

        private adalgluggi frm;
        #endregion

        #region "Form"
        public frmSkiptaTulk(string[] lst, adalgluggi form)
        {
            InitializeComponent();
            List = lst;
            frm = form;
        }
        #endregion

        #region "Form load"
        private void frmSkiptaTulk_Load(object sender, EventArgs e)
        {
            tulkur.hladaTulkur(listBox1);
        }
        #endregion

        #region "Listbox1"
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nafn = listBox1.GetItemText(listBox1.SelectedItem);
            //List[1] = nafn;
            Hlada_KT();
            naKennitala();
        }

        public void Hlada_KT()
        {
            tulkur.HladaKennitala(nafn);
        }

        public void naKennitala()
        {
            kennitala = tulkur.getKennitala();
        }
        #endregion

        #region "Buttons"
        private void button2_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        //---------//
        // Skipta  //
        //---------//
        private void button1_Click(object sender, EventArgs e)
        {
             
            DialogResult dialogResult = MessageBox.Show("Túlkur : " + nafn + "\nHeiti verkefnis : " + List[1] + "\nStaður : " + List[2] + "\nDagur : " + List[3] + "\nTími - inn : " + List[4] + "\nTími - út : " + List[5] + "\nVettvangur : " + List[7], "Á að skipta túlk ?", MessageBoxButtons.YesNo);
             if (dialogResult == DialogResult.Yes)
             {

                tulkur.setNumer(List[0]);
                tulkur.setKennitala(kennitala);
                //tulkur.setMaeta(1);
                //tulkur.setVinna(1);
                //tulkur.setFell(1);
                //tulkur.setVettvangur(List[6]);

                /*verk.setTitill(List[1]);
                verk.setStadur(List[2]);
                verk.setDagur(List[3]);
                verk.setTima_Byrja(List[4]);
                verk.setTima_Endir(List[5]);
                verk.setVettvangur(List[6]);*/

                //vidskipta.setNumer();

                //----------------------------//

                //verk.skiptaUmVerkefni();

                tulkur.skiptaUmTulk();

                //vidskipta.skiptaUmPontun(List[0]);

                //greidsla.afritaGreidsla(List[0]);
                
                //----------------------------//

                frm.endurhladaVerkefni(); 
                frm.endurhladaTulkur();

                MessageBox.Show("Túlkur hafa verið skipta");

                Close();
             }

             else if (dialogResult == DialogResult.No)
             {
                MessageBox.Show("Túlkur hafa ekki verið skipta");
             }
        }
        #endregion
    }
}

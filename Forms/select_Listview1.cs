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
    public partial class select_Listview1 : Form
    {
        #region "Class"
        clsVerkefni verk = new clsVerkefni();
        clsTulkur tulkur = new clsTulkur(); 
        #endregion 

        #region "VARIABLES"
        public string[] List = new string[9];
        private adalgluggi form;
        #endregion

        #region "Form"
        public select_Listview1(string[] lst, adalgluggi fmr)
        {
            InitializeComponent();
            List = lst;
            form = fmr; 
        }
        #endregion

        #region "Buttons"

        //----------------------//
        // Uppfæra pöntun       //
        // Breyta pöntun-button //
        //----------------------//
        private void button2_Click(object sender, EventArgs e)
        {
            uppfaeraPontun form12 = new uppfaeraPontun(List, form);
            form12.Visible = true;
            Close(); 
        }

        //-----------------------------------------------------------------------//
        // Verkefni fell - button                                                //
        // -Hvorki Döff né Túlkur að kenna heldur verkefni sjálfs fell niður     //
        //-----------------------------------------------------------------------//
        private void button3_Click(object sender, EventArgs e)
        {
            string verkefni_fellur = "Er " + List[1] + " fellur niður ?";
            string verkefni_fellur_stadfest = "Fellur verkefni niður?";

            DialogResult result = MessageBox.Show(verkefni_fellur, verkefni_fellur_stadfest, MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                verk.setId(List[0]);
                verk.fellVerkefni();
                form.endurhladaVerkefni();
                form.endurhladaTulkur();
                Close(); 
            }

            else
            {
                MessageBox.Show("Verkefni hafa ekki verið fellið");
            }
        }

        //---------------------//
        // Prenta verkefni     //
        //---------------------//
        private void button4_Click(object sender, EventArgs e)
        {
            prenta form6 = new prenta(List);
            form6.Visible = true;
            Close();
        }

        //----------------------//
        // Skipta túlk          //
        //----------------------//
        private void button1_Click(object sender, EventArgs e)
        {
            frmSkiptaTulk stulkur = new frmSkiptaTulk(List, form);
            stulkur.Show();
            Close(); 
        }
        #endregion

        //----------------------------//
        // Viðskiptavinur hættur við  //
        //----------------------------//
        private void button5_Click(object sender, EventArgs e)
        {
            string verkefni_fellur = "Á að fella " + List[1] + " niður af því að viðskiptavinur mæta ekki? ";
            string verkefni_fellur_stadfest = "Mæta viðskiptavinur ekki ?";

            DialogResult result = MessageBox.Show(verkefni_fellur, verkefni_fellur_stadfest, MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                verk.setId(List[0]);
                verk.skraVidskiptavinurKomaEkki();
                form.endurhladaVerkefni();
                form.endurhladaTulkur(); 

                Close();
            }

            else
            {
                MessageBox.Show("Verkefni hafa ekki verið eyðið");
            }
        }
    }
}

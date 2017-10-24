using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTulkun.Forms
{
    public partial class uppfaereVidskiptavin : Form
    {
        #region "Class"
        clsVidskiptavinur vidskipta = new clsVidskiptavinur();
        #endregion

        #region "Variable"
        private adalgluggi form1;
        string nafn;
        bool kyn = false; 
        #endregion

        #region "Form"
        public uppfaereVidskiptavin(adalgluggi fm1)
        {
            InitializeComponent();
            form1 = fm1;
        }
        #endregion

        #region "Load Form"
        private void uppfaereVidskiptavin_Load(object sender, EventArgs e)
        {
            vidskipta.hladaVidskiptavinurListBox(listBox1);
            comboBox1.Items.Add("Karl");
            comboBox1.Items.Add("Kona");
        }
        #endregion

        #region "ListBox1_Select"
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            nafn = listBox1.GetItemText(listBox1.SelectedItem);

            vidskipta.VeljaEinnVidskiptavin(nafn, textBox1, textBox3, textBox4, textBox2, label6);
        }
        #endregion 

        #region "Buttons"
        //---------// 
        // Uppfæra //
        //---------//
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (kyn && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                vidskipta.setNafn(textBox1.Text);
                vidskipta.setSimi(textBox3.Text);
                vidskipta.setNetfang(textBox2.Text);
                vidskipta.setHeimilsfang(textBox4.Text);

                vidskipta.BreytaVidskiptavin();

                form1.endurhladaTulkur();
                form1.endurhladaVerkefni();

                MessageBox.Show("Viðskiptavinur hefur verið uppfærð");

                Close();
            }

            else
            {
                MessageBox.Show("Vinsamlegast fylltu inn allar upplýsingar");
            }
        }

       
        //------//
        // Loka //
        //------//
        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region "TextBoxes"

        //------//
        // Nafn //
        //------//
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //-----------//
        // Simanúmer //
        //-----------//
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //-------------//
        // Tölvupóstur //
        //-------------//
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
        }
        #endregion

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vidskipta.setKyn(comboBox1.SelectedItem.ToString());
            kyn = true;
        }
    }
}

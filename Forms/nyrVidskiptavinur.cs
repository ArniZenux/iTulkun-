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
    public partial class nyrVidskiptavinur : Form
    {
        #region "Class"
        clsVidskiptavinur vidskipta = new clsVidskiptavinur();
        #endregion

        #region "Variable"
        bool kyn = false;
        #endregion

        #region "Form"
        public nyrVidskiptavinur()
        {
            InitializeComponent();
        }
        #endregion

        #region "Form Load"
        private void nyrVidskiptavinur_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Karl");
            comboBox1.Items.Add("Kona");
        }
        #endregion

        #region "Buttons"
        //--------------------------------------//
        //Bóka nýr viðskiptainvur í gagnagrunn  //
        //--------------------------------------//
        private void button1_Click(object sender, EventArgs e)
        {
            if ( kyn && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) )
            {
                vidskipta.setKennitala(textBox5.Text);
                vidskipta.setNafn(textBox1.Text);
                vidskipta.setSimi(textBox2.Text);
                vidskipta.setHeimilsfang(textBox3.Text);
                vidskipta.setNetfang(textBox4.Text);
               
                vidskipta.skraNyrVidskiptavinur(); 

                MessageBox.Show("Viðskiptavinur hefur verið bókuð");

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
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region "Textboxes"
        //Kennitala
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar))
            {
                e.Handled = true; 
            }
            textBox5.MaxLength = 10;
        }

        //Nafn
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            textBox1.MaxLength = 50;
        }
        
        //Símanúmer
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            textBox5.MaxLength = 7;
        }

        //Heimilisfang
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox3.MaxLength = 50;
        }

        //Tölvupóstur
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
        }

        #endregion

        #region "ComboBox"
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vidskipta.setKyn(comboBox1.SelectedItem.ToString());
            kyn = true;
        }
        #endregion
    }
}

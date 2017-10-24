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
    public partial class Form3 : Form
    {
        #region "Class"
        clsTulkur tulkur = new clsTulkur();
        #endregion

        #region "Variable"
        private adalgluggi form1;
        #endregion

        #region "Form"
        public Form3(adalgluggi fm1)
        {
            InitializeComponent();
            form1 = fm1; 
        }
        #endregion

        #region "Buttons"
        private void button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                tulkur.setKennitala(textBox2.Text);
                tulkur.setNafn(textBox1.Text);
                tulkur.setSimi(textBox3.Text);
                tulkur.setNetfang(textBox4.Text);

                tulkur.skraNyrTulkur();

                form1.endurhladaTulkur(); 

                MessageBox.Show("Túlkur hefur verið bókuð");

                Close(); 
            }

            else
            {
                MessageBox.Show("Vinsamlegast fylltu inn allar upplýsingar");
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion 

        #region "Textboxes"
        //Kennitala 
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true; 
            }
            textBox2.MaxLength = 10;
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
        
        //Sími 
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true; 
            }
            textBox3.MaxLength = 7;
        }
        
        //Netfang
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Vantar virkar til að athuga hvort strengur sé löglegur þar sem t.d. @ og .hi eða .com 
        }
        #endregion
    }
}

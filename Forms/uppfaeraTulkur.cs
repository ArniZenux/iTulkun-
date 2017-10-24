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
   public partial class uppfaeraTulkur : Form
   {
        #region "Class"
        clsTulkur tulkur = new clsTulkur();
        #endregion 
        
        #region "Variable"
        private adalgluggi form1;
        string nafn; 
        #endregion

        #region "Form"
        public uppfaeraTulkur(adalgluggi fm1)
        {
            InitializeComponent();
            form1 = fm1;  
        }
        #endregion

        #region "Load Form"
        private void Form4_Load(object sender, EventArgs e)
        {
             tulkur.hladaTulkur(listBox1);
        }
        #endregion 
        
        #region "ListBox1_Select"
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nafn = listBox1.GetItemText(listBox1.SelectedItem);

            tulkur.VeljaEinnTulkur(nafn, textBox1, textBox3, textBox4);
        }
        #endregion 

        #region "Buttons"
        //---------// 
        // Uppfæra //
        //---------//
        private void button1_Click(object sender, EventArgs e)
        {
           if(!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)) 
           {
               tulkur.setNafn(textBox1.Text);
               tulkur.setSimi(textBox3.Text);
               tulkur.setNetfang(textBox4.Text); 
            
               tulkur.BreytaTulkur();

               form1.endurhladaTulkur();   

               MessageBox.Show("Túlkur hefur verið uppfærð");

               tulkur.hladaTulkur(listBox1);  
           }
                        
           else
           {
              MessageBox.Show("Vinsamlegast fylltu inn allar upplýsingar");
           }
        }

        //------//
        // Eyða //
        //------//    
        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                string tulkurUT = "Er þessi táknmálstúlkur hættur í störf?";
                string stadfest = "Eyða táknmálstúlk úr gagnagrunn";

                DialogResult result = MessageBox.Show(tulkurUT, stadfest, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    tulkur.EydaTulkur();

                    MessageBox.Show("Táknmálstúlkur hefur verið eyðið");

                    tulkur.hladaTulkur(listBox1); 
                }
                else
                {
                    MessageBox.Show("Táknmálstúlkur hafa ekki verið eyða");
                }
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
   }
}

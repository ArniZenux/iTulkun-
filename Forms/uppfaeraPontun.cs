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
    public partial class uppfaeraPontun : Form  
    {
        #region "Class"
        clsVerkefni verk = new clsVerkefni();
        clsGreidsla greidsla = new clsGreidsla(); 
        #endregion
        
        #region "Variables"
        string[] List;
        private adalgluggi form1; 
        #endregion

        #region "Form"
        public uppfaeraPontun(string[] lst, adalgluggi fm1)
        {
            InitializeComponent();
            List = lst;
            form1 = fm1;
        }
        #endregion

        #region "Load Form"
        private void Form12_Load(object sender, EventArgs e)
        {
            HladaComboBox();
            //HladaDagssetningur();
            HladaTextBox();
            HladaLabel(); 
        }
        #endregion

        #region "HladaTextBoxes"
        public void HladaTextBox()
        {
            textBox4.Text   = List[1];
            textBox5.Text   = List[2];
            textBox6.Text   = List[4];
            textBox1.Text   = List[5];
            textBox2.Text   = List[6];
        }
        #endregion

        #region "HladaLabel"
        public void HladaLabel()
        {
            label5.Text = List[3].ToString();
            label3.Text = List[7].ToString();
        }
        #endregion

        #region "HladaComboBox"
        public void HladaComboBox()
        {
            comboBox1.Items.Add("Heilbrigðismál");
            comboBox1.Items.Add("Fjármál");
            comboBox1.Items.Add("Menntamál");
            comboBox1.Items.Add("Sálfræðiþjóunsta");
            comboBox1.Items.Add("Húsnæðismál");
            comboBox1.Items.Add("Ráðgjöf og þjónusta");
            comboBox1.Items.Add("Bifreiðamál");
            comboBox1.Items.Add("Dómaramál");
            comboBox1.Items.Add("Kirkjumál");
            comboBox1.Items.Add("Hátíð og veisla");
            comboBox1.Items.Add("Atvinnumál");
            comboBox1.Items.Add("Annað");
        }
        #endregion

        #region "Hlaða dagssetningi"
        public void HladaDagssetningur()
        {
            //nyja_tima = dateTimePicker1.Value.ToShortDateString();
            //label5.Text = List[4].ToString(); 
        }
        #endregion

        #region "Buttons"
        //----------//
        // Uppfæra  //
        //----------//
        private void button1_Click(object sender, EventArgs e)
        {
            if ( !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) )
            {
                DialogResult dialogResult = MessageBox.Show("Heiti verkefnis : " + textBox4.Text + "\nStaðsetningur : " + textBox5.Text + "\nDagssetningur : " + label5.Text + "\nTími - inn : " + textBox6.Text + "\nTími - út : " + textBox1.Text + "\nGreiðsla : " + textBox2.Text + "\nVettvangur : " + label3.Text , "Er upplýsingar rétt ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) {

                    verk.setId(List[0]);
                    greidsla.setNr(List[0]);                  

                    verk.setTitill(textBox4.Text);
                    verk.setStadur(textBox5.Text);
                    verk.setDagur(label5.Text);
                    verk.setTima_Byrja(textBox6.Text);
                    verk.setTima_Endir(textBox1.Text);
                    verk.setVettvangur(label3.Text);
                    greidsla.setHeiti(textBox2.Text);
                    
                    verk.breytaVerkefni();
                    greidsla.breytaHeitiGreidsla();

                    form1.endurhladaVerkefni();
                    form1.endurhladaTulkur();

                    MessageBox.Show("Pöntun hefur verið uppfærð");

                    Close();
                }
            }

            else
            {
                MessageBox.Show("Vinsamlegast fylltu inn allar upplýsingar");
            }
        }
        //----------//
        // Loka     //
        //----------//
        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region "dateTimePicker"
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label5.Text = dateTimePicker1.Value.ToString("dd.MMMM.yyyy"); 
        }
        #endregion

        #region "comboBox1_Select"
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = comboBox1.SelectedItem.ToString();
        }
        #endregion

        #region "Textbox"
        //Greiðsla - TextBox
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
       
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox6.MaxLength = 5;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.MaxLength = 5;
        }
        #endregion

        
    }
}

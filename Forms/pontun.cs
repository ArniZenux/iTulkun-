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
    public partial class pontun : Form
    {
        #region "Classes"
        clsTulkur tulkur = new clsTulkur();
        clsVerkefni verk = new clsVerkefni();
        clsVidskiptavinur vidskipta = new clsVidskiptavinur();
        clsGreidsla greisla = new clsGreidsla(); 
        #endregion 
        
        #region "Variables"
        ListViewItem item, item2;
        bool vettvangur = false;
        bool dagssetningur = false;
        private adalgluggi form1;
        #endregion

        #region "Form"
        public pontun(adalgluggi adalform)
        {
            InitializeComponent();
            form1 = adalform; 
        }
        #endregion 
        
        #region "Load Form"
        private void Form5_Load(object sender, EventArgs e)
        {
            vidskipta.hladaVidskiptavinur(listView1); 
            tulkur.hladaTulkurListView(listView2);

            HladaComboBox();
            HladaListView();
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

        #region "HladaListView"
        public void HladaListView()
        {
            listView2.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.GridLines = false;
            listView1.FullRowSelect = true;
        }
        #endregion

        #region "Buttons"
        //---------------------------//
        //  Bóka pöntun              //
        //---------------------------//
        private void button1_Click(object sender, EventArgs e)
        {
            if (dagssetningur && vettvangur && !string.IsNullOrWhiteSpace(label18.Text) && !string.IsNullOrWhiteSpace(label19.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)  && !string.IsNullOrWhiteSpace(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                DialogResult dialogResult = MessageBox.Show("Nafn túlks: " + label19.Text  + "\nNafn viðskiptavins : " + label18.Text + "\nHeiti verkefnis : " + textBox4.Text + "\nStaðsetningur : " + textBox5.Text + "\nTími - inn : " + textBox6.Text + "\nTími - út : " + textBox1.Text + "\nGreiðsla : " + textBox2.Text + "\nUpphæð : " + textBox3.Text , "Er upplýsingar rétt ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    verk.setTitill(textBox4.Text);
                    verk.setStadur(textBox5.Text);
                    verk.setTima_Byrja(textBox6.Text);
                    verk.setTima_Endir(textBox1.Text);

                    greisla.setHeiti(textBox2.Text);
                    greisla.setUpphaed(textBox3.Text);

                    tulkur.setMaeta(1);
                    tulkur.setVinna(1);
                    tulkur.setFell(1);

                    tulkur.skraVinnaVerkefni();

                    vidskipta.pantaTulkur();

                    verk.skraVerkefni();

                    greisla.skraGreidsla();

                    form1.endurhladaVerkefni(); 

                    MessageBox.Show("Pöntun hafa verið bókað");

                    Close();
                }
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

        private void button3_Click(object sender, EventArgs e)
        {
            nyrVidskiptavinur formVid = new nyrVidskiptavinur();
            formVid.Show();
        }
        #endregion 

        #region "dataTimePicker1"
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            verk.setDagur( dateTimePicker1.Value.ToString("dd.MMMM.yyyy"));
            label13.Text = dateTimePicker1.Value.ToString("dd.MMMM.yyyy");
            dagssetningur = true; 
        }
        #endregion

        #region "ListViewes_Select"
        //---------------------//
        // Viðskiptaivinur     //
        //---------------------//
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                item2 = listView1.SelectedItems[0];
                vidskipta.setKennitala(item2.SubItems[0].Text);
                label18.Text = item2.SubItems[1].Text;    
            }

            else
            {

                label18.Text = string.Empty;
            }
        }
        
        //-------------//
        // Túlkur      //
        //-------------//
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                item = listView2.SelectedItems[0];
                tulkur.setKennitala(item.SubItems[0].Text );
                label19.Text = item.SubItems[1].Text; 
            }

            else
            {
                label19.Text = string.Empty; 
            }
        }
        #endregion
        
        #region "ComboBox1_Select"
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            verk.setVettvangur( comboBox1.SelectedItem.ToString() );
            tulkur.setVettvangur(comboBox1.SelectedItem.ToString());
            vettvangur = true; 
        }
        #endregion
        
        #region "TextBoxes"
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }*/
            textBox1.MaxLength = 5;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }*/
            textBox6.MaxLength = 5; 
        }
        #endregion
    }
}

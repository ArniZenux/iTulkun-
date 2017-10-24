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
    public partial class Leita_vid : Form
    {
        #region "Class"
        clsVidskiptavinur vidskipta = new clsVidskiptavinur();  
        #endregion 

        #region "Form"
        public Leita_vid()
        {   
            InitializeComponent();  
        }
        #endregion 

        #region "Load Form"
        //   Hlaða viðskiptavin í listView 
        private void Form11_Load(object sender, EventArgs e)
        {
            //vidskipta.hladaVidskiptavinurDataGridView(dataGridView1);
        }
        #endregion 
        
        #region "Buttons"
        //   Leitavél
        private void button1_Click(object sender, EventArgs e)
        {
            //vidskipta.leitaVidskiptavinur(dataGridView1); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion 

        #region "Textbox"
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //vidskipta.leitaVidskiptavinur(textBox1.Text, dataGridView1);
            }
        }
        #endregion
    }
}

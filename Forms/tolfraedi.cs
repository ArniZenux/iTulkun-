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
    public partial class tolfraedi : Form
    {
        #region "Class"
        clsTulkur tulkur = new clsTulkur();
        clsTolfraedi tol = new clsTolfraedi(); 
        #endregion 
        
        #region "Variables"
        //Graphics g;
        //Rectangle rect; 
        string nafn;
        #endregion

        #region "Form"
        public tolfraedi()
        {
            InitializeComponent();
        }
        #endregion

        #region "Load Form"
        private void Form13_Load(object sender, EventArgs e)
        {
            tulkur.hladaTulkur(listBox1);
        }
        #endregion

        #region "Button"
        private void button1_Click(object sender, EventArgs e)
        {
            Close(); 
        }
        #endregion

        #region "Tulkur"
        #region "ListBox_Select"
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nafn = listBox1.GetItemText(listBox1.SelectedItem);

            tol.hladaStadaTulkur(nafn, label4, label8, label10, label12,label14, label22, label28, label16, label18, label20, label26, label30, label25, label3, label6);
        }
        #endregion
        #endregion
    }
}
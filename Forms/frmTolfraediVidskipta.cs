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
    public partial class frmTolfraediVidskipta : Form
    {
        #region "Class"
        clsTolfraedi tol = new clsTolfraedi();
        #endregion

        #region "Variables"

        #endregion

        #region "Form"
        public frmTolfraediVidskipta()
        {
            InitializeComponent();
        }
        #endregion

        #region "Form Load"
        private void frmTolfraediVidskipta_Load(object sender, EventArgs e)
        {
            tol.hladaStadaVidskiptavina(label4, label3, label8, label10, label12, label14, label22, label28, label16, label18, label20, label26, label30, label25);
        }
        #endregion

        #region "Button"
        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}

using System;
//using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Printing; 

namespace iTulkun
{
    public partial class prenta : Form
    {
        #region "Class"
        #endregion

        #region "Variables"
        public string[] list;
        #endregion

        #region "Form"
        public prenta(string[] lst)
        {
            InitializeComponent();
            list = lst;  
        }
        #endregion

        #region "Load Form"
        private void Form6_Load(object sender, EventArgs e)
        { 
            label11.Text = list[0]; // verk.getId(); 
            label13.Text = list[1]; // verk.getTilill(); 
            label12.Text = list[2]; // verk.getStadur();
            label15.Text = list[3]; // verk.getDagur();
            label14.Text = list[4]; // verk.getTima_Byrja();
            label23.Text = list[5]; // verk.getTima_Endir();
            label26.Text = list[6]; // verk.getGreidsla();
            label24.Text = list[7]; // verk.getVettvangur();
            label19.Text = list[8]; // pre.getNafnTulkur();
            /*label17.Text = pre.getNafnVidskipa();
            label21.Text = pre.getSimanumer();
            */
        }
        #endregion

        #region "PrintPage"
        //Bitmap memory; 
        private void pd_PrintPage(Object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Times New Roman", 11, FontStyle.Regular);
            Font font_Titill = new Font("Times New Roman", 15, FontStyle.Bold);
            Font font_undirtitill = new Font("Times New Roman", 13, FontStyle.Bold); 
            

            //e.Graphics.DrawLine
            e.Graphics.DrawString("Verkefni",font_Titill,Brushes.Black,300,50);
                //e.Graphics.DrawString(nafn, font, Brushes.Black, 280, 70);
           
            e.Graphics.DrawString("Verkefni", font, Brushes.Black, 20, 180);
               e.Graphics.DrawString("Númer", font_undirtitill, Brushes.Black, 30, 220);
               e.Graphics.DrawString(label11.Text, font, Brushes.Black, 150, 220);
               e.Graphics.DrawString("Tilefni", font_undirtitill, Brushes.Black, 30, 240);
               e.Graphics.DrawString(label13.Text, font, Brushes.Black, 150, 240);
               e.Graphics.DrawString("Staðsetningur", font_undirtitill, Brushes.Black, 30, 260);
               e.Graphics.DrawString(label12.Text, font, Brushes.Black, 150, 260);
               e.Graphics.DrawString("Vettvangur", font_undirtitill, Brushes.Black, 30, 280);
               e.Graphics.DrawString(label24.Text, font, Brushes.Black, 150, 280);
            
            e.Graphics.DrawString("Túlkur", font,  Brushes.Black, 20, 330);
               e.Graphics.DrawString("Nafn", font_undirtitill, Brushes.Black, 30, 370);
               e.Graphics.DrawString(label19.Text, font, Brushes.Black, 150, 370);

            e.Graphics.DrawString("Greiðandi", font, Brushes.Black, 20, 410);
               e.Graphics.DrawString("Sjóður", font_undirtitill, Brushes.Black, 30, 450);
               e.Graphics.DrawString(label26.Text, font, Brushes.Black, 150, 450);
             

            e.Graphics.DrawString("Viðskiptavinur", font, Brushes.Black, 450, 180);
                e.Graphics.DrawString("Nafn", font_undirtitill, Brushes.Black, 450, 220);
                e.Graphics.DrawString(label17.Text, font, Brushes.Black, 590, 220);
               e.Graphics.DrawString("Símanúmer", font_undirtitill, Brushes.Black, 450, 240);
               e.Graphics.DrawString(label21.Text, font, Brushes.Black, 590, 240);


            e.Graphics.DrawString("Hvenær", font, Brushes.Black, 450, 330);
                e.Graphics.DrawString("Dagur", font_undirtitill, Brushes.Black, 450, 370);
                e.Graphics.DrawString(label15.Text, font, Brushes.Black, 590, 370);
                e.Graphics.DrawString("Tími - frá ", font_undirtitill, Brushes.Black, 450, 390);
                e.Graphics.DrawString(label14.Text, font, Brushes.Black, 590, 390);
               e.Graphics.DrawString("Tími - Til", font_undirtitill, Brushes.Black, 450, 410);
               e.Graphics.DrawString(label23.Text, font, Brushes.Black, 590, 410);


            e.Graphics.DrawString("Undirskrift viðskiptavins:", font, Brushes.Black, 20, 630);
                e.Graphics.DrawString("Undirskrift túlks:", font, Brushes.Black, 20, 700);
            
        }
        #endregion

        #region "Buttons"
        private void button1_Click_1(object sender, EventArgs e)
        {

            /* PrintDialog printDialog = new PrintDialog(); 

             PrintDocument pd = new PrintDocument();

             printDialog.Document = pd; 

             //pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 877, 1170);
             pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);

             DialogResult result = printDialog.ShowDialog();
             if (result == DialogResult.OK)
             {
                 pd.Print(); 
             }
            
             /*CaptureScreen();
             printDocument1.Print();
             printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}

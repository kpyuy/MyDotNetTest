using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace ReportNet2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(doc_PrintPage);

            PrintDialog pd = new PrintDialog();
            pd.Document = printDocument;
            pd.ShowDialog();

            //PageSetupDialog ps = new PageSetupDialog();
            //ps.Document = printDocument;
            //ps.ShowDialog();

            printDocument.Print(); 
        }

        private void doc_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Font f = new Font("Arial", 12);
            ev.Graphics.DrawString("Hello,World.", f, Brushes.Black, 100, 100);
            ev.HasMorePages = false;  
        }
    }
}

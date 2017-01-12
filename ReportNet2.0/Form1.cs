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
            printDocument.DocumentName = "客户1";
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("Custum", 500, 500);

            //打印事件处理
            printDocument.PrintPage += new PrintPageEventHandler(doc_PrintPage);
            printDocument.BeginPrint += new PrintEventHandler(doc_BeginPrint);

            //预览
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = printDocument;
            if (printPreviewDialog1.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            //打印机设置
            //this.printDialog1.Document = printDocument;
            //if (this.printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            //{
            //    return;
            //}

            //页面设置
            //this.pageSetupDialog1.Document = printDocument;
            //this.pageSetupDialog1.ShowDialog();

            printDocument.Print(); 
        }

        private void doc_BeginPrint(object sender, PrintPageEventArgs ev)
        {
            Font f = new Font("Arial", 12);
            ev.Graphics.DrawString("Hello,World.", f, Brushes.Black, 100, 100);
            ev.HasMorePages = false;
        }

        private void doc_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Font f = new Font("Arial", 12);
            ev.Graphics.DrawString("Hello,World.", f, Brushes.Black, 100, 100);
            ev.HasMorePages = false;
        }

        private void doc_EndPrint(object sender, PrintPageEventArgs ev)
        {
            Font f = new Font("Arial", 12);
            ev.Graphics.DrawString("Hello,World.", f, Brushes.Black, 100, 100);
            ev.HasMorePages = false;  
        }
    }
}

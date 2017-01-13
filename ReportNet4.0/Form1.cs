using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Drawing;
using System.Drawing.Printing;

namespace ReportNet4._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitprinterComboBox();
            consumStatus.Text = "正在监听打印消息";

            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.RunWorkerAsync(this); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var printDocument = new PrintDocument();
            printDocument.DocumentName = "来访登记单";

            //这个事件在开始打印每一页时被触发，每页的打印都是在这个事件中完成的。用户必须为这个事件提供处理函数，以完成实际的打印操作。
            printDocument.PrintPage += new PrintPageEventHandler(doc_PrintPage);

            //这个事件在调用Print方法之后，并且在打印第1个页面之前被触发。可以在这个事件中设置应用于所有页面的打印机属性和页面属性，以及使用的字体等参数。
            printDocument.BeginPrint += new PrintEventHandler(doc_BeginPrint);

            //这个事件在打印完最后一个页面时被触发。可以在这个事件中完成一些资源清理工作。
            printDocument.EndPrint += new PrintEventHandler(doc_EndPrint);

            //这个事件在每个PrintPage事件之前被触发，可以使用这个事件来设置打印每一个页面的页面设置。
            printDocument.QueryPageSettings += new QueryPageSettingsEventHandler(doc_QueryPageSettings);

            //页面属性
            //设置边距
            Margins margin = new Margins(20, 20, 20, 20);
            printDocument.DefaultPageSettings.Margins = margin;
            //纸张设置默认
            //PaperSize pageSize = new PaperSize("Custum", 500, 500);
            PaperSize pageSize = new PaperSize("A4", 827, 1169); //A4是默认值，第一个参数是PaperName，第二个是Width，第三个是Height
            printDocument.DefaultPageSettings.PaperSize = pageSize;


            //打印机设置对话框
            this.printDialog1.Document = printDocument;
            this.printDialog1.UseEXDialog = true; //将PrintDialog.UseEXDialog属性设置为True，才可显示出打印对话框
            printDialog1.AllowPrintToFile = true; //对话框中显示“打印到文件”按钮
            printDialog1.AllowSelection = true; //显示选择页面范围的控件
            printDialog1.AllowSomePages = true; //显示"页"选择按钮
            if (this.printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var printSetting = printDialog1.PrinterSettings;
            }
            else
            {
                return;
            }

            //页面设置对话框
            this.pageSetupDialog1.Document = printDocument;
            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                var pageSetting = pageSetupDialog1.PageSettings;
            }
            else
            {
                return;
            }


            //预览对话框
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = printDocument;
            if (printPreviewDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                printPreviewDialog1.Close();
                printDocument.Print();
            }
            else
            {
                return;
            }

        }

        private void doc_BeginPrint(object sender, PrintEventArgs e)
        {
            e.Cancel = false; //True禁用打印操作
        }

        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font f = new Font("Arial", 12);
            e.Graphics.DrawString("Hello,World.", f, Brushes.Black, 100, 100);

            //是否还有未打印的页面
            e.HasMorePages = false;
        }

        private void doc_EndPrint(object sender, PrintEventArgs e)
        {

        }

        private void doc_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            var setting = e.PageSettings;
        }


        private void InitprinterComboBox()
        {
            List<String> list = LocalPrinter.GetLocalPrinters(); //获得系统中的打印机列表
            var defaultPrinter = LocalPrinter.GetDefaultPrinter();
            for (var i = 0; i < list.Count; i++)
            {
                var printer = list[i];
                printerComboBox.Items.Add(printer); //将打印机名称添加到下拉框中

                if (printer == defaultPrinter)
                {
                    printerComboBox.SelectedIndex = i;
                }
            }
        }

        private void printerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = printerComboBox.SelectedItem.ToString();
            if (string.IsNullOrEmpty(item))
            {
                return;
            }
            Externs.SetDefaultPrinter(item);
            status.Text = LocalPrinter.GetPrinterStatus(item).ToString("G");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var item = printerComboBox.SelectedItem.ToString();
            if (string.IsNullOrEmpty(item))
            {
                return;
            }
            status.Text = LocalPrinter.GetPrinterStatus(item).ToString("G");
        }

        private string ConsumerString(BackgroundWorker bw)
        {
            var factory = new ConnectionFactory();
            factory.HostName = txtQueueServerIp.Text;
            factory.UserName = "admin";
            factory.Password = "123456";
            factory.Port = 5672;
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(txtQueueName.Text, false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(txtQueueName.Text, true, consumer);

                    bw.ReportProgress(0, "开始消费打印队列");

                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        bw.ReportProgress(0, string.Format("接收到打印消息 {0}", message));

                    }
                }
            }
        }

        private void Log(string msg)
        {
            txtLog.AppendText(msg + Environment.NewLine);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            Form1 form1 = e.Argument as Form1;
            e.Result = ConsumerString(bw);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //执行百分百
            var percent = e.ProgressPercentage;

            //执行过程消息
            Log(e.UserState.ToString());
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //获取执行完成结果
            var result = e.Result.ToString();
        }


    }
}

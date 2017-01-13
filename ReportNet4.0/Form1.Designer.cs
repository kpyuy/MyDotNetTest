namespace ReportNet4._0
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPrintTest = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtQueueName = new System.Windows.Forms.TextBox();
            this.btnRefreshPrinterStatus = new System.Windows.Forms.Button();
            this.consumStatus = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.printerComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQueueServerIp = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnPrintTest
            // 
            this.btnPrintTest.Location = new System.Drawing.Point(364, 247);
            this.btnPrintTest.Name = "btnPrintTest";
            this.btnPrintTest.Size = new System.Drawing.Size(75, 23);
            this.btnPrintTest.TabIndex = 6;
            this.btnPrintTest.Text = "打印测试";
            this.btnPrintTest.UseVisualStyleBackColor = true;
            this.btnPrintTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(10, 276);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(460, 161);
            this.txtLog.TabIndex = 16;
            // 
            // txtQueueName
            // 
            this.txtQueueName.Location = new System.Drawing.Point(108, 149);
            this.txtQueueName.Name = "txtQueueName";
            this.txtQueueName.Size = new System.Drawing.Size(227, 21);
            this.txtQueueName.TabIndex = 15;
            this.txtQueueName.Text = "rpt_01";
            // 
            // btnRefreshPrinterStatus
            // 
            this.btnRefreshPrinterStatus.Location = new System.Drawing.Point(227, 69);
            this.btnRefreshPrinterStatus.Name = "btnRefreshPrinterStatus";
            this.btnRefreshPrinterStatus.Size = new System.Drawing.Size(108, 23);
            this.btnRefreshPrinterStatus.TabIndex = 14;
            this.btnRefreshPrinterStatus.Text = "刷新打印机状态";
            this.btnRefreshPrinterStatus.UseVisualStyleBackColor = true;
            this.btnRefreshPrinterStatus.Click += new System.EventHandler(this.button2_Click);
            // 
            // consumStatus
            // 
            this.consumStatus.AutoSize = true;
            this.consumStatus.Location = new System.Drawing.Point(114, 180);
            this.consumStatus.Name = "consumStatus";
            this.consumStatus.Size = new System.Drawing.Size(29, 12);
            this.consumStatus.TabIndex = 8;
            this.consumStatus.Text = "……";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(114, 74);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(29, 12);
            this.status.TabIndex = 9;
            this.status.Text = "……";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "监听状态：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "监听队列名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "打印机状态：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "打印机：";
            // 
            // printerComboBox
            // 
            this.printerComboBox.FormattingEnabled = true;
            this.printerComboBox.Location = new System.Drawing.Point(83, 43);
            this.printerComboBox.Name = "printerComboBox";
            this.printerComboBox.Size = new System.Drawing.Size(332, 20);
            this.printerComboBox.TabIndex = 7;
            this.printerComboBox.SelectedIndexChanged += new System.EventHandler(this.printerComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "队列服务器：";
            // 
            // txtQueueServerIp
            // 
            this.txtQueueServerIp.Location = new System.Drawing.Point(108, 119);
            this.txtQueueServerIp.Name = "txtQueueServerIp";
            this.txtQueueServerIp.Size = new System.Drawing.Size(227, 21);
            this.txtQueueServerIp.TabIndex = 15;
            this.txtQueueServerIp.Text = "10.5.23.221";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 449);
            this.Controls.Add(this.btnPrintTest);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtQueueServerIp);
            this.Controls.Add(this.txtQueueName);
            this.Controls.Add(this.btnRefreshPrinterStatus);
            this.Controls.Add(this.consumStatus);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.printerComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrintTest;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtQueueName;
        private System.Windows.Forms.Button btnRefreshPrinterStatus;
        private System.Windows.Forms.Label consumStatus;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox printerComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQueueServerIp;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

    }
}


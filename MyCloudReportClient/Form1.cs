using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RabbitMQ.Client;


namespace MyCloudReportClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory();
            factory.UserName = "admin";
            factory.Password = "123456";

        }
    }
}

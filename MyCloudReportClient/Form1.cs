using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


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
            factory.HostName = "192.168.1.7";
            factory.UserName = "admin";
            factory.Password = "123456";
            factory.Port = 5672;

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);
                    string message = "Hello World";
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "hello", null, body);
                    Log(string.Format("Send {0}", message));
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "192.168.1.7";
            factory.UserName = "admin";
            factory.Password = "123456";
            factory.Port = 5672;
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("hello", true, consumer);
                    Log("waiting for message");

                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Log(string.Format("Received {0}", message));

                    }
                }
            }
        }

        private void Log(string msg)
        {
            textBox1.AppendText(msg + Environment.NewLine);
        }
    }
}

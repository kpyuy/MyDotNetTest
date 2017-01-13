using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Management;

namespace ReportNet4._0
{
    class LocalPrinter
    {
        //获取本机默认打印机名称
        public static String GetDefaultPrinter()
        {
            var fPrintDocument = new PrintDocument();
            return fPrintDocument.PrinterSettings.PrinterName;
        }
        //获取打印机列表
        public static List<String> GetLocalPrinters()
        {
            List<String> fPrinters = new List<String>();
            foreach (String fPrinterName in PrinterSettings.InstalledPrinters)
            {
                if (!fPrinters.Contains(fPrinterName))
                {
                    fPrinters.Add(fPrinterName);
                }
            }
            return fPrinters;
        }


        /// <summary>
        /// 获取打印机的当前状态
        /// </summary>
        /// <param name="PrinterDevice">打印机设备名称</param>
        /// <returns>打印机状态</returns>
        public static PrinterStatus GetPrinterStatus(string PrinterDevice)
        {
            PrinterStatus ret = 0;
            string path = @"win32_printer.DeviceId='" + PrinterDevice + "'";
            ManagementObject printer = new ManagementObject(path);
            printer.Get();
            ret = (PrinterStatus)Convert.ToInt32(printer.Properties["PrinterStatus"].Value);
            return ret;
        }
    }
}
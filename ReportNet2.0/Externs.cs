using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ReportNet2._0
{
    class Externs
    {
        [DllImport("winspool.drv")]
        public static extern bool SetDefaultPrinter(String name); //调用win api将指定名称的打印机设置为默认打印机
    }
}
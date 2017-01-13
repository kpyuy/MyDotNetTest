using System;
using System.Collections.Generic;
using System.Text;

namespace MyCloudReportClient
{
    enum PrinterStatus
    {
        其他状态 = 1,
        未知,
        空闲,
        正在打印,
        预热,
        停止打印,
        打印中,
        离线
    }
}

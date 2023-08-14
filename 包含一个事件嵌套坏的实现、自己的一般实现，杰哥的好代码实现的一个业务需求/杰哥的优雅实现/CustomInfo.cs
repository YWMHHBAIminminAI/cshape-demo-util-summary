using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCustomInfo
{
    class CustomInfo
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public double[] NumSeries { get; set; }
        //public List<double> NumSeries { get; set; }

        public enum FileType
        {
            // 自定义的文件类型枚举
            Txt,
            Png,
            Xls,
            Video,
            Jpg
            // 可以根据需要添加更多的文件类型
        }
    }
}

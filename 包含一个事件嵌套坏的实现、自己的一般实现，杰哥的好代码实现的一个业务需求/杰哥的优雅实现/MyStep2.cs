using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCustomInfo
{
    class MyStep2 :IStep
    {
        public int StepIndex => 2;

        public bool IsLastStep => false;
        int randomSeriesAverageCount = 0;

        public T DoAction<T>(object parameters)
        {
            if (parameters is IEnumerable<CustomInfo> customInfos)
            {
                var obj = customInfos.OrderBy(x => x.NumSeries.Average());
                return (T)obj;
            }
            return default;
        }

        public bool Processor(params object[] parameters)
        {
            Form1 form = null;
            if (parameters.Length == 2 && parameters[0] is Form1 && parameters[1] is IEnumerable<CustomInfo> infos)
            {
                form = parameters[0] as Form1;
                var listBox = form.GetListBox();

                foreach (var i in infos)
                {
                    listBox.Items.Add("第" + randomSeriesAverageCount + "组随机序列的平均值" +  i.NumSeries.Average());
                    randomSeriesAverageCount++;
                }
            }
            if (form != null)
            {
                form.SetCurrentIndex(StepIndex + 1);
            }
            return false;
        }
    }
}

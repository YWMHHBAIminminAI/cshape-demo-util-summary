using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCustomInfo
{
    class MyStep1 :IStep
    {
        //步骤索引为1
        public int StepIndex => 1;

        //判断是否时最后一步，不是最后一步
        public bool IsLastStep => false;

        CustomInfo[] CustomInfoArray;

        List<double> SplitSequenceList = null;

        //随机数生成器
        static readonly Random r1 = new Random((int)DateTime.Now.Ticks);

        int randomSeriesCount = 0;

        /// <summary>
        /// 下面的两层for循环是的意思：第一层for循环表示生成了几个随机序列，内层的for循环是按照第一层外边的各个随机生成的序列的长度，为其填值
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T DoAction<T>(object parameters)
        {
            //随机生成CustomInfoArray数组的长度
            CustomInfoArray = new CustomInfo[r1.Next(2, 10)];

            /*
             * 下面的两层for循环是的意思：第一层for循环表示生成了几个随机序列，内层的for循环是按照第一层外边的各个随机生成的序列的长度，为其填值
             */
            for (int i = 0; i < CustomInfoArray.Length; i++)
            {
                CustomInfoArray[i] = new CustomInfo();
                
                //创建长度为2到10的随机数组
                var array = new double[r1.Next(2, 10)];


                //为CustomInfo对象设置ID属性
                CustomInfoArray[i].ID = r1.Next(1, 10);

                //遍历数组并为其赋值
                for (int j = 0; j < array.Length; j++)
                {
                    //生成40到(40+100)之间的随机数，并保留小数点后两位
                    array[j] = Math.Round(r1.NextDouble() * r1.Next(0, 100) + 40);


                }
                
                //为CustomInfo对象设置NumSeries属性
                CustomInfoArray[i].NumSeries = array;

                List<double> SplitSequenceList = array.ToList();


            }

            //将CustomInfoArray数组转换为泛型参数类型并返回
            object arrObj = CustomInfoArray;
            return (T)arrObj;
        }

        public bool Processor(params object[] parameters)
        {
            Form1 form = null;
            if (parameters.Length > 1 && parameters[0] is Form1 && parameters[1] is IEnumerable<CustomInfo> infos)
            {
                form = parameters[0] as Form1;
                var listBox = form.GetListBox();



                // 遍历CustomInfo集合并将其NumSeries的值添加到listBox中
                foreach (var i in infos)
                {
                    listBox.Items.Add("第" + randomSeriesCount + "组随机序列");
                    randomSeriesCount++;

                    //listBox.Items.Add(i.NumSeries.Average());
                    for (int j = 0; j < i.NumSeries.Length; j++)
                    {
                        listBox.Items.Add("序列中的第" + j + "一个数是：" + i.NumSeries.ElementAt(j));

                    }
                }
            }

            //如果form不为空，则设置当前索引为当前步骤索引+1
            if (form != null)
            {
                form.SetCurrentIndex(StepIndex + 1);
            }
            return true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCustomInfo
{
    /**
     *  Form1类被声明为一个部分类，代表应用程序的主窗体
     */
    public partial class Form1 : Form
    {
        /**
         *  Form1类的一个构造函数，在创建类的实例时调用。它通过调用InitializeComponent方法来初始化窗体。
         */
        public Form1()
        {
            InitializeComponent();//调用InitializeComponent方法来初始化窗体

        }

        /**
         *  代码声明了私有字段来存储当前步骤索引（currentStepIndex）、当前数据（CurrentData）和常量变量（SeriesValueMax和SeriesValueMin）
         */
        private int currentStepIndex = 1;//声明一个私有整数变量来存储当前步骤索引

        const double SeriesValueMax = 100;//声明常量变量来定义系列的最大和最小值

        const double SeriesValueMin = 0;

        IEnumerable<CustomInfo> CurrentData;//声明一个变量来存储当前数据

        /**
         * 窗体的Load事件的事件处理程序
         * 这些事件处理程序使用+=运算符将其附加到相应的事件上。
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            //设置lb_currentIndex标签的文本以显示当前步骤索引
            lb_currentIndex.Text = $"CurrentIndex：{currentStepIndex}";
            //将DoNextStep方法附加到btn_nextstep按钮的Click事件,
            btn_nextstep.Click += DoNextStep;
        }

        /**
         *  btn_nextstep按钮的Click事件的事件处理程序,这些事件处理程序使用+=运算符将其附加到相应的事件上
         */
        private void DoNextStep(object sender, EventArgs e)
        {
            //使用StepFactory类根据currentStepIndex获取步骤
            var step = StepFactory.GetStep(currentStepIndex);
            if (step.StepIndex == 1)
            {
                //执行每一个步骤的DoAction方法实现每一个步骤的事情或者动作，并将结果赋值给CurrentData变量。此时是执行步骤一的DoAction()方法
                CurrentData = step.DoAction<IEnumerable<CustomInfo>>(null);
            }
            else
            {
                // 使用CurrentData作为参数执行步骤的DoAction方法
                step.DoAction<object>(CurrentData);
            }
            //调用步骤的Processor方法，传递当前Form1实例和CurrentData
            step.Processor(this, CurrentData);
        }

        

        /**
         *  获取ListBox控件的方法
         */
        internal ListBox GetListBox() => listBox1;

        /**
         *  设置当前步骤索引
         */
        internal void SetCurrentIndex(int index)
        {
            currentStepIndex = index;
            //更新lb_currentIndex标签的文本以显示新的当前步骤索引
            lb_currentIndex.Text = $"CurrentIndex：{currentStepIndex}";
        }
    }
}
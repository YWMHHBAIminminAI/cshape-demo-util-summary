using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading; //代表多线程相关的命名空间

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            //定义间隔多长时间会触发这个事件,相当于给这个定时器一个属性值
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1); //用多长时间的秒数来生成TimeSpan，这个时间间隔或者说时间跨度
            //定义事件处理器
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            //启动事件
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object? sender, EventArgs e)
        {
            this.timerTextBox.Text = DateTime.Now.ToString();
        }
    }
}

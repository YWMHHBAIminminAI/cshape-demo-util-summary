using Microsoft.Win32;
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

namespace AddNotUseMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 实现 通过add按钮，实现两个文本框中的数字相加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_click(object sender, RoutedEventArgs e)
        {
            //实战尽量不要用parse方法这样写
            double addVal1 = double.Parse(tb1.Text);
            double addVal2 = double.Parse(tb2.Text);
            double res = addVal1 + addVal2;
            this.tb3.Text = res.ToString();
        }

        /// <summary>
        /// 实现 通过save按钮，实现保存两个文本框中的数字相加结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
        }
    }
}

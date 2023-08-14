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

namespace WpfExercise03
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            inside_canvas.Loaded += (s, e) =>
              {
                  dynamicButton = new DynamicButton(btn_222, inside_canvas.ActualWidth - btn_222.ActualWidth, inside_canvas.ActualHeight - btn_222.ActualHeight);
              };

            txt_111.TextChanged += Txt_111_TextChanged;
        }

        private void Txt_111_TextChanged(object sender, TextChangedEventArgs e)
        {
            btn_222.Content = (sender as TextBox).Text;
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            var a = new List<int> { 1, 5, 7, 9, 7 };
            var b = (from c in a
                     let f = c * Convert.ToInt32((sender as Button).Content)
                     select f).OrderBy(x => x).GroupBy(x => x).Select(x => x.FirstOrDefault());
            MessageBox.Show($"[{string.Concat(b.Select(x => $"{x},")).TrimEnd(',')}]");
        }


        DynamicButton dynamicButton;
        bool flag = false;

        private void Btn_start_Click(object sender, MouseButtonEventArgs e)
        {
            flag = !flag;
            dynamicButton?.SetEnable(flag);
        }
    }
}

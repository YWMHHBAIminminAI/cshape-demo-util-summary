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
using System.Windows.Shapes;

namespace WpfExercise
{
    /// <summary>
    /// StepOne.xaml 的交互逻辑
    /// </summary>
    public partial class StepOne : Window
    {
        public StepOne()
        {
            InitializeComponent();
            this.average.Click += this.HbClickedEvent;
        }


        private void JumpToStepTwo(object sender, RoutedEventArgs e)
        {
            StepTwo stepTwo = new StepTwo();
            stepTwo.Show();
        }

        private void HbClickedEvent(object sender, RoutedEventArgs e)
        {
            this.HuBox.Text = "8.2,first wpf";
        }
    }
}

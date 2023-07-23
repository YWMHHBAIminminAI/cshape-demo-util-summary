using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ShowNameWhenClickButtonFromWpf
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Human h = this.FindResource("human") as Human;
            if(h != null)
            {
                MessageBox.Show(h.Name);
                Thread.Sleep(1000);
                MessageBox.Show(h.Child.Name);
            }
        }
    }

    /**
     * [TypeConverter(typeof(NameToHumanTypeConverter))]代表，将NameToHumanTypeConverter这个类以特性的形式附加到Human这个类上面
     */
    [TypeConverter(typeof(NameToHumanTypeConverter))]
    public class Human
    {
        public string Name { get; set; }
        public Human Child { get; set; }

    }

    public class NameToHumanTypeConverter : TypeConverter
    {
        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            string name = value.ToString();
            Human child = new Human();
            child.Name = name;
            return child;
        }
    }
}

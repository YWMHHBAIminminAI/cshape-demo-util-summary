using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambdaAndLinqToSplitSequence
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var input = new List<int> { 1, 15, 7, 9, 3, 0, 5, 18, 23 };
            var output = (from tempVar in input
                          let res = tempVar * 2
                          select res).OrderBy(x => x).GroupBy(x => x > 5);

            foreach(var i in output)
            {
                if (i.Key)
                {
                    MessageBox.Show($"大于10的序列：【{string.Concat(i.Select(k => $"{k},")).TrimEnd(',')}】");
                }
                else
                {
                    MessageBox.Show($"小于等于10的序列：【{string.Concat(i.Select(k => $"{k},")).TrimEnd(',')}】");
                }
            }
                
        }
    }
}

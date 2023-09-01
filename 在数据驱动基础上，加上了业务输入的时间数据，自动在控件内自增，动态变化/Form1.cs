using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public void InitData(MyData data)
        {
            tb_Name.Text = data.Name;
            tb_Desc.Text = data.Descriptions;
        }

        public void UpdateData(string dataType,string data)
        {
            switch(dataType)
            {
                case "Name":
                    tb_Name.Text = data;
                    break;
                case "Desc":
                    tb_Desc.Text = data;
                    break;
            }
        }
    }
}

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

namespace WpfExercise02
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<CustomInfo> customInfos = new List<CustomInfo>();

        private int currentStep = 1;

        public MainWindow()
        {
            InitializeComponent();
            ShowStepInstructions(currentStep);

        }

        private void ShowStepInstructions(int currentStep)
        {
            StepIndexTextBlock.Text = "步骤索引：" + currentStep;
            switch (currentStep)
            {
                case 1:
                    InstuctionsTextBlock.Text = "步骤1：生成CustomInfo序列。";
                    break;
                case 2:
                    InstuctionsTextBlock.Text = "步骤2：排序并显示平均值。";
                    break;
                case 3:
                    InstuctionsTextBlock.Text = "步骤3：检查所有平均值是否低于50.";
                    break;
                case 4:
                    InstuctionsTextBlock.Text = "步骤4：文件保存成功。";
                    break;
                default:
                    break;
            }
        }

        /**
         *  将有按钮用来进行下一步或保存文件，把步骤的指导说明显示出来.点击"下一步"按钮时，它会按照需求依次进行四个步骤
         */
        private void NextStepButton_Click(object sender, RoutedEventArgs e)
        {
            switch (currentStep)
            {
                case 1:
                    Step1();
                    break;
                case 2:
                    Step2();
                    break;
                case 3:
                    Step3();
                    break;
                case 4:
                    SaveFile();
                    break;
                default:
                    break;
            }
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void Step1()
        {
            //生成CustomInfo序列,创建两个带有随机数据的序列
            Random random = new Random();
            List<double> sequence1 = new List<double>();
            List<double> sequence2 = new List<double>();

            for (int i = 0; i < 5; i++)
            {
                sequence1.Add(random.Next(0, 101));
                sequence2.Add(random.Next(0, 101));
            }
            customInfos.Add(new CustomInfo { id = 1, Description = "序列1", NumSeries = sequence1 });
            customInfos.Add(new CustomInfo { id = 2, Description = "序列2", NumSeries = sequence2 });

            //在控件中显示自定义信息数据
            ShowCustomInfoData(customInfos);

            currentStep = 2;

            ShowStepInstructions(currentStep);
        }

        private void Step2()
        {
            //按照平均值对序列进行排序
            customInfos = customInfos.OrderBy(temp => temp.NumSeries.Average()).ToList();

            //在空间中显示自定义信息数据
            ShowCustomInfoData(customInfos);

            currentStep = 3;

            ShowStepInstructions(currentStep);
        }

        private void Step3()
        {
            if (customInfos.All(temp => temp.NumSeries.Average() < 50))
            {
                MessageBox.Show("数据值无效，返回到步骤1...");
                customInfos.Clear();
                currentStep = 1;
                ShowStepInstructions(currentStep);
            }
            else
            {
                currentStep = 4;
                ShowStepInstructions(currentStep);
            }
        }

        /**
         *  在SaveFile方法中实现将数据按照期望的格式保存到文件的逻辑.方法会将自定义信息数据保存为文本文件，文件名包含当前时间以避免重复。
         */
        public void SaveFile()
        {
            // 实现将数据保存到文件的逻辑

            // 生成文件名，格式为CustomInfo_当前日期时间.txt
            string fileName = $"CustomInfo_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";

            // 初始化文件内容为空字符串
            string fileContent = "";

            // 遍历customInfos列表中的每个CustomInfo对象,将其信息拼接到文件内容中。
            foreach (var info in customInfos)
            {
                // 遍历当前CustomInfo对象的Data列表中的每个数据项,并拼接每个CustomInfo对象的信息到文件内容中
                fileContent += $"Id: {info.id}, Description: {(string.IsNullOrEmpty(info.Description) ? "No Description。" : info.Description)}, Data: [";

                // 遍历当前CustomInfo对象的Data列表中的每个数据项
                foreach (var data in info.NumSeries)
                {
                    // 将每个数据项拼接到文件内容中
                    fileContent += $"{data}, ";
                }

                // 去除文件内容中的最后一个逗号和空格，并添加右括号和换行符
                fileContent = fileContent.TrimEnd(',', ' ') + "]\n";
            }

            try
            {
                // 创建保存文件对话框
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                // 设置对话框的标题
                saveFileDialog.Title = "选择保存位置";

                // 设置对话框的默认文件名
                saveFileDialog.FileName = fileName;

                // 添加文件类型过滤器，用于区分不同格式的文件
                saveFileDialog.Filter = "文本文件 (*.txt)|*.txt|图片文件 (*.png, *.jpg)|*.png;*.jpg|Excel文件 (*.xls)|*.xls|视频文件 (*.mp4)|*.mp4";

                // 显示对话框并获取用户选择的文件路径
                if (saveFileDialog.ShowDialog() == true)
                {
                    // 将文件内容写入用户选择的文件路径
                    System.IO.File.WriteAllText(saveFileDialog.FileName, fileContent);

                    // 显示保存成功的消息框
                    MessageBox.Show("文件保存成功！");
                }
            }
            catch (Exception ex)
            {
                // 如果保存文件时出现错误，显示错误消息框并返回
                MessageBox.Show($"保存文件时出现错误：{ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // 清空customInfos列表
            customInfos.Clear();

            // 重置currentStep为1
            currentStep = 1;

            // 显示当前步骤的指令
            ShowStepInstructions(currentStep);
        }





        /**
         * ShowCustomInfoData方法实现逻辑来将第一步第二步的自定义信息数据显示在控件中,将自定义信息数据以简单的对话框形式弹出来
         */
        private void ShowCustomInfoData(List<CustomInfo> customInfos)
        {
            // 在控件中显示自定义信息数据
            string dataToShow = "";
            foreach (var info in customInfos)
            {
                dataToShow += $"Id: {info.id}, Description: {info.Description}, Data: [";
                foreach (var data in info.NumSeries)
                {
                    dataToShow += $"{data}, ";
                }
                dataToShow = dataToShow.TrimEnd(',', ' ') + "]\n";
            }
            MessageBox.Show(dataToShow, "CustomInfo数据");
        }

    }
}

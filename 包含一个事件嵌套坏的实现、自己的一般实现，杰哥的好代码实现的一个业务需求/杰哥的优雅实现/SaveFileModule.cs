using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCustomInfo
{
    /// <summary>
    /// 文件保存模块
    /// </summary>
    public class SaveFileModule
    {
        CustomInfo customInfo;

        /// <summary>
        /// 通过依赖注入构建文件保存模块
        /// 代码使用internal访问修饰符，使某些方法在同一程序集内可访问。
        /// C#的五个可访问性级别：public：访问不受限制、protected：访问仅限于包含类或从包含类派生的类型、Internal：访问仅限于当前程序集、protected internal:访问限制到当前程序集或从包含派生的类型的类别、private：访问仅限于包含类型
        /// </summary>
        /// <param name="infos"></param>
        internal SaveFileModule(IEnumerable<CustomInfo> infos)
        {
            CustomInfoArray = infos.ToArray();
            this.customInfo = infos.FirstOrDefault();

        }


        readonly CustomInfo[] CustomInfoArray;



        /// <summary>
        /// 保存文件功能
        /// 在SaveFile方法中实现将数据按照期望的格式保存到文件的逻辑.方法会将自定义信息数据保存为文本文件，文件名包含当前时间以避免重复。
        /// <para>用于保存数据集文件,保存的数据类型为<see cref="CustomInfo"/></para>
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void SaveFile()
        {
            if (CustomInfoArray == null)
            {
                return;
            }
            // 实现将数据保存到文件的逻辑

            // 生成文件名，格式为CustomInfo_当前日期时间.txt
            string fileName = $"CustomInfo_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";

            // 初始化文件内容为空字符串
            string fileContent = "";

            // 遍历customInfos列表中的每个CustomInfo对象,将其信息拼接到文件内容中。
            // 
            /**
             * LINQ的第一中写法，第二种简便写法就是foreach (var info in CustomInfoArray.Where(x => x.NumSeries?.Length != 4))中Where后面的内容
             *      var result = from i in CustomInfoArray
             *      where i.NumSeries?.Length != 4
             *      select i;
             * 第二种写法：foreach (var info in CustomInfoArray.Where(x => x.NumSeries?.Length != 4))
             */


            foreach (var info in CustomInfoArray)
            {
                // 遍历当前CustomInfo对象的Data列表中的每个数据项,并拼接每个CustomInfo对象的信息到文件内容中
                fileContent += $"Id: {info.ID}, Description: {(string.IsNullOrEmpty(info.Description) ? "No Description。" : info.Description)}, Data: [";

                //info.Nu mSeries = info.NumSeries?.Length == 3 ? null : info.NumSeries;

                // 遍历当前CustomInfo对象的Data列表中的每个数据项
                foreach (var data in info.NumSeries ?? Enumerable.Empty<double>())
                //错误代码：foreach (var data in info.Description)
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
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
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
                MessageBox.Show($"保存文件时出现错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new InvalidOperationException();
                //return;
            }

            // 清空customInfos列表
            // 重置currentStep为1
            // 显示当前步骤的指令

        }
    }


    //    // 根据文件类型获取文件名
    //    private string GetFileName(CustomInfo.FileType info)
    //    {
    //        string extension = GetFileExtension(info);
    //        string fileName = $"file_{DateTime.Now.ToString("yyyyMMddHHmmss")}{extension}";
    //        return fileName;
    //    }

    //    // 根据文件类型获取文件扩展名
    //    private string GetFileExtension(CustomInfo.FileType fileType)
    //    {
    //        switch (fileType)
    //        {
    //            case CustomInfo.FileType.Txt:
    //                return ".txt";
    //            case CustomInfo.FileType.Png:
    //                return ".png";
    //            case CustomInfo.FileType.Xls:
    //                return ".xls";
    //            case CustomInfo.FileType.Video:
    //                return ".mp4";
    //            case CustomInfo.FileType.Jpg:
    //                return ".jpg";
    //            // 可以根据需要添加更多的文件类型判断
    //            default:
    //                return ".txt";
    //        }

    //    }


    //}


    //// 根据文件类型保存文件
    //private void SaveFile(string filePath, CustomInfo info)
    //{
    //    // 根据文件类型进行相应的处理
    //    if (info.FileType == FileType.Txt)
    //    {
    //        // 保存为txt文件
    //        File.WriteAllText(filePath, info.Content);
    //    }
    //    else if (info.FileType == FileType.Png)
    //    {
    //        // 保存为png文件
    //        // TODO: 保存png文件的逻辑
    //    }
    //    else if (info.FileType == FileType.Xls)
    //    {
    //        // 保存为xls文件
    //        // TODO: 保存xls文件的逻辑
    //    }
    //    else if (info.FileType == FileType.Video)
    //    {
    //        // 保存为视频文件
    //        // TODO: 保存视频文件的逻辑
    //    }
    //    else if (info.FileType == FileType.Jpg)
    //    {
    //        // 保存为jpg文件
    //        // TODO: 保存jpg文件的逻辑
    //    }
    //    // 可以根据需要添加更多的文件类型判断
    //}
}

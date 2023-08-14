using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCustomInfo
{
    class MyStep3 : IStep
    {
        public int StepIndex => 3;

        public bool IsLastStep => true;

        public T DoAction<T>(object parameters)
        {

            return default;
        }

        public bool Processor(params object[] parameters)
        {
            bool flag = false;
            Form1 form = null;
            IEnumerable<CustomInfo> customInfos = null;
            if (parameters.Length == 2 && parameters[0] is Form1 && parameters[1] is IEnumerable<CustomInfo> infos)
            {
                form = parameters[0] as Form1;
                flag = !infos.All(x => x.NumSeries.Average() > 50);
                customInfos = infos;
            }
            try
            {
                if (flag)
                {
                    MessageBox.Show("数值不合理");
                }
                else
                {
                    //new SaveFileUtils().SaveFile();
                    //SaveFiles();
                    // 弹出文件选择对话框，让用户选择存储的目录位置
                    using (var folderDialog = new FolderBrowserDialog())
                    {
                        if (folderDialog.ShowDialog() == DialogResult.OK)
                        {
                            string selectedPath = folderDialog.SelectedPath;

                            // 根据文件类型进行分类存储
                            //foreach (var info in CustomInfo.FileType)
                            //{
                            //    string filePath = Path.Combine(selectedPath, GetFileName(info));
                            //    SaveFile(filePath, info);
                            //}
                            SaveFileModule m = new SaveFileModule(customInfos);

                            m.SaveFile();
                        }
                    }
                }
            }
            finally
            {
                if (form != null)
                {
                    form.GetListBox().Items.Clear();
                    form.SetCurrentIndex(1);
                }
            }
            return flag;
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCustomInfo
{
    /// <summary>
    /// 步骤接口
    /// </summary>
    interface IStep
    {
        //步骤索引
        int StepIndex { get; }

        T DoAction<T>(object parameters);

        bool Processor(params object[] parameters);


        bool IsLastStep { get; }
    }
}

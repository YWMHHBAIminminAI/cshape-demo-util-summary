using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCustomInfo
{
    static class StepFactory
    {
        /// <summary>
        /// 获取指定步骤的实例
        /// </summary>
        /// <param name="stepIndex"></param>
        /// <returns></returns>
        public static IStep GetStep(int stepIndex)
        {
            //如果步骤字典中包含指定的步骤索引，则返回对应的步骤实例，否则返回null
            return _StepMap.ContainsKey(stepIndex) ? _StepMap[stepIndex] : null;
            
        }

        /// <summary>
        /// 步骤字典，用于存储步骤索引和对应的步骤实例。字典用于存储键值对的集合，通过键快速查找对应的值
        /// </summary>
        private static readonly Dictionary<int, IStep> _StepMap = new Dictionary<int, IStep>()
        {
            {1,new MyStep1() },//使用步骤索引1创建MyStep1实例并添加到字典中
            {2,new MyStep2() },//使用步骤索引2创建MyStep2实例并添加到字典中
            {3,new MyStep3() },//使用步骤索引3创建MyStep3实例并添加到字典中
            
        };

        
    }


    
}



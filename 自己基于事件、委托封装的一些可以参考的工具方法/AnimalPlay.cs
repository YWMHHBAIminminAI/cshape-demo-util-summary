using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndDelegateAndLambdaExercise
{
    /// <summary>
    /// 动物门表演的上层管理接口
    /// </summary>
    interface IAnimalPlay
    {
        void StartPlay(string animalName);
    }
}

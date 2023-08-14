using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndDelegateAndLambdaExercise
{
    class LionPlay : IAnimalPlay
    {
        public void StartPlay(string animalName)
        {
            Console.WriteLine("I'm " + Animal.AnimalType.Lion + "===" + animalName + "!..." + "playing");
        }
    }
}

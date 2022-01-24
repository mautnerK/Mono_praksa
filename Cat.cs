using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prvi_dan_mono
{
    internal class Cat : Animals, IAnimalActions
    {
        public void Sound()
        {
            System.Console.WriteLine("Meow");
        }
        public void Eat(int amount)
        {
            if (sex == 'M')
            {
                weight += amount / 8;
            }
            else if (sex == 'F')
            {
                weight += amount / 12;
            }
        }
        public Cat(string inName, int inWeight, double inHeight, char inSex)
        {
            weight = inWeight;
            height = inHeight;
            name = inName;
            sex = inSex;
        }
    }
}

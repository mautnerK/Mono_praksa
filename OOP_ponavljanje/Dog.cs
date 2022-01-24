using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prvi_dan_mono
{
    internal class Dog : Animals, IAnimalActions
    {
        public void Sound() {
            System.Console.WriteLine("Vuf Vuf");
            play();
        }

        public void Eat(int amount) {
            if (sex == 'M')
            {
                weight += amount / 4;
            }
            else if (sex == 'F')
            {
                weight += amount / 6;
            }
        }
        
        private void play()
        {
            weight--;
        }

        public Dog(string inName, int inWeight, double inHeight, char inSex)
        {
            weight= inWeight;
            height= inHeight;
            name= inName;
            sex= inSex;
        }
    }
}

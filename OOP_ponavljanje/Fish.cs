using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prvi_dan_mono
{
    internal class Fish : Animals, IAnimalActions
    {
        public void Sound()
        {
            System.Console.WriteLine("Blup");
        }
        
        public void Eat(int amount) {
            weight += amount / 2;
        }
        
        public Fish(string inName, int inWeight, double inHeight)
        {
            weight = inWeight;
            height = inHeight;
            name = inName;
        }
        
        public unsafe void swim() {
            int meters=10;
            int* pointer = &meters;

            System.Console.WriteLine(*pointer);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prvi_dan_mono
{
    internal abstract class Animals
    {
        public String name;

        protected int weight;

        protected double height;

        protected char sex;

        public void GetHeight()
        {
            System.Console.WriteLine(height);
        }
        public void GetWeight()
        {
            System.Console.WriteLine(weight);
        } 
    }
}




using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    internal class Month
    {
        public int Number { get; }
        public string Name { get; }
        public int NumberOfDays { get; }

        public Month(int number, string name, int nuberOfDays)
        {
            Number = number;
            Name = name;
            NumberOfDays = nuberOfDays;
        }

        public override string ToString()
        {
            return $"{Number} mon/year. {Name} has {NumberOfDays} days";
        }
    }
}

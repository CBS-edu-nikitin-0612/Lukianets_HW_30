using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.People
{
    internal abstract class Citizen
    {
        protected string Name { get; set; }
        protected int Id { get; set; }
        protected int Age { get; set; }

        public Citizen(string name, int id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public abstract void ShowStatus();

        public override bool Equals(object obj)
        {
            if (obj is Citizen objCitizen)
                return this.Id == objCitizen.Id;
            else 
                return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} {Age} y.o., passport number: {Id}";
        }
    }
}

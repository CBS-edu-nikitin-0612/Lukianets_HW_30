using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.People
{
    internal class Pensioner : Citizen
    {
        public Pensioner(string name, int id, int age) : base(name, id, age)
        {
        }

        public override void ShowStatus()
        {
            Console.WriteLine("I'm Pensioner");
        }
    }
}

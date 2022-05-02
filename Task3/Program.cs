using System;
using Task3.People;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student("Vladimir", 345, 22);
            Student st2 = new Student("Igor", 724, 18);
            Worker w1 = new Worker("Ivan", 123, 45);
            Worker w2 = new Worker("Alex", 125, 35);
            Pensioner p1 = new Pensioner("Fedor", 892, 77);
            Pensioner p2 = new Pensioner("Oleg", 321, 60);
            Pensioner p3 = new Pensioner("Oleg 2", 321, 6);


            GroupOfPeople g1 = new GroupOfPeople();
            g1.Add(st1);
            g1.Add(w1);
            g1.Add(w2);
            g1.Add(p1);
            g1.Add(p2);
            g1.Add(st2);
            g1.Add(p2); // will not add - p2 already exists
            g1.Add(p3); // will not add - Id of p3 is Equal to some in collection
            Console.WriteLine(g1);
            Console.WriteLine(new String('-', 50));

            g1.Remove(st1);
            Console.WriteLine($"After Remove(object) method: \nobject - {st1}");
            Console.WriteLine(g1);
            Console.WriteLine(new String('-', 50));

            Console.WriteLine($"IndexOf(object) method: \nIndex of {p2} is {g1.IndexOf(p2)}");
            Console.WriteLine(new String('-', 50));

            Console.WriteLine("RemoveAt(int index) method: \nRemove at index 2");
            g1.RemoveAt(2);
            Console.WriteLine(g1);
            Console.WriteLine(new String('-', 50));

            Console.WriteLine("Remove at index 0");
            g1.RemoveAt(0);
            Console.WriteLine(g1);

            Console.WriteLine(new String('-', 50));
            try
            {
                g1.Remove(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"try/catch => ERROR: " + ex.Message);
            }

            Console.WriteLine(new String('-', 10));
            Console.WriteLine("Remove at index 0");
            g1.RemoveFromStart();
            Console.WriteLine(g1);
            Console.WriteLine(new String('-', 50));

            Citizen lastCitizen;
            int indexOfLast;
            g1.ReturnLast(out lastCitizen, out indexOfLast);
            Console.WriteLine($"ReturnLast method: {lastCitizen}, index = {indexOfLast}");
        }
    }
}

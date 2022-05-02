using System;
using System.Collections;

namespace AdditionalTask
{
    internal class Program
    {
        public static IEnumerable SomeFunction(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                    yield return array[i] * array[i];
            }
        }
        // throw new NotImplementedException();

        public static void Main(string[] args)
        {
            int[] testArr1 = { 1, 2, 3, 4, 5 };
            foreach (var item in SomeFunction(testArr1))
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}

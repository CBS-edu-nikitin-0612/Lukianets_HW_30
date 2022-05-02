using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task2
{
    internal class MonthCollection : ICollection
    {
        private readonly object syncRoot = new object();
        private readonly Month[] months;
        private const int maxNumberOfMonths = 12;
        private int size;

        public MonthCollection()
        {
            size = maxNumberOfMonths;
            months = new Month[maxNumberOfMonths]
            {
                new Month (1, "January", 31),
                new Month (2, "February", 28),
                new Month (3, "March", 31),
                new Month (4, "April", 30),
                new Month (5, "May", 31),
                new Month (6, "June", 30),
                new Month (7, "Luly", 31),
                new Month (8, "August", 31),
                new Month (9, "September", 30),
                new Month (10, "October", 31),
                new Month (11, "November", 30),
                new Month (12, "December", 31)
            };
        }

        public MonthCollection(int size)
        {
            if (size > 0 && size <= maxNumberOfMonths)
            {
                months = new Month[size];
                this.size = size;
            }
            else
                throw new Exception("Incorrect size value");
        }

        public Month this[int index]
        {
            get 
            {
                index--;
                if (index >= 0 && index < size )
                    return months[index]; 
                throw new Exception("Incorrect index reference");
            }
            set
            {
                index--;
                if (index >= 0 && index < size)
                    months[index] = value;
                throw new Exception("Incorrect index reference"); 
            }
        }

        public Month[] GetMonthsByNumberOfDays(int numberOfDays)
        {
            Month[] result = (from month in months
                              where month.NumberOfDays == numberOfDays
                              select month).ToArray();

            return result;
        }

        // Number of elements in collection
        int ICollection.Count => months.Length;

        bool ICollection.IsSynchronized => true;

        object ICollection.SyncRoot => syncRoot;

        void ICollection.CopyTo(Array array, int userArrayIndex)
        {
            var arr = array as object[];

            if (arr == null)
                throw new ArgumentException("Expecting array to be object[]");

            for (int i = 0; i < array.Length; i++)
            {
                arr[userArrayIndex++] = months[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return months.GetEnumerator();
        }
    }
}

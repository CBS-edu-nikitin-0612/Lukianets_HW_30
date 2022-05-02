using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Task3.People;

namespace Task3
{
    internal class GroupOfPeople : IList
    {
        private Citizen[] citizenArray;
        private int pensionerNumber;

        public object this[int index]
        {
            get => citizenArray[index];
            set => citizenArray[index] = (Citizen)value;
        }

        public bool Contains(object value)
        {
            for (int i = 0; i < citizenArray.Length; i++)
            {
                if (citizenArray[i].Equals(value))
                    return true;
            }
            return false;
        }

        public int IndexOf(object value)
        {
            for (int i = 0; i < citizenArray.Length; i++)
            {
                if (citizenArray[i].Equals(value))
                    return i;
            }
            return -1;
        }

        public int Add(object value)
        {
            Citizen citizenToAdd = value as Citizen;

            if (citizenToAdd != null)
            {
                if (citizenArray == null)
                {
                    citizenArray = new Citizen[1];
                    citizenArray[0] = citizenToAdd;

                    if (citizenToAdd is Pensioner)
                        pensionerNumber++;
                    
                    return 0;
                }
                else if (!((IList)this).Contains(citizenToAdd))
                {
                    // at least 1 citizen
                    Citizen[] tempArr = new Citizen[this.citizenArray.Length + 1];
                    if (citizenToAdd is Pensioner)
                    {
                        // previos array doesn't contain Pensioner => value to add (Pensioner) => position 0
                        if (pensionerNumber == 0)
                        {
                            tempArr[pensionerNumber++] = citizenToAdd;
                            for (int i = 0; i < citizenArray.Length; i++)
                                tempArr[i + 1] = (Citizen)citizenArray[i];
                            citizenArray = tempArr;
                            return 0;
                        }
                        // Initial array has pensioners = value to add (Pensioner) - int the end of all pensioners
                        else
                        { 
                            //pensionerNumber++;
                            for (int i = 0; i < pensionerNumber; i++)
                                tempArr[i] = (Citizen)citizenArray[i];
                            tempArr[pensionerNumber++] = citizenToAdd;
                            for (int i = pensionerNumber - 1; i < this.citizenArray.Length; i++)
                                tempArr[i + 1] = citizenArray[i];
                            citizenArray = tempArr;
                            return pensionerNumber - 1;
                        }
                    }
                    else
                    {
                        for ( int i = 0; i < this.citizenArray.Length; i++ )
                            tempArr[i] = (Citizen)this.citizenArray[i];
                        tempArr[citizenArray.Length] = citizenToAdd;
                        citizenArray = tempArr;
                        return citizenArray.Length;
                    }
                }
                return -1;
            }
            else
            {
                Console.WriteLine("Element can't be added");
                return -1;
            }
        }

        public void Clear()
        {
            citizenArray = null;
        }

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public int Count => citizenArray.Length;

        public bool IsSynchronized => false;

        public object SyncRoot => null;

        IEnumerator IEnumerable.GetEnumerator() => citizenArray.GetEnumerator();

        // IEnumerable
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < citizenArray.Length; i++)
            {
                yield return citizenArray[i];
            }
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            if (!this.Contains(value))
                throw new Exception("Object to delete not in collection.");

            int indexOfElementToDelete = this.IndexOf(value);
            this.RemoveAt(indexOfElementToDelete);
        }

        public void RemoveAt(int index)
        {
            if (index >= citizenArray.Length)
                throw new IndexOutOfRangeException();
            
            Citizen[] tempArr = new Citizen[citizenArray.Length - 1];
            for (int i = 0, j = 0; i < citizenArray.Length; i++)
            {
                if (index == i)
                    continue;
                tempArr[j++] = citizenArray[i];
            }
            citizenArray = tempArr;
        }

        public void RemoveFromStart()
        {
            RemoveAt(0);
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public void ReturnLast(out Citizen returnedCitizen, out int index)
        {
            if ((citizenArray != null) && (citizenArray.Length > 0))
            {
                returnedCitizen = citizenArray[citizenArray.Length - 1];
                index = citizenArray.Length - 1;
            }
            else
            {
                returnedCitizen = null;
                index = -1;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in citizenArray)
                sb.Append(item.ToString() + "\n");
            return sb.ToString();
        }
    }
}

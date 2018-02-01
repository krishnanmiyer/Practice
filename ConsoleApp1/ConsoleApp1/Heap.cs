using System;

namespace ConsoleApp1
{
    public class Heap
    {
        private int Capacity = 10;
        private int Size = 0;

        private int[] items;

        public Heap()
        {
            items = new int[Capacity];
        }

        public int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }
        public int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }
        public int GetParentIndex(int childIndex)
        {
            return Convert.ToInt32(childIndex - 1 / 2);
        }

        public bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) > Size;
        }

        public bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) > Size;
        }

        public bool HasParent(int index)
        {
            return GetParentIndex(index) >= 0;
        }

        public int GetLeftChild(int index)
        {
            return items[GetLeftChildIndex(index)];
        }
        public int GetRightChild(int index)
        {
            return items[GetRightChildIndex(index)];
        }
        public int GetParent(int index)
        {
            return items[GetParentIndex(index)];
        }

        public void EnsureExtraCapacity()
        {
            if (Capacity == Size)
            {
                Array.Copy(items, items, Capacity * 2);
                Capacity = Capacity * 2;
            }
        }

        public void Swap(int indexOne, int indexTwo)
        {
            var temp = items[indexOne];
            items[indexOne] = items[indexTwo];
            items[indexTwo] = temp;
        }

        public int Peek()
        {
            if (Size == 0) throw new IndexOutOfRangeException();
            return items[0];
        }

        public int Poll()
        {
            if (Size == 0) throw new IndexOutOfRangeException();
            var temp = items[0];
            items[0] = items[Size - 1];
            HeapifyDown();
            Size--;
            return temp;
        }

        public void Add(int value)
        {
            EnsureExtraCapacity();
            items[Size] = value;
            HepifyUp();
            Size++;
        }

        public void HepifyUp()
        {
            var index = Size - 1;

            while(HasParent(index) && GetParent(index) > items[index])
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }

        public void HeapifyDown()
        {
            var index = 0;

            while(HasLeftChild(index))
            {
                if (GetLeftChild(index) < items[index])
                {
                    var smallerIndex = GetLeftChildIndex(index);
                    if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                    {
                        smallerIndex = GetRightChildIndex(index);
                    } 

                    if (items[index] < items[smallerIndex])
                    {
                        break;
                    }

                    Swap(index, smallerIndex);
                    index = smallerIndex;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Data_Structure
{
    internal class Queue<T>
    {
        int head = 0;
        int tail = 0;
        int size = 100;
        T[] arr;
        public bool IsEmpty { get { return head == tail; } }
        public int Count { get { return tail - head; } }
        public Queue() 
        {
            arr = new T[size];
        }

        public void Enqueue(T item) 
        {
            arr[tail++] = item;
        }
        public T Dequeue()
        {
            if(head == 0 && tail == 0)
                throw new InvalidOperationException("Queue is empty");
            T ret = arr[head];
            arr[head] = default(T);
            head++;
            return ret;
        }
        public void Clear()
        {
            for(int i = head; i < tail; i++)
            {
                arr[i] = default(T);
            }
            head = 0;
            tail = 0;
        }
        public bool Contains(T item)
        {
            for (int i = head; i < tail; i++)
            {
                if(arr[i].Equals(item))
                    return true;
            }
            return false;
        }

        public T[] ToArray()
        {
            int arrSize = Count;
            T[] retArr = new T[arrSize];

            for (int i = head; i < tail; i++)
            {
                retArr[i-head] = arr[i];
            }
            return retArr;
        }
        public void CopyTo(T[] ret, int index)
        {
            for (int i = head; i < tail; i++)
            {
                ret[i - head] = arr[i];
            }
        }
    }
}

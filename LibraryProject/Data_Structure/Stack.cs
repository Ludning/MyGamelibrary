using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryProject.Data_Structure
{
    //첫 스택의 예약사이즈는 size만큼 할당된다
    internal class Stack<T>
    {
        int cursor = 0;
        int size = 100;
        T[] arr;

        public int Count { get { return cursor; } }
        public bool IsEmpty { get { return cursor == 0; } }
        public Stack()
        {
            arr = new T[size];
        }
        public void Push(T data)
        {
            arr[cursor] = data;
            if(cursor < size)
            {
                TrimExcess();
            }
            else
            {
                cursor++;
            }
        }
        public T Pop()
        {
            cursor--;
            T ret = arr[cursor];
            arr[cursor] = default(T);
            return ret;
        }
        public T Peek()
        {
            return arr[cursor];
        }
        public void Clear()
        {
            while(Count>0)
                Pop();
        }
        public bool Contains(T item)
        {
            foreach(T data in arr)
            {
                if(data.Equals(item))
                    return true;
            }
            return false;
        }
        public T[] ToArray()
        {
            int arrSize = Count;
            T[] retArr = new T[arrSize];
            int index = 0;
            foreach(T data in arr)
            {
                retArr[index] = data;
                index++;
            }
            return retArr;
        }
        public void CopyTo(T[] ret, int index)
        {
            if (ret == null)
                throw new ArgumentNullException(nameof(ret));

            if (index < 0 || index >= ret.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (Count > ret.Length - index)
                throw new ArgumentException("Destination array is not long enough to copy all the items in the collection. Check array index and length.");

            int i = index;
            foreach (var item in arr)
                ret[i++] = item;
        }
        private void TrimExcess()
        {
            T[] temp = arr;
            size += 100;
            arr = new T[size];
            int index = 0;
            foreach (var item in temp)
                arr[index++] = item;
        }
        /*
            ToArray: 스택의 모든 요소를 배열로 반환합니다.
            CopyTo: 스택의 요소를 배열로 복사합니다.
            TrimExcess: 내부 배열의 크기를 현재 요소 수에 맞게 조정합니다(일부 구현에서만 해당).
        */
    }
}

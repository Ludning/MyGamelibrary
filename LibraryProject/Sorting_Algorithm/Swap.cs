using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Sorting_Algorithm
{
    internal class Swap
    {
        public static void SwapValue<T>(T[] arr, int idx1, int idx2)
        {
            T temp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = temp;
        }
        public static void SwapValue<T>(IList<T> arr, int left, int right)
        {
            T temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }
    }
}

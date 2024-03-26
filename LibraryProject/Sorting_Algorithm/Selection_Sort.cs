using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Sorting_Algorithm
{
    /*
        버블정렬
        전체배열을 순회하면서 항목이 다른 항목보다 큰 경우 두 항목을 교환한다

        시간복잡도
        
    */
    internal class Selection_Sort
    {
        public int[] SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                //최소값의 인덱스를 저장하는 변수
                int min = i;
                //현재 인덱스부터 배열 끝까지의 요소를 비교하여 최소값을 찾음
                for (int k = i + 1; k < arr.Length; k++)
                {
                    if (arr[k] < arr[min])
                    {
                        min = k;
                    }
                }
                if (i != min)
                {
                    Swap.SwapValue(arr, i, min);
                }
            }
            return arr;
        }
    }
}

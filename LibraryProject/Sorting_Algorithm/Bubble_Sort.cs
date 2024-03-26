using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Sorting_Algorithm
{
    internal class Bubble_Sort
    {
        /*
        버블정렬
        전체배열을 순회하면서 항목이 다른 항목보다 큰 경우 두 항목을 교환한다

        시간복잡도

        */

        public int[] BubbleSort(int[] arr)
        {
            //뱌열의 모든 요소를 탐색
            for (int i = 0; i < arr.Length; i++)
            {
                //각 반복에서 가장 큰 요소가 맨 위로 이동하므로
                //끝 인덱스는 감소하여 반복횟수를 줄임
                for (int k = 0; k < arr.Length - i - 1; k++)
                {
                    //현재 요소와 다음 요소를 비교하여 정렬이 필요한 경우
                    if (arr[k] > arr[k + 1])
                    {
                        //두 요소의 위치를 교환
                        Swap.SwapValue(arr, k, k + 1);
                    }
                }
            }
            return arr;
        }
    }
}

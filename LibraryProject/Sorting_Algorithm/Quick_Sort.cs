using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Sorting_Algorithm
{
    internal class Quick_Sort
    {
        void QuickSort(int[] items)
        {
            //배열의 전체 범위를 대상으로 퀵정렬 수행
            QuickSortHelper(items, 0, items.Length - 1);
        }
        void QuickSortHelper(int[] items, int left, int right)
        {
            while (left < right)
            {
                //배열을 분할하고 분할 인덱스를 반환
                int partitionIndex = Partition(items, left, right);

                //분할된 배열의 왼쪽 부분에 대해 재귀적으로 정렬 수행
                if (partitionIndex - left < right - partitionIndex)
                {
                    QuickSortHelper(items, left, partitionIndex - 1);
                    left = partitionIndex + 1;
                }
                else
                {
                    QuickSortHelper(items, partitionIndex + 1, right);
                    right = partitionIndex - 1;
                }
            }
        }
        //배열을 분할하고 분할 인덱스를 변환하는 함수
        int Partition(int[] arr, int left, int right)
        {
            //중간 값을 피벗으로 선택
            int pivotIndex = (left + right) / 2;
            int pivotvalue = arr[pivotIndex];

            Swap.SwapValue(arr, pivotIndex, right);

            /*
            배열을 순회하며 피벗보다 작은 값을 찾아내고 피벗보다 큰 값을 교환
            피벗의 왼쪽에는 피벗보다 작은 값들이 오고 오른쪽에는 피벗보다 큰 값들이 위치하게 된다
            */

            //배열을 순회하며 피벗보다 작은 값들을 저장할 인덱스
            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (arr[i] < pivotvalue)
                {
                    //현재 값이 피벗보다 작으면 해당 값을 storeIndex에 위치한 값과 교환
                    Swap.SwapValue(arr, i, storeIndex);
                    storeIndex++;
                }
            }
            Swap.SwapValue(arr, storeIndex, right);

            return storeIndex;
        }
    }
}

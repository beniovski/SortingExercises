using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLogic
{
    public static class SortingAlghorithms
    {

        public static void BubbleSort<T>(T[] inputArray) where T : IComparable<T>
        {
            int arrayLength = inputArray.Length;
            for (int i = 0; i < arrayLength - 1; i++)
            {
                for (int j = 0; j < arrayLength - i - 1; j++)
                {
                    if (inputArray[j].CompareTo(inputArray[j + 1]) > 0)
                    {
                        T temp = inputArray[j];
                        inputArray[j] = inputArray[j + 1];
                        inputArray[j + 1] = temp;
                    }
                }
            }
        }

        public static void InsertionSort(int[] inputArray)
        {
            for (int i = 1; i < inputArray.Length; i++)
            {
                int key = inputArray[i];
                int j = i - 1;

                while (j >= 0 && inputArray[j] > key)
                {
                    inputArray[j + 1] = inputArray[j];
                    j = j - 1;
                }
                inputArray[j + 1] = key;
            }
        }

        public static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }

        private static int[] Merge(int[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int i = 0; i < n1; ++i)
                L[i] = array[left + i];
            for (int j = 0; j < n2; ++j)
                R[j] = array[middle + 1 + j];


            int iIndex = 0, jIndex = 0;

            int k = left;
            while (iIndex < n1 && jIndex < n2)
            {
                if (L[iIndex] <= R[jIndex])
                {
                    array[k] = L[iIndex];
                    iIndex++;
                }
                else
                {
                    array[k] = R[jIndex];
                    jIndex++;
                }
                k++;
            }

            while (iIndex < n1)
            {
                array[k] = L[iIndex];
                iIndex++;
                k++;
            }

            while (jIndex < n2)
            {
                array[k] = R[jIndex];
                jIndex++;
                k++;
            }
            return array;
        }

        public static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);

                QuickSort(arr, left, pivotIndex - 1); // Before pivot
                QuickSort(arr, pivotIndex + 1, right); // After pivot
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = (left - 1); // Index of smaller element

            for (int j = left; j < right; j++)
            {
                // If current element is smaller than or equal to pivot
                if (arr[j] <= pivot)
                {
                    i++;

                    // swap arr[i] and arr[j]
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot)
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[right];
            arr[right] = temp1;

            return i + 1;
        }

        public static void BucketSort(int[] inputArray, int bucketSize)
        {
            if (inputArray.Length == 0) return;
            int minValue = inputArray[0];
            int maxValue = inputArray[0];
            foreach (int value in inputArray)
            {
                if (value < minValue) minValue = value;
                else if (value > maxValue) maxValue = value;
            }

            int bucketCount = (maxValue - minValue) / bucketSize + 1;
            List<List<int>> buckets = new List<List<int>>();
            for (int i = 0; i < bucketCount; i++)
            {
                buckets.Add(new List<int>());
            }

            foreach (int value in inputArray)
            {
                buckets[(value - minValue) / bucketSize].Add(value);
            }

            int currentIndex = 0;
            foreach (List<int> bucket in buckets)
            {
                bucket.Sort(); 
                foreach (int value in bucket)
                {
                    inputArray[currentIndex++] = value;
                }
            }
        }

    }
}

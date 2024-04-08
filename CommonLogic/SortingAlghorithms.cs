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

        public static void InsertionSort<T>(T[] inputArray) where T : IComparable
        {
            for (int i = 1; i < inputArray.Length; i++)
            {
                T key = inputArray[i];
                int j = i - 1;

                while (j >= 0 && inputArray[j].CompareTo(key) > 0)
                {
                    inputArray[j + 1] = inputArray[j];
                    j--;
                }
                inputArray[j + 1] = key;
            }
        }

        public static void MergeSort<T>(T[] array, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }

        private static void Merge<T>(T[] array, int left, int middle, int right) where T : IComparable
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            T[] L = new T[n1];
            T[] R = new T[n2];

            Array.Copy(array, left, L, 0, n1);
            Array.Copy(array, middle + 1, R, 0, n2);

            int i = 0, j = 0;
            int k = left;
            while (i < n1 && j < n2)
            {
                if (L[i].CompareTo(R[j]) <= 0)
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                array[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = R[j];
                j++;
                k++;
            }
        }

        public static void QuickSort<T>(T[] arr, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);

                QuickSort(arr, left, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, right);
            }
        }

        private static int Partition<T>(T[] arr, int left, int right) where T : IComparable
        {
            T pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                // Use CompareTo for comparison, which works with IComparable
                if (arr[j].CompareTo(pivot) <= 0)
                {
                    i++;

                    // Swapping elements
                    T temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // Swap arr[i+1] and arr[right] (or pivot)
            T temp1 = arr[i + 1];
            arr[i + 1] = arr[right];
            arr[right] = temp1;

            return i + 1;
        }

        private static (int min, int max) FindMinMax(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            foreach (int value in arr)
            {
                if (value < min) min = value;
                if (value > max) max = value;
            }
            return (min, max);
        }

        public static void BucketSort(int[] inputArray, int bucketSize)
        {
            int n = inputArray.Length;
            if (n <= 1) return;

            var (min, max) = FindMinMax(inputArray);
            int bucketCount = Math.Max(1, n / 5); // Choose the number of buckets
            int bucketRange = (max - min) / bucketCount + 1;

            List<List<int>> buckets = new List<List<int>>();
            for (int i = 0; i < bucketCount; i++)
            {
                buckets.Add(new List<int>());
            }

            // Distribute input array values into buckets
            foreach (int value in inputArray)
            {
                int bucketIndex = (value - min) / bucketRange;
                buckets[bucketIndex].Add(value);
            }

            // Sort each bucket and concatenate all buckets into the original array
            int index = 0;
            foreach (var bucket in buckets)
            {
                bucket.Sort();
                foreach (var value in bucket)
                {
                    inputArray[index++] = value;
                }
            }
        }

    }
}

using CommonLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class QuickSortTest: BaseTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Sort_EmptyArray_NoChange()
        {
            int[] array = new int[0];
            SortingAlghorithms.QuickSort(array,0, array.Length-1);
            Assert.IsEmpty(array);
        }

        [Test]
        public void Sort_SingleElementArray_NoChange()
        {
            int[] array = { 1 };
            SortingAlghorithms.QuickSort(array, 0, array.Length - 1);
            Assert.AreEqual(new int[] { 1 }, array);
        }

        [Test]
        public void Sort_IntArray_Sorted()
        {
            int[] array = new int[arrayToSort.Length];
            Array.Copy(arrayToSort, array, arrayToSort.Length);
            SortingAlghorithms.QuickSort(array, 0, array.Length - 1);
            Assert.AreEqual(sortedArray, array);
        }

        [Test]
        public void Sort_StringArray_Sorted()
        {
            string[] array = { "banana", "apple", "mango", "cherry" };
            SortingAlghorithms.QuickSort(array, 0, array.Length - 1);
            Assert.AreEqual(new string[] { "apple", "banana", "cherry", "mango" }, array);
        }
    }
}

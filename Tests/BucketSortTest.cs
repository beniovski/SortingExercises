using CommonLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class BucketSortTest : BaseTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Sort_EmptyArray_NoChange()
        {
            int[] array = new int[0];
            SortingAlghorithms.BucketSort(array);
            Assert.IsEmpty(array);
        }

        [Test]
        public void Sort_SingleElementArray_NoChange()
        {
            int[] array = { 1 };
            SortingAlghorithms.BucketSort(array);
            Assert.AreEqual(new int[] { 1 }, array);
        }

        [Test]
        public void Sort_IntArray_Sorted()
        {
            int[] array = new int[arrayToSort.Length];
            Array.Copy(arrayToSort, array, arrayToSort.Length);

            SortingAlghorithms.BucketSort(array);
            Assert.AreEqual(sortedArray, array);
        }
    }
}

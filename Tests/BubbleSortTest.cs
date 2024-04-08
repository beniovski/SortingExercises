using CommonLogic;

namespace Tests
{
    public class BubbleSortTest : BaseTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Sort_EmptyArray_NoChange()
        {
            int[] array = new int[0];
            SortingAlghorithms.BubbleSort(array);
            Assert.IsEmpty(array);
        }

        [Test]
        public void Sort_SingleElementArray_NoChange()
        {
            int[] array = { 1 };
            SortingAlghorithms.BubbleSort(array);
            Assert.AreEqual(new int[] { 1 }, array);
        }

        [Test]
        public void Sort_IntArray_Sorted()
        {
            int[] array = new int[arrayToSort.Length];
            Array.Copy(arrayToSort, array, arrayToSort.Length);
            SortingAlghorithms.BubbleSort(array);
            Assert.AreEqual(sortedArray, array);
        }

        [Test]
        public void Sort_StringArray_Sorted()
        {
            string[] array = { "banana", "apple", "mango", "cherry" };
            SortingAlghorithms.BubbleSort(array);
            Assert.AreEqual(new string[] { "apple", "banana", "cherry", "mango" }, array);
        }

    }
}
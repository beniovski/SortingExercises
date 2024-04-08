using CommonLogic;

var array = Utils.GenerateArray(1000);

SortingAlghorithms.MergeSort(array, 0, array.Length - 1);
Utils.PrintTable(array);

Console.ReadLine();
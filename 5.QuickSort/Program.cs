using CommonLogic;

var array = Utils.GenerateArray(100000);

SortingAlghorithms.QuickSort(array, 0, array.Length - 1);

Utils.PrintTable(array);


Console.ReadLine();
using CommonLogic;

var array = Utils.GenerateArray(1000);

SortingAlghorithms.BucketSort(array, array.Length-1);
Utils.PrintTable(array);


Console.ReadLine();
using CommonLogic;

int records;


records = Utils.PromptForNumber<int>("Please enter the number of records:", number => number > 0, "Please enter a number greater than 0.");


decimal[] carPrices = new decimal[records];

for (int i = 0; i < records; i++)
{
    carPrices[i] = Utils.PromptForNumber<decimal>($"{i + 1} Car : ", price=> price>0, "Invalid input. Please enter a valid price.");

}

SortingAlghorithms.BubbleSort(carPrices);

var mediana = Utils.CalculateMedian(carPrices);
Console.WriteLine($"mediana : {mediana}");



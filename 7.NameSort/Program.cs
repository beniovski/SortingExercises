
using CommonLogic;
using NameSort;

int records;
records = Utils.PromptForNumber<int>("Please enter the number of records:", number => number > 0, "Please enter a number greater than 0.");

PersonInfo[] personInfos = new PersonInfo[records];

for(int i = 0; i < records; i++)
{
    string userName = Utils.PromptForString("please provide user name :", " username can't be empty");
    int height = Utils.PromptForNumber<int>($"please provide height for: {userName} ", height => height > 0, "height must be greater than 0");

    personInfos[i] = new PersonInfo(userName, height);
}

SortingAlghorithms.BubbleSort(personInfos);

foreach (var person in personInfos)
{
    Console.WriteLine($"{person.Name} - {person.Height} cm");
}

Console.ReadLine();
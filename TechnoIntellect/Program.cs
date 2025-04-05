using System.Diagnostics;
using TechnoIntellect;
using TechnoIntellect.trie;

Console.WriteLine("Введите номер столбца для поиска");
var inputColumn = Console.ReadLine();
if(!int.TryParse(inputColumn, out int columnNumber))
{
    Console.WriteLine("не корректный номер колонки");
    return;
}

var tree = new TreeObserver();
var csvReader = new CsvReader();
var inputFile = csvReader.ReadFile();
for(int i = 0; i < inputFile.Length; i++)
{
    try
    {
        tree.AddElement(csvReader.ParseCSV(inputFile[i])[columnNumber-1].ToLower(), i);
    }
    catch(ArgumentOutOfRangeException exception)
    {
        Console.WriteLine("Не корректный номер колонки");
        return;
    }
    catch (Exception exception) { 
        Console.WriteLine(exception.ToString());
        return; 
    }
}

var inputString = "";

Console.WriteLine("Введите строку для поиска");
inputString = Console.ReadLine();
var timer = new Stopwatch();

while (inputString != "!quit")
{
    timer.Restart();
    timer.Start();
    var temp = tree.GetMatching(inputString.ToLower());
    temp.Sort();
    foreach( var item in csvReader.ReadLines(temp))
    {
        Console.WriteLine($"{csvReader.ParseCSV(item)[columnNumber - 1]} [{item}]");
    }
    timer.Stop();
    Console.WriteLine($"строк: {temp.Count+1}, время на выполнение: {timer.ElapsedMilliseconds} мс");
    Console.WriteLine("Введите строку для поиска");
    inputString = Console.ReadLine();
}




// See https://aka.ms/new-console-template for more information
string input = File.ReadAllText("./day1/data.txt");

var values = input.
  Split("\n\n").ToList(). //all elfs
  Select(x => x.Split('\n')). //Each elf
  Select(
    x => x.
    Where(y => int.TryParse(y, out int tmp)).
    Sum(y => int.Parse(y))). //Sum each elfs calories
  Order().Reverse().
  Take(3).Sum();

Console.WriteLine(values);
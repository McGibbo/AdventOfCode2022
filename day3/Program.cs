string input = File.ReadAllText("./data.txt");

List<string> bags = input.Replace("\r", "").Split("\n").ToList();

int value = bags.
    Chunk(3).
    Select(bag => bag[0].Intersect(bag[1]).Intersect(bag[2]).First()).
    Select(item => getPrio(item)).
    Sum();

Console.WriteLine(value);

int getPrio(char item)
{
    if(char.IsUpper(item))
        return (int)item - 38;
    else
        return (int)item - 96;
}

char getError(string bag)
{
    string compartment1 = bag.Substring(0, bag.Length/2);
    string compartment2 = bag.Substring(bag.Length/2, bag.Length/2);
    return compartment1.Intersect(compartment2).First();
}
string input = File.ReadAllText("./data.txt");

List<string> pairs = input.Replace("\r", "").Split("\n").ToList();

int badPairs = 0;
foreach (string pair in pairs)
{    
    List<int> elf1 = BuildSection(pair.Split(",")[0]);
    List<int> elf2 = BuildSection(pair.Split(",")[1]);

    List<int> sharedSections = elf1.Intersect(elf2).ToList();

    if(sharedSections.Count > 0)
        badPairs++;
    else
    {
        Console.WriteLine(pair + " " + sharedSections.Count + " " + elf1.Count + " " + elf2.Count);
    }
}

Console.WriteLine(badPairs);


List<int> BuildSection(string elf)
{
    List<int> section = elf.
        Split("-").ToList().
        Select(section => int.Parse(section)).ToList();

    return Enumerable.Range(section[0], section[1] - section[0] + 1).ToList();
}

string input = File.ReadAllText("./data.txt");

HashSet<char> decrypter = new();

for(int i = 0; i <= input.Length; i++)
{
    if(!decrypter.Add(input[i]))
        decrypter.Clear();
    else if (decrypter.Count() == 14)
    {
        Console.WriteLine(i + 1);
        break;
    }
}
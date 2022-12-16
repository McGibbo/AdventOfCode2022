string input = File.ReadAllText("./data.txt");

List<string> rows = input.Replace("\r", "").Split("\n").ToList();

Stack<char> stack1 = new();
Stack<char> stack2 = new();
Stack<char> stack3 = new();
Stack<char> stack4 = new();
Stack<char> stack5 = new();
Stack<char> stack6 = new();
Stack<char> stack7 = new();
Stack<char> stack8 = new();
Stack<char> stack9 = new();
Stack<char> createMover9001 = new();

List<Stack<char>> stacks = new()
{
    stack1,
    stack2,
    stack3,
    stack4,
    stack5,
    stack6,
    stack7,
    stack8,
    stack9,
};

for(int rowID = 7; rowID >= 0; rowID--)
{
    for(int stack = 0; stack <= 8; stack++)
    {
        if(rows[rowID][1 + 4 * stack] != ' ')
            stacks[stack].Push(rows[rowID][1 + 4 * stack]);
    }
}

rows = rows.GetRange(10, rows.Count - 10);

foreach (string row in rows)
{
    string[] commands = row.Split(' ');
    for(int i = 0; i <= int.Parse(commands[1]) - 1; i++)
    {
        if(stacks[int.Parse(commands[3]) - 1].TryPop(out char box))
            createMover9001.Push(box);
    }
    while(createMover9001.TryPop(out char box))
    {
        stacks[int.Parse(commands[5]) - 1].Push(box);
    }
}

foreach(var stack in stacks)
{
    if(stack.TryPop(out char box))
        Console.Write(box);
}
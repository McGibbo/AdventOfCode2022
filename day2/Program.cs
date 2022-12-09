string input = File.ReadAllText("./data.txt");

var moves = 
input.Replace("\r", "").Split("\n").
    Select(x => x.Split(" ")).ToList();
    
int points = 0;

Dictionary<string, string> win = new() {
    {"A", "B"},
    {"B", "C"},
    {"C", "A"}
};

Dictionary<string, string> lose = new() {
    {"A", "C"},
    {"B", "A"},
    {"C", "B"}
};

Dictionary<string, int> pointuse = new(){
    {"A", 1},
    {"B", 2},
    {"C", 3}
};

Dictionary<string, int> pointwin = new(){
    {"X", 0},
    {"Y", 3},
    {"Z", 6}
};

foreach (var move in moves)
{
    string opponent = move[0];
    points += pointwin[move[1]];
    if(move[1] == "X")
    {
        points += pointuse[lose[opponent]];
    }
    else if (move[1] == "Y")
    {
        points += pointuse[opponent];
    }
    else if (move[1] == "Z")
    {
        points += pointuse[win[opponent]];
    }
}

Console.WriteLine(points);

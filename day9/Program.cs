string input = File.ReadAllText("./data.txt");

string[] rows = input.Replace("\r", "").Split("\n");

List<Position> rope = new List<Position>()
{
    new Position() {xPos = 0, yPos = 0},
    new Position() {xPos = 0, yPos = 0},
    new Position() {xPos = 0, yPos = 0},
    new Position() {xPos = 0, yPos = 0},
    new Position() {xPos = 0, yPos = 0},
    new Position() {xPos = 0, yPos = 0},
    new Position() {xPos = 0, yPos = 0},
    new Position() {xPos = 0, yPos = 0},
    new Position() {xPos = 0, yPos = 0},
    new Position() {xPos = 0, yPos = 0}
};

List<Position> visitedTailPositions = new List<Position>() {new Position(){xPos = 0, yPos = 0}};

foreach(string row in rows)
{
    string[] movement = row.Split(" ");
    for (int i = 0; i < int.Parse(movement[1]); i++)
    {
        MoveHead(movement[0]);
    }
}

void MoveHead(string direction)
{
    List<Position> prevRope = new List<Position>(rope);
    switch (direction)
    {
        case "D":
            rope[0] = new Position(){xPos = rope[0].xPos, yPos = rope[0].yPos - 1};
            break;
        case "U":
            rope[0] = new Position(){xPos = rope[0].xPos, yPos = rope[0].yPos + 1};
            break;
        case "L":
            rope[0] = new Position(){xPos = rope[0].xPos - 1, yPos = rope[0].yPos};
            break;
        case "R":
            rope[0] = new Position(){xPos = rope[0].xPos + 1, yPos = rope[0].yPos};
            break;
        default:
            break;
    }

    for (int i = 1; i < rope.Count(); i++)
    {
        if(Math.Abs(rope[i-1].xPos - rope[i].xPos) > 1 || Math.Abs(rope[i-1].yPos - rope[i].yPos) > 1)
        {
            rope[i] = new Position(
                rope[i].xPos + (Math.Sign(rope[i-1].xPos - rope[i].xPos)), 
                rope[i].yPos + (Math.Sign(rope[i-1].yPos - rope[i].yPos)));
        }
    }
    if(!visitedTailPositions.Exists(x => x.xPos == rope[9].xPos && x.yPos == rope[9].yPos))
        visitedTailPositions.Add(new Position(rope[9]));
}

Console.WriteLine(visitedTailPositions.Count());

struct Position
{
    public int xPos;
    public int yPos;

    public Position(Position pos)
    {
        xPos = pos.xPos;
        yPos = pos.yPos;
    }

        public Position(int xPos, int yPos)
    {
        this.xPos = xPos;
        this.yPos = yPos;
    }
}


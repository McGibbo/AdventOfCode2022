string input = File.ReadAllText("./data.txt");

string[] rows = input.Replace("\r", "").Split("\n");

List<Tree> allTrees = new();

for(int i = 0; i < rows.Count(); i++)
{
    for(int j = 0; j < rows[i].Count(); j++)
    {
        char tree = rows[i][j];
        allTrees.Add(new Tree() {xPos = j, yPos = i, size = (int)char.GetNumericValue(tree)});
    }
}

int topScore = 0;

foreach(Tree tree in allTrees)
{
    //Part1
    // if(
    //     allTrees.Where(x => (x.yPos == tree.yPos) && x.size >= tree.size && x.xPos < tree.xPos).Count() == 0 ||
    //     allTrees.Where(x => (x.yPos == tree.yPos) && x.size >= tree.size && x.xPos > tree.xPos).Count() == 0 ||
    //     allTrees.Where(x => (x.xPos == tree.xPos) && x.size >= tree.size && x.yPos < tree.yPos).Count() == 0 ||
    //     allTrees.Where(x => (x.xPos == tree.xPos) && x.size >= tree.size && x.yPos > tree.yPos).Count() == 0 ||
    //     tree.xPos == 0 || tree.xPos == 98 || tree.yPos == 0 || tree.yPos == 98)
    // {
    //     visibleTrees++;
    // }

    //Part2
    int scenicPoints = 1;
    int visibleTrees = 0;
    for(int i = tree.xPos -1; i >= 0; i--)
    {
        visibleTrees++;
        if(allTrees.Find(x => x.xPos == i && x.yPos == tree.yPos).size >= tree.size)
            break;
    }
    scenicPoints *= visibleTrees;
    visibleTrees = 0;
    for(int i = tree.xPos + 1; i <= 98; i++)
    {
        visibleTrees++;
        if(allTrees.Find(x => x.xPos == i && x.yPos == tree.yPos).size >= tree.size)
            break;
    }
    scenicPoints *= visibleTrees;
    visibleTrees = 0;
    for(int i = tree.yPos -1; i >= 0; i--)
    {
        visibleTrees++;
        if(allTrees.Find(x => x.yPos == i && x.xPos == tree.xPos).size >= tree.size)
            break;
    }
    scenicPoints *= visibleTrees;
    visibleTrees = 0;
    for(int i = tree.yPos + 1; i <= 98; i++)
    {
        visibleTrees++;
        if(allTrees.Find(x => x.yPos == i && x.xPos == tree.xPos).size >= tree.size)
            break;
    }
    scenicPoints *= visibleTrees;

    if(scenicPoints > topScore)
        topScore = scenicPoints;
}

Console.WriteLine(topScore);

struct Tree
{
    public int xPos;
    public int yPos;
    public int size;

    public static bool operator == (Tree lhs, Tree rhs) 
    {
        return lhs.xPos == rhs.xPos && lhs.yPos == rhs.yPos;
    }
    public static bool operator !=(Tree lhs, Tree rhs) 
    {
        return lhs.xPos != rhs.xPos || lhs.yPos != rhs.yPos;
    }
}
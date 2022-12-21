string input = File.ReadAllText("./data.txt");

Directory activeDirectory = new Directory(null, "/");

Directory.allDirectories.Add(activeDirectory);

List<string> commands = input.Replace("\r", "").Split("\n").ToList();

foreach(var command in commands)
{
    switch (command.StartsWith("$"))
    {
        case true:
            HandleCommand(command.Replace("$ ", ""));
            break;
        default:
            HandleData(command);
            break;
    }
}

int requiredSpace = (70000000 - Directory.allDirectories[0].CountSize() - 30000000) * -1;

Console.WriteLine(
        Directory.allDirectories.
            Select(x => x.CountSize()).
            Where(x => x > requiredSpace).
            Order().First());

void HandleCommand(string command)
{

    switch (command.StartsWith("cd "))
    {
        case true:
            HandleCD(command.Replace("cd ", ""));
            break;
        default: //ls
            break;
    }
}

void HandleCD(string directoryName)
{
    switch (directoryName.Trim())
    {
        case "..":
            activeDirectory = activeDirectory.parent;
            break;
        case "/":
            break;
        default:
            activeDirectory = activeDirectory.TraverseToChild(directoryName);
            break;
    }
}

void HandleData(string data)
{
    switch (data.StartsWith("dir "))
    {
        case true:
            activeDirectory.AddDirectory(new Directory(activeDirectory, data.Replace("dir ", "")));
            break;
        case false:
            activeDirectory.AddFile(new FileData() {Size = int.Parse(data.Split(' ')[0])});
            break;
        default:
    }
}

class FileData
{
    public int Size;
}
class Directory
{
    public Directory(Directory parent, string name)
    {
        this.parent = parent;
        this.name = name;
        children = new List<Directory>();
        files = new List<FileData>();
    }

    public string name;
    public Directory parent;
    List<Directory> children;
    public static List<Directory> allDirectories = new List<Directory>();
    List<FileData> files;

    public int CountSize()
    {
        int size = 0;
        foreach (var dir in children)
        {
            size += dir.CountSize();
        }
        foreach (var file in files)
        {
            size += file.Size;
        }
        return size;
    }

    public void AddDirectory(Directory directory)
    {
        if(children == null)
            children = new();
        if(!children.Contains(directory))
            children.Add(directory);

        if(allDirectories == null)
            allDirectories = new();
        if(!allDirectories.Contains(directory))
            allDirectories.Add(directory);
    }

    public void AddFile(FileData file)
    {
        if(files == null)
            files = new();
        if (!files.Contains(file))
            files.Add(file);
    }

    public Directory TraverseToChild(string name)
    {
        return children.Find(dir => dir.name == name);
    }
}
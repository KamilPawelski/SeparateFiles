using System.Diagnostics;
using System.IO;
using System.IO.Enumeration;

//Program is not ready
//to do
//the size of the folders must be larger than the largest file size
//loops and exceptions to paths that exist? or something like this
//copying to folders 
//more and more i need to think :O
class Program
{
    static void Main(string[] args)
    {
        FileInfo[] files;
        DirectoryInfo directory;
        DirectoryInfo newDirectory;
        ulong directorySize;
        ulong newSize;
        ushort folderCount;
        Console.WriteLine("Enter directory path.");
        var path = Console.ReadLine() ?? string.Empty;
        directory = Directory.CreateDirectory(path);
        files = directory.GetFiles();
        directorySize = DirectorySize(directory); 
        Console.WriteLine(DirectorySize(directory));
        Console.WriteLine("Enter how much space you want for the folders (B)");
        while (true)
        {
            try
            {
                var size = Console.ReadLine() ?? string.Empty;
                newSize = ulong.Parse(size);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error - Wrong format");
            }
        }
        folderCount = (ushort)(Math.Ceiling((double)(directorySize / newSize)));
        Console.WriteLine("Enter new directory path.");
        path = Console.ReadLine() ?? string.Empty;
        newDirectory = Directory.CreateDirectory(path);
    
        //woops
       /* for (ushort i = 0; i < folderCount; i++)
        {
            ulong filesCount = 0;
            ulong sizeToCompare = 0;
            var destinetionFile = newDirectory + "\\" + i;
            while (sizeToCompare + (ulong) files[filesCount].Length < newSize && (ulong)files.Length >= filesCount)
            {
                directory = Directory.CreateDirectory(destinetionFile);
                string destFile = Path.Combine(directory.FullName, files[filesCount].Name);
                File.Copy(files[filesCount].FullName, destFile);
                filesCount++;
            }
        }*/
    }

    public static ulong DirectorySize(DirectoryInfo directory)
    {
        ulong size = 0;
        FileInfo[] files = directory.GetFiles();
        foreach (FileInfo file in files)
        {

            size += (ulong)(file.Length);
        }
        
        return size;
    }
}
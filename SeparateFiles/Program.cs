class Program
{
    static void Main(string[] args)
    {
        FileInfo[] filesPath;
        DirectoryInfo directory;
        while (true) { 
            try
            {
                Console.WriteLine("Enther the files path");
                directory = new DirectoryInfo(Console.ReadLine());
                filesPath =directory.GetFiles();
                foreach (var x in filesPath) {
                    Console.WriteLine(x);
                }
                break;
            }
            catch (DirectoryNotFoundException) 
            {
                Console.WriteLine("Error - Directory not found.");
            }

        }

        Console.WriteLine(DirSize(directory));
    }

    public static ulong DirSize(DirectoryInfo d)
    {
        ulong size = 0;
        FileInfo[] fis = d.GetFiles();
        foreach (FileInfo fi in fis)
        {
            Console.WriteLine(fi);
            size += Convert.ToUInt64(fi.Length);
        }
        DirectoryInfo[] dis = d.GetDirectories();
        foreach (DirectoryInfo di in dis)
        {
            size += DirSize(di);
        }
        return size;
    }
}
using System.Reflection.Metadata.Ecma335;

namespace Day_7
{
    internal class Program
    {
        public static int spaceNeeded { get; } = 3562874;
        static void Main(string[] args)
        {
            Part2();
        }

        public static void Part2()
        {
            string filepath = @"D:\coding\Personal\AdventOfCode\2022\Day-7\input.txt";
            TextReader sr = new StreamReader(filepath);
            sr.ReadLine(); //skipping over the /

            string buffer;

            int bestDir = int.MaxValue;

            Directory main = new Directory("/");
            while ((buffer = sr.ReadLine()) != null)
            {
                string[] input = buffer.Split(' ');
                if (input[0] == "dir")
                {
                    main.directories.Add(input[1], new Directory(input[1]));
                }
                else if (input[0] == "$")
                {
                    if (input[1] == "cd")
                    {
                        main.size += ExpandDir2(sr, main.directories[input[2]], ref bestDir);
                    }
                    else { continue; }
                }
                else
                {
                    main.size += int.Parse(input[0]);
                }
            }

            Console.WriteLine(main.size);
            Console.WriteLine(bestDir);
        }

        public static void Part1()
        {
            string filepath = @"D:\coding\Personal\AdventOfCode\2022\Day-7\input.txt";
            TextReader sr = new StreamReader(filepath);
            sr.ReadLine(); //skipping over the /

            string buffer;
            int totalSize = 0;
            int bestDir = int.MaxValue;

            Directory main = new Directory("/");
            while((buffer = sr.ReadLine()) != null)
            {
                string[] input = buffer.Split(' ');
                if (input[0] == "dir")
                {
                    main.directories.Add(input[1], new Directory(input[1]));
                }
                else if (input[0] == "$" && input[1] == "cd") 
                {
                    main.size += ExpandDir(sr, main.directories[input[2]], ref totalSize);
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine(totalSize);
            //Console.WriteLine(bestDir);
        }

        public static int ExpandDir(TextReader sr, Directory current, ref int totalSize)
        {
            string buffer;
            while ((buffer = sr.ReadLine()) != null)
            {
                string[] input = buffer.Split(' ');
                if (input[0] == "dir")
                {
                    current.directories.Add(input[1], new Directory(input[1]));
                }
                else if (input[0] == "$")
                {
                    if (input[1] == "cd")
                    {
                        if (input[2] != "..")
                        {
                            current.size += ExpandDir(sr, current.directories[input[2]], ref totalSize);
                        }
                        else
                        {
                            if(current.size <= 100000)
                            {
                                totalSize += current.size;
                            }
                            
                            return current.size;
                        }
                    }
                    else//skipping ls commands since they don't matter
                    {
                        continue;
                    }                  
                }
                else
                {
                    current.size += int.Parse(input[0]);
                }
            }
            //for the end of the file
            if(current.size <= 100000)
            {
                totalSize += current.size;
            }

            //return 0;
            return current.size;
        }
        public static int ExpandDir2(TextReader sr, Directory current, ref int bestDir)
        {
            string buffer;
            while ((buffer = sr.ReadLine()) != null)
            {
                string[] input = buffer.Split(' ');
                if (input[0] == "dir")
                {
                    current.directories.Add(input[1], new Directory(input[1]));
                }
                else if (input[0] == "$")
                {
                    if (input[1] == "cd")
                    {
                        if (input[2] != "..")
                        {
                            current.size += ExpandDir2(sr, current.directories[input[2]], ref bestDir);
                        }
                        else
                        {
                            if ((current.size < bestDir) && current.size > spaceNeeded)
                            {
                                bestDir = current.size;
                            }
                            return current.size;
                        }
                    }
                    else//skipping ls commands since they don't matter
                    {
                        continue;
                    }
                }
                else
                {
                    current.size += int.Parse(input[0]);
                }
            }

            if (current.size >= spaceNeeded)
            {
                if (current.size - spaceNeeded < bestDir)
                {
                    bestDir = current.size;
                }
            }
            //return 0;
            return current.size;
        }
    }

    public class Directory()
    {
        public int size { get; set; } = 0;
        public string Name { get; }
        public Dictionary<string, Directory> directories { get; set; } = new Dictionary<string, Directory>();

        public Directory(string name) : this()
        {
            Name = name;
        }

    }
}

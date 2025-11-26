using System.Text;

namespace Day_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Part1();
            Part2();
        }

        public static void Part1()
        {
            string filepath = @"D:\coding\Personal\AdventOfCode\2022\Day-10\input.txt";
            TextReader sr = new StreamReader(filepath);

            string buffer = "";
            int sum = 0;
            int toAddTimer = 0; int toAdd = 0;
            int cycles = 0;
            int x = 1;
            while(true)
            {
                cycles++;

                if(toAddTimer == 0)
                {
                    x += toAdd;
                    toAdd = 0;
                    if((buffer = sr.ReadLine()) == null)
                    {
                        break;
                    }

                    string[] line = buffer.Split(' ');
                    if(line.Length == 2)
                    {
                        toAdd = int.Parse(line[1]);
                        toAddTimer = 2;
                    }
                }

                if(toAddTimer > 0)
                {
                    toAddTimer--;
                }

                if(cycles % 40 == 20)
                {
                    int operation = cycles * x;
                    Console.WriteLine($"{cycles} * {x} = {operation}");
                    sum += operation;
                }
            }
            
            Console.WriteLine(sum);
        }

        public static void Part2()
        {
            string filepath = @"D:\coding\Personal\AdventOfCode\2022\Day-10\input.txt";
            TextReader sr = new StreamReader(filepath);

            List<string> lines = new List<string>();

            string buffer = "";

            int toAddTimer = 0; int toAdd = 0; int offSet = 0;
            int cycles = 0;
            int x = 1;
            StringBuilder str = new StringBuilder();
            while (true)
            {
                cycles++;

                if (toAddTimer == 0)
                {
                    x += toAdd;
                    toAdd = 0;
                    if ((buffer = sr.ReadLine()) == null)
                    {
                        break;
                    }

                    string[] split = buffer.Split(' ');
                    if (split.Length == 2)
                    {
                        toAdd = int.Parse(split[1]);
                        toAddTimer = 2;
                    }
                }

                if (toAddTimer > 0)
                {
                    toAddTimer--;
                }

                if(cycles - 1 - offSet == x - 1 || cycles - 1 - offSet == x + 1 || cycles - 1 - offSet == x)
                {
                    str.Append("#");
                }
                else { str.Append("."); }

                if (cycles % 40 == 0)
                {
                    offSet += 40;
                    Console.WriteLine(str.ToString());
                    str = new StringBuilder();
                }

            }

            for(int i = 0; i < lines.Count; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }
    }
}

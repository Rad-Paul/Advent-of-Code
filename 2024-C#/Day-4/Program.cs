using System.Runtime.InteropServices;

namespace Day_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../../input.txt");
            string input = sr.ReadToEnd();

            PartOne(input);
            PartTwo(input);
        }

        static void PartOne(string input)
        {
            string[] lines = input.Split(Environment.NewLine);
            int result = 0;

            for(int y = 0; y < lines.Length; y++)
            {
                string line = lines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    char c = line[x];
                    if (c == 'X')
                    {
                        string target = "MAS";
                        (int x, int y)[] directions = [(0, -1), (1, -1), (1, 0), (1, 1), (0, 1), (-1, 1), (-1, 0), (-1, -1)];
                        foreach((int x, int y) direction in directions)
                        {
                            int targetInd = 0;
                            int depth = 1;
                            while (CharFound(lines, line, target[targetInd], x + (direction.x * depth), y + (direction.y * depth)))
                            {
                                if (targetInd == target.Length - 1)
                                {
                                    result++;
                                    break;
                                }

                                targetInd++;
                                depth++;
                            }
                        }
                    }
                       
                }
            }

            Console.WriteLine(result);
        }

        static void PartTwo(string input)
        {
            string[] lines = input.Split(Environment.NewLine);
            int result = 0;

            for (int y = 0; y < lines.Length; y++)
            {
                string line = lines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    char c = line[x];
                    if (c == 'A')
                    {
                        (int x, int y)[] directions = [(-1, -1), (1, -1), (1, 1), (-1, 1)];
                        List<char> chars = new List<char>();

                        foreach ((int x, int y) direction in directions)
                        {
                            int targetX = x + direction.x;
                            int targetY = y + direction.y;
                            if(CharFound(lines, line, null, targetX, targetY)) {
                                chars.Add(lines[targetY][targetX]);
                            }
                        }

                        //when correct, order will be same as direction order
                        if(chars.Count == directions.Length)
                        {
                            string primaryDiagonal = $"{chars[0]}{c}{chars[2]}";
                            string secondaryDiagonal = $"{chars[1]}{c}{chars[3]}";

                            if ((primaryDiagonal == "MAS" || primaryDiagonal == "SAM") && (secondaryDiagonal == "MAS" || secondaryDiagonal == "SAM"))
                                result++;
                        }

                    }

                }
            }

            Console.WriteLine(result);
        }



        static bool CharFound(string[] lines, string line, char? target, int x, int y)
        {
            if(y < 0 || y >= lines.Length || x < 0 || x >= line.Length)
            {
                return false;
            }
            else
            {
                if (lines[y][x] == target || target is null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

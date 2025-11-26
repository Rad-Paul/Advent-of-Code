using System.Runtime.InteropServices;

namespace Day_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = "../../../input.txt";
            TextReader sr = new StreamReader(filepath);
            string input = sr.ReadToEnd();

            List<char[]> map = input.Split("\r\n").Select(line => line.ToCharArray()).ToList();

            int[][] directions = {
                [0, -1],
                [1, 0],
                [0, 1],
                [-1, 0]
            };

            var position = GetStart(map, directions);

            if (position is null)
                throw new NullReferenceException();

            int partOneAnswer = Part1(map, directions, position);

            Console.WriteLine(partOneAnswer);

            sr.Close();
        }

        public static (int x, int y, int directionInd)? GetStart(List<char[]> map, int[][] directions)
        {
            for(int i = 0; i < map.Count; i++)
            {
                for(int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] != '#' &&  map[i][j] != '.')
                    {
                        int x = j;
                        int y = i;
                        int directionInd;
                        if (map[i][j] == '^')
                            directionInd = 0;
                        else if (map[i][j] == '>')
                            directionInd = 1;
                        else if(map[i][j] == 'v')
                            directionInd = 2;
                        else 
                            directionInd = 3;

                            return (x, y, directionInd);
                    }
                }
            }

            return null;
        }

        public static int Part1(List<char[]> map, int[][] directions, (int x, int y, int directionInd)? startPosition)
        {
            if(startPosition is null)
                throw new ArgumentNullException("position");

            int x = startPosition.Value.x;
            int y = startPosition.Value.y;
            int directionInd = startPosition.Value.directionInd;

            while(true)
            {
                map[y][x] = 'X';

                int nextX = directions[directionInd][0] + x;
                int nextY = directions[directionInd][1] + y;

                if(WithinBounds(nextX, nextY, map))
                {
                    if (map[nextY][nextX] == '#')
                        directionInd = ((directionInd+1) % directions.Length);
                    else
                    {
                        x = nextX;
                        y = nextY;
                    }                 
                }
                else
                {
                    break;
                }
            }

            int result = CountX(map, true);

            return result;
        }

        public static int CountX(List<char[]> map, bool print = false)
        {
            int result = 0;

            for(int i = 0; i < map.Count; i++)
            {
                for(int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'X')
                        result++;
                    Console.Write(map[i][j]);
                }
                Console.WriteLine();
            }
            return result;
        }

        public static bool WithinBounds(int x, int y, List<char[]> map)
        {
            if(y > -1 && y < map.Count && x > 0 && x < map[0].Length)
            {
                return true;
            }

            return false;
        }
    }
}

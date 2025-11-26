namespace Day_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Part1(GetInput());
            Part2(GetInput());
        }
        public static List<char[]> GetInput()
        {
            string filepath = "D:\\coding\\Personal\\AdventOfCode\\2020\\Day-11\\input.txt";
            TextReader reader = new StreamReader(filepath);
            List<char[]> lines = new List<char[]>();
            string buffer;
            while ((buffer = reader.ReadLine()) != null)
            {
                lines.Add(buffer.ToCharArray());
            }
            return lines;
        }
        public static void Part1(List<char[]> lines)
        {
            int lastOccupied = -1;
            for (int rounds = 0; rounds < 999; rounds++)
            {
                int occupiedSeats = 0;
                List<char[]> next = new List<char[]>();
                for (int i = 0; i < lines.Count; i++)
                {
                    char[] newLine = new char[lines[0].Length];
                    for (int j = 0; j < lines.Count; j++)
                    {
                        newLine[j] = GetNextFaze(lines, i, j, ref occupiedSeats);
                    }
                    next.Add(newLine);
                }

                lines = next;
                if(occupiedSeats == lastOccupied)
                {
                    Console.WriteLine(occupiedSeats);
                    break;
                }
                lastOccupied = occupiedSeats;
            }
        }
        public static void Part2(List<char[]> lines)
        {
            int lastOccupied = -1;
            for (int rounds = 0; rounds < 999; rounds++)
            {
                int occupiedSeats = 0;
                List<char[]> next = new List<char[]>();
                for (int i = 0; i < lines.Count; i++)
                {
                    char[] newLine = new char[lines[0].Length];
                    for (int j = 0; j < lines.Count; j++)
                    {
                        newLine[j] = GetNextFaze2(lines, i, j, ref occupiedSeats);
                    }
                    next.Add(newLine);
                }

                lines = next;
                if (occupiedSeats == lastOccupied)
                {
                    Console.WriteLine(occupiedSeats);
                    break;
                }
                lastOccupied = occupiedSeats;
            }
        }
        public static char GetNextFaze(List<char[]> lines, int i, int j, ref int occupiedSeats)
        {
            int w = lines[0].Length;
            int h = lines.Count;
            if (lines[i][j] == '.')
            {
                return '.';
            }
            int occupied = 0;
            int[][] directions = [[i - 1, j], [i - 1, j + 1], [i, j + 1], [i + 1, j + 1], [i + 1, j], [i + 1, j - 1], [i, j - 1], [i - 1, j - 1]];
            for (int d = 0; d < directions.Length; d++)
            {
                int[] current = directions[d];
                if (current[0] >= 0 && current[1] >= 0 && current[0] <= h-1 && current[1] <= w - 1)
                {
                    if (lines[current[0]][current[1]] == '#')
                    {
                        occupied++;
                    }
                }
            }

            if (lines[i][j] == 'L')
            {
                if(occupied == 0) { return '#'; }
                else 
                { 
                    return 'L'; 
                }
            }
            if (lines[i][j] == '#')
            {
                occupiedSeats++;
                if(occupied >= 4) { return 'L'; }
                else
                {
                    return '#';
                }
            }

            return 'Z';
        }
        public static char GetNextFaze2(List<char[]> lines, int i, int j, ref int occupiedSeats)
        {
            int w = lines[0].Length;
            int h = lines.Count;
            if (lines[i][j] == '.')
            {
                return '.';
            }
            int occupied = 0;
            int[][] directions = [[-1, 0], [-1,+1], [0,+1], [+1,+1], [+1,0], [+1,-1], [0,-1], [-1,-1]];
            for (int d = 0; d < directions.Length; d++)
            {
                int[] current = directions[d];
                int ni = i;
                int nj = j;
                while(ni+current[0] >= 0 && nj+current[1] >= 0 && ni+current[0] <= h - 1 && nj+current[1] <= w - 1)
                {
                    if (lines[ni+current[0]][nj+current[1]] == '#')
                    {
                        occupied++;
                        break;
                    }
                    if (lines[ni+current[0]][nj+current[1]] == 'L')
                    {
                        break;
                    }
                    ni += current[0];
                    nj += current[1];
                }
            }

            if (lines[i][j] == 'L')
            {
                if (occupied == 0) { return '#'; }
                else
                {
                    return 'L';
                }
            }
            if (lines[i][j] == '#')
            {
                occupiedSeats++;
                if (occupied >= 5) { return 'L'; }
                else
                {
                    return '#';
                }
            }

            return 'Z';
        }
    }
}

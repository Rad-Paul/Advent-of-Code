using System.Diagnostics.CodeAnalysis;

namespace Day_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = "D:\\coding\\Personal\\AdventOfCode\\2020\\Day-12\\input.txt";
            TextReader reader = new StreamReader(filepath);
            string[] shipInstructions = reader.ReadToEnd().Split("\r\n");
            Part1(shipInstructions);
            Part2(shipInstructions);
        }

        public static void Part1(string[] instructions)
        {
            int result = 0;
            int x = 0;
            int y = 0;

            int dirInd = 1;

            char[] directions = ['N', 'E', 'S', 'W'];

            for (int i = 0; i < instructions.Length; i++)
            {
                char direction = instructions[i][0];
                int value = int.Parse(instructions[i].Substring(1));
                if (direction == 'L')
                {
                    dirInd = ((dirInd - value / 90) + 4) % 4;
                }
                else if(direction == 'R')
                {
                    dirInd = (dirInd + (value / 90)) % 4;
                }
                else
                {
                    if (direction == 'F') { direction = directions[dirInd]; }
                    Move(direction, value, ref x, ref y);
                }
            }
            Console.WriteLine("x:" + x + " " + "y:" + y);
            Console.WriteLine(Math.Abs(x) + Math.Abs(y));
        }
        public static void Part2(string[] instructions)
        {
            int shipX = 0;
            int shipY = 0;

            int wayptX = 10;
            int wayptY = 1;

            for (int i = 0; i < instructions.Length; i++)
            {
                int[] coords = new int[2];
                int value = int.Parse(instructions[i].Substring(1));
                if (instructions[i][0] == 'L')
                {
                    coords = RotateCCW(value/90, wayptX,  wayptY);
                    wayptX = coords[0];
                    wayptY = coords[1];
                }
                else if (instructions[i][0] == 'R')
                {
                    coords = RotateCW(value/90, wayptX, wayptY);
                    wayptX = coords[0];
                    wayptY = coords[1];
                }
                else if (instructions[i][0] == 'F')
                {
                    shipX += wayptX * value;
                    shipY += wayptY * value;
                }
                else
                {
                    Move(instructions[i][0], value, ref wayptX, ref wayptY);
                }
                //Console.WriteLine($"x:{wayptX} y:{wayptY}");
            }

            Console.WriteLine("x:" + shipX + " " + "y:" + shipY);
            Console.WriteLine(Math.Abs(shipX) + Math.Abs(shipY));
        }
        public static int[] RotateCW(int times, int x, int y)
        {
            for (int i = 0; i < times; i++)
            {
                int temp = x;
                x = y;
                y = temp * -1;
            }
            return [x, y];
        }
        public static int[] RotateCCW(int times, int x, int y) 
        {
            for (int i = 0; i < times; i++)
            {
                int temp = y;
                y = x;
                x = temp * -1;
            }
            return [x, y];
        }
        public static void Move(char direction, int value, ref int x, ref int y)
        {
            if (direction == 'N') { y += value; }
            else if (direction == 'E') { x += value; }
            else if (direction == 'S') { y -= value; }
            else if (direction == 'W') { x -= value; }
        }
    }
}

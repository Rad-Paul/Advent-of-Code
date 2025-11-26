namespace Day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"D:\coding\Personal\AdventOfCode\2022\Day-2\Day-2\input.txt";
            Part2(filepath);
        }
        public static void Part1(string filepath)
        {
            //A - Rock     X - Rock
            //B - Paper    Y - Paper
            //C - Scissors Z - Scissors
            TextReader sr = new StreamReader(filepath);
            string buffer;
            int totalScore = 0;
            while((buffer = sr.ReadLine()) != null)
            {
                totalScore += DecideWinner(buffer[0], buffer[2]);
            }
            
            Console.WriteLine(totalScore);
        }
        public static void Part2(string filepath)
        {
            TextReader sr = new StreamReader(filepath);
            string buffer;
            int totalScore = 0;
            while ((buffer = sr.ReadLine()) != null)
            {
                totalScore += DecideWinner(buffer[0], Translate(buffer[0], buffer[2]));
            }

            Console.WriteLine(totalScore);
        }

        public static int DecideWinner(char a, char b)
        {
            int win = 6; int draw = 3; int loss = 0;
            int rock = 1; int paper = 2; int scissors = 3;
            int score = 0;
            if (a == 'A')
            {
                if (b == 'X') { score += rock + draw; } //draw
                else if (b == 'Y') { score += paper + win; } //win
                else if (b == 'Z') { score += scissors + loss; } //loss
            }
            else if (a == 'B')
            {
                if (b == 'X') { score += rock + loss; }
                else if (b == 'Y') { score += paper + draw; }
                else if (b == 'Z') { score += scissors + win; }
            }
            else if (a == 'C')
            {
                if (b == 'X') { score += rock + win; }
                else if (b == 'Y') { score += paper + loss; }
                else if (b == 'Z') { score += scissors + draw; }
            }

            return score;
        }

        public static char Translate(char a, char b)
        {
            char result = '?';

            if(a == 'A')
            {
                if(b == 'X')
                {
                    result = 'Z';
                }
                else if(b == 'Y')
                {
                    result = 'X';
                }
                else if(b == 'Z')
                {
                    result = 'Y';
                }
            }
            else if(a == 'B')
            {
                if (b == 'X')
                {
                    result = 'X';
                }
                else if (b == 'Y')
                {
                    result = 'Y';
                }
                else if (b == 'Z')
                {
                    result = 'Z';
                }
            }
            else if(a == 'C')
            {
                if (b == 'X')
                {
                    result = 'Y';
                }
                else if (b == 'Y')
                {
                    result = 'Z';
                }
                else if (b == 'Z')
                {
                    result = 'X';
                }
            }

            return result;
        }

    }
}

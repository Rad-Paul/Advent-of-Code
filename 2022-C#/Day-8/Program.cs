using System.Runtime.CompilerServices;

namespace Day_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"D:\coding\Personal\AdventOfCode\2022\Day-8\input.txt";
            TextReader sr = new StreamReader(filepath);

            List<string> lines = new List<string>();
            string buffer;
            while((buffer = sr.ReadLine()) != null)
            {
                lines.Add(buffer);
            }
            //Part1(lines);
            Part2(lines);
        }     
        
        public static void Part1(List<string> input)
        {
            int count = 0;

            for(int i = 0; i < input.Count; i++)
            {
                for(int j = 0; j < input[i].Length; j++)
                {
                    if(!IsVisible(input, i, j))
                    {
                        continue;
                    }
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        public static void Part2(List<string> input)
        {
            int scenicScr = 0;
            int bestScr = int.MinValue;
            for (int i = 0; i < input.Count; 
                i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    scenicScr = GetScenicScore(input, i, j);  
                    if(scenicScr > bestScr)
                    {
                        bestScr = scenicScr;
                    }
                }               
            }

            Console.WriteLine(bestScr);
        }

        private static int GetScenicScore(List<string> input, int lineInd, int ind)
        {
            string line = input[lineInd];
            int val = (int)char.GetNumericValue(line[ind]);
            int scenicScr = 1;

            scenicScr *= DFSN2(input, lineInd - 1, ind, val);
            scenicScr *= DFSE2(line, ind + 1, val);
            scenicScr *= DFSS2(input, lineInd + 1, ind, val);
            scenicScr *= DFSW2(line, ind - 1, val);
            return scenicScr;
        }

        public static bool IsVisible(List<string> input, int lineInd, int ind)
        {
            string line = input[lineInd];
            int val = (int)char.GetNumericValue(line[ind]);
            if (DFSN(input, lineInd - 1, ind, val)) { return true; }
            if (DFSE(line, ind + 1, val)) { return true; }
            if (DFSS(input, lineInd + 1, ind, val)) { return true; }
            if (DFSW(line, ind - 1, val)) { return true; }

            return false;
        }
        #region Part1Dfs
        public static bool DFSN(List<string> input, int lineInd, int ind, int val)
        {
            if(lineInd < 0)
            {
                return true;
            }

            string line = input[lineInd];
            if((int)char.GetNumericValue(line[ind]) >= val) { return false; ; }
            if(!DFSN(input, lineInd - 1, ind, val)) { return false; }
            return true;
        }
        public static bool DFSE(string line, int ind, int val)
        {
            if (ind >= line.Length)
            {
                return true;
            }

            if ((int)char.GetNumericValue(line[ind]) >= val) { return false; }
            if (!DFSE(line, ind + 1, val)) { return false; }
            return true;
        }
        public static bool DFSS(List<string> input, int lineInd, int ind, int val)
        {
            if (lineInd >= input.Count)
            {
                return true;
            }

            string line = input[lineInd];
            if ((int)char.GetNumericValue(line[ind]) >= val) { return false; }
            if (!DFSS(input, lineInd + 1, ind, val)) { return false; }
            return true;
        }
        public static bool DFSW(string line, int ind, int val)
        {
            if (ind < 0)
            {
                return true;
            }

            if ((int)char.GetNumericValue(line[ind]) >= val) { return false; }
            if (!DFSW(line, ind - 1, val)) { return false; }
            return true;
        }
        #endregion
        #region Part2Dfs
        public static int DFSN2(List<string> input, int lineInd, int ind, int val, int score = 0)
        {
            if(lineInd < 0)
            {
                return score;
            }
            string line = input[lineInd];
            score++;
            if ((int)char.GetNumericValue(line[ind]) >= val)
            {
                return score;
            }
            else
            {
                score = DFSN2(input, lineInd - 1, ind, val, score);
            }
            return score;
        }
        public static int DFSE2(string line, int ind, int val, int score = 0)
        {
            if(ind >= line.Length)
            {
                return score;
            }

            score++;
            if ((int)char.GetNumericValue(line[ind]) >= val)
            {
                return score;
            }
            else
            {
                score = DFSE2(line, ind + 1, val, score);
            }
            return score;
        }
        public static int DFSS2(List<string> input, int lineInd, int ind, int val, int score = 0)
        {
            if (lineInd >= input.Count)
            {
                return score;
            }
            score++;
            string line = input[lineInd];
            if ((int)char.GetNumericValue(line[ind]) >= val)
            {
                return score;
            }
            else
            {
                score = DFSS2(input, lineInd + 1, ind, val, score);
            }
            return score;
        }
        public static int DFSW2(string line, int ind, int val, int score = 0)
        {
            if (ind < 0)
            {
                return score;
            }

            score++;
            if ((int)char.GetNumericValue(line[ind]) >= val)
            {
                return score;
            }
            else
            {
                score = DFSW2(line, ind - 1, val, score);
            }
            return score;
        }
        #endregion
    }
}

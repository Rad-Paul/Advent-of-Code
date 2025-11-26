using System.Text;

namespace Day_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"D:\coding\Personal\AdventOfCode\2022\Day-6\input.txt";
            TextReader sr = new StreamReader(filepath);
            string[] buffer = sr.ReadToEnd().Split('\n');
            Part2(buffer);
        }

        public static void Part1(string[] input)
        {
            Dictionary<char, int> charIndex;
            
            for (int i = 0; i < input.Length; i++)
            {                
                string line = input[i];
                charIndex = new Dictionary<char, int>();

                int index = 0;
                int length = 0;
                while (line[index] != '\r')
                {
                    char c = line[index];
                    if (!charIndex.ContainsKey(c))
                    {
                        charIndex.Add(c, index);
                    }
                    else
                    {
                        int duplicateInd = charIndex[c];
                        foreach(KeyValuePair<char, int> pair in charIndex)
                        {
                            if(pair.Value <= duplicateInd)
                            {
                                charIndex.Remove(pair.Key);
                            }
                        }
                        charIndex.Add(c, index);
                    }

                    length++;
                    index++;
                    if(charIndex.Count == 4)
                    {
                        break;
                    }
                }

                Console.WriteLine(length);
            }
        }

        //exactly the same but with 14
        public static void Part2(string[] input)
        {
            Dictionary<char, int> charIndex;

            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];
                charIndex = new Dictionary<char, int>();

                int index = 0;
                int length = 0;
                while (line[index] != '\r')
                {
                    char c = line[index];
                    if (!charIndex.ContainsKey(c))
                    {
                        charIndex.Add(c, index);
                    }
                    else
                    {
                        int duplicateInd = charIndex[c];
                        foreach (KeyValuePair<char, int> pair in charIndex)
                        {
                            if (pair.Value <= duplicateInd)
                            {
                                charIndex.Remove(pair.Key);
                            }
                        }
                        charIndex.Add(c, index);
                    }

                    length++;
                    index++;
                    if (charIndex.Count == 14)
                    {
                        break;
                    }
                }

                Console.WriteLine(length);
            }
        }
    }
}

using System.Linq.Expressions;
using System.Text;

namespace Day_14
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string filepath = "D:\\coding\\Personal\\AdventOfCode\\2020\\Day-14\\input.txt";
            TextReader reader = new StreamReader(filepath);
            string[] input = reader.ReadToEnd().Split("\r\n");

            Part1(input);
            Part2(input);
        }
        public static void Part1(string[] input)
        {
            Dictionary<string, long> memory = new Dictionary<string, long>();
            string bitmask = "";
            for (int i = 0; i < input.Length; i++)
            {
                string[] instruction = input[i].Split(" = ");
                if (instruction[0] == "mask")
                {
                    bitmask = instruction[1];
                }
                else
                {
                    string address = instruction[0].Substring(3);
                    long decimalValue = long.Parse(instruction[1]);
                    memory[address] = DecimalToBinary(decimalValue, bitmask);
                }
            }

            Console.WriteLine(memory.Values.ToList().Sum());
        }

        public static void Part2(string[] input)
        {
            //a long time in between part 1 and 2, so I did it quite differently
            Dictionary<long, long> memory = new Dictionary<long, long>();
            string bitmask = "";
            for (int i = 0; i < input.Length; i++)
            {
                string[] instruction = input[i].Split(" = ");
                if (instruction[0] == "mask")
                {
                    bitmask = instruction[1];
                }
                else
                {
                    string address = Convert.ToString(GetMemoryAdress(instruction[0]), 2);
                    long decimalValue = long.Parse(instruction[1]);

                    List<StringBuilder> result = GenerateAllAdresses(address, bitmask);
                    foreach (StringBuilder sb in result)
                    {
                        memory[Convert.ToInt64(sb.ToString(), 2)] = decimalValue;
                    }
                }
            }

            Console.WriteLine(memory.Values.ToList().Sum());
        }

        public static List<StringBuilder> GenerateAllAdresses(string address, string bitmask)
        {
            List<StringBuilder> result = new List<StringBuilder>() {new StringBuilder("")};
            address = address.PadLeft(36, '0');
            for (int i = 0; i < address.Length; i++)
            {
                if (bitmask[i] == 'X')
                {
                    int count = result.Count;
                    for (int j = 0; j < count; j++)
                    {
                        result.Add(new StringBuilder("" + result[j] + '1'));
                        result[j].Append('0');
                    }
                }
                else
                {
                    char toAdd = address[i];
                    if (bitmask[i] == '1')
                    {
                        toAdd = '1';
                    }
                   
                    foreach (StringBuilder s in result)
                    {
                        s.Append(toAdd);
                    }
                }
            }

            return result;
        }
        public static int GetMemoryAdress(string input)
        {
            int startInd = input.IndexOf('[') + 1;
            return int.Parse(input.Substring(startInd, input.Length-1 - startInd));
        }
        public static long DecimalToBinary(long value, string bitmask)
        {
            string binaryOfInput = Convert.ToString(value, 2);
            char[] chars = bitmask.ToCharArray();
            int index = binaryOfInput.Length - 1;
            for (int i = chars.Length-1; i >= 0; i--)
            {
                if (chars[i] == 'X')
                {
                    if(index >= 0)
                    {
                        chars[i] = binaryOfInput[index];
                    }
                    else
                    {
                        chars[i] = '0';
                    }
                }
                index--;
            }
            return Convert.ToInt64(new string(chars), 2);
        }
    }
}

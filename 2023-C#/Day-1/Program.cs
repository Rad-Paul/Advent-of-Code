using System.Collections.Generic;
using System.Text;

class Program
{
    public class NamedDigit
    {
        public string Name { get; }
        public int Value { get; }
        public int Length { get; } = 0; //I could just get the Length from Name

        public NamedDigit(string name, int value)
        {
            Name = name;
            Value = value;
            Length = name.Length;
        }
    }
    public static Dictionary<string, int> strNums = new Dictionary<string, int>()
    {
        {"one", 1 },
        {"two", 2 },
        {"three", 3 },
        {"four", 4 },
        {"five", 5 },
        {"six", 6 },
        {"seven", 7 },
        {"eight", 8 },
        {"nine", 9 },
    };
    public static List<NamedDigit> namedDigits = new List<NamedDigit>() 
    {
        {new NamedDigit("one", 1) },
        {new NamedDigit("two", 2) },
        {new NamedDigit("three", 3) },
        {new NamedDigit("four", 4) },
        {new NamedDigit("five", 5) },
        {new NamedDigit("six", 6) },
        {new NamedDigit("seven", 7) },
        {new NamedDigit("eight", 8) },
        {new NamedDigit("nine", 9) }
    };
    static void Main(string[] args)
    {
        string filepath = @"D:/coding/AdventOfCode/2023/Day-1/input.txt";
        TextReader sr = new StreamReader(filepath);
        int toReturn = 0;
        string line;
        while((line = sr.ReadLine()) != null)
        {
            //toReturn += FindFirstDigit(line) + FindLastDigit(line);
            toReturn += FindFirstNamed(line) + FindLastNamed(line);
        }
        Console.WriteLine(toReturn);
    }

    public static int FindFirstDigit(string line)
    {
        int answer = 0;
        for(int i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
            {
                answer = int.Parse(line[i].ToString());
                break;
            }
        }
        return answer * 10;
    }
    public static int FindLastDigit(string line)
    {
        int answer = 0;
        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(line[i]))
            {
                answer = int.Parse(line[i].ToString());
                break;
            }
        }
        return answer;
    }
    public static int FindFirstNamed(string line)
    {
        int answer = 0;

        for (int i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
            {
                answer = int.Parse(line[i].ToString());
                break;
            }
            
            for(int j = 0; j < namedDigits.Count; j++)
            {
                //if one of the digits starts with the same char
                if (namedDigits[j].Name[0] == line[i])
                {
                    //if it's within bounds
                    if(i + namedDigits[j].Length < line.Length)
                    {
                        if (line.Substring(i, namedDigits[j].Length) == namedDigits[j].Name)
                        {
                            answer = namedDigits[j].Value * 10;
                            return answer;
                        }
                    }                  
                }
            }       
        }
        return answer * 10;
    }
    public static int FindLastNamed(string line)
    {
        int answer = 0;
        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(line[i]))
            {
                answer = int.Parse(line[i].ToString());
                break;
            }

            for (int j = 0; j < namedDigits.Count; j++)
            {
                //if the last digit starts with the same char
                if (namedDigits[j].Name[namedDigits[j].Length - 1] == line[i])
                {
                    //if it's within bounds
                    if ((i - namedDigits[j].Length + 1) > 0)
                    {
                        if (line.Substring(i - namedDigits[j].Length + 1, namedDigits[j].Length) == namedDigits[j].Name)
                        {
                            answer = namedDigits[j].Value;
                            return answer;
                        }
                    }
                }
            }
        }
        return answer;
    }
}
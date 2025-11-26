namespace Day_4
{
    internal class Program
    {
        static void Main()
        {
            Solution();
        }

        public static void Solution()
        {
            int part1Answer = 0;
            int part2Answer = 0;
            string[] input = ProcessInput();
            Dictionary<string, Func<string[], bool>> reqFields = new Dictionary<string, Func<string[], bool>>
            {
                {"byr", ValidYears},
                {"iyr", ValidYears},
                {"eyr", ValidYears},
                {"hgt", ValidHeight},
                {"hcl", ValidHairCl},
                {"ecl", ValidEyeCl},
                {"pid", ValidPId},
                {"cid", null }
            };

            for (int i = 0; i < input.Length; i++)
            {
                int fieldCount = 0;
                bool missingCid = true;
                bool validValues = true;
                string[] fieldLines = input[i].Split("\r\n");
                for (int j = 0; j < fieldLines.Length; j++)
                {
                    string[] fieldEntries = fieldLines[j].Split(" ");
                    for (int k = 0; k < fieldEntries.Length; k++)
                    {
                        string[] field = fieldEntries[k].Split(":");
                        if (field[0] == "cid")
                        {
                            missingCid = false;
                            fieldCount++;
                        }else if (reqFields.ContainsKey(field[0])){
                            fieldCount++;
                            bool valid = reqFields[field[0]](field);
                            Console.WriteLine(valid);
                            if (!valid)
                            {
                                validValues = false;
                            }
                        }
                    }
                }
                Console.WriteLine();
                if (missingCid)
                {
                    fieldCount++;
                }
                if (fieldCount == reqFields.Count) {
                    part1Answer++;
                    if (validValues) {
                        part2Answer++;
                    }
                }
            }

            Console.WriteLine(part1Answer);
            Console.WriteLine(part2Answer);
        }

        public static bool ValidYears(string[] entry)
        {
            if (entry[1].Length != 4)
            {
                return false;
            }

            string field = entry[0];
            int value = int.Parse(entry[1]);
            
            if(field == "byr")
            {
                if(value < 1920 || value > 2002)
                {
                    return false;
                }
            }
            else if(field == "iyr")
            {
                if(value < 2010 || value > 2020)
                {
                    return false;
                }
            }
            else if(field == "eyr")
            {
                if(value < 2020 || value > 2030)
                {
                    return false;
                }
            }

            return true;
        }
        public static bool ValidHeight(string[] entry)
        {
            if (entry[1].Length < 4)
            {
                return false;
            }

            string measurement = entry[1].Substring(entry[1].Length-2);
            int height = int.Parse(entry[1].Substring(0, entry[1].Length-2));
            
            if(measurement != "cm" && measurement != "in")
            {
                return false;
            }
            if(measurement == "in")
            {
                if(height < 59 || height > 76)
                {
                    return false;
                }
            }
            else if(measurement == "cm")
            {
                if(height < 150 || height > 193)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool ValidHairCl(string[] entry)
        {
            string cl = entry[1];
            if (cl[0] != '#' || cl.Length != 7)
            {
                return false;
            }

            for(int i = 1; i < cl.Length; i++)
            {
                if(char.IsDigit(cl[i]) || (cl[i] >= (int)'a' && cl[i] <= (int)'f'))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        public static bool ValidEyeCl(string[] entry)
        {
            string cl = entry[1];

            if(cl != "amb" && cl != "blu" && cl != "brn" && cl != "gry" && cl != "grn" && cl != "hzl" && cl != "oth")
            {
                return false;
            }

            return true;
        }
        public static bool ValidPId(string[] entry)
        {
            if(entry[1].Length != 9)
            {
                return false;
            }
            string pId = entry[1];

            for (int i = 0; i < pId.Length; i++)
            {
                if (!char.IsDigit(pId[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static string[] ProcessInput()
        {
            TextReader sr = new StreamReader("D:\\coding\\Personal\\AdventOfCode\\2020\\Day-4\\input.txt");
            string[] entries = sr.ReadToEnd().Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);

            return entries;
        }
    }
}

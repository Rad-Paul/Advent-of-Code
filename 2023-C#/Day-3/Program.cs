using System;
using System.Security.Cryptography;
class Program
{
    static string filepath = "D:/coding/AdventOfCode/2023/Day-3/input.txt";

    static void Main(string[] args)
    {
        Part2();
    }

    public static void Part2()
    {
        StreamReader sr = new StreamReader(filepath);
        string[] input = sr.ReadToEnd().Split('\n');
        int finalSum = 0;
        for (int row = 0; row < input.Length; row++)
        {
            string currentLine = input[row];
            for (int j = 0; j < input[row].Length; j++)
            {
                if (currentLine[j] == '*')
                {
                    finalSum += Find2Nums(row, j);
                }
            }
            Console.WriteLine(Environment.NewLine);
        }

        Console.WriteLine(finalSum);
        int Find2Nums(int rowindex, int index)
        {
            //checking if the rows exist
            bool[,] directions = new bool[3,3];
            List<int> nums = new List<int>();

            string rowAbove = "";
            if (rowindex - 1 >= 0)
            {
                rowAbove = input[rowindex - 1];
            }
            string rowBelow = "";
            if (rowindex + 1 < input.Length)
            {
                rowBelow = input[rowindex + 1];
            }
            string currentRow = input[rowindex];

            int i = 0;
            //Above
            if (rowAbove != "")
            {
                //N
                if (char.IsDigit(rowAbove[index]) && !directions[i,1])
                {
                    directions[i, 1] = true;
                    nums.Add(RetrieveNumber(index,rowAbove, 1));
                }
                //NE
                if (rowAbove[index + 1] != '\r' && !directions[i,2] && char.IsDigit(rowAbove[index + 1]))
                {
                    directions[i, 2] = true;
                    nums.Add(RetrieveNumber(index + 1, rowAbove, 2));
                }
                //NW
                if (index - 1 > 0 && !directions[i, 0] && char.IsDigit(rowAbove[index - 1]))
                {
                    directions[i, 0] = true;
                    nums.Add(RetrieveNumber(index - 1, rowAbove, 0));
                }
            }
            i = 1;
            //E
            if (currentRow[index + 1] != '\r' && !directions[i,2] && char.IsDigit(currentRow[index + 1]))
            {
                directions[i, 2] = true;
                nums.Add(RetrieveNumber(index + 1, currentRow, 2));
            }
            //W
            if (index - 1 > 0 && !directions[i,0] && char.IsDigit(currentRow[index - 1]))
            {
                directions[i, 0] = true;
                nums.Add(RetrieveNumber(index - 1, currentRow, 0));
            }
            i = 2;
            //Below
            if(rowBelow != "")
            {
                //S
                if (char.IsDigit(rowBelow[index]) && !directions[i, 1])
                {
                    directions[i, 1] = true;
                    nums.Add(RetrieveNumber(index, rowBelow, 1));
                }
                //SE
                if (rowBelow[index + 1] != '\r' && !directions[i, 2] && char.IsDigit(rowBelow[index + 1]))
                {
                    directions[i, 2] = true;
                    nums.Add(RetrieveNumber(index + 1, rowBelow, 2));
                }
                //SW
                if (index - 1 > 0 && !directions[i, 0] && char.IsDigit(rowBelow[index - 1]))
                {
                    directions[i, 0] = true;
                    nums.Add(RetrieveNumber(index - 1, rowBelow, 0));
                }
            }

            if(nums.Count == 2)
            {         
                int toReturn = nums[0] * nums[1];
                Console.Write(nums[0] + " * " + nums[1] + " = " + toReturn + " | ");
                return toReturn;
            }
            return 0;

            int RetrieveNumber(int nrIndex, string row, int y)
            {
                int resetY = y;

                int startIndex = nrIndex;
                int length = 1;
                int asNum = 0;

                while (startIndex - 1 >= 0 && char.IsDigit(row[startIndex - 1]))
                {
                    if(y > 0)
                    {
                        y--;
                    }                   
                    directions[i, y] = true;

                    startIndex--;
                    length++;
                }

                y = resetY;
                while (row[nrIndex + 1] != '\r' && char.IsDigit(row[nrIndex + 1]))
                {
                    if(y < 2)
                    {
                        y++;
                    }                   
                    directions[i, y] = true;

                    ++nrIndex;
                    length++;
                }
                
                return asNum = int.Parse(row.Substring(startIndex, length));                
            }
        }
    }
    public static void Try2()
    {
        StreamReader sr = new StreamReader(filepath);
        string[] input = sr.ReadToEnd().Split('\n');
        int finalSum = 0;
        for(int row = 0; row < input.Length; row++)
        {
            string currentLine = input[row];
            for (int j = 0; j < input[row].Length; j++)
            {
                if (char.IsDigit(currentLine[j]))
                {
                    List<int> indexesToSearch = new List<int>() { j };
                    string numFound = "";
                    numFound += currentLine[j];
                    while (j + 1 < currentLine.Length && char.IsDigit(currentLine[j + 1]))
                    {
                        j++;
                        indexesToSearch.Add(j);
                        numFound += currentLine[j];
                    }

                    if(nextToSymbol(indexesToSearch, row))
                    {
                        finalSum += int.Parse(numFound);
                    }
                }
            }
        }

        Console.WriteLine(finalSum);

        bool nextToSymbol(List<int> indexes, int rowindex)
        {
            //checking if the rows exist
            string rowAbove = "";
            if (rowindex - 1 > 0)
            {
                rowAbove = input[rowindex - 1];
            }
            string rowBelow = "";
            if (rowindex + 1 < input.Length)
            {
                rowBelow = input[rowindex + 1];
            }
            string currentRow = input[rowindex];

            for (int i = 0; i < indexes.Count; i++)
            {               
                //N
                if(rowAbove != "" && rowAbove[indexes[i]] != '.')
                {
                    return true;
                }
                //NE
                if (rowAbove != "" && rowAbove[indexes[i] + 1] != '\r' && rowAbove[indexes[i] + 1] != '.' )
                {
                    return true;
                }
                //NW
                if (rowAbove != "" && indexes[i] - 1 > 0 && rowAbove[indexes[i] - 1] != '.')
                {
                    return true;
                }
                //E
                if (currentRow[indexes[i] + 1] != '\r' && !char.IsDigit(currentRow[indexes[i] + 1]) && currentRow[indexes[i] + 1] != '.')
                {
                    return true;
                }
                //W
                if (indexes[i] - 1 > 0 && !char.IsDigit(currentRow[indexes[i] - 1]) && currentRow[indexes[i] - 1] != '.')
                {
                    return true;
                }
                //S
                if (rowBelow != "" && rowBelow[indexes[i]] != '.')
                {
                    return true;
                }
                //SE
                if (rowBelow != "" && rowBelow[indexes[i] + 1] != '\r' && rowBelow[indexes[i] + 1] != '.')
                {
                    return true;
                }
                //SW
                if (rowBelow != "" && indexes[i] - 1 > 0 && rowBelow[indexes[i] - 1] != '.')
                {
                    return true;
                }
            }

            return false;
        }
    }
    public static void Try1()
    {
        int test = 12;
        int finalSum = 0;

        StreamReader sr = new StreamReader(filepath);
        string input = sr.ReadToEnd();
        for (int i = 0; i < input.Length; i++)
        {
            Console.WriteLine(input[i] + " " + i);
            //Searching for a symbol
            if (input[i] != '.' && !char.IsDigit(input[i]) && input[i] != '\n' && input[i] != ' ' && input[i] != '\r')
            {
                finalSum += HasNeighbouringNums(i);
            }

        }

        int HasNeighbouringNums(int index)
        {

            int toReturn = 0;
            //N
            if (index - test > 0 && char.IsDigit(input[index - test]))
            {
                toReturn += NumToAdd(index - test);
            }
            //NE
            if (index - test + 1 > 0 && char.IsDigit(input[index - test + 1]))
            {
                toReturn += NumToAdd(index - test + 1);
            }
            //E
            if (index + 1 < input.Length && char.IsDigit(input[index + 1]))
            {
                toReturn += NumToAdd(index + 1);
            }
            //SE
            if (index + test + 1 < input.Length && char.IsDigit(input[index + test + 1]))
            {
                toReturn += NumToAdd(index + test + 1);
            }
            //S
            if (index + test < input.Length && char.IsDigit(input[index + test]))
            {
                toReturn += NumToAdd(index + test);
            }
            //SW
            if (index + test - 1 < input.Length && char.IsDigit(input[index + test - 1]))
            {
                toReturn += NumToAdd(index + test - 1);
            }
            //W
            if (index - 1 > 0 && char.IsDigit(input[index - 1]))
            {
                toReturn += NumToAdd(index - 1);
            }
            //NW
            if (index - test - 1 > 0 && char.IsDigit(input[index - test - 1]))
            {
                toReturn += NumToAdd(index - test - 1);
            }

            return toReturn;
        }

        int NumToAdd(int index)
        {
            int length = 1;
            int depth = 1;
            int startIndex = index;

            while (index - depth > 0 && char.IsDigit(input[index - depth]))
            {
                startIndex--;
                depth++;
                length++;
            }
            depth = 1;
            while (index + depth < input.Length && char.IsDigit(input[index + depth]))
            {
                length++;
                depth++;
            }

            return int.Parse(input.Substring(startIndex, length));
        }

        Console.WriteLine(finalSum);
    }
    
}
using System.Text.RegularExpressions;

StreamReader sr = new StreamReader("../../../input.txt");

string input = $"do(){sr.ReadToEnd()}";

string operationsPattern = @"do\(\)|don't\(\)";
string multiplicationsPattern = @"mul\((\d+),(\d+)\)";

MatchCollection multiplicationMatches = Regex.Matches(input, multiplicationsPattern);
MatchCollection operationMatches = Regex.Matches(input, operationsPattern);

List<(int index, int value)> multiplicationResults = GetMultiplicationResults(multiplicationMatches);

int partOneResult = 0;
multiplicationResults.ForEach(result => partOneResult += result.value);

int partTwoResult = GetFilteredSum(operationMatches, multiplicationResults);

Console.WriteLine(partOneResult);
Console.WriteLine(partTwoResult);

static List<(int, int)> GetMultiplicationResults(MatchCollection multiplicationMatches)
{
    List<(int, int)> result = [];

    foreach (Match match in multiplicationMatches)
    {
        int num1 = int.Parse(match.Groups[1].Value);
        int num2 = int.Parse(match.Groups[2].Value);

        result.Add((match.Index, num1 * num2));
    }

    return result;
}

static int GetFilteredSum(MatchCollection operationMatches, List<(int matchIndex, int value)> multiplicationResults)
{
    int result = 0;

    string addOperation = "do()";
    string skipOperation = "don't()";

    int mpIndex = 0;
    for(int i = 0; i < operationMatches.Count; i++)
    {
        string operation = operationMatches[i].Value;
        int operationIndex = operationMatches[i].Index;

        bool adding = false;

        if (operation == addOperation)
            adding = true;

        for(int j = mpIndex; j < multiplicationResults.Count; j++)
        {
            (int index, int value) current = multiplicationResults[j];

            if(i+1 < operationMatches.Count && current.index > operationMatches[i + 1].Index)
            {
                mpIndex = j;
                break;
            }

            if (adding)
                result += current.value;
        }
    }

    return result;
}
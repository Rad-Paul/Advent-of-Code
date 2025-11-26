
TextReader reader = new StreamReader("../../../input.txt");

string input = reader.ReadToEnd();

(int[] leftIds, int[] rightIds) = GetIdLists(input);

int partOneResult = GetTotalDistance(leftIds, rightIds);
int partTwoResult = GetSimilarityScore(leftIds, rightIds);

Console.WriteLine(partOneResult);
Console.WriteLine(partTwoResult);

int GetTotalDistance(int[] leftIds, int[] rightIds)
{
    int totalDistance = 0;
    for (int i = 0; i < leftIds.Length; i++)
    {
        totalDistance += Math.Abs(leftIds[i] - rightIds[i]);
    }

    return totalDistance;
}

int GetSimilarityScore(int[] leftIds, int[] rightIds)
{
    int similarityScore = 0;

    Dictionary<int, int> idAppearances = new Dictionary<int, int>();

    for(int i = 0; i < rightIds.Length; i++)
    {
        if (idAppearances.ContainsKey(rightIds[i]))
            idAppearances[rightIds[i]]++;
        else
            idAppearances.Add(rightIds[i], 1);
    }

    foreach (int id in leftIds)
        similarityScore += id * (idAppearances.TryGetValue(id, out int value) ? value : 0);

    return similarityScore;
}

(int[] leftIds, int[] rightIds) GetIdLists(string input)
{
    string[] lines = input.Split("\r\n");

    int[] leftIds = new int[lines.Length];
    int[] rightIds = new int[lines.Length];

    for(int i = 0; i < lines.Length; i++)
    {
        string[] idPair = lines[i].Split("   ");
        leftIds[i] = int.Parse(idPair[0]);
        rightIds[i] = int.Parse(idPair[1]);
    }

    Array.Sort(leftIds);
    Array.Sort(rightIds);

    return (leftIds, rightIds);
}
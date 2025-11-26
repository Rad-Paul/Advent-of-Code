
TextReader reader = new StreamReader("../../../input.txt");

string input = reader.ReadToEnd();

List<List<int>> reports = GetReportsAndLevels(input);

int partOneResult = GetCountOfValidReports(reports);
int partTwoResult = GetCountOfValidReportsWithToleration(reports);

Console.WriteLine(partOneResult);
Console.WriteLine(partTwoResult);

static int GetCountOfValidReports(List<List<int>> reports)
{
    int count = 0;

    foreach (List<int> report in reports)
    {

        if(ReportIsSafe(report))
            count++;
    }

    return count;
}

static int GetCountOfValidReportsWithToleration(List<List<int>> reports)
{
    int count = 0;

    foreach (List<int> report in reports)
    {

        if (ReportIsSafe(report))
            count++;
        else
        {
            for (int i = 0; i < report.Count; i++)
            {
                int value = report[i];
                report.RemoveAt(i);
                if (ReportIsSafe(report))
                {
                    count++;
                    break;
                }

                report.Insert(i, value);
            }
        }
    }

    return count;
}

static bool ReportIsSafe(List<int> report)
{
    bool valid = true;
    bool ascending = false;
    bool descending = false;

    for (int i = 1; i < report.Count && valid; i++)
    {
        int levelDiff = report[i] - report[i - 1];

        if (Math.Abs(levelDiff) > 3 || levelDiff == 0)
        {
            valid = false;
        }
            

        if (report[i] > report[i - 1])
        {
            if (descending)
            {
                valid = false;
            }

            ascending = true;
        }
        else
        {
            if (ascending)
            {
                valid = false;
            }

            descending = true;
        }
    }

    return valid;
}

static List<List<int>> GetReportsAndLevels(string input)
{
    List<List<int>> reports = [];

    string[] lines = input.Split("\r\n");

    foreach (string line in lines)
    {
        string[] levels = line.Split(' ');
        reports.Add(levels.Select(level => int.Parse(level)).ToList());
    }

    return reports;
}
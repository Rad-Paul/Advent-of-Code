namespace Day_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../../input.txt");

            string input = sr.ReadToEnd();
            string[] orderingRulesAndPages = input.Split($"{Environment.NewLine}{Environment.NewLine}");
            string[] orderingRulesInput = orderingRulesAndPages[0].Split(Environment.NewLine);

            List<List<int>> pages = orderingRulesAndPages[1].Split(Environment.NewLine)
                .Select(pageList => pageList.Split(',')
                .Select(page => int.Parse(page)).ToList())
                .ToList();

            Dictionary<int, List<int>> orderingRules = new Dictionary<int, List<int>>();

            for(int i = 0; i < orderingRulesInput.Length; i++)
            {
                string[] rules = orderingRulesInput[i].Split('|');

                int leftPage = int.Parse(rules[0]);
                int rightPage = int.Parse(rules[1]);

                if (orderingRules.ContainsKey(leftPage))
                    orderingRules[leftPage].Add(rightPage);
                else
                    orderingRules[leftPage] = new List<int>();

            }

            PartOne(pages, orderingRules);

        }

        static void PartOne(List<List<int>> pageLists, Dictionary<int, List<int>> orderingRules)
        {
            for(int i = 0; i < pageLists.Count(); i++)
            {
                List<int> list = pageLists[i];
            }
        }
    }
}

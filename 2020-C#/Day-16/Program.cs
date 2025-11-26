using System.ComponentModel;

namespace Day_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = "D:\\coding\\Personal\\AdventOfCode\\2020\\Day-16\\input.txt";
            StreamReader sr = new StreamReader(filepath);
            string[] input = sr.ReadToEnd().Split("\r\n\r\n");
            
            List<Field> fieldsAndRanges = GetFieldsFromInput(input[0]);
            List<int[]> ownTicket = GetTicketValuesFromInput(input[1]);
            List<int[]> otherTickets = GetTicketValuesFromInput(input[2]);

            //for part 2
            List<int[]> validTickets = Part1(fieldsAndRanges, otherTickets);
            validTickets.Add(ownTicket[0]);

            Part2(fieldsAndRanges, validTickets, ownTicket);
        }

        public static List<int[]> Part1(List<Field> fieldsAndRanges, List<int[]> otherTickets)
        {
            int errorScore = 0;
            List<int[]> validTickets = new List<int[]>();
            foreach (int[] values in otherTickets)
            {
                bool valid = true;
                foreach(int value in values)
                {
                    if(isInvalidValue(value, fieldsAndRanges) != -1)
                    {
                        errorScore += value;
                        valid = false;
                    }
                }
                if (valid)
                {
                    validTickets.Add(values);
                }
            }

            Console.WriteLine(errorScore);
            return validTickets;
        }
        public static void Part2(List<Field> fieldsAndRanges, List<int[]> validTickets, List<int[]> ownTicket)
        {
            List<int>[] columnChoices = new List<int>[fieldsAndRanges.Count];
            for(int i = 0; i < columnChoices.Length; i++)
            {
                columnChoices[i] = new List<int>();
            }

            for (int i = 0; i < fieldsAndRanges.Count; i++)
            {
                int col = i;
                int[] validTicketsPerField = new int[fieldsAndRanges.Count];
                for(int j = 0; j < validTickets.Count; j++)
                {
                    int value = validTickets[j][col];
                    FindColumnRanges(value, fieldsAndRanges, validTicketsPerField, columnChoices, validTickets.Count, col);
                }
            }

            string[] translatedFields = FindColumnFields(fieldsAndRanges, columnChoices);
            Console.WriteLine(GetPart2Answer(translatedFields, ownTicket));

            
            int FindColumnRanges(int value, List<Field> fieldsAndRanges, int[] validTicketsPerField, List<int>[] columnChoices, int count, int colInd)
            {
                for(int i = 0; i < fieldsAndRanges.Count; i++)
                {
                    int[] ranges = fieldsAndRanges[i].Ranges;
                    bool within = false;

                    if (value >= ranges[0] && value <= ranges[1]) { within = true; }
                    else if (value >= ranges[2] && value <= ranges[3]) { within = true; }

                    if (within)
                    {
                        validTicketsPerField[i]++;
                        if (validTicketsPerField[i] == count)
                        {
                            columnChoices[colInd].Add(i);
                        }
                    }
                }

                return value;
            }
            string[] FindColumnFields(List<Field> fieldsAndRanges, List<int>[] columnChoices)
            {
                string[] translatedFields = new string[columnChoices.Length];

                for(int i = 0; i < translatedFields.Length; i++)
                {
                    for(int j = 0; j < columnChoices.Length; j++)
                    {
                        List<int> list = columnChoices[j];
                        if(list.Count == 1)
                        {
                            int fieldInd = list[0];
                            translatedFields[j] = fieldsAndRanges[fieldInd].Type;
                            foreach(List<int> l in columnChoices)
                            {
                                l.Remove(fieldInd);
                            }
                        }
                    }
                }

                return translatedFields;
            }
            long GetPart2Answer(string[] translatedFields, List<int[]> ownTicket)
            {
                //multiply all of the values in our ticket which are under the fields that start with departure
                long answer = 1;
                for(int i = 0; i < translatedFields.Length; i++)
                {
                    if(translatedFields[i].Split(' ')[0] == "departure")
                    {
                        answer *= ownTicket[0][i];
                    }
                }
                return answer;
            }
        }
        public static int isInvalidValue(int value, List<Field> fieldsAndRanges)
        {
            foreach (Field field in fieldsAndRanges)
            {
                int[] ranges = field.Ranges;
                bool within = false;

                if (value >= ranges[0] && value <= ranges[1]) { within = true; }
                else if (value >= ranges[2] && value <= ranges[3]) { within = true; }



                if (within)
                {
                    return -1;
                }
            }

            return value;
        }
        public static List<int[]> GetTicketValuesFromInput(string inputTickets)
        {
            List<int[]> AllTicketValues = new List<int[]>();
            string[] lines = inputTickets.Split("\r\n");
            for(int i = 1; i < lines.Length; i++)
            {
                int[] ticketValues = ToIntArray(lines[i].Split(','));
                AllTicketValues.Add(ticketValues);
            }

            return AllTicketValues;

            int[] ToIntArray(string[] array)
            {
                int[] toR = new int[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    toR[i] = Convert.ToInt32(array[i]);
                }
                return toR;
            }
        }
        public static List<Field> GetFieldsFromInput(string input)
        {
            List<Field> fields = new List<Field>();
            string[] lines = input.Split("\r\n");
            foreach (string line in lines)
            {
                string[] fieldTypeAndRanges = line.Split(": ");
                string newFieldType = fieldTypeAndRanges[0];
                int[] newFieldRanges = ExtractRangesFromField(fieldTypeAndRanges[1].Split(" or "));
                fields.Add(new Field(newFieldType, newFieldRanges));
            }

            return fields;

            int[] ExtractRangesFromField(string[] inputRanges)
            {
                string[] rangeOne = inputRanges[0].Split('-');
                string[] rangeTwo = inputRanges[1].Split("-");
                return  [int.Parse(rangeOne[0]), int.Parse(rangeOne[1]), int.Parse(rangeTwo[0]), int.Parse(rangeTwo[1])];
            }
        }
        public class Field(string type, int[] ranges)
        {
            public string Type = type;
            public int[] Ranges = ranges;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Interfaces
{
    public class CalculateNumberService : ICalculateNumberService
    {
        public int Add(string numbers)
        {
            var isDelimiter = false;
            var delimeters = new List<string> { ",", "\n" };

            if (string.IsNullOrEmpty(numbers))
                return 0;

           var matches = Regex.Matches(numbers, @"\[([^]]*)\]").Cast<Match>().Select(x => x.Groups[1].Value).ToList();

            if (numbers.Contains('\n') && matches.Count == 0)
                isDelimiter = !char.IsDigit(Convert.ToChar(numbers.Split('\n')[0]));

            if (matches.Count > 0)
                delimeters.AddRange(matches);
            else if (isDelimiter)
                delimeters.Add(numbers.Split('\n')[0]);

            var values = Regex.Replace(numbers, @"\[[^]]*\]", "").Split(delimeters.Select(s => s).ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(int.Parse);

            values.RemoveAll(c => c > 1000);

            return values.Sum();
        }
    }
}

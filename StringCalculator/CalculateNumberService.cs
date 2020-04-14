using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class CalculateNumberService
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var delimiters = new List<string>() { ",", "\n", "[", "]"};

            var matches = Regex.Matches(numbers, @"\[([^]]*)\]").Cast<Match>().Select(x => x.Groups[1].Value).ToList();

            if(matches.Count > 0)
                delimiters.AddRange(matches);
            else if (!char.IsDigit(numbers[0]) && numbers[0] != '-')
                delimiters.Add(numbers[0].ToString());

            var sumOfNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(int.Parse);

            if (sumOfNumbers.Any(num => num < 0))
                throw new Exception($"Negatives are not allow: {string.Join(",", sumOfNumbers.Where(num => num < 0))}");

            sumOfNumbers.RemoveAll(num => num > 1000);

            return sumOfNumbers.Sum();
        }
    }
}

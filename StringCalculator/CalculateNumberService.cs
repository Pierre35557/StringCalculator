using System;
using System.Collections;
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

            var delimeters = new List<string>() { ",", "\n" };

            if (!char.IsDigit(numbers[0]) && numbers[0] != '-')
                delimeters.Add(numbers[0].ToString());

            var values = numbers.Split(delimeters.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(int.Parse);

            if (values.Any(number => number < 0))
            {
                throw new Exception($"negatives not allowed: {string.Join(",", values.Where(number => number < 0))}");
            }

            values.RemoveAll(c => c > 1000);

            return values.Sum();
        }
    }
}

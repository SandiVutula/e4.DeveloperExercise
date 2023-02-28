using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e4.ConsoleApp
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            char delimiter = ',';
            if (numbers.StartsWith("//"))
            {
                delimiter = numbers[2];
                numbers = numbers.Substring(4);
            }

            var splitNumbers = numbers.Split(new[] { delimiter, '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToList();

            var negativeNumbers = splitNumbers.Where(x => x < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }

            return splitNumbers.Sum();
        }
    }

}


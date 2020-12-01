using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                InvalidInputMessage();
                return;
            }

            foreach (var arg in args)
            {
                List<int> digits = new List<int>();

                foreach (var digit in arg)
                {
                    int currentDigit;
                    if (int.TryParse(digit.ToString(), out currentDigit))
                    {
                        digits.Add(currentDigit);
                    }
                    else
                    {
                        InvalidInputMessage();
                        return;
                    }
                }

                var answer1 = CalculateCaptchaIndexPlusOne(digits);
                var answer2 = CalculateCaptchaIndexPlusHalf(digits);

                Console.WriteLine($"Input: {arg}");
                Console.WriteLine();

                Console.WriteLine($"Answer 1: {answer1}");
                Console.WriteLine($"Answer 2: {answer2}");
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static int CalculateCaptchaIndexPlusOne(List<int> digits)
        {
            int i = 1;
            int count = 0;
            int sum = 0;

            while (i <= 9)
            {
                for (var j = 0; j < digits.Count; ++j)
                {
                    var comparisonIndex = (j + 1) % digits.Count;
                    if (digits[j] == i && digits[j] == digits[comparisonIndex])
                    {
                        sum += i;
                    }
                }
                ++i;
            }

            return sum;
        }

        private static int CalculateCaptchaIndexPlusHalf(List<int> digits)
        {
            int i = 1;
            int count = 0;
            int sum = 0;

            while (i <= 9)
            {
                for (var j = 0; j < digits.Count; ++j)
                {
                    var comparisonIndex = (j + (digits.Count / 2)) % digits.Count;
                    if (digits[j] == i && digits[j] == digits[comparisonIndex])
                    {
                        sum += i;
                    }
                }
                ++i;
            }

            return sum;
        }

        private static void InvalidInputMessage()
        {
            Console.WriteLine("Invalid input.");
            Console.ReadKey();
        }
    }
}

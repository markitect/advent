using System;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                InvalidInputMessage();
                return;
            }

            foreach (var arg in args)
            {
                int inputNum;

                var numMove = 0;
                
                if(!int.TryParse(arg, out inputNum))
                {
                    InvalidInputMessage();
                    return;
                }

                int ringNumber = 0;
                int rootNumber = 1;

                while((rootNumber * rootNumber) < inputNum)
                {
                    ringNumber++;
                    rootNumber += 2;
                }

                Console.WriteLine($"Ring number: {ringNumber}");
            }
        }

        private static void InvalidInputMessage()
        {
            Console.WriteLine("Invalid input.");
            Console.ReadKey();
        }
    }
}

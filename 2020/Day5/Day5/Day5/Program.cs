using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var seats = File.ReadLines("input.txt");

            var numSeats = seats.Count();
            var maxId = -1;
            
            var seatIds = new List<int>();

            foreach (var seat in seats)
            {
                var row = Calculate(seat.Substring(0, 7), 0, 127, 'F');
                var col = Calculate(seat.Substring(7), 0, 7, 'L');
                var id = row * 8 + col;
                seatIds.Add(id);
            }
            
            seatIds.Sort();

            int missingId = 0;
            
            for (var i = 0; i < seatIds.Count - 1; ++i)
            {
                if (seatIds[i + 1] - seatIds[i] == 2)
                {
                    missingId = seatIds[i] + 1;
                }
            }
            
            Console.WriteLine(missingId);
        }

        static int Calculate(string directions, int min, int max, char lower)
        {
            if (directions.Length == 1)
            {
                return directions[0] == lower ? min : max;
            }
            else
            {
                return directions[0] == lower ? 
                    Calculate(directions.Substring(1), min, min + (max-min) / 2, lower) : 
                    Calculate(directions.Substring(1), min + 1 + ((max-min) / 2), max, lower);
            }
        }
    }
}
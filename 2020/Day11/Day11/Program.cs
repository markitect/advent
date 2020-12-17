using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var seats = File.ReadAllLines("input.txt");

            
            while (changed)
            {
                changed = false;
                seats = SeatPassengers(seats);
            }

            var count = 0;
            foreach (var row in seats)
            {
                foreach (var seat in row)
                {
                    if (seat == SEATED) count++;
                }
            }
            
            Console.WriteLine(count);
        }
        
        const char EMPTY = 'L';
        private const char SEATED = '#';
        private const char FLOOR = '.';
        private static bool changed = true;
        
        static string[] SeatPassengers(string[] seats)
        {
            var result = new List<string>();
            var countChanged = 0;

            for (var y = 0; y < seats.Length; ++y)
            {
                var row = new StringBuilder(seats[y]);
                for (var x = 0; x < seats[y].Length; ++x)
                {
                    if (seats[y][x] == FLOOR)
                    {
                        continue;
                    }
                    var seated = seats[y][x] == SEATED;
                    var adjacentSeated = 0;

                    var offset = 1;

                    while (y-offset >= 0) // TOP
                    {
                        var seat = seats[y - offset][x];
                        if (seat == SEATED)
                        {
                            adjacentSeated++;
                            break;
                        }
                        if (seat == EMPTY)
                        {
                            break;
                        }
                        offset++;
                    }
                    
                    offset = 1;

                    while (y + offset < seats.Length) // BOTTOM
                    {
                        var seat = seats[y + offset][x];
                        if (seat == SEATED)
                        {
                            adjacentSeated++;
                            break;
                        }
                        if (seat == EMPTY)
                        {
                            break;
                        }
                        offset++;
                    }

                    offset = 1;
                    
                    while (y-offset >= 0 && x + offset < seats[y].Length ) // TOP RIGHT
                    {
                        var seat = seats[y - offset][x + offset];
                        if (seat == SEATED)
                        {
                            adjacentSeated++;
                            break;
                        }

                        if (seat == EMPTY)
                        {
                            break;
                        }

                        offset++;
                    }

                    offset = 1;
                    
                    while (y + offset < seats.Length && x - offset >= 0) // BOTTOM LEFT
                    {
                        var seat = seats[y + offset][x - offset];
                        if (seat == SEATED)
                        {
                            adjacentSeated++;
                            break;
                        }

                        if (seat == EMPTY)
                        {
                            break;
                        }

                        offset++;
                    }
                    
                    offset = 1;
                    
                    while (x - offset >= 0) // LEFT
                    {
                        var seat = seats[y][x - offset];
                        if (seat == SEATED)
                        {
                            adjacentSeated++;
                            break;
                        }

                        if (seat == EMPTY)
                        {
                            break;
                        }

                        offset++;
                    }

                    offset = 1;
                    
                    while (x + offset < seats[y].Length) // RIGHT
                    {
                        var seat = seats[y][x + offset];
                        if (seat == SEATED)
                        {
                            adjacentSeated++;
                            break;
                        }

                        if (seat == EMPTY)
                        {
                            break;
                        }

                        offset++;
                    }
                    
                    offset = 1;
                    
                    while (y - offset >= 0 && x - offset >= 0) // TOP LEFT
                    {
                        var seat = seats[y - offset][x - offset];
                        if (seat == SEATED)
                        {
                            adjacentSeated++;
                            break;
                        }

                        if (seat == EMPTY)
                        {
                            break;
                        }

                        offset++;
                    }
                    
                    offset = 1;
                    
                    while (y + offset < seats.Length && x + offset < seats[y].Length) // BOTTOM RIGHT
                    {
                        var seat = seats[y + offset][x + offset];
                        if (seats[y+offset][x + offset] == SEATED)
                        {
                            adjacentSeated++;
                            break;
                        }

                        if (seat == EMPTY)
                        {
                            break;
                        }
                        
                        offset++;
                    }

                    //if (y > 0 && seats[y - 1][x] == SEATED) adjacentSeated++; // #1 y - 1, x TOP
                    //if (y < seats.Length - 1 && seats[y+1][x] == SEATED) adjacentSeated++; // #3 y + 1, x BOTTOM
                    //if (x > 0 && seats[y][x - 1] == SEATED) adjacentSeated++; // #8 y, x - 1 LEFT
                    //if (x < seats[y].Length - 1 && seats[y][x+1] == SEATED) adjacentSeated++; // #5 y, x + 1 RIGHT
                    //if (x > 0 && y > 0 && seats[y - 1][x - 1] == SEATED) adjacentSeated++; // #2 y - 1, x - 1 TOP LEFT
                    //if (y > 0 && x < seats[y].Length - 1 &&  seats[y - 1][x + 1] == SEATED) adjacentSeated++; // #6 y - 1, x + 1 TOP RIGHT
                    //if (y < seats.Length - 1  && x > 0 &&  seats[y + 1][x - 1] == SEATED) adjacentSeated++; // #7 y + 1, x - 1 BOTTOM LEFT
                    //if (y < seats.Length - 1 && x < seats[y].Length - 1 && seats[y+1][x+1] == SEATED) adjacentSeated++; // #4 y + 1, x + 1 BOTTOM RIGHT

                    if (seated && adjacentSeated >= 5)
                    {
                        row[x] = EMPTY;
                        changed = true;
                        countChanged++;
                    }
                    else if (!seated && adjacentSeated == 0)
                    {
                        row[x] = SEATED;
                        changed = true;
                        countChanged++;
                    }
                }

                result.Add(row.ToString());
            }
            Console.WriteLine(countChanged);

            Console.WriteLine();
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
            
            Console.WriteLine();

            //Console.ReadKey();
            
            return result.ToArray();
        }

    }
}
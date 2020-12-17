using System;
using System.IO;
using System.Net;

namespace Day12
{
    class Program
    {
        private enum Direction
        {
            East = 0,
            South = 1,
            West = 2,
            North = 3
        }

        static void Main(string[] args)
        {
            var movements = File.ReadAllLines("input.txt");

            var eastDistance = 0L;
            var northDistance = 0L;

            var waypointEast = 10L;
            var waypointNorth = 1L;

            foreach (var movement in movements)
            {
                var direction = movement.Substring(0, 1);
                var distance = int.Parse(movement.Substring(1));

                switch (direction)
                {
                    case "N":
                    {
                        waypointNorth += distance;
                        break;
                    }
                    case "S":
                    {
                        waypointNorth -= distance;
                        break;
                    }
                    case "E":
                    {
                        waypointEast += distance;
                        break;
                    }
                    case "W":
                    {
                        waypointEast -= distance;
                        break;
                    }
                    case "F":
                    {
                        eastDistance += waypointEast * distance;
                        northDistance += waypointNorth * distance;
                        // switch (currentDirection)
                        // {
                        //     case Direction.East:
                        //     {
                        //         eastDistance += distance;
                        //         break;
                        //     }
                        //     case Direction.South:
                        //     {
                        //         northDistance -= distance;
                        //         break;
                        //     }
                        //     case Direction.West:
                        //     {
                        //         eastDistance -= distance;
                        //         break;
                        //     }
                        //     case Direction.North:
                        //     {
                        //         northDistance += distance;
                        //         break;
                        //     }
                        // }

                        break;
                    }
                    case "R":
                    {
                        var turns = distance / 90;

                        var newNorth = 0L;
                        var newEast = 0L;
                        for (var i = 0; i < turns; ++i)
                        {
                            if (waypointNorth > 0)
                            {
                                newEast = waypointNorth;
                            }
                            else
                            {
                                newEast = -waypointNorth;
                            }

                            if (waypointEast > 0)
                            {
                                newNorth = -waypointEast;
                            }
                            else
                            {
                                newNorth = waypointEast;
                            }
                        }

                        waypointNorth = newNorth;
                        waypointEast = newEast;

                        break;
                    }
                    case "L":
                    {
                        var turns = distance / 90;

                        var newEast = 0L;
                        var newNorth = 0L;
                        for (var i = 0; i < turns; ++i)
                        {
                            if (waypointNorth > 0) 
                            {
                                newEast = -waypointNorth;
                            }
                            else
                            {
                                newEast = waypointNorth;
                            }

                            if (waypointEast > 0)
                            {
                                newNorth = waypointEast;
                            }
                            else
                            {
                                newNorth = -waypointEast;
                            }

                        }
                        
                        waypointNorth = newNorth;
                        waypointEast = newEast;
                        break;
                    }
                }
            }
            
            Console.WriteLine(Math.Abs(eastDistance) + Math.Abs(northDistance));
        }
    }
}
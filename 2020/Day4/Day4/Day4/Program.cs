using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var validCount = 0;
            var processedCount = 0;
            var lineCount = 0;
            var fieldCount = 0;
            var hasCID = false;

            Dictionary<string, string> fieldChecks = new Dictionary<string, string>
            {
                {"byr", string.Empty},
                {"cid", string.Empty},
                {"iyr", string.Empty},
                {"hgt", string.Empty},
                {"eyr", string.Empty},
                {"pid", string.Empty},
                {"hcl", string.Empty},
                {"ecl", string.Empty}
            };



            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    processedCount++;
                }
            }
            
            Console.WriteLine(processedCount);

            foreach (var inputLine in input)
            {
                ++lineCount;
                if (inputLine.Length > 0 || lineCount == input.Length-2)
                {
                    var fields = inputLine.Split(' ');
                    foreach (var field in fields)
                    {
                        var fieldNameValue = field.Split(':');
                        fieldChecks[fieldNameValue[0]] = fieldNameValue[1];
                    }
                }
                else
                {
                    bool valid = true;
                    foreach (var field in fieldChecks)
                    {
                        if (field.Value == string.Empty && field.Key != "cid")
                        {
                            valid = false;
                            break;
                        }
                        else
                        {
                            if (field.Key == "byr")
                            {
                                if (!ValidateYear(field.Value, 1920, 2002))
                                {
                                    valid = false;
                                    break;
                                }
                            }
                            else if (field.Key == "iyr")
                            {
                                if (!ValidateYear(field.Value, 2010, 2020))
                                {
                                    valid = false;
                                    break;
                                }
                            } 
                            else if (field.Key == "eyr")
                            {
                                if (!ValidateYear(field.Value, 2020, 2030))      
                                {
                                    valid = false;
                                    break;
                                }
                            }
                            else if (field.Key == "hgt")
                            {
                                var units = field.Value.Substring(field.Value.Length - 2);
                                if (units != "cm" && units != "in")
                                {
                                    valid = false;
                                    break;
                                }
                                var height = int.Parse( field.Value.Substring(0, field.Value.Length - 2));
                                if (units == "cm")
                                {
                                    if (!ValidateHeight(height, 150, 193))
                                    {
                                        valid = false;
                                        break;
                                    }
                                } 
                                else if (units == "in")
                                {
                                    if (!ValidateHeight(height, 59, 76))
                                    {
                                        valid = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    valid = false;
                                    break;
                                }
                            }
                            else if (field.Key == "hcl")
                            {
                                if (!ValidateHairColor(field.Value))
                                {
                                    valid = false;
                                    break;
                                }
                            }
                            else if (field.Key == "ecl")
                            {
                                if (!ValidateEyeColor(field.Value))
                                {
                                    valid = false;
                                    break;
                                }
                            }
                            else if (field.Key == "pid")
                            {
                                if (!ValidatePid(field.Value))
                                {
                                    valid = false;
                                    break;
                                }
                            }
                        }
                    }

                    if (valid)
                    {
                        ++validCount;
                    }

                    fieldChecks = fieldChecks.ToDictionary(p => p.Key, p => string.Empty);
                }
            }

            Console.WriteLine("Count: " + validCount + " out of " + processedCount);
            Console.ReadKey();
        }

        static bool ValidateYear(string year, int min, int max)
        {
            if (year.Length == 4)
            {
                var yearNum = int.Parse(year);

                if (yearNum >= min && yearNum <= max)
                {
                    return true;
                }
            }

            return false;
        }

        static bool ValidateHeight(int height, int min, int max)
        {

            return height >= min && height <= max;

        }

        static bool ValidateEyeColor(string color)
        {
            var validColors = new string[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};

            return color.Length == 3 && validColors.Contains(color);
        }

        static bool ValidateHairColor(string color)
        {
            return Regex.IsMatch(color, "[#]{1}([0-9]|[a-f]){6}");
        }

        static bool ValidatePid(string pid)
        {
            return Regex.IsMatch(pid, "[0-9]{9}");
        }
    }
}

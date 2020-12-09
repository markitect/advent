using System;
using System.Collections.Generic;
using System.IO;

namespace Day8
{
    class Program
    {
        static string[] input;
        static void Main(string[] args)
        {

            input = File.ReadAllLines("input.txt");

            var accumulator = 0;
            var startInstruction = input.Length - 1;
            List<int> changedInstructions = new List<int>();

            if (ExecuteProgram(0, out accumulator))
            {
                Console.WriteLine(accumulator);
            }

            var programFinished = false;
            
            do
            {
                programFinished = ExecuteProgram(startInstruction, out accumulator);

                if (programFinished)
                {
                    startInstruction--;
                }
                else
                {
                    var changeInstruction = startInstruction;
                    var instruction = input[changeInstruction].Substring(0, 3);
                    
                    if (!changedInstructions.Contains(changeInstruction))
                    {
                        if (instruction == "jmp")
                        {
                            input[changeInstruction] = input[changeInstruction].Replace("jmp", "nop");
                        }
                        else
                        {
                            input[changeInstruction] = input[changeInstruction].Replace("nop", "jmp");
                        }
                        
                        changedInstructions.Add(changeInstruction);
                    }

                    accumulator = 0;
                    programFinished = ExecuteProgram(0, out accumulator);

                    if (!programFinished)
                    {
                        instruction = input[changeInstruction].Substring(0, 3);
                        if (instruction == "jmp")
                        {
                            input[changeInstruction] = input[changeInstruction].Replace("jmp", "nop");
                        }
                        else
                        {
                            input[changeInstruction] = input[changeInstruction].Replace("nop", "jmp");
                        }

                        startInstruction--;
                        programFinished = true;
                    
                    }
                    else
                    {
                        break;
                    }

                }

            } while (programFinished);


            Console.WriteLine(accumulator);
        }

        static bool ExecuteProgram(int startInstruction, out int accumulator)
        {
            HashSet<int> executedInstructions = new HashSet<int>();
            var instructionToExecute = startInstruction;
            accumulator = 0;
            bool programEnds = true;

            string instruction;
            int number;
            
            while (!executedInstructions.Contains(instructionToExecute))
            {
                if (instructionToExecute >= input.Length)
                {
                    return true;
                }
                
                executedInstructions.Add(instructionToExecute);
                instruction = input[instructionToExecute].Substring(0, 3);
                number = int.Parse(input[instructionToExecute].Substring(4));

                switch (instruction)
                {
                    case "acc":
                    {
                        accumulator += number;
                        instructionToExecute++;
                        break;
                    }
                    case "jmp":
                    {
                        instructionToExecute += number;
                        break;
                    }
                    default:
                    {
                        instructionToExecute++;
                        break;
                    }
                }
            }

            return false;
        }
    }
}
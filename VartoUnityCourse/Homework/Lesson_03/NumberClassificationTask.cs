using Spectre.Console.Cli;
using System;
using static VartoUnityCourse.Business.MenuHelper;

namespace VartoUnityCourse.Homework.Lesson_03
{
    public class NumberClassificationTask : Command
    {
        public override int Execute(CommandContext context)
        {
            Console.WriteLine("Welcome to the Number Classification Task! Designed to classify your number as positive or negative.\r\n");

            Console.Write("Please enter your number: ");
            var inputNumberString = Console.ReadLine();

            if (!decimal.TryParse(inputNumberString, out decimal inputNumber))
            {
                Console.WriteLine("\r\nInvalid input. Please enter a valid number.");
                return ToTheMenu();
            }

            switch (inputNumber)
            {
                case > 0:
                    Console.WriteLine($"The number {inputNumber} is positive.");
                    break;

                case < 0:
                    Console.WriteLine($"The number {inputNumber} is negative.");
                    break;

                default:
                    Console.WriteLine($"The number {inputNumber} is zero.");
                    break;
            }

            return ToTheMenu();
        }
    }
}

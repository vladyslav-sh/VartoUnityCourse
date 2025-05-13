using Spectre.Console.Cli;
using System;
using static VartoUnityCourse.Business.MenuHelper;

namespace VartoUnityCourse.Homework.Lesson_03
{
    public class NumberRangeCheckTask : Command
    {
        public override int Execute(CommandContext context)
        {
            Console.WriteLine("Welcome to the Number Range Task! Designed to check if your number is in range.\r\n");

            Console.Write("Please enter your number: ");
            var inputNumberString = Console.ReadLine();

            if (decimal.TryParse(inputNumberString, out decimal inputNumber))
            {
                CheckNumberInRange(inputNumber, min: 10, max: 20);
                CheckNumberInRange(inputNumber, min: 30, max: 40);
            }

            return ToTheMenu();
        }

        private static void CheckNumberInRange(decimal number, int min, int max)
        {
            var isInRange = number >= min && number <= max;
            if (isInRange)
            {
                Console.WriteLine($"The number {number} is in the range of {min} and {max}.");
                return;
            }

            Console.WriteLine($"The number {number} is NOT in the range of {min} and {max}.");
        }
    }
}

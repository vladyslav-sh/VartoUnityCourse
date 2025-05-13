using Spectre.Console.Cli;
using System;

namespace VartoUnityCourse.Homework.Lesson_02
{
    public class NumberSumTask : Command
    {
        public override int Execute(CommandContext context)
        {
            Console.WriteLine("Welcome to the Number Sum Task! Designed to calculate a sum of two given numbers.\r\n");

            Console.Write("Please enter first number: ");
            var firstNumberInputString = Console.ReadLine();

            Console.Write("Please enter second number: ");
            var secondNumberInputString = Console.ReadLine();

            var firstNumber = int.Parse(firstNumberInputString ?? string.Empty);
            var secondNumber = int.Parse(secondNumberInputString ?? string.Empty);

            var resultSum = firstNumber + secondNumber;

            Console.WriteLine($"\r\nThe sum of {firstNumberInputString} and {secondNumberInputString} is {resultSum}.");


            Console.WriteLine("\r\nPress any key to return to the menu...");
            Console.ReadKey();
            return 0;
        }
    }
}

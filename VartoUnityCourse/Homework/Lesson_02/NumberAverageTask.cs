using Spectre.Console.Cli;
using System;

namespace VartoUnityCourse.Homework.Lesson_02
{
    public class NumberAverageTask : Command
    {
        public override int Execute(CommandContext context)
        {
            Console.WriteLine("Welcome to the Number Average Task! Designed to calculate an average of tree given numbers.\r\n");

            Console.Write("Please enter first number: ");
            var firstNumberInputString = Console.ReadLine();

            Console.Write("Please enter second number: ");
            var secondNumberInputString = Console.ReadLine();

            Console.Write("Please enter trird number: ");
            var thirdNumberInputString = Console.ReadLine();

            var firstNumber = int.Parse(firstNumberInputString ?? string.Empty);
            var secondNumber = int.Parse(secondNumberInputString ?? string.Empty);
            var thirdNumber = int.Parse(thirdNumberInputString ?? string.Empty);

            var resultAverage = (firstNumber + secondNumber + thirdNumber) / 3;

            Console.WriteLine($"\r\nThe average of {firstNumber}, {secondNumber} and {thirdNumber} is {resultAverage}.");


            Console.WriteLine("\r\nPress any key to return to the menu...");
            Console.ReadKey();
            return 0;
        }
    }
}

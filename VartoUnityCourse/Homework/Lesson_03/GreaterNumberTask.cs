using Spectre.Console.Cli;
using System;
using static VartoUnityCourse.Business.MenuHelper;

namespace VartoUnityCourse.Homework.Lesson_03
{
    public class GreaterNumberTask : Command
    {
        public override int Execute(CommandContext context)
        {
            Console.WriteLine("Welcome to the Greater Number Task! Designed to return a greater number.\r\n");

            Console.Write("Please enter your first number: ");
            var firstInputNumberString = Console.ReadLine();

            Console.Write("Please enter your second number: ");
            var secondInputNumberString = Console.ReadLine();


            if (!decimal.TryParse(firstInputNumberString, out decimal firstInputNumber) || 
                !decimal.TryParse(secondInputNumberString, out decimal secondInputNumber))
            {
                Console.WriteLine("\r\nInvalid input. Please enter a valid number.");
                return ToTheMenu();
            }

            var greaterNumber = firstInputNumber > secondInputNumber ? firstInputNumber : secondInputNumber;

            Console.WriteLine($"The greater number between {firstInputNumber} and {secondInputNumber} is {greaterNumber}.");

            return ToTheMenu();
        }
    }
}

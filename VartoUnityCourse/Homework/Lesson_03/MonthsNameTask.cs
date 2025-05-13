using Spectre.Console.Cli;
using System;
using VartoUnityCourse.Homework.Lesson_03.Enums;
using static VartoUnityCourse.Business.MenuHelper;

namespace VartoUnityCourse.Homework.Lesson_03
{
    partial class MonthsNameTask : Command
    {
        public override int Execute(CommandContext context)
        {
            Console.WriteLine("Welcome to the Months Number Task! Designed to return a month name by it's number.\r\n");

            Console.Write("Please enter month's number: ");
            var monthNumberInputString = Console.ReadLine();


            if (!int.TryParse(monthNumberInputString, out int monthNumber) || !Enum.IsDefined(typeof(MonthsEnum), monthNumber - 1))
            {
                Console.WriteLine("\r\nInvalid input. Please enter a valid month number.");
                return ToTheMenu();
            }

            var monthName = Enum.GetValues<MonthsEnum>()[monthNumber - 1].ToString();

            Console.WriteLine($"The name of {monthNumber} month is {monthName}.");

            return ToTheMenu();
        }
    }
}

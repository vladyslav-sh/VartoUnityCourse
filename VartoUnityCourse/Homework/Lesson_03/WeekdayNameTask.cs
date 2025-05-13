using Spectre.Console.Cli;
using System;
using VartoUnityCourse.Homework.Lesson_03.Enums;
using static VartoUnityCourse.Business.MenuHelper;

namespace VartoUnityCourse.Homework.Lesson_03
{
    partial class WeekdayNameTask : Command
    {
        public override int Execute(CommandContext context)
        {
            Console.WriteLine("Welcome to the Weekday Name Task! Designed to return a day name by it's number.\r\n");

            Console.Write("Please enter day number: ");
            var dayNumberInputString = Console.ReadLine();


            if (!byte.TryParse(dayNumberInputString, out byte dayNumber) || !Enum.IsDefined(typeof(WeekdayEnum), dayNumber))
            {
                Console.WriteLine("\r\nInvalid input. Please enter a valid day number.");
                return ToTheMenu();
            }

            var dayName = ((WeekdayEnum)dayNumber).ToString();

            Console.WriteLine($"The name of {dayNumber} day of week is {dayName}.");

            return ToTheMenu();
        }
    }
}

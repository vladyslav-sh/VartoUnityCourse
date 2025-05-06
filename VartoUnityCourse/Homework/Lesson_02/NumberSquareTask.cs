using Spectre.Console.Cli;

namespace VartoUnityCourse.Homework.Lesson_02;

public class NumberSquareTask : Command
{
    public override int Execute(CommandContext context)
    {
        Console.WriteLine("Welcome to the Number Square Task! Designed to calculate a square of a given number.\r\n");
        Console.Write("Please enter your number: ");

        var inputString = Console.ReadLine();
        var inputNumber = int.Parse(inputString ?? string.Empty);
        var inputNumberSquere = Math.Pow(inputNumber, 2);

        Console.WriteLine($"\r\nThe square of {inputNumber} is {inputNumberSquere}");


        Console.WriteLine("\r\nPress any key to return to the menu...");
        Console.ReadKey();
        return 0;
    }
}

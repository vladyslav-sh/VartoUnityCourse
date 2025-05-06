using Spectre.Console.Cli;

namespace VartoUnityCourse.Homework.Lesson_02;

public class ReversedNameTask : Command
{
    public override int Execute(CommandContext context)
    {
        Console.WriteLine("Welcome to the Reversed Name Task! Designed to return your last name first.\r\n");
     
        Console.Write("Please enter your first name: ");
        var firstNameInputString = Console.ReadLine();

        Console.Write("Please enter your last name: ");
        var lastNameInputString = Console.ReadLine();

        Console.WriteLine($"\r\nYour full name is: {lastNameInputString} {firstNameInputString}.");


        Console.WriteLine("\r\nPress any key to return to the menu...");
        Console.ReadKey();
        return 0;
    }
}

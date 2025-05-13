using Spectre.Console;
using System;

namespace VartoUnityCourse.Business
{
    public static class MenuHelper
    {
        public static int ToTheMenu()
        {
            Console.WriteLine();

            var repeat = "[green]Repeat[/]";
            var exit = "[red]Back to the menu[/]";

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .AddChoices(new[] { repeat, exit }));

            return choice == repeat ? (int)ShowcaseAppResultCode.Repeat : (int)ShowcaseAppResultCode.Exit;
        }
    }
}

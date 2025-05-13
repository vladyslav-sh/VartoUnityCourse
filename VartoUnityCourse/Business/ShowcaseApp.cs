using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace VartoUnityCourse.Business
{
    public class ShowcaseApp
    {
        private readonly ITypeRegistrar _typeRegistrar;

        public ShowcaseApp(ITypeRegistrar typeRegistrar)
        {
            _typeRegistrar = typeRegistrar;
        }

        public async Task RunAsync(IReadOnlyList<string> args)
        {
            var app = new CommandApp(_typeRegistrar);
            var tasksGroupedByLesson = RegisterCommands(app);

            var selectionPrompt = new SelectionPrompt<string>()
                .Title("A homework showcase. Please select a [green]task[/]:");

            foreach (var lesson in tasksGroupedByLesson.OrderByDescending(lesson => lesson.Key))
            {
                selectionPrompt.AddChoiceGroup(
                    lesson.Key,
                    lesson.Select(taskName => taskName));
            }

            var exitCommand = "[red]Exit[/]";
            selectionPrompt.AddChoiceGroup(
                string.Empty,
                new[] { exitCommand });

            while (true)
            {
                Console.Clear();

                var selected = AnsiConsole.Prompt(selectionPrompt);
                if (selected == exitCommand)
                    break;

                int resultCode = 0;

                do
                {
                    resultCode = await app.RunAsync(new[] { selected });
                    DrawALine();
                }
                while (resultCode == (int)ShowcaseAppResultCode.Repeat);
            }
        }

        private static void DrawALine()
        {
            var length = Math.Max(1, (int)(AnsiConsole.Profile.Width * 0.75));

            // Draw a horizontal line of ─ chars, in grey
            AnsiConsole.MarkupLine($"[grey]{new string('─', length)}[/]");
        }

        private IEnumerable<IGrouping<string, string>> RegisterCommands(CommandApp app)
        {
            var commands = GetType().Assembly.GetTypes()
                .Where(type => typeof(ICommand).IsAssignableFrom(type))
                .ToList();

            var tasksGroupedByLesson = commands
                .GroupBy(
                    commandType => commandType.Namespace!.Split('.', StringSplitOptions.RemoveEmptyEntries).Last(),
                    commandType => commandType.Name.Replace("Task", ""));

            var taskNames = tasksGroupedByLesson.SelectMany(tasks => tasks).ToList();

            app.Configure(config =>
            {
                config.PropagateExceptions();
                var addCommandMethod = config.GetType().GetMethod("AddCommand")!;

                for (var i = 0; i < commands.Count; i++)
                {
                    var addCommand = addCommandMethod.MakeGenericMethod(commands[i]);
                    addCommand.Invoke(config, new[] { taskNames[i] });
                }
            });

            return tasksGroupedByLesson;
        }
    }
}

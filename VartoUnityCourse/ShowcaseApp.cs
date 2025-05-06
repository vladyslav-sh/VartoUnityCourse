using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Data;

namespace VartoUnityCourse;

public class ShowcaseApp(ITypeRegistrar typeRegistrar)
{
    public async Task RunAsync(IReadOnlyList<string> args)
    {
        var app = new CommandApp(typeRegistrar);
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
            [exitCommand]);

        while (true)
        {
            Console.Clear();

            var selected = AnsiConsole.Prompt(selectionPrompt);
            if (selected == exitCommand)
                break;

            await app.RunAsync([selected]);
        }
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
                addCommand.Invoke(config, [taskNames[i]]);
            }
        });

        return tasksGroupedByLesson;
    }

    public sealed class ServiceCollectionRegistrar : ITypeRegistrar
    {
        private readonly IServiceCollection builder;

        public ServiceCollectionRegistrar(IServiceCollection builder)
        {
            this.builder = builder;
        }

        public ITypeResolver Build()
        {
            return new TypeResolver(builder.BuildServiceProvider());
        }

        public void Register(Type service, Type implementation)
        {
            builder.AddSingleton(service, implementation);
        }

        public void RegisterInstance(Type service, object implementation)
        {
            builder.AddSingleton(service, implementation);
        }

        public void RegisterLazy(Type service, Func<object> func)
        {
            if (func is null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            builder.AddSingleton(service, _ => func());
        }

        private sealed class TypeResolver : ITypeResolver
        {
            private readonly IServiceProvider provider;

            public TypeResolver(IServiceProvider provider)
            {
                this.provider = provider ?? throw new ArgumentNullException(nameof(provider));
            }

            public object? Resolve(Type? type)
            {
                if (type == null)
                {
                    return null;
                }

                return provider.GetService(type);
            }
        }
    }
}

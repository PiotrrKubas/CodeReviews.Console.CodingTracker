using Spectre.Console;
using System.Diagnostics;
using static CodingTracker.PiotrrKubas.Enums;

namespace CodingTracker.PiotrrKubas
{
    internal class UserInterface
    {
        UserInput input = new();
        internal void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                var rule = new Rule("[yellow]MAIN MENU[/]");
                AnsiConsole.Write(rule);

                var actionChoice = AnsiConsole.Prompt
                    (new SelectionPrompt<Selection>()
                    .AddChoices(Enum.GetValues<Selection>()));

                switch (actionChoice)
                {
                    case Selection.StartSession:
                        StartSession();
                        break;
                    case Selection.EnterManually:
                        ManualEntry();
                        break;
                    case Selection.Report:
                        Report();
                        break;
                    case Selection.Goal:
                        GoalMenu();
                        break;
                    default:
                        break;
                }
            }
        }

        internal void GoalMenu()
        {
            Console.Clear();
            GoalActions goalActions = new();
            Console.Clear();
            var rule = new Rule("[yellow]GOAL MENU[/]");
            AnsiConsole.Write(rule);

            var actionChoice = AnsiConsole.Prompt
                (new SelectionPrompt<GoalSelection>()
                .AddChoices(Enum.GetValues<GoalSelection>()));

            switch (actionChoice)
            {
                case GoalSelection.SetGoal:
                    goalActions.SetGoal();
                    break;
                case GoalSelection.ChangeGoal:
                    goalActions.ChangeGoal();
                    break;
                case GoalSelection.GoalProgress:
                    goalActions.GoalProgress();
                    break;
                case GoalSelection.GoalCancel:
                    goalActions.GoalCancel();
                    break;
                case GoalSelection.MainMenu:
                    MainMenu();
                    break;
                default:
                    break;
            }

        }
        internal void StartSession()
        {
            Console.Clear();
            Console.WriteLine("Session start");
            DateTime sessionStart = DateTime.Now;

            Stopwatch stopwatch = new();
            stopwatch.Start();
            CancellationTokenSource source = new();
            CancellationToken token = source.Token;

            Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.SetCursorPosition(0, 1);
                    Console.Write($"Session Length: {stopwatch.Elapsed:g}   ");
                }
            }, token);

            while (!PromptToStopSession())
            {
            }
            source.Cancel();
            stopwatch.Stop();
            DateTime sessionEnd = DateTime.Now;
            DatabaseOperations.AddRecord(sessionStart, sessionEnd);

            Console.ReadKey();
        }

        private bool PromptToStopSession()
        {
            return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Stop coding session?")
            .AddChoices("Yes", "No")) == "Yes";
        }

        internal void ManualEntry()
        {
            Console.Clear();
            Console.WriteLine("Manual Entry");
            DateTime sessionStart;
            DateTime sessionEnd;           

            sessionStart = input.DateInput("Enter start of the session");
            sessionEnd = input.DateInput("Enter end of the session");

            DatabaseOperations.AddRecord(sessionStart, sessionEnd);
        }

        internal void Report()
        {
            Console.Clear();
            var table = DatabaseOperations.GetTable().Item1;
            AnsiConsole.Write(table);
            int denominator = table.Rows.Count;
            TimeSpan totalSessionDuration = new();

            totalSessionDuration = DatabaseOperations.GetTable().Item2;
            Console.WriteLine($"Total duration = {totalSessionDuration}");
            Console.WriteLine($"Average duration = {totalSessionDuration / denominator}");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }
    }
}

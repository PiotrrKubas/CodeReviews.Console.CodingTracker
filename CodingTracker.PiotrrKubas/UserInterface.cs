using Spectre.Console;
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
                var rule = new Rule();
                AnsiConsole.Write(rule);

                var actionChoice = AnsiConsole.Prompt
                    (new SelectionPrompt<Selection>()
                    .Title("[yellow]MAIN MENU[/]")
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
                    default:
                        break;
                }
            }
        }
        
        internal void StartSession()
        {
            Console.WriteLine("Session start");
            DateTime sessionStart = DateTime.Now;          

            while (!PromptToStopSession())
            {
                Console.Clear();
            }

            DateTime sessionEnd = DateTime.Now;

            DatabaseOperations.AddRecord(sessionStart, sessionEnd);

            Console.ReadKey();
        }

        private bool PromptToStopSession()
        {
            return AnsiConsole.Prompt(
            new TextPrompt<bool>("Stop coding session?")
                .AddChoice(true)
                .AddChoice(false)
                .WithConverter(choice => choice ? "y" : "n"));
        }

        internal void ManualEntry()
        {
            Console.WriteLine("Manual Entry");
            DateTime sessionStart;
            DateTime sessionEnd;           

            sessionStart = input.DateInput("Enter start of the session");
            sessionEnd = input.DateInput("Enter end of the session");

            DatabaseOperations.AddRecord(sessionStart, sessionEnd);
        }

        internal void Report()
        {
            DatabaseOperations.PrintReport();
            Console.ReadLine();
        }
    }
}

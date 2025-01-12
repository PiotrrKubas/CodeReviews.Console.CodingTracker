using Spectre.Console;
using static CodingTracker.PiotrrKubas.Enums;

namespace CodingTracker.PiotrrKubas
{
    internal class UserInterface
    {
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
            TimeSpan duration = sessionEnd - sessionStart;
            Console.WriteLine(duration);            

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

            sessionStart = DateTime.Parse(Console.ReadLine());
            sessionEnd = DateTime.Parse(Console.ReadLine());

            TimeSpan duration = sessionEnd - sessionStart;
        }

        internal void Report()
        {
            Console.WriteLine("Report printing");
        }
    }
}

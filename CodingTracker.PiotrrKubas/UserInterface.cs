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
            Console.WriteLine("Press any key to stop coding session");
            Console.ReadKey();
            DateTime sessionEnd = DateTime.Now;
            TimeSpan duration = sessionEnd - sessionStart;
            Console.WriteLine(duration);
            Console.ReadKey();
        }

        internal void ManualEntry()
        {
            Console.WriteLine("Manual Entry");
        }

        internal void Report()
        {
            Console.WriteLine("Report printing");
        }
    }
}

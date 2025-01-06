using Spectre.Console;
using static CodingTracker.PiotrrKubas.Enums;
namespace CodingTracker.PiotrrKubas
{
    internal class UserInterface
    {
        internal void MainMenu()
        {
            var rule = new Rule();
            AnsiConsole.Write(rule);

            AnsiConsole.Prompt(new SelectionPrompt<Selection>()
                .Title("[yellow]MAIN MENU[/]")
                .AddChoices(Enum.GetValues<Selection>()));
        }
    }
}

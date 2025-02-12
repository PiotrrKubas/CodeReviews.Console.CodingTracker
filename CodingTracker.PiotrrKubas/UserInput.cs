using Spectre.Console;
using System.Globalization;

namespace CodingTracker.PiotrrKubas
{
    internal class UserInput
    {
        internal string Input(string prompt)
        {
            AnsiConsole.Write(new Markup(prompt));
            string? userInput;
            do
            {
                userInput = Console.ReadLine();
            } while (userInput == null); 

            return userInput;
        }

        internal DateTime DateInput(string prompt)
        {
            string timeFormat = "dd.MM.yyyy HH:mm";
            string dateUserInput;
            DateTime result; 
            CultureInfo culture = new CultureInfo("pl-PL");
            do
            {
                dateUserInput = Input(prompt + " using [blue]dd.mm.yyyy HH:mm[/] format\n");
            } while (!DateTime.TryParseExact(dateUserInput, timeFormat, culture, DateTimeStyles.None, out result));

            return result;
        }
    }
}

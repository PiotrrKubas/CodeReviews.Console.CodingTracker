using Spectre.Console;

namespace CodingTracker.PiotrrKubas
{
    class Report
    {
        internal void PrintReport()
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

        internal void SortByDate()
        {
            
        }
    }
}

using Microsoft.Data.Sqlite;
using Dapper;

namespace CodingTracker.PiotrrKubas
{
    internal class DatabaseConnection
    {
        internal static void Connection()
        {
            try
            {
                using (var connection = new SqliteConnection("Data Source=CodingTracker.db"))
                {
                    connection.Open();

                    var createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS coding_tracker (
                        id INTEGER PRIMARY KEY,
                        session_start_time TEXT,
                        session_end_time TEXT,
                        session_duration_minutes INTEGER
                    )";
                    
                    connection.Execute(createTableQuery);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"An error occured: {error.Message}");
            }
        }
    }
}
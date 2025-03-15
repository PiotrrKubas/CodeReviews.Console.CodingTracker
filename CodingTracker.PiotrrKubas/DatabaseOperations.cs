using CodingTracker.PiotrrKubas;
using Dapper;
using Microsoft.Data.Sqlite;
using Spectre.Console;

class DatabaseOperations
{
    private static string connectionString = "Data Source=CodingTracker.db";

    public static void Connection()
    {
        try
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var createTableQuery = @"
                CREATE TABLE IF NOT EXISTS coding_tracker (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    session_start_time TEXT NOT NULL,
                    session_end_time TEXT NOT NULL,
                    session_duration TEXT NOT NULL
                )";

                connection.Execute(createTableQuery);
            }
        }
        catch (Exception error)
        {
            Console.WriteLine($"An error occurred: {error.Message}");
        }
    }

    public static void AddRecord(DateTime sessionStart, DateTime sessionEnd)
    {
        TimeSpan duration = sessionEnd - sessionStart;

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            var insertRecordQuery = @"INSERT INTO coding_tracker (session_start_time, session_end_time, session_duration) VALUES (@SessionStart, @SessionEnd, @Duration)";
            
            var parameters = new { @SessionStart = sessionStart.ToString("g"), @SessionEnd = sessionEnd.ToString("g"), @Duration = duration.ToString("g")};

            connection.Execute(insertRecordQuery, parameters);
        }
    }

    public static (Table, TimeSpan) GetTable()
    {
        var table = new Table();
        table.Title("Coding sessions");
        table.AddColumn("Session ID");
        table.AddColumn("Session start date");
        table.AddColumn("Session end date");
        table.AddColumn("Session duration");

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            int denominator = 0;
            TimeSpan totalSessionDuration = new();
            List<CodingSession> sessions = new();
            sessions = connection.Query<CodingSession>("SELECT * FROM coding_tracker").AsList();

            foreach (var session in sessions)
            {
                table.AddRow(session.Id.ToString(), session.session_start_time, session.session_end_time, session.session_duration);
                totalSessionDuration += TimeSpan.Parse(session.session_duration);
                denominator++;
            }

            return (table, totalSessionDuration);
        }
    }
    public static void EditRecord()
    {
        GetTable();
    }
}

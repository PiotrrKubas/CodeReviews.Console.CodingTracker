namespace CodingTracker.PiotrrKubas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterface();
            
            DatabaseConnection.Connection();
            userInterface.MainMenu();
        }
    }
}
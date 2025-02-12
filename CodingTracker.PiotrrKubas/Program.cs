namespace CodingTracker.PiotrrKubas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterface();
            
            DatabaseOperations.Connection();
            userInterface.MainMenu();
        }
    }
}
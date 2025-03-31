namespace CodingTracker.PiotrrKubas
{
    class GoalActions
    {
        internal void SetGoal()
        {
            Console.WriteLine("Please select your coding goal. Your coding time will count towards it from now on");
        }

        internal void ChangeGoal()
        {
            Console.WriteLine("Change goal");
        }

        internal void GoalProgress()
        {
            Console.WriteLine("GoalProgress");
        }

        internal void GoalCancel()
        {
            Console.WriteLine("Goal cancel");
        }
    }
}

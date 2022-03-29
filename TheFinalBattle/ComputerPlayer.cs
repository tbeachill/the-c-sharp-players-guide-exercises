namespace TheFinalBattle
{
    public class ComputerPlayer : IPlayer
    {
        // Generate a random action to perform
        public IAction ChooseAction(Battle battle, Character character)
        {
            IAction action;

            Random random = new Random();
            action = random.Next(0,0) switch
            {
                0 => new DoNothingAction()
            };

            return action;
        }
    }
}

namespace TheFinalBattle
{
    public class ComputerPlayer : IPlayer
    {
        public IAction ChooseAction(Battle battle, Character character)
        {
            Thread.Sleep(500);
            return new DoNothingAction();
        }
    }
}

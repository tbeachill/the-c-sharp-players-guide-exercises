namespace TheFinalBattle
{
    public interface IPlayer
    {
        IAction ChooseAction(Battle battle, Character character);
    }
}

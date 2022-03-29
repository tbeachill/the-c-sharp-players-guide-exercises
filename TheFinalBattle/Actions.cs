namespace TheFinalBattle
{
    public interface IAction
    {
        void Run(Battle battle, Character character);
    }
    
    public class DoNothingAction : IAction
    {
        public void Run(Battle battle, Character character) => Console.WriteLine($"{character.Name} did NOTHING.");
    }
}

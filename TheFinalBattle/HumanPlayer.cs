namespace TheFinalBattle
{
    public class HumanPlayer : IPlayer
    {
        // Let the player choose an action to take
        public IAction ChooseAction(Battle battle, Character character)
        {
            IAction? action;

            // Loop until a valid action is selected
            do
            {
                Console.WriteLine("What action?");
                
                action = Console.ReadLine() switch
                {
                    "Nothing" => new DoNothingAction(),
                    _ => null
                };
            }
            while (action == null);

            return action;
        }
    }
}

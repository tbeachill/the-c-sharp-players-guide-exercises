namespace TheFinalBattle
{
    public class HumanPlayer : IPlayer
    {
        // Let the player choose an action to take
        public IAction ChooseAction(Battle battle, Character character)
        {
            IAction? action;

            IAttack attack = character.StandardAttack;
            List<Character> enemyParty = battle.GetEnemyParty(character).Members;

            // Loop until a valid action is selected
            do
            {
                Console.WriteLine("What action?");
                
                action = Console.ReadLine() switch
                {
                    "Nothing" => new DoNothingAction(),
                    "Attack" => new AttackAction(attack, SelectTarget(enemyParty)),
                    _ => null
                };
            }
            while (action == null);

            return action;
        }


        // Allows the player to select a target to attack
        private Character SelectTarget(List<Character> enemyParty)
        {
            // Print a list of enemy characters
            foreach (Character enemyChar in enemyParty)
            {
                Console.Write(enemyParty.IndexOf(enemyChar) + ". ");
                Console.WriteLine(enemyChar.Name);
            }

            // Ask for a target until a legitimate answer is chosen
            int index;
            bool success;
            do
            {
                Console.WriteLine("Select a target");
                success = int.TryParse(Console.ReadLine(), out index);
            }
            while (index == null || index < 0 || index > enemyParty.Count - 1 || !success);

            return enemyParty[index];
        }
    }
}

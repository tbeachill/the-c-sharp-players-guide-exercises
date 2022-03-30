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
                Console.WriteLine($"\n1. Standard Attack ({character.StandardAttack.Name})");
                Console.WriteLine($"2. Do Nothing");
                Console.Write("What action? ");

                action = Console.ReadLine() switch
                {
                    "1" => new AttackAction(attack, SelectTarget(enemyParty)),
                    "2" => new DoNothingAction(),
                    _ => null
                };
            }
            while (action == null);

            return action;
        }


        // Allows the player to select a target to attack
        private Character SelectTarget(List<Character> enemyParty)
        {
            Console.WriteLine();

            // Print a list of enemy characters
            foreach (Character enemyChar in enemyParty)
            {
                Console.Write(enemyParty.IndexOf(enemyChar) + 1 + ". ");
                Console.WriteLine(enemyChar.Name);
            }

            // Ask for a target until a legitimate answer is chosen
            int index;
            bool success;
            do
            {
                Console.Write("Select a target: ");
                success = int.TryParse(Console.ReadLine(), out index);
            }
            while (index == null || index < 1 || index > enemyParty.Count || !success);

            return enemyParty[index - 1];
        }
    }
}

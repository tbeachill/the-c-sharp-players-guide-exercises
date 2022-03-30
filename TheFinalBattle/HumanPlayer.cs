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
            Party selfParty = battle.GetParty(character);

            // Loop until a valid action is selected
            do
            {
                Console.WriteLine($"\n1. Standard Attack ({character.StandardAttack.Name})");
                Console.WriteLine($"2. Use Item");
                Console.WriteLine($"3. Do Nothing");
                Console.Write("What action? ");

                action = Console.ReadLine() switch
                {
                    "1" => new AttackAction(attack, SelectTarget(enemyParty)),
                    "2" => selfParty.Inventory.Count > 0? new UseItemAction(SelectItem(selfParty.Inventory), SelectTarget(selfParty.Members)) : null,
                    "3" => new DoNothingAction(),
                    _ => null
                };
            }
            while (action == null);

            return action;
        }


        // Allows the player to select a target to attack
        private Character SelectTarget(List<Character> enemyParty)
        {
            // return if there is only 1 char in the party
            if (enemyParty.Count == 1) return enemyParty[0];

            Console.WriteLine();

            // Print a list of enemy characters
            foreach (Character enemyChar in enemyParty)
            {
                Console.Write(enemyParty.IndexOf(enemyChar) + 1 + ". ");
                Console.WriteLine($"{enemyChar.Name} ({enemyChar.HP}/{enemyChar.MaxHP})");
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


        private Item SelectItem(List<Item> inventory)
        {
            Console.WriteLine();

            // Print out unique items in inventory
            int i = 1;
            foreach (String item in inventory.Select(x => x.Name).Distinct())
            {
                Console.Write(i + ". ");
                Console.WriteLine($"{item} ({inventory.Select(x => x.Name).Count()})");
                i++;
            }

            // Ask user to select an item from the list
            int index;
            bool success;
            do
            {
                Console.Write("Select an item: ");
                success = int.TryParse(Console.ReadLine(),out index);
            }
            while (index == null || index < 1 || index > i - 1 || !success);

            return inventory.Distinct().ToList()[index - 1];
        }
    }
}

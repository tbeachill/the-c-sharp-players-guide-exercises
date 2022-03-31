namespace TheFinalBattle
{
    public class HumanPlayer : IPlayer
    {
        // Let the player choose an action to take
        public IAction ChooseAction(Battle battle, Character character)
        {
            Party enemyParty = battle.GetEnemyParty(character);
            Party selfParty = battle.GetParty(character);
            List<MenuChoice> menuChoices = CreateMenu(character, enemyParty, selfParty);

            // Write out all menu choices
            foreach (MenuChoice choice in menuChoices)
            {
                Console.Write(menuChoices.IndexOf(choice) + 1 + ". ");
                Console.WriteLine(choice.Description);
            }

            // Loop until a valid choice is selected
            int i;
            do
            {
                Console.Write("What action? ");
            }
            while (!int.TryParse(Console.ReadLine(), out i) || i < 1 || i > menuChoices.Count());

            return menuChoices[i - 1].Action;
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
            while (index < 1 || index > enemyParty.Count || !success);

            return enemyParty[index - 1];
        }


        // Allows the user to select an inventory item from a list
        public static Item SelectItem(List<Item> inventory)
        {
            Console.WriteLine();

            // Print out unique items in inventory
            int i = 1;
            foreach (string item in inventory.Select(x => x.Name).Distinct())
            {
                Console.Write(i + ". ");
                Console.WriteLine($"{item} ({inventory.Where(x => x.Name == item).Count()})");
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
            while (index < 1 || index > i - 1 || !success);

            return Enumerable.DistinctBy(inventory, x => x.Name).ToList()[index - 1];
        }


        private List<MenuChoice> CreateMenu(Character character, Party enemy, Party friend)
        {
            List<MenuChoice> optionList = new List<MenuChoice>();

            optionList.Add(new MenuChoice($"Standard Attack ({character.StandardAttack.Name})", new AttackAction(character.StandardAttack, SelectTarget(enemy.Members))));

            if (character.Weapon != null)
                optionList.Add(new MenuChoice($"Weapon Attack ({character.Weapon.SpecialAttack.Name})", new AttackAction(character.Weapon.SpecialAttack, SelectTarget(enemy.Members))));

            if (friend.Inventory.Count() > 0)
                optionList.Add(new MenuChoice("Inventory", new UseItemAction(character)));

            optionList.Add(new MenuChoice("Do Nothing", new DoNothingAction()));

            return optionList;
        }
    }

    public record MenuChoice(string Description, IAction Action);
}

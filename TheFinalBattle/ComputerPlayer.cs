namespace TheFinalBattle
{
    public class ComputerPlayer : IPlayer
    {
        // Generate a random action to perform
        public IAction ChooseAction(Battle battle, Character character)
        {
            Random r = new Random();
            IAction action;
            IAttack attack = character.StandardAttack;
            List<Item> inventory = battle.GetParty(character).Inventory;

            // Select a target randomly
            int targetIndex = r.Next(battle.GetEnemyParty(character).Members.Count);
            Character target = battle.GetEnemyParty(character).Members[targetIndex];

            // If character is <50% HP and there is a health potion in inventory, 25% chance of using
            if (character.HP < character.MaxHP / 2 && inventory.Any(x => x.Name == "HEALTH POTION"))
            {
                if (r.NextDouble() <= 0.25)
                    return new UseItemAction(inventory[inventory.FindIndex(x => x.Name == "HEALTH POTION")], character);
            }

            // Select a random action to perform
            action = r.Next(1) switch
            {
                0 => new AttackAction(attack, target),
                //1 => new DoNothingAction()
            };

            return action;
        }
    }
}

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
                    return new UseItemAction(character, inventory[inventory.FindIndex(x => x.Name == "HEALTH POTION")]);
            }

            // If a weapon is in inventory and a character does not have one equipped, 50% chance to equip
            if (inventory.Where(x => x is Weapon).Count() > 0 && character.Weapon == null)
            {
                if (r.NextDouble() <= 0.5)
                {
                    // Use the first item with the type of weapon on the character
                    return new UseItemAction(character, inventory.Where(x => x is Weapon).ToList()[0]);
                }
            }

            // Use a weapon attack if available
            if (character.Weapon != null)
                action = new AttackAction(character.Weapon.SpecialAttack, target);
            else
                action = new AttackAction(attack, target);

            return action;
        }
    }
}

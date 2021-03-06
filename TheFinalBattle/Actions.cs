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


    public class AttackAction : IAction
    {
        private IAttack Attack;
        private Character? Target;

        public AttackAction(IAttack attack, Character target)
        {
            Attack = attack;
            Target = target;
        }


        public AttackAction(IAttack attack)
        {
            Attack = attack;
        }

        // Perform the attack and display to console
        public void Run(Battle battle, Character character)
        {
            if (Target == null) Target = HumanPlayer.SelectTarget(battle.GetEnemyParty(character).Members);

            // Get damage to deal from attack
            int damage = Attack.Damage();

            Console.WriteLine($"\n{character.Name} used {Attack.Name} on {Target.Name}.");
            Console.WriteLine($"{Attack.Name} dealt {damage} damage.");

            // If at 0 HP or below from attack, remove target from their party
            if (Target.HP - damage <= 0)
            {
                Console.WriteLine($"{Target.Name} has been defeated.");

                // Pick up the enemy's equipped weapon
                if (Target.Weapon != null)
                {
                    battle.GetParty(character).Inventory.Add(Target.Weapon);
                    Console.WriteLine($"{Target.Name} dropped {Target.Weapon.Name}");
                }

                battle.GetEnemyParty(character).Members.Remove(Target);
            }
            else
            {
                Target.HP -= damage;
                Console.WriteLine($"{Target.Name} is now at {Target.HP}/{Target.MaxHP} HP.");
            }
        }
    }


    public class UseItemAction : IAction
    {
        private Item? UseItem;
        private Character Target;


        public UseItemAction(Character target)
        {
            Target = target;
        }


        public UseItemAction(Character target, Item item)
        {
            UseItem = item;
            Target = target;
        }

        // Use item and remove from inventory
        public void Run(Battle battle, Character character)
        {
            if (UseItem == null) UseItem = HumanPlayer.SelectItem(battle.GetParty(character).Inventory);

            UseItem.Use(Target);
            battle.GetParty(character).Inventory.Remove(UseItem);
        }
    }
}

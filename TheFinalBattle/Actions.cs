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
        private readonly IAttack Attack;
        private readonly Character Target;

        public AttackAction(IAttack attack, Character target)
        {
            Attack = attack;
            Target = target;
        }
        

        public void Run(Battle battle, Character character)
        {
            // Get damage to deal from attack
            int damage = Attack.Damage();

            Console.WriteLine($"\n{character.Name} used {Attack.Name} on {Target.Name}.");
            Console.WriteLine($"{Attack.Name} dealt {damage} damage.");

            // If at 0 HP or below from attack, remove target from their party
            if (Target.HP - damage <= 0)
            {
                Console.WriteLine($"{Target.Name} has been defeated.");
                battle.GetEnemyParty(character).Members.Remove(Target);
            }
            else
            {
                Target.HP -= damage;
                Console.WriteLine($"{Target.Name} is now at {Target.HP}/{Target.MaxHP} HP.");
            }
        }
    }
}

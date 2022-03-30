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

            // Ensure health doesn't go below 0
            if (Target.HP - damage < 0)
            {
                Target.HP = 0;
            }
            else
            {
                Target.HP -= damage;
            }
            
            Console.WriteLine($"{character.Name} used {Attack.Name} on {Target.Name}.");
            Console.WriteLine($"{Attack.Name} dealt {damage} damage.");
            Console.WriteLine($"{Target.Name} is now at {Target.HP}/{Target.MaxHP} HP.");
        }
    }
}

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

        public void Run(Battle battle, Character character) => Console.WriteLine($"{character.Name} used {Attack.Name} on {Target.Name}.");
    }
}

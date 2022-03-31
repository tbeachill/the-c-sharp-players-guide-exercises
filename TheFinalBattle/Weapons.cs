namespace TheFinalBattle
{
    public abstract class Weapon : Item
    {
        public abstract IAttack SpecialAttack { get; }

        // Using a weapon equips it
        public override void Use(Character character)
        {
            character.Weapon = this;
            Console.WriteLine($"{character.Name} has equipped {Name}");
        }
    }


    public class Sword : Weapon
    {
        public override string Name { get; } = "SWORD";
        public override IAttack SpecialAttack { get; } = new Slash();
    }


    public class Dagger : Weapon
    {
        public override string Name { get; } = "SWORD";
        public override IAttack SpecialAttack { get; } = new Stab();
    }
}

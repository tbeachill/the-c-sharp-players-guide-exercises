namespace TheFinalBattle
{
    // The player's character
    public class TrueProgrammer : Character
    {
        public override string Name { get; }
        public override int HP { get; set; } = 25;
        public override int MaxHP { get; } = 25;
        public override IAttack StandardAttack { get; } = new Punch();

        // Get name from the player
        public TrueProgrammer()
        {
            do
            {
                Console.Write("What is your name? ");
                Name = Console.ReadLine();
            }
            while (Name == "");
        }

        public TrueProgrammer(Weapon weapon) => Weapon = weapon;
    }
}

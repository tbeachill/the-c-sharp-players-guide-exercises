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
            Name = GetName();
        }


        public TrueProgrammer(Weapon weapon)
        {
            Weapon = weapon;
            Name = GetName();
        }


        private string GetName()
        {
            string name;
            do
            {
                Console.Write("What is your name? ");
                name = Console.ReadLine();
            }
            while (name == "");

            return name;
        }
    }
}

namespace TheFinalBattle
{
    // The player's character
    public class TrueProgrammer : Character
    {
        public override string Name { get; }
        public override IAttack StandardAttack { get; } = new Punch();

        // Get name from the player
        public TrueProgrammer()
        {
            do
            {
                Console.WriteLine("What is your name? ");
                Name = Console.ReadLine();
            }
            while (Name == "");
        }
    }
}

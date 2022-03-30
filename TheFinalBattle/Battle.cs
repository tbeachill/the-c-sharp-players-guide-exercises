namespace TheFinalBattle
{
    public class Battle
    {
        public Party Heroes { get; }
        public Party Monsters { get; }

        public Battle(Party heroes, Party monsters)
        {
            Heroes = heroes;
            Monsters = monsters;
        }


        // Run looped rounds until one party is defeated
        public bool Run()
        {
            while (true)
            {
                foreach (Party party in new[] { Heroes, Monsters })
                {
                    foreach (Character character in party.Members)
                    {
                        Thread.Sleep(1000);

                        // Make the player characters text blue and the enemy's red
                        Console.ForegroundColor = party.Player.ToString() == "TheFinalBattle.HumanPlayer"? ConsoleColor.Blue: ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine($"It is {character.Name}'s turn.");
                        party.Player.ChooseAction(this, character).Run(this, character);

                        // Print a white line between players
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n" + new string('-', 24));

                        // Win/lose conditions
                        if (Heroes.Members.Count == 0) return false;
                        if (Monsters.Members.Count == 0) return true;
                    }
                }
            }
        }

        public Party GetEnemyParty(Character character) => Heroes.Members.Contains(character) ? Monsters : Heroes;
    }
}

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
        public void Run()
        {
            while (true)
            {
                foreach (Party party in new[] { Heroes, Monsters })
                {
                    foreach (Character character in party.Members)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"It is {character.Name}'s turn.");
                        party.Player.ChooseAction(this, character).Run(this, character);

                        // Win/lose conditions
                        if (Heroes.Members.Count == 0)
                        {
                            Console.WriteLine("The heroes have lost. The Uncoded One has prevailed!");
                            return;
                        }
                        if (Monsters.Members.Count == 0)
                        {
                            Console.WriteLine("The heroes have won. The Uncoded One is deafeated!");
                            return;
                        }
                    }
                }
            }
        }

        public Party GetEnemyParty(Character character) => Heroes.Members.Contains(character) ? Monsters : Heroes;
    }
}

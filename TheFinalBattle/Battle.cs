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
            PrintBattleStatus();

            while (true)
            {
                foreach (Party party in new[] { Heroes, Monsters })
                {
                    foreach (Character character in party.Members)
                    {
                        Thread.Sleep(500);

                        
                        // Make the player characters text blue and the enemy's red
                        Console.ForegroundColor = party.Player.GetType() == typeof(HumanPlayer) ? ConsoleColor.Blue: ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine($"It is {character.Name}'s turn.");
                        party.Player.ChooseAction(this, character).Run(this, character);

                        // Print a white line between players
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n" + new string('-', 24));

                        // Win/lose conditions
                        if (Heroes.Members.Count == 0) return false;
                        if (Monsters.Members.Count == 0)
                        {
                            // Display which items were dropped
                            string dropString = "";
                            foreach (Item item in Enumerable.DistinctBy(Monsters.Inventory, x => x.Name))
                            {
                                dropString += item.Name + " (" + Monsters.Inventory.Where(x => x.Name == item.Name).Count() + ")  ";
                            }
                            Console.WriteLine($"The enemy party drops {dropString}");


                            foreach (Item item in Monsters.Inventory)
                            {
                                Heroes.Inventory.Add(item);
                            }

                            return true;
                        }
                    }
                }
            }
        }


        // Write out the members of each party involved in the battle and their HP values
        private void PrintBattleStatus()
        {
            Console.WriteLine(new string('=', 24) + " BATTLE " + new string('=', 24));
            bool firstPass = true;

            foreach (Party party in new[] { Heroes, Monsters })
            {
                foreach (Character character in party.Members)
                {
                    // Work out adjustment for monster party to be right-aligned
                    if (party.Equals(Monsters))
                        Console.Write(new string(' ', 56 - (character.Name.Length + character.MaxHP.ToString().Length * 2 + 4)));

                    Console.WriteLine($"{character.Name} ({character.HP}/{character.MaxHP})");
                }

                // Print divider line between parties and double line after both
                if (firstPass == true)
                    Console.WriteLine(new string('-', 26) + " VS " + new string('-', 26));
                else
                    Console.WriteLine(new string('=', 56));

                firstPass = false;
            }
        }

        public Party GetEnemyParty(Character character) => Heroes.Members.Contains(character) ? Monsters : Heroes;
        public Party GetParty(Character character) => Heroes.Members.Contains(character) ? Heroes : Monsters;
    }
}

namespace TheFinalBattle
{
    public class Party
    {
        public IPlayer Player { get; }
        public List<Character> Members { get; } = new List<Character> { };
        public List<Item> Inventory { get; set; }  = new List<Item> { };

        public Party(IPlayer player, List<Character> members, List<Item> items)
        {
            Player = player;
            Members = members;
            Inventory = items;
        }
    }
}

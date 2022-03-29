namespace TheFinalBattle
{
    public class Party
    {
        public IPlayer Player { get; set; }
        public List<Character> Members { get; set; } = new List<Character> { };

        public Party(IPlayer player, List<Character> members)
        {
            Player = player;
            Members = members;
        }
    }
}

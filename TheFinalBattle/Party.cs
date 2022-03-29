namespace TheFinalBattle
{
    public class Party
    {
        public IPlayer Player { get; }
        public List<Character> Members { get; } = new List<Character> { };

        public Party(IPlayer player, List<Character> members)
        {
            Player = player;
            Members = members;
        }
    }
}

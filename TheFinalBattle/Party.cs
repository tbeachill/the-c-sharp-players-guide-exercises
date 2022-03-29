namespace TheFinalBattle
{
    internal class Party
    {
        public List<Character> Members { get; set; } = new List<Character> { };

        public Party(Character member)
        {
            Members.Add(member);
        }
    }
}

namespace TheFinalBattle
{
    public class UncodedOne : Character
    {
        public override string Name { get; } = "THE UNCODED ONE";
        public override int HP { get; set; } = 15;
        public override int MaxHP { get; } = 15;
        public override IAttack StandardAttack { get; } = new Unraveling();
    }
}

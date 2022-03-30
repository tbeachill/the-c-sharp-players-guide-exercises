namespace TheFinalBattle
{
    public class Skeleton : Character
    {
        public override string Name { get; } = "SKELETON";
        public override int HP { get; set; } = 5;
        public override int MaxHP { get; } = 5;
        public override IAttack StandardAttack { get; } =  new BoneCrunch();
    }
}

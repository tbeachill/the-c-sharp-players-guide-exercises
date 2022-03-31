namespace TheFinalBattle
{ 
    // Base class for different character types
    public abstract class Character
    {
        public abstract string Name { get; }
        public abstract int HP { get; set; }
        public abstract int MaxHP { get; }
        public Weapon? Weapon { get; set; }
        public abstract IAttack StandardAttack { get; }
    }
}

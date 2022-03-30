namespace TheFinalBattle
{
    public abstract class Item
    {
        public abstract string Name { get; }

        public abstract void Use(Character character);
    }

    public class HealthPotion : Item
    {
        public override string Name { get; } = "HEALTH POTION";
        public const int HP_RESTORE = 10;

        public override void Use(Character character)
        {
            // Ensure health doesn't restore past max
            if (character.MaxHP - character.HP < HP_RESTORE)
                character.HP = character.MaxHP;
            else
                character.HP += HP_RESTORE;

            // Display the characters new health
            Console.WriteLine($"{Name} was used on {character.Name}. Their health is now {character.HP}/{character.MaxHP}");

            return;
        }
    }
}

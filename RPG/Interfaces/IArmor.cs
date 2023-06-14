namespace RPG.Interfaces
{
    public interface IArmor : IItem
    {
        int Armor { get; }
        int Durability { get; }
        int DefaultDurability { get; }

        void HandleDurability();
        void FixArmor();
    }
}
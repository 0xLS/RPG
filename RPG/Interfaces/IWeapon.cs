using System;
namespace RPG.Interfaces
{
    public interface IWeapon
    {
        string Description { get; }
        int Damage { get; }
        int Durability { get; }
        int DefaultDurability { get; }
        bool IsEnchanted { get; }
        WeaponType WeaponType { get; }

        void HandleDurability();
        void FixWeapon();
    }
}


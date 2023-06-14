using System;
using RPG.Interfaces;
using RPG.Items.Weapons.Magic;
using RPG.Items.Weapons.Melee;
using RPG.Items.Weapons.Ranged;

namespace RPG.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(WeaponList type)
        {
#pragma warning disable CS8603 // Possible null reference return.
            switch (type)
            {
                case WeaponList.Sword: return new Sword();
                case WeaponList.Axe: return new Axe();
                case WeaponList.Bow: return new Bow();
                case WeaponList.Crossbow: return new Crossbow();
                case WeaponList.Dagger: return new Dagger();
                case WeaponList.Mace: return new Mace();
                case WeaponList.Spear: return new Spear();
                case WeaponList.Staff: return new Staff();
                case WeaponList.Wand: return new Wand();
                case WeaponList.Magic: return new Magic();
                case WeaponList.Shield: return new Shield();
                default: return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
    }
}


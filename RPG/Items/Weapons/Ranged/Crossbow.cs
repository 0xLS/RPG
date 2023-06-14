using System;
using RPG.Interfaces;

namespace RPG.Items.Weapons.Ranged
{
    public class Crossbow : WeaponBase
    {
        public override string Description
        {
            get { return "Iron-Fist Crossbow"; }
        }

        public override int Damage
        {
            get { return 78; }
        }

        public override int Durability
        {
            get { return _durability; }
        }

        public override int DefaultDurability
        {
            get { return _defaultDurability; }
        }

        public override bool IsEnchanted
        {
            get { return false; }
        }

        public override WeaponType WeaponType
        {
            get { return WeaponType.Ranged; }
        }

        public Crossbow()
        {
            _durability = _defaultDurability = 150;
        }
    }
}


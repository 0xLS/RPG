using System;
using RPG.Interfaces;

namespace RPG.Items.Weapons.Magic
{
    public class Wand : WeaponBase
    {
        public override string Description
        {
            get { return "MagiWood Wand"; }
        }

        public override int Damage
        {
            get { return 37; }
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
            get { return WeaponType.Magic; }
        }

        public Wand()
        {
            _durability = _defaultDurability = 250;
        }
    }
}


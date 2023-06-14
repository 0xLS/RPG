using System;
using RPG.Interfaces;

namespace RPG.Items.Weapons.Ranged
{
    public class Bow : WeaponBase
    {
        public override string Description
        {
            get { return "Bow"; }
        }

        public override int Damage
        {
            get { return 65; }
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

        public Bow()
        {
            _durability = _defaultDurability = 200;
        }

    }
}


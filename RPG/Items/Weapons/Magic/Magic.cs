using System;
using RPG.Helpers;
using RPG.Interfaces;

namespace RPG.Items.Weapons.Magic
{
    public class Magic : WeaponBase
    {
        public override string Description
        {
            get { return "Magic"; }
        }

        public override int Damage
        {
            get { return 67; }
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

        public Magic()
        {
            _durability = _defaultDurability = 250;
        }
    }
}


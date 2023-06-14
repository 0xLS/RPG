﻿using System;
using RPG.Interfaces;

namespace RPG.Items.Weapons.Melee
{
    public class Axe : WeaponBase
    {
        public override string Description
        {
            get { return "Iron Axe"; }
        }

        public override int Damage
        {
            get { return 56; }
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
            get { return WeaponType.Melee; }
        }

        public Axe()
        {
            _durability = _defaultDurability = 200;
        }
    }
}

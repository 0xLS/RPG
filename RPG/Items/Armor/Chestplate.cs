using System;
using RPG.Interfaces;

namespace RPG.Items.Armor
{
    public class Chestplate : ArmorBase
    {
        #region Properties

        public override string Description
        {
            get { return base._description; }
        }

        public override int Armor
        {
            get { return base._armor; }
        }

        public override int Durability
        {
            get { return base._durability; }
        }

        public override int DefaultDurability
        {
            get { return base._defaultDurability; }
        }

        #endregion

        #region Constructors

        public Chestplate(ArmorMaterial material)
        {
            base._description = $"{material} Chestplate";
            base._armor = 10;
            base._durability = base._defaultDurability = 250;
        }

        #endregion
    }
}


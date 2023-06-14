using System;
using RPG.Interfaces;

namespace RPG.Items.Armor
{
    public class Leggings : ArmorBase
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

        public Leggings(ArmorMaterial material)
        {
            base._description = $"{material} Leggings";
            base._armor = 7;
            base._durability = base._defaultDurability = 200;
        }

        #endregion;
    }
}


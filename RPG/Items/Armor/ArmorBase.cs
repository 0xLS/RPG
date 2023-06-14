using System;
using System.Security.Cryptography;
using RPG.Interfaces;

namespace RPG.Items.Armor
{
    public abstract class ArmorBase : ItemBase, IArmor
    {
        #region Instance fields

        protected int _armor = 0;
        protected string _description = "";
        protected int _durability = 0;
        protected int _defaultDurability = 0;

        #endregion

        #region Properties

        public abstract int Armor { get; }
        public abstract int Durability { get; }
        public abstract int DefaultDurability { get; }

        #endregion

        #region Methods

        public void HandleDurability()
        {
            var durabilityDecrease = RandomNumberGenerator.GetInt32(1, 7);
            _durability -= durabilityDecrease;
            Console.WriteLine($"Decreased weapon durability with {durabilityDecrease}");
        }

        public void FixArmor()
        {
            _durability = _defaultDurability;
        }

        #endregion
    }
}


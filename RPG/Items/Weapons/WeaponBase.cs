using System;
using System.Security.Cryptography;
using RPG.Interfaces;


namespace RPG.Items.Weapons
{
    public abstract class WeaponBase : ItemBase, IWeapon
    {
        #region Instance fields

        protected int _durability = 100;
        protected int _defaultDurability = 100;

        #endregion

        #region Properties

        public abstract int Damage { get; }
        public abstract int Durability { get; }
        public abstract int DefaultDurability { get; }
        public abstract bool IsEnchanted { get; }
        public abstract WeaponType WeaponType { get; }

        #endregion

        #region Methods

        public void HandleDurability()
        {
            var durabilityDecrease = RandomNumberGenerator.GetInt32(1, 7);
            _durability -= durabilityDecrease;
#if DEBUG
            Console.WriteLine($"Decreased weapon durability with {durabilityDecrease}");
#endif
        }

        public void FixWeapon()
        {
            _durability = _defaultDurability;
        }

        #endregion
    }
}


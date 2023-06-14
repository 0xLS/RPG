#pragma warning disable CS8603 // Possible null reference return.
using System;
using RPG.Interfaces;

namespace RPG.Factories
{
    public class ArmorFactory : IArmorFactory
    {
        public IArmor CreateArmor(ArmorType type, ArmorMaterial material)
        {
            switch (material)
            {
                case ArmorMaterial.Iron: return IronArmor(type, material);
                default: return null;

            }
        }

        private IArmor IronArmor(ArmorType type, ArmorMaterial material)
        {
            switch (type)
            {
                case ArmorType.Helmet: return new RPG.Items.Armor.Helmet(material);
                case ArmorType.Chestplate: return new RPG.Items.Armor.Chestplate(material);
                case ArmorType.Leggings: return new RPG.Items.Armor.Leggings(material);
                case ArmorType.Boots: return new RPG.Items.Armor.Boots(material);
                default: return null;
            }
        }
    }
}


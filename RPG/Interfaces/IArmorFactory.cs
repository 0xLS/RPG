using System;
namespace RPG.Interfaces
{
    public interface IArmorFactory
    {
        IArmor CreateArmor(ArmorType type, ArmorMaterial material);
        //IArmor IronArmor(ArmorType type, ArmorMaterial material);
    }
}


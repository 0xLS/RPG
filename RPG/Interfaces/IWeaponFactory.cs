using System;
namespace RPG.Interfaces
{
	public interface IWeaponFactory
	{
		IWeapon CreateWeapon(WeaponList type);
	}
}


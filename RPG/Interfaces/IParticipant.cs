namespace RPG.Interfaces
{
	public interface IParticipant
	{
		string Name { get; }
		double HP { get; }
		bool IsDead { get; }
		int GoldOwned { get; set; }
		List<IArmor> ArmorOwned { get; }
		List<IWeapon> WeaponsOwned { get; }
		double DealDamage();
		void ReceiveDamage(double damagePoints);
	}
}
using RPG.GameManagement;
using RPG.Helpers;
using RPG.Interfaces;

namespace RPG.Participants
{
    public class ParticipantBase : IParticipant
    {
        #region Instance fields

        private int _maxInitHP;
        private int _maxInitGold;
        private int _maxInitArmor;
        private int _maxInitWeapons;
        private double _maxMeleeDmg;

        private double _defaultHP;

        #endregion

        #region Properties

        public virtual string Name { get; }
        public double HP { get; private set; }
        public int GoldOwned { get; set; }
        public List<IArmor> ArmorOwned { get; }
        public List<IWeapon> WeaponsOwned { get; }

        public bool IsDead { get { return HP <= 0; } }

        public double Armor => ArmorOwned.Count == 0 ? 0
            : ArmorOwned.Select(z => z.Armor).Average();

        public PlayerClass pClass { get; protected set; } = PlayerClass.None;

        #endregion

        #region Constructor
        public ParticipantBase(
            string name,
            int maxInitHP,
            int maxInitGold,
            int maxInitArmor,
            int maxInitWeapons,
            double maxMeleeDmg,
            PlayerClass pClass = PlayerClass.None
            )
        {
            Name = name;
            _maxInitHP = maxInitHP;
            _maxInitGold = maxInitGold;
            _maxInitArmor = maxInitArmor;
            _maxInitWeapons = maxInitWeapons;
            _maxMeleeDmg = maxMeleeDmg;
            this.pClass = pClass;
            if (pClass != PlayerClass.None)
            {
                switch (pClass)
                {
                    case PlayerClass.Worrier: _maxInitHP += 500; break;
                    case PlayerClass.Barbarian: _maxInitHP += 1000; break;
                    case PlayerClass.Mage: _maxInitHP += 250; break;
                }
            }
            this.HP = _defaultHP = SetInitHP();
            this.GoldOwned = SetInitGoldOwned();
            this.ArmorOwned = SetInitArmorOwned();
            this.WeaponsOwned = SetInitWeaponsOwned();
        }

        #endregion

        #region Methods

        private double SetInitHP()
        {
            return RNG.RandomDouble(_maxInitHP / 2, _maxInitHP);
        }

        private int SetInitGoldOwned()
        {
            return RNG.RandomInt(_maxInitGold / 2, _maxInitGold);
        }

        List<IArmor> SetInitArmorOwned()
        {
            List<IArmor> initArmor = new List<IArmor>();

            switch (pClass)
            {
                case PlayerClass.Barbarian:
                case PlayerClass.Worrier: initArmor.Add(GameFactory.Instance().ArmorFactory.CreateArmor(ArmorType.Chestplate, ArmorMaterial.Iron)); break;
            }

            for (int i = 0; i < RNG.RandomInt(0, _maxInitArmor); i++)
            {
                int number = RNG.RandomInt(0, 3);

                initArmor.Add(GameFactory.Instance().ArmorFactory.CreateArmor((ArmorType)number, ArmorMaterial.Iron));
            }

            return initArmor;
        }

        List<IWeapon> SetInitWeaponsOwned()
        {
            List<IWeapon> initWeapons = new List<IWeapon>();

            switch (pClass)
            {
                case PlayerClass.Worrier: initWeapons.Add(GameFactory.Instance().WeaponFactory.CreateWeapon(WeaponList.Sword)); break;
                case PlayerClass.Barbarian: initWeapons.Add(GameFactory.Instance().WeaponFactory.CreateWeapon(WeaponList.Mace)); break;
                case PlayerClass.Mage: initWeapons.Add(GameFactory.Instance().WeaponFactory.CreateWeapon(WeaponList.Staff)); break;
            }

            for (int i = 0; i < RNG.RandomInt(0, _maxInitWeapons); i++)
            {
                int number = RNG.RandomInt(0, 10);
                initWeapons.Add(GameFactory.Instance().WeaponFactory.CreateWeapon((WeaponList)number));

            }
            return initWeapons;
        }

        public virtual double DealDamage()
        {
            double bestWeaponDaamage = WeaponsOwned.Count == 0 ? 0 : WeaponsOwned.Select(w => w.Damage).Max();
            double bestDmg = bestWeaponDaamage > _maxMeleeDmg ? bestWeaponDaamage : _maxMeleeDmg;

            double damage = RNG.RandomDouble(_maxMeleeDmg, bestDmg);
            Console.WriteLine($"{Name} dealt {Math.Round(damage, 2)} damage");

            return damage;
        }

        public virtual void ReceiveDamage(double damage)
        {

            double armorPoints = ArmorOwned.Count <= 0 ? 0
                : ArmorOwned.Select(a => a.Armor).Sum() / 100;

            damage = armorPoints <= 0 ? damage
                : damage / (1 + armorPoints);

            HP -= damage;

            Console.WriteLine($"{Name} took {Math.Round(damage, 2)} damage");
        }

        public void Heal() => HP = _defaultHP;

        public virtual void AddArmor(IArmor armor)
        {
            ArmorOwned.Add(armor);
        }

        public virtual void AddWeapon(IWeapon weapon)
        {
            WeaponsOwned.Add(weapon);
        }

        public virtual void ClearItems()
        {
            ArmorOwned.Clear();
            WeaponsOwned.Clear();
        }

        public virtual void DisplayStats()
        {

            double bestWeaponDamage = WeaponsOwned.Count == 0 ? 0 : WeaponsOwned.Select(w => w.Damage).Max();
            int armorPoints = ArmorOwned.Count == 0 ? 0 : ArmorOwned.Select(a => a.Armor).Sum();

            string stats = $"Health: {Math.Round(HP, 2)}/{Math.Round(_defaultHP, 2)}\n" +
                $"Max Melee Damage: {_maxMeleeDmg}\n" +
                $"Best Weapon Damage: {bestWeaponDamage}\n" +
                $"Weapons: {WeaponsOwned.Count}\n" +
                $"Armor Points: {armorPoints}\n" +
                $"Armor Pieces: {ArmorOwned.Count}\n";

            Console.WriteLine(stats);

        }

        public override string ToString()
        {
            string desc = $"{Name} has {GoldOwned} gold, " +
                $"has {HP:F1} hp " +
                $"and has {Armor:F1} Armor\n";

            desc += $"{Name} owns {ArmorOwned.Count} Armor pieces\n";

            foreach (var piece in ArmorOwned)
            {
                desc += $"{piece.Description}\n";
            }

            if (ArmorOwned.Count > 0)
                desc += $"\n";

            desc += $"{Name} owns {WeaponsOwned.Count} Weapons\n";

            foreach (var weapon in WeaponsOwned)
            {
                desc += $"{weapon.Description}\n";
            }

            return desc;
        }

        #endregion
    }
}


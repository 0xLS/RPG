using System;
using RPG.GameManagement;
using RPG.Interfaces;

namespace RPG.Participants
{
    public class Character : ParticipantBase
    {
        #region Instance fields

        public const int maxInitHP = 1;
        public const int maxInitGold = 100;
        public const int maxInitArmor = 3;
        public const int maxInitWeapons = 3;
        public const double maxMeeleDmg = 50;

        #endregion

        #region Properties

        public int Level { get; set; }

        public Movement? movement { get; private set; }

        #endregion

        #region Constructors

        public Character(string name, PlayerClass pClass)
            : base(name, maxInitHP, maxInitGold, maxInitArmor, maxInitWeapons, maxMeeleDmg, pClass)
        {
            Level = 1;
            movement = null;
        }

        #endregion

        #region Methods

        public void LevelUp()
        {
            Level++;
        }

        /*
		* Init our movement this way as doing the original way can fuckup everything and cause a character creation loop
		*/
        public void InitMovement()
        {
            this.movement = this.movement ?? new Movement(this);
        }

        public override void DisplayStats()
        {
            Console.WriteLine("*** Character Stats ***");
            Console.WriteLine($"Class: {base.pClass}");
            base.DisplayStats();
        }

        #endregion
    }
}

using System;
using RPG.Helpers;

namespace RPG.Participants.Creatures
{
    public class CreatureBase : ParticipantBase
    {
        #region Instance fields

        public const int maxInitArmor = 2;
        public static int maxInitWeapons = CMath.PercentageToWeapons();

        #endregion

        #region Constructors

        public CreatureBase(int maxInitHP, double maxDamage)
            : base("", maxInitHP, 0, maxInitArmor, maxInitWeapons, maxDamage)
        {
        }

        #endregion

        #region Methods

        public override string Name
        {
            get { return GetType().Name; }
        }

        public override void DisplayStats()
        {
            Console.WriteLine("*** Creature Stats ***");
            base.DisplayStats();
        }

        #endregion
    }
}

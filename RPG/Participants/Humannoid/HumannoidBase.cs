using System;
using RPG.Helpers;

namespace RPG.Participants.Humannoid
{
    public class HumannoidBase : ParticipantBase
    {
        #region Instance fields

        public const int maxInitGold = 50;
        public const int maxInitArmor = 3;
        public static int maxInitWeapons = CMath.PercentageToWeapons();

        #endregion

        #region Constructors

        public HumannoidBase(string name, int maxInitHP, double maxDamage)
            : base(name, maxInitHP, maxInitGold, maxInitArmor, maxInitWeapons, maxDamage)
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
            Console.WriteLine("*** Humannoid Stats ***");
            base.DisplayStats();
        }

        #endregion
    }
}

using System;

namespace RPG.Participants.Creatures
{
    public class Bear : CreatureBase
    {
        #region Instance fields

        public const int maxInitHP = 500;
        public const double maxMeleeDmg = 25;

        #endregion

        #region Constructors

        public Bear()
            : base(maxInitHP, maxMeleeDmg)
        {

        }

        #endregion

    }
}

using System;

namespace RPG.Participants.Humannoid
{
    public class Goblin : HumannoidBase
    {
        #region Instance fields

        public const int maxInitHP = 78;
        public const double maxDamage = 25;

        #endregion

        #region Constructors
        public Goblin(string name)
            : base(name, maxInitHP, maxDamage)
        {

        }
        #endregion
    }
}

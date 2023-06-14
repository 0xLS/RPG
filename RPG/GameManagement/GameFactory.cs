using System;
using System.Security.Principal;
using RPG.Factories;
using RPG.Interfaces;

namespace RPG.GameManagement
{
    public class GameFactory
    {
        /// <summary>
        /// This is a singleton
        /// GameFactory references the other factories to make everything collected easily in the same place
        /// </summary>

        #region Properties

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static GameFactory _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public IWeaponFactory WeaponFactory { get; set; }
        public IArmorFactory ArmorFactory { get; set; }
        public IParticipantFactory ParticipantFactory { get; set; }

        #endregion

        #region Methods

        public static GameFactory Instance()
        {
            return _instance ?? (_instance = new GameFactory());
        }

        #endregion

        #region Constructors

        private GameFactory()
        {
            WeaponFactory = new WeaponFactory();
            ArmorFactory = new ArmorFactory();
            ParticipantFactory = new ParticipantFactory();
        }

        #endregion
    }
}


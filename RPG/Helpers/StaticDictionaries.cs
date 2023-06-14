using System;
using RPG.Interfaces;

namespace RPG.Helpers
{
    public static class StaticDictionaries
    {
        // Static dictionary for our classes
        public static Dictionary<string, PlayerClass> PlayerClasses { get; } = new Dictionary<string, PlayerClass>() {
            {"Worrior", PlayerClass.Worrier},
            {"Barbarian", PlayerClass.Barbarian},
            {"Mage", PlayerClass.Mage}
        };
    }
}

using System;
using RPG.Interfaces;

namespace RPG.Items
{
    public abstract class ItemBase : IItem
    {
        public abstract string Description { get; }

        public override string ToString()
        {
            return Description;
        }
    }
}

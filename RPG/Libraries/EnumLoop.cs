using System;

namespace RPG.Libraries
{
    class EnumLoop<Key> where Key : struct, IConvertible
    {
        static readonly Key[] arr = (Key[])Enum.GetValues(typeof(Key));
        static internal void ForEach(Action<Key> act)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                act(arr[i]);
            }
        }
    }
}

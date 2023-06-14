#pragma warning disable CS8603 // Possible null reference return.
using RPG.Helpers;
using RPG.Interfaces;
using RPG.Participants;
using RPG.Participants.Creatures;
using RPG.Participants.Humannoid;

namespace RPG.Factories
{
    public class ParticipantFactory : IParticipantFactory
    {
        public Character CreateCharacter(string name, PlayerClass pClass)
        {
            return new Character(name, pClass);
        }

        public IParticipant CreateParticipant(int index = 0)
        {
            index = index == 0 ? RNG.RandomInt(1, 3) : index;
            switch (index)
            {
                case 1: return new Bear();
                case 2: return new Goblin(GenerateName());
                case 3: return new Gnome(GenerateName());
                default: return null;
            }
        }

        private string GenerateName()
        {
            List<string> syllables = new List<string>()
            {
                "xan", "tran", "ser", "mor",
                "houl", "rez", "qex", "sir",
                "vaar"
            };

            string randomName = syllables[RNG.RandomInt(0, syllables.Count() - 1)] +
                syllables[RNG.RandomInt(0, syllables.Count() - 1)] +
                syllables[RNG.RandomInt(0, syllables.Count() - 1)];


            string name = randomName.Substring(0, 1).ToUpper() + randomName.Substring(1, randomName.Length - 1);
            return name;
        }
    }
}


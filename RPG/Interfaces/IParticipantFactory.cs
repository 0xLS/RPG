using System;
using RPG.Participants;

namespace RPG.Interfaces
{
    public interface IParticipantFactory
    {
        Character CreateCharacter(string name, PlayerClass pClass);
        IParticipant CreateParticipant(int index = 0);
    }
}


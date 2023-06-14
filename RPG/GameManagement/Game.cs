using System;
using RPG.Helpers;
using RPG.Interfaces;
using RPG.Participants;

namespace RPG.GameManagement
{
    public class Game
    {
        #region Properties

        private Dictionary<string, Action> actions = new Dictionary<string, Action>();
        private Character player;

        private bool breakLoop = false;

        #endregion

        #region Constructors

        /*
		* Constructor for actions
		*/
        public Game(Character player)
        {
            this.player = player;
            actions.Add("Display stats", () => { player.DisplayStats(); });
            actions.Add("Movement", () => { player.movement?.DoMovement(); });
            actions.Add("Heal", () => { player.Heal(); });
            actions.Add("Exit", () => { Console.WriteLine("Byebye"); breakLoop = true; return; });
        }

        #endregion

        #region Methods

        /*
		* Main game loop
		*/
        public void run()
        {
            while (!breakLoop)
            {
                HandleActions();
            }
        }

        /*
		* Handles actions
		*/
        private void HandleActions()
        {
            var number = InputActions.handleInput(actions);
            actions.ElementAt(number).Value();

            return;
        }

        /*
		* Init fighting (shared from working with the same as the class)
		*/
        public void initFighting(int noOfOpponents)
        {
            Character pCharacter = GameFactory.Instance().ParticipantFactory.CreateCharacter("test_name", PlayerClass.Worrier);
            List<IParticipant> participants = CreateParticipants(noOfOpponents);

            participants.ForEach(participant =>
            {
                if (!participant.IsDead && !pCharacter.IsDead)
                {
                    Fighting.fightParticipant(pCharacter, participant);
                }
            });
        }

        /*
		* Create X amount of opponents
		*/
        private List<IParticipant> CreateParticipants(int noOfOpponents)
        {
            List<IParticipant> participants = new List<IParticipant>();
            for (int i = 0; i < noOfOpponents; i++)
            {
                participants.Add(GameFactory.Instance().ParticipantFactory.CreateParticipant());
            }

            return participants;
        }

        #endregion
    }
}

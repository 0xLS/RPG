using System;
using RPG.Helpers;
using RPG.Interfaces;
using RPG.Libraries;
using RPG.Participants;

namespace RPG.GameManagement
{
    public class Movement
    {
        #region Instance fields

        private Dictionary<string, Action> movementActions = new Dictionary<string, Action>();
        private Character character;
        private Dictionary<string, Character> characters = new Dictionary<string, Character>();
        private bool BreakLoop = false;

        #endregion

        #region Properties

        protected int _y, _x = 0;

        public int y
        {
            get { return _y; }
        }

        public int x
        {
            get { return _x; }
        }

        #endregion

        #region Constructors

        public Movement(Character character)
        {
            this.character = character;
            characters.Add(character.Name, character);

            int pAmount = 1;

            EnumLoop<PlayerClass>.ForEach(pClass =>
            {
                if (pClass != this.character.pClass && pClass != PlayerClass.None && pAmount < 3)
                {
                    pAmount++;
                    var newPlayer = new Character($"Player {pAmount}", pClass);
                    characters.Add(newPlayer.Name, newPlayer);
                }
            });

            movementActions.Add("Move Up", this.MoveUp);
            movementActions.Add("Move Down", this.MoveDown);
            movementActions.Add("Move Right", this.MoveRight);
            movementActions.Add("Move Left", this.MoveLeft);
            movementActions.Add("Return to menu", () => { Console.WriteLine("Cancelled movement"); BreakLoop = true; });
        }

        #endregion

        #region Methods

        /*
		* Movement loop
		*/
        public void DoMovement()
        {
            BreakLoop = false;

            while (!BreakLoop)
            {
                HandleMove();
            }

            return;

        }

        /*
		* Handles the movement of the character
		*/
        private void HandleMove()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Current Position");
            Console.WriteLine($"X: {x}\nY: {y}");
            Console.WriteLine("-------------------------------------------------------------------\n");

            var number = InputActions.handleInput(movementActions, "Select a movement action: ");
            movementActions.ElementAt(number).Value();
            if (BreakLoop)
                return;

            Thread.Sleep(1500);

            DoFightingCalculations();
        }

        /*
		* Set position of player to a custom one
		*/
        private void SetPosition(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /*
		* Move up
		*/
        private void MoveUp()
        {
            Console.WriteLine("Moved up");
            _y++;
        }

        /*
        * Move down 
        */
        private void MoveDown()
        {
            Console.WriteLine("Moved down");
            _y--;
        }

        /*
        * Move right 
        */
        private void MoveRight()
        {
            Console.WriteLine("Moved right");
            _x++;
        }

        /*
        * Move left 
        */
        private void MoveLeft()
        {
            Console.WriteLine("Moved left");
            _x--;
        }

        /*
		* Calculates the chance of fighting a enemy & init the fight
		*/
        private void DoFightingCalculations()
        {
            bool shouldFight = RNG.CoinFlip();
            if (!shouldFight)
            {
                Console.Clear();
                return;
            }

            Console.Clear();

            IParticipant enemy = GameFactory.Instance().ParticipantFactory.CreateParticipant();
            Console.WriteLine($"You've encountered a wild {enemy.Name}");

            Thread.Sleep(2000);

            Fighting.fightParticipant(characters, enemy);

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }

        #endregion
    }
}

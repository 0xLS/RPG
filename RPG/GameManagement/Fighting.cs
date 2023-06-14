using System;
using RPG.Helpers;
using RPG.Interfaces;
using RPG.Participants;

namespace RPG.GameManagement
{
    public static class Fighting
    {
        /*
		* Fight apponent
		*/
        public static void fightParticipant(Dictionary<string, Character> pCharacters, IParticipant apponent)
        {
            // Get our "main" character
            Character mainCharacter = pCharacters.ElementAt(0).Value;
            printStartInfo(mainCharacter, apponent);

            // Init our variables
            IParticipant? attacker = null;
            IParticipant? victim = null;
            bool allDead = false;

            // While loop 
            while (!allDead && !apponent.IsDead)
            {
                // Chance of who is the fighter & who is the apponent
                int chance = RNG.RandomInt(1, 10);
                attacker = chance <= 5 ? mainCharacter : apponent;
                victim = chance >= 6 ? mainCharacter : apponent;

                // Damage calculations based on if the attacker is players or creatures/humannionds
                var damage = attacker.GetType() != mainCharacter.GetType() ? attacker.DealDamage()
                    : pCharacters.Values.Select(c => c.IsDead ? 0 : c.DealDamage()).Sum();

                // Recive damage based on if the victim is a player or creature/humannionds
                if (victim.GetType() != mainCharacter.GetType())
                    victim.ReceiveDamage(damage);
                else
                    foreach (var c in pCharacters.Values)
                    {
                        c.ReceiveDamage(damage / 3);
                    }

                Console.WriteLine();

                // Check if all characters are dead
                int amountDead = 0;
                foreach (var c in pCharacters.Values)
                {
                    if (c.IsDead)
                        amountDead++;
                }

                allDead = amountDead == pCharacters.Count();

            }

            // if the attacker is a player then loot the apponent
            if (attacker?.GetType() == mainCharacter.GetType())
            {
                lootApponent(mainCharacter, apponent);
            }

            printEndInfo(mainCharacter, apponent);
        }

        /*
		* Allow legacy support with only 1 character as the pCharacter
		*/
        public static void fightParticipant(Character pCharacter, IParticipant apponent)
        {
            var dictionary = new Dictionary<string, Character>() {
                {pCharacter.pClass.ToString(), pCharacter}
            };

            fightParticipant(dictionary, apponent);
        }

        /*
		* Loot the apponent if we won
		*/
        private static void lootApponent(Character pCharacter, IParticipant apponent)
        {
            pCharacter.GoldOwned += apponent.GoldOwned;
            foreach (var item in apponent.ArmorOwned)
            {
                pCharacter.AddArmor(item);
            }
            foreach (var item in apponent.WeaponsOwned)
            {
                pCharacter.AddWeapon(item);
            }
#if DEBUG
            //Console.WriteLine($"\nLooted dead apponent and got {apponent.GoldOwned} gold, {apponent.ArmorOwned.Count} armor pieces and {apponent.WeaponsOwned.Count} weapons\n");
#endif
        }

        /*
		* Print start info of the fight
		*/
        private static void printStartInfo(Character pCharacter, IParticipant participants)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            Console.WriteLine("Fight is starting....");
            Console.WriteLine(pCharacter);
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }

        /*
		* Print end info of the fight
		*/
        private static void printEndInfo(Character pCharacter, IParticipant apponent)
        {
            IParticipant winner = !pCharacter.IsDead ? pCharacter : apponent;

            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            Console.WriteLine("Fight is over....");
            Console.WriteLine();

            Console.WriteLine("Results:");
            Console.WriteLine($"{winner.Name} Has won");
            if (!pCharacter.IsDead)
                Console.WriteLine(winner);
            Console.WriteLine("-------------------------------");
        }
    }
}

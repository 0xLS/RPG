using System;

namespace RPG.Helpers
{
    public class InputActions
    {
        /*
		* Handle the input from our actions
		*/
        public static int handleInput<T>(Dictionary<string, T> actions, string message = "Please select a action: ")
        {
            for (int i = 0; i < actions.Count; i++)
            {
                Console.WriteLine($"{i}: {actions.ElementAt(i).Key}");
            }

            Console.Write(message);
            var input = Console.ReadLine();
            int number;
            if (!(input != null && input != "" && Int32.TryParse(input, out number)))
                goto INVALIDNUMBER;

            if (number >= actions.Count)
                goto INVALIDNUMBER;

            goto SUCCESS;

        INVALIDNUMBER:
            Console.WriteLine("Invalid input. Please select a valid action.");
            return handleInput(actions);

        SUCCESS:
            Console.WriteLine();
            return number;
        }
    }
}

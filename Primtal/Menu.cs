using System;

namespace Primtal
{
    static class Menu
    {
        /// <summary>
        /// Runs the program and prints the menu
        /// </summary>
        internal static void Run()
        {
            //instance of PrimeNumber
            PrimeNumber pm = new();
            var errorMsg = "";
            var endProgram = false;
            //Menu items
            string[] mainMenuItems = { "Kontrollera om ett tal är ett Primtal", "lägg till nästa primtal", "Lista alla sparade primtal", "Avsluta programmet" };
            do
            {
                Console.Clear();
                Console.WriteLine($"\t{errorMsg}");

                //Prints menu
                for (int i = 0; i < mainMenuItems.Length; i++)
                {
                    Console.WriteLine($"\t{i + 1}. {mainMenuItems[i]}");
                }
                Console.Write("\n\tGör ditt val /> ");
                //Checks if number been pressed
                var successfullyConverted = int.TryParse(Console.ReadLine(), out int choice);

                errorMsg = default;
                int number;

                //Switch for menu choice
                switch (choice)
                {
                    //If 0 pressed or if string is typed in
                    case 0:
                        if (successfullyConverted)
                        {
                            errorMsg = "Felaktigt menyval";
                        }
                        else
                        {
                            errorMsg = "Felaktig inmatning, endast nummer tillåna";
                        }
                        break;
                    case 1:
                        //Recieves validated input from user
                        number = InputNumber();
                        //Calculates if number is Prime number 
                        var isPrimenumber = pm.Calculate(number);

                        //If number is primenumber
                        if (isPrimenumber)
                        {
                            Console.WriteLine($"\tTalet {number} är ett primtal. Om det inte sparats tidigare, så ligger det nu i din lista.");
                        }
                        else
                        {
                            Console.WriteLine($"\tTalet {number} är inget primtal.");
                        }
                        Console.WriteLine("\tTryck enter för att fortsätta.");
                        Console.ReadKey();
                        break;
                    case 2:
                        //Calculate the next prime number
                        number = pm.CalculateNextPrimeNumber();
                        errorMsg = $"\n\tNästa Primtal, ({number}), har lagts till i listan";
                        break;
                    case 3:
                        //Lists all prime numbers added to the list
                        pm.ListPrimeNumbers();
                        break;
                    case 4:
                        //Quit program
                        endProgram = true;
                        break;
                    default:
                        //Default error message if user presses number above number of menu options in the menu.
                        errorMsg = "Felaktigt menyval";
                        break;
                }
            } while (!endProgram);
        }

        /// <summary>
        /// Takes a input from the user, and validates so it's above 0 and not a string.
        /// </summary>
        /// <returns>Returns valid integer (above 0).</returns>
        private static int InputNumber()
        {
            var errorMsg = default(string);
            int input;
            var wrongInput = true;

            do
            {
                Console.Clear();
                Console.WriteLine("\n\tPrimtal?");
                Console.WriteLine("\t" + errorMsg);
                Console.Write("\tKontrollera det här talet/> ");
                var isNumber = int.TryParse(Console.ReadLine().Replace(" ", ""), out input);
                if (isNumber && input > 0)
                {
                    wrongInput = false;
                    errorMsg = default;
                }
                else if (input < 1 && isNumber)
                {
                    errorMsg = "Du behöver mata in ett tal större än 0";
                }
                else
                {
                    errorMsg = "Felaktig inmatning, endast heltal är giltiga";
                }

            } while (wrongInput);

            return input;
        }
    }
}
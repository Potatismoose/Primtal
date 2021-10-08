using System;
using System.Collections.Generic;

namespace Primtal
{
    class PrimeNumber
    {
        /// <summary>
        /// List with users primenumbers
        /// </summary>
        SortedList<int, int> primeNumbers = new();

        /// <summary>
        /// Calculates if the number is a primenumber
        /// </summary>
        /// <param name="number">Takes a user input as a number to check for prime number validity</param>
        /// <returns>Returns true if number is a prime number, false if not</returns>
        internal bool Calculate(int number)
        {
            //test for edgecase if number is 0 or less
            if (number <= 1)
            {
                return false;
            }
            //Check if number is a even number but not 2
            else if (number % 2 == 0 && number !=2)
            {
                return false;
            }
            //Takes the square root from the number and checks
            //dividability with all numbers from 2 up til result from square root.
            //If dividable with a number, return false.
            //Else check if number already been added and add number if it does not already exists in list
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            if (!primeNumbers.ContainsKey(number))
            {
                primeNumbers.Add(number, number);
            }
            return true;
        }

        /// <summary>
        /// Simple method for printing out the list if it contains any items.
        /// Else print a message saying the list is empty.
        /// </summary>
        internal void ListPrimeNumbers()
        {
            Console.WriteLine();
            
            if (primeNumbers.Count > 0)
            {
                Console.WriteLine("\tHär är de primtal du angett eller genererat:");
                foreach (var item in primeNumbers)
                {
                    Console.WriteLine("\t" + item.Value);
                }
            }
            else
            {
                Console.WriteLine("\n\tInga nummer finns i listan");
            }

            Console.WriteLine("\n\tTryck valfri knapp för att fortsätta...");
            Console.ReadKey();
        }

        /// <summary>
        /// Method that takes the last integer in the sorted list and calculates the next prime number
        /// </summary>
        /// <returns>Returns the next integer that is a prime number</returns>
        internal int CalculateNextPrimeNumber(){
            int highestNumber;
            if (primeNumbers.Count == 0){
                highestNumber = default;
            }
            else{
                //Takes the last number (value) of the sorted list and assigns it value to highestNumber
                 highestNumber = primeNumbers.Values[^1];
            }
            //Loop that runs until it finds the next prime number.
            while (true)
            {
                if (Calculate(++highestNumber))
                {
                    return highestNumber;
                }
            }

        }
    }
}
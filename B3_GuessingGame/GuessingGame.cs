using System;
using System.Media;
///-----------------------------------------------------------------------------
///   Namespace:    B3_GuessingGame
///   Description:  Guess a psuedo-randomly generated number
///   Author:       Derek Wolters                
///   Date:         3.29.17
///   Revision History:
///   Name:           Date:        Description:
///-----------------------------------------------------------------------------

namespace B3_GuessingGame
{
    class GuessingGame
    {
        static int minNum = 1;
        static int maxNum = 100;

        static void Main(string[] args)
        {
            //initialize variables
            bool keepGoing = true;
           
            Console.WriteLine("Guessing game of fun numbers!");
            Console.WriteLine("Guess a number from " + minNum + " to " +
                maxNum + "!");

            while (keepGoing)
            {
                //generate random number
                int randNum = genRandNum();

                //get input, calculate and display the results
                CheckInput(GetInput(), randNum);

                //exit program               
                if (ExitProgram())
                {
                    Console.WriteLine("Goodbye!");
                    System.Threading.Thread.Sleep(1000);
                    SystemSounds.Beep.Play();
                    break;
                }
            }
        }

        //get the user's number
        public static int GetInput()
        {
            string input = "";
            int temp;

            input = Console.ReadLine();

            if (!int.TryParse(input, out temp))
            {
                //check that input is an integer & ask for reentry if not
                Console.WriteLine("Input should be a whole number. " +
                    "Try again.");
                return GetInput();
            }
            else if (temp < minNum || temp > maxNum)
            {
                //check that input is withing range & ask for reentry if not
                Console.WriteLine("Input should between 1 and 100");
                return GetInput();
            }
            else { return temp; }
        }

        //generate random number
        public static int genRandNum()
        {
            Random rnd = new Random();
            int randNum = rnd.Next(minNum, maxNum);
            //Console.WriteLine("Secret: " + randNum);
            return randNum;
        }

        //check if user's number is too high or too low
        public static void CheckInput(int num, int randNum)
        {                   
            if (num < randNum)
            {
                Console.WriteLine("Too low - Guess again!");
                CheckInput(GetInput(), randNum);
            }
            else if(num > randNum)
            {
                Console.WriteLine("Too high, Guess again!");
                CheckInput(GetInput(), randNum);
            }
            else
            {
                Console.WriteLine("You got it! The number was " + randNum +
                    ".");
            }
        }

        //exit the program when the user wants to
        public static Boolean ExitProgram()
        {
            string xitChoice = "";

            Console.WriteLine("Do you want to continue? Enter Y or N.");

            xitChoice = Console.ReadLine().ToUpper();

            while (xitChoice != "N" && xitChoice != "Y")
            {
                Console.WriteLine("Not a vaid answer. Do you want to " +
                    "continue? Enter Y or N.");
                xitChoice = Console.ReadLine().ToUpper();
            }

            return xitChoice == "N" ? true : false;
        }
    }
}
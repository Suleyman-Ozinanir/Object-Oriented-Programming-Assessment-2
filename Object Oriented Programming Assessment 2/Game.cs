using System;
using System.Media;
using System.Xml.Schema;

namespace Object_Oriented_Programming_Assessment_2
{
    public class Game
    {
        // variables that are shared among Sevensout and ThreeOrMore
        Die Die = new Die();
        public int Turn;
        public int Total_1;
        public int Total_2;
        public int Roll_0;
        public int Roll_1;
        public int Roll_2;
        public int Roll_3;
        public int Roll_4; 

        internal class SevensOut : Game
        {  
            public void sevens_out()
            {
                // initial two rolls set to 0 to enter while loop
                Roll_1 = 0;
                Roll_2 = 0;

                while (Roll_1 + Roll_2 != 7)
                {
                    // roll dice
                    Roll_1 = Die.Roll();
                    Roll_2 = Die.Roll();

                    // determining the points gained from the thrown dice
                    if (Roll_1 == Roll_2 && Roll_1 + Roll_2 != 7)
                    {
                        Total_1 += 2 * (Roll_1 + Roll_2);
                        Turn++;
                        Console.WriteLine("Roll " + Turn + ": [" + Roll_1 + "," + Roll_2 + "]" + " (Total=" + Total_1 + ")");
                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                    else if (Roll_1 + Roll_2 != 7)
                    {
                        Total_1 += Roll_1 + Roll_2;
                        Turn++;
                        Console.WriteLine("Roll " + Turn + ": [" + Roll_1 + "," + Roll_2 + "]" + " (Total=" + Total_1 + ")");
                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();

                    }
                }
                // ending Player 1's turn when they roll a 7
                Console.WriteLine("You rolled a seven!");
                Console.WriteLine("Player 1 end total is " + Total_1);
                Console.WriteLine("");
                Console.WriteLine("Press ENTER to pass turn...");
                Console.ReadLine();

                // repeating the same code for Player 2's turn
                Roll_1 = 0;
                Roll_2 = 0;
                
                while (Roll_1 + Roll_2 != 7)
                {
                    Roll_1 = Die.Roll();
                    Roll_2 = Die.Roll();

                    if (Roll_1 == Roll_2 && Roll_1 + Roll_2 != 7)
                    {
                        Total_2 += 2 * (Roll_1 + Roll_2);
                        Turn++;
                        Console.WriteLine("Roll " + Turn + ": [" + Roll_1 + "," + Roll_2 + "]" + " (Total=" + Total_2 + ")");
                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                    else if (Roll_1 + Roll_2 != 7)
                    {
                        Total_2 += Roll_1 + Roll_2;
                        Turn++;
                        Console.WriteLine("Roll " + Turn + ": [" + Roll_1 + "," + Roll_2 + "]" + " (Total=" + Total_2 + ")");
                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();

                    }
                }
                Console.WriteLine("You rolled a seven!");
                Console.WriteLine("Player 2 end total is " + Total_2);
                Console.WriteLine("");
                Console.WriteLine("Press ENTER to proceed to results...");
                Console.ReadLine();

                if (Total_1 > Total_2)
                {
                    Console.WriteLine("Player 1 wins!");
                }
                else if (Total_1 == Total_2)
                {
                    Console.WriteLine("It's a tie!");
                }
                else
                {
                    Console.WriteLine("Player 2 wins!");
                }
            }



        }
        internal class ThreeOrMore : Game
        {

            public void three_or_more()
            {
                Turn = 1;
                Total_1 = 0;
                Total_2 = 0;
                // two players alternate turns so long as both of them have score < 20
                while (Total_1 < 20 && Total_2 < 20)
                {
                    // initialising variables & rolls
                    int Roll_0 = Die.Roll();
                    int Roll_1 = Die.Roll();
                    int Roll_2 = Die.Roll();
                    int Roll_3 = Die.Roll();
                    int Roll_4 = Die.Roll();
                    int[] Roll = { Roll_0, Roll_1, Roll_2, Roll_3, Roll_4 };
                    int Points = 0;
                    int Highest_Row = 1;
                    int reacurring_n;

                    for (int x = 0; x < Roll.Length; x++)
                    {
                        Console.Write(Roll[x] + ", ");

                    }
                    // using an array and nested for loops to find the most often reacurring number
                    // most reacurring number as represented by Highest_Row
                    Console.WriteLine("");
                    reacurring_n = Roll[0];
                    for (int i = 0; i < 5; i++)
                    {
                        int Row = 1;
                        for (int j = (1 + i); j < 5; j++)
                        {
                            if (Roll[i] == Roll[j])
                            {
                                Row++;
                            }
                        }

                        if (Row > Highest_Row)
                        {
                            reacurring_n = Roll[i];
                            Highest_Row = Row;
                        }
                    }
                    // giving the player the option to reroll if two of a kind
                    if (Highest_Row >= 2)
                    {
                        Console.WriteLine("The most reacurring number is " + reacurring_n);
                        Console.WriteLine("Would you like to reroll?");
                        Console.WriteLine("");
                        Console.WriteLine("1 - Yes");
                        Console.WriteLine("2 - No");
                        Console.WriteLine("");
                        string input = Console.ReadLine();
                        Console.WriteLine("");

                        if (input == "1")
                        {
                            Console.WriteLine("All or the remaining dice?");
                            Console.WriteLine("");
                            Console.WriteLine("1 - All");
                            Console.WriteLine("2 - Remaining");
                            Console.WriteLine("");
                            input = Console.ReadLine();
                            Console.WriteLine("");

                            if (input == "1")
                            {
                                Highest_Row = reroll();
                            }

                            else if (input == "2")
                            {
                                Highest_Row = reroll_remaining(reacurring_n, Highest_Row);
                            }
                        }
                    }
                    // calculating score for 3, 4 and 5 in a row
                    // turn number is used to deduce which player's turn it is, that player recieves the points
                    if (Highest_Row == 3)
                    {
                        Console.WriteLine("3 of a kind");
                        if (Turn % 2 == 0)
                        {
                            Points += 3;
                            Total_2 += 3;
                            Console.WriteLine("Player 2 Points: " + Total_2);
                            Console.WriteLine("");
                        }
                        else
                        {
                            Total_1 += 3;
                            Console.WriteLine("Player 1 Points: " + Total_1);
                            Console.WriteLine("");
                        }

                    }

                    else if (Highest_Row == 4)
                    {
                        Console.WriteLine("4 of a kind");
                        if (Turn % 2 == 0)
                        {
                            Points += 6;
                            Total_2 += 6;
                            Console.WriteLine("Player 2 Points: " + Total_2);
                            Console.WriteLine("");
                        }
                        else
                        {
                            Points += 6;
                            Total_1 += 6;
                            Console.WriteLine("Player 1 Points: " + Total_1);
                            Console.WriteLine("");
                        }
                    }

                    else if (Highest_Row == 5)
                    {
                        Console.WriteLine("5 of a kind");
                        if (Turn % 2 == 0)
                        {
                            Points += 12;
                            Total_2 += 12;
                            Console.WriteLine("Player 2 Points: " + Total_2);
                            Console.WriteLine("");
                        }
                        else
                        {
                            Points += 12;
                            Total_1 += 12;
                            Console.WriteLine("Player 1 Points: " + Total_1);
                            Console.WriteLine("");
                        }
                    }

                    else
                    {
                        if (Turn % 2 == 0)
                        {
                            Console.WriteLine("Player 2 Points: " + Total_2);
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Player 1 Points: " + Total_1);
                            Console.WriteLine("");
                        }
                    }
                    // checking score to see if either player wins
                    if (Total_1 >= 20)
                    {
                        Console.WriteLine("Player 1 wins!");
                        Console.WriteLine("");
                    }
                    else if (Total_2 >= 20)
                    {
                        Console.WriteLine("Player 2 wins!");
                        Console.WriteLine("");
                    }
                    Turn++;


                }
            }
            // reroll every dice method
            internal int reroll()
            {
                Roll_0 = Die.Roll();
                Roll_1 = Die.Roll();
                Roll_2 = Die.Roll();
                Roll_3 = Die.Roll();
                Roll_4 = Die.Roll();
                int[] Roll = { Roll_0, Roll_1, Roll_2, Roll_3, Roll_4 };
                int Highest_Row = 1;
                int reacurring_n;

                for (int x = 0; x < Roll.Length; x++)
                {
                    Console.Write(Roll[x] + ", ");

                }
                Console.WriteLine("");

                reacurring_n = Roll[0];

                for (int i = 0; i < 5; i++)
                {
                    int Row = 1;
                    for (int j = (1 + i); j < 5; j++)
                    {
                        if (Roll[i] == Roll[j])
                        {
                            Row++;
                        }
                    }

                    if (Row > Highest_Row)
                    {
                        reacurring_n = Roll[i];
                        Highest_Row = Row;
                    }
                }
                return Highest_Row;
            }
            // this method rerolls the remaining dice after the most commonly occurring numbers are kept
            
            internal int reroll_remaining(int reacurring_n, int Highest_Row)
            {
                // redefining the size of the new, smaller array
                Die Die = new Die();
                int remaining_dice = 5 - Highest_Row;
                int[] Roll = new int[remaining_dice];

                // for loop looking for the Highest_Row in the rerolled dice
                for (int x = 0; x < remaining_dice; x++)
                {
                    Roll[x] = Die.Roll();
                    if (Roll[x] == reacurring_n)
                    {
                        Highest_Row++;
                    }
                }

                for (int x = 0; x < Roll.Length; x++)
                {
                    Console.Write(Roll[x] + ", ");
                }
                Console.WriteLine("");

                return Highest_Row;


            }
        }
    }
}

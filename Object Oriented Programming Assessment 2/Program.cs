using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Oriented_Programming_Assessment_2
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            // setting up the menu
            bool on_off = true;
            string input;            
            Console.WriteLine("Welcome.");
            while (on_off == true) 
            {
                Console.WriteLine("");
                Console.WriteLine("Type in the corresponding number to navigate.");
                Console.WriteLine("1 - Sevens Out");
                Console.WriteLine("2 - Three or More");
                Console.WriteLine("3 - Testing");
                Console.WriteLine("4 - Exit");
                Console.WriteLine("");
                input = Console.ReadLine();
                Console.WriteLine("");

                // if statements for accepting input
                if (input == "1")
                {
                    Game.SevensOut sevensout = new Game.SevensOut();
                    sevensout.sevens_out();
                }
                else if (input == "2")
                {
                    Game.ThreeOrMore threeOrMore = new Game.ThreeOrMore();
                    threeOrMore.three_or_more();
                }
                else if (input == "3") 
                { 
                    Test test = new Test();
                    test.test();
                           
                }
                else if (input == "4")
                {
                    on_off = false;
                }
                // error message if an invalid input is entered
                else
                {
                    Console.WriteLine("Please enter a valid input.");
                }
            }
        }
    }
}

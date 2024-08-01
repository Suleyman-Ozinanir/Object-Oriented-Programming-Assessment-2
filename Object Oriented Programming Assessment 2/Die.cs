using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Oriented_Programming_Assessment_2
{
    public class Die
    {
        // variable
        private int dice_roll;
        public int Dice_Roll 
        { 
            get { return dice_roll; } 
            set { dice_roll = value;}
        }

        // setting up the die method with Random
        private Random rnd = new Random();
        public int Roll()
        {
            int dice_Roll = rnd.Next(1, 7);
            return dice_Roll;
        }

    }
}

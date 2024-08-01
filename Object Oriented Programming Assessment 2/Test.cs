using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Object_Oriented_Programming_Assessment_2
{
    internal class Test
    {
        public void test()
        {
            Game game = new Game();
            Game.SevensOut sevensout = new Game.SevensOut();
            Debug.Assert(sevensout.Total_1 == 2 * (sevensout.Roll_1 + sevensout.Roll_2) &&
                sevensout.Total_2 == 2 * (sevensout.Roll_1 + sevensout.Roll_2));
        }
    }
}

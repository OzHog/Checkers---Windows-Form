using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.Checkers.GameLogic
{
    public class DidNotMoveToEatException : Exception
    {
        public override string ToString()
        {
            return "You Must Pick A Move That Eat Enemy Men";
        }

    }
}

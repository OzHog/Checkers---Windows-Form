using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.Checkers.GameLogic
{
    public class PlayerMustToEatAgainException : Exception
    {
        public override string ToString()
        {
            return "You Must To Eat Again";
        }
    }
}

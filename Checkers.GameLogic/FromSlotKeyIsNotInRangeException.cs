using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.Checkers.GameLogic
{
    public class FromSlotKeyIsNotInRangeException : Exception
    {
        public override string ToString()
        {
            return "This Move Is Not Possible";
        }
    }
}

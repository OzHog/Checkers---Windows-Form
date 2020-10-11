using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.Checkers.GameLogic
{
    public class ToSlotKeyIsNotInRangeException : SlotKeyIsNotInRangeException
    {

        public ToSlotKeyIsNotInRangeException(string i_ToSlotKey)
            : base(i_ToSlotKey)
        {
        }

        public override string ToString()
        {
            return "Indexes Are Not In Board Range";
        }

    }
}

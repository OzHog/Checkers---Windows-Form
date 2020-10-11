using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.Checkers.GameLogic
{
    public class SlotKeysAreNotInRangeException : Exception
    {
        private readonly string r_FromSlotKey;
        private readonly string r_ToSlotKey;

        public SlotKeysAreNotInRangeException(string i_FromSlotKey, string i_ToSlotKey)
        {
            r_FromSlotKey = i_FromSlotKey;
            r_ToSlotKey = i_ToSlotKey;
        }

        public string FromSlotKey
        {
            get
            {
                return r_FromSlotKey;
            }
        }

        public string ToSlotKey
        {
            get
            {
                return r_ToSlotKey;
            }
        }

        public override string ToString()
        {
            return "Indexes Are Not In Board Range";
        }
    }
}

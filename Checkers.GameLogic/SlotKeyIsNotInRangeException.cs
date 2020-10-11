using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.Checkers.GameLogic
{
    public class SlotKeyIsNotInRangeException : Exception
    {
        private readonly string r_SlotKey;

        public SlotKeyIsNotInRangeException(string i_SlotKey)
        {
            r_SlotKey = i_SlotKey;
        }

        public string SlotKey
        {
            get
            {
                return r_SlotKey;
            }
        }

        public override string ToString()
        {
            return string.Format("Index: {0}, Is Not In Board Rang", r_SlotKey);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C20_Ex05_Oz_203596275
{
    internal class CheckerMenAnimationSelectedEventArgs : EventArgs
    {
        private readonly string r_SlotKey;

        internal CheckerMenAnimationSelectedEventArgs(string i_SlotKey)
        {
            r_SlotKey = i_SlotKey;
        }

        internal string SlotKey
        {
            get
            {
                return r_SlotKey;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex05.Checkers.Logic
{
    public class SlotContentEventArgs : EventArgs
    {
        private readonly string r_Key;
        private readonly CheckersMen? r_Content;

        public SlotContentEventArgs(string i_SlotKey, CheckersMen? i_SlotContent)
        {
            r_Content = i_SlotContent;
            r_Key = i_SlotKey;
        }

        public string Key
        {
            get
            {
                return r_Key;
            }
        }

        public CheckersMen? Content
        {
            get
            {
                return r_Content;
            }
        }
    }
}

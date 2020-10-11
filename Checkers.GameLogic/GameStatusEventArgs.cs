using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex05.Checkers.Logic;

namespace Ex05.Checkers.GameLogic
{
    public class GameStatusEventArgs : EventArgs
    {
        private readonly object r_Data;

        public GameStatusEventArgs()
            : base()
        {
            r_Data = null;
        }

        public GameStatusEventArgs(DataGameOver i_DataGameOver)
        {
            r_Data = i_DataGameOver;
        }

        public DataGameOver? DataGameOver
        {
            get
            {
                return r_Data as DataGameOver?;
            }
        }

        public object Data
        {
            get
            {
                return r_Data;
            }
        }
    }
}

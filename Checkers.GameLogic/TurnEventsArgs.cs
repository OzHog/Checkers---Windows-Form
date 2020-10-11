using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex05.Checkers.Logic;

namespace Ex05.Checkers.GameLogic
{
    public class TurnEventsArgs : EventArgs
    {
        private readonly CheckersMen r_RegularCheckersMen;
        private readonly CheckersMen r_KingCheckersMen;
        private readonly bool r_PlayerTurnComputer;

        public TurnEventsArgs(
            CheckersMen i_RegularCheckersMen,
            CheckersMen i_KingCheckersMen,
            bool i_PlayerTurnComputer)
        {
            r_RegularCheckersMen = i_RegularCheckersMen;
            r_KingCheckersMen = i_KingCheckersMen;
            r_PlayerTurnComputer = i_PlayerTurnComputer;
        }

        public CheckersMen RegularCheckersMen
        {
            get
            {
                return r_RegularCheckersMen;
            }
        }

        public CheckersMen KingCheckersMen
        {
            get
            {
                return r_KingCheckersMen;
            }
        }

        public bool PlayerTurnComputer
        {
            get
            {
                return r_PlayerTurnComputer;
            }
        }
    }
}

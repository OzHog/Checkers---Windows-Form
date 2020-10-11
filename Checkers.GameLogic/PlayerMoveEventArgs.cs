using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex05.Checkers.Logic;

namespace Ex05.Checkers.GameLogic
{
    public class PlayerMoveEventArgs : EventArgs
    {
        private readonly PlayerMove r_PlayerMove;

        internal PlayerMoveEventArgs(PlayerMove i_PlayerMove)
        {
            r_PlayerMove = i_PlayerMove;

        }

        public PlayerMove PlayerMove
        {
            get
            {
                return r_PlayerMove;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.Checkers.Logic
{
    public struct Direction
    {
        private int m_Forward;
        private  int m_Backward;
        private  int m_Left;
        private  int m_Right;
        
        public Direction(int i_Forward, int i_Backward, int i_Left, int i_Right)
        {
            m_Forward = i_Forward;
            m_Backward = i_Backward;
            m_Left = i_Left;
            m_Right = i_Right;
        }

        public int Forward
        {
            get
            {
                return m_Forward;
            }
        }
  
        public int Backward {
            get
            {
                return m_Backward;
            }
        }

        public int Left
        {
            get
            {
                return m_Left;
            }
        }

        public int Right
        {
            get
            {
                return m_Right;
            }
        }
    }
}

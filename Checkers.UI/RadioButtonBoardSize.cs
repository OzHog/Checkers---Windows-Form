using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C20_Ex05_Oz_203596275
{
    public class RadioButtonBoardSize : RadioButton
    {
        private int m_Value;

        public RadioButtonBoardSize()
        {
            m_Value = 0;
            setText();
        }

        public int Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = value;
                setText();
            }
        }

        private void setText()
        {
            this.Text = string.Format("{0} x {1}", m_Value, m_Value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C20_Ex05_Oz_203596275
{
    public class TextBoxPlayerName : TextBox
    {
        private string m_Value;
        private string m_EnableDefaultNameWhen;
        private string m_UnEnableDefaultNameWhen;

        public TextBoxPlayerName()
        {
            m_Value = "Player";
            m_EnableDefaultNameWhen = "Player";
            m_UnEnableDefaultNameWhen = "Player";
        }

        internal string Value
        {
            get
            {
                return m_Value;
            }
        }

        public string DefaultNameWhenEnable
        {
            get
            {
                return m_EnableDefaultNameWhen;
            }
            set
            {
                m_EnableDefaultNameWhen = value;
                setDefaultTextAndValue();
            }
        }

        public string DefaultNameWhenUnEnable
        {
            get
            {
                return m_UnEnableDefaultNameWhen;
            }
            set
            {
                m_UnEnableDefaultNameWhen = value;
                setDefaultTextAndValue();
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if(this.Text.Length > 0)
            {
                m_Value = this.Text;
            }
            else
            {
                m_Value = m_EnableDefaultNameWhen;
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            setDefaultTextAndValue();
            base.OnEnabledChanged(e);
        }

        private void setDefaultTextAndValue()
        {
            if (this.Enabled)
            {
                m_Value = m_EnableDefaultNameWhen;
                this.Text = "";
            }
            else
            {
                m_Value = m_UnEnableDefaultNameWhen;
                this.Text = string.Format("[{0}]", m_UnEnableDefaultNameWhen);
            }
        }
    }
}

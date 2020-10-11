using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05.Checkers.Logic;

namespace C20_Ex05_Oz_203596275
{
    internal class SlotButton : Button
    {
        private static readonly int r_HeightAndWidth = 60;
        private CheckersMen? m_Content;
        private readonly string r_Key;
        private static readonly Color r_SelectedColor = Color.CornflowerBlue;
        private static readonly Color r_UnSelectedColor = Color.WhiteSmoke;
        private static readonly Color r_UnEnableColor = Color.Gray;

        internal SlotButton(string i_Key, bool i_Enable)
        {
            r_Key = i_Key;
            m_Content = null;
            InitializeButton(i_Enable);
        }
        
        internal static int SlotHeightAndWidth
        {
            get
            {
                return r_HeightAndWidth;
            }
        }

        internal static Color SelectedColor
        {
            get
            {
                return r_SelectedColor;
            }
        }

        internal static Color UnSelectedColor
        {
            get
            {
                return r_UnSelectedColor;
            }
        }

        internal string Key
        {
            get
            {
                return r_Key;
            }
        }

        private void InitializeButton(bool i_Enable)
        {
            this.Width = r_HeightAndWidth;
            this.Height = r_HeightAndWidth;
            this.FlatStyle = FlatStyle.Flat;
            this.BackgroundImage = null;
            this.BackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.BorderColor = Color.Black;
            this.Enabled = i_Enable;

            if(i_Enable)
            {
                this.BackColor = r_UnSelectedColor;
                this.Name = string.Format("button{0}", r_Key);
            }
            else
            {
                this.BackColor = r_UnEnableColor;
                this.Name = "null";
            }
        }

        internal CheckersMen? Content
        {
            get
            {
                return m_Content;
            }
            set
            {
                m_Content = value;
                setCheckerMenImage();
            }
        }

        protected override void OnClick(EventArgs e)
        {
            ChangeSelectedStyle();
            base.OnClick(e);
        }

        internal void ChangeSelectedStyle()
        {
            Color currentColor = this.BackColor;

            if(currentColor == r_UnSelectedColor)
            {
                this.BackColor = r_SelectedColor;
            }
            else
            {
                this.BackColor = r_UnSelectedColor;
            }
        }

        private void setCheckerMenImage()
        {
            Bitmap checkerMenImage = null;

            if(m_Content != null)
            {
                switch(m_Content.Value.Sign)
                {
                    case CheckersMen.eSign.X:
                        checkerMenImage = Properties.Resources.BlackCheckerMen;
                        break;
                    case CheckersMen.eSign.K:
                        checkerMenImage = Properties.Resources.BlackKingCheckerMen;

                        break;
                    case CheckersMen.eSign.O:
                        checkerMenImage = Properties.Resources.RedCheckerMen;
                        break;
                    case CheckersMen.eSign.U:
                        checkerMenImage = Properties.Resources.RedKingCheckerMen;
                        break;
                }
            }

            this.BackgroundImage = checkerMenImage;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05.Checkers.Logic;
using Timer = System.Windows.Forms.Timer;

namespace C20_Ex05_Oz_203596275
{
    internal class CheckerMenAnimation
    {
        private PictureBox m_CheckerMenPicture;
        private PictureBox m_ToSlotPicture;
        private Timer m_Timer;
        private SlotButtonPlayerMove m_PlayerMove;
        private Point m_Direction;
        private CheckersMen m_FromSlotContent;
        private bool m_ShowSelectAnimation;
        private int m_TickCounter;
        private readonly int r_SelectedSlotInterval;
        private readonly int r_CheckerMenMoveInterval;

        internal event SlotContentEventHandler SlotContentChanged;

        internal event CheckerMenAnimationEventHandler Done;

        public CheckerMenAnimation()
        {
            SlotContentChanged = null;
            Done = null;
            m_ToSlotPicture = null;
            m_CheckerMenPicture = null;
            m_Timer = null;
            m_PlayerMove = new SlotButtonPlayerMove();
            m_Direction = new Point(0, 0);
            m_ShowSelectAnimation = true;
            m_TickCounter = 0;
            r_SelectedSlotInterval = 300;
            r_CheckerMenMoveInterval = 2;
        }

        internal bool ShowSelectAnimation
        {
            get
            {
                return m_ShowSelectAnimation;
            }
            set
            {
                m_ShowSelectAnimation = value;
            }
        }

        internal PictureBox CheckerMenPicture
        {
            get
            {
                return m_CheckerMenPicture;
            }
            set
            {
                m_CheckerMenPicture = value;
                m_CheckerMenPicture.BackColor = Color.Transparent;
            }
        }

        internal PictureBox ToSlotPicture
        {
            get
            {
                return m_ToSlotPicture;
            }
            set
            {
                m_ToSlotPicture = value;
            }
        }

        internal Timer Timer
        {
            get
            {
                return m_Timer;
            }
            set
            {
                m_Timer = value;
                m_Timer.Tick += timer_Tick;
            }
        }

        internal SlotButtonPlayerMove SlotButtonPlayerMove
        {
            get
            {
                return m_PlayerMove;
            }
            set
            {
                m_PlayerMove = value;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            m_TickCounter++;
            if(m_ShowSelectAnimation)
            {
                slotSelectedAnimation();
            }
            else
            {
                if(m_CheckerMenPicture != null)
                {
                    if(isPictureCanMove())
                    {
                        setAnimation();
                    }
                    else
                    {
                        stop();
                    }
                }
            }
        }

        private void slotSelectedAnimation()
        {
            switch(m_TickCounter)
            {
                case 1:
                    //onSlotSelected(new CheckerMenAnimationSelectedEventArgs(m_PlayerMove.FromSlotButton.Key));
                    m_CheckerMenPicture.BackColor = SlotButton.SelectedColor;
                    break;
                case 3:
                    m_ToSlotPicture.BackColor = SlotButton.SelectedColor;
                    break;
                case 5:
                    m_CheckerMenPicture.BackColor = SlotButton.UnSelectedColor;
                    m_CheckerMenPicture.BorderStyle = BorderStyle.None;
                    m_ToSlotPicture.BackColor = SlotButton.UnSelectedColor;
                    m_ToSlotPicture.Visible = false;
                    m_ShowSelectAnimation = false;
                    m_Timer.Interval = r_CheckerMenMoveInterval;

                    break;
            }
        }

        private void stop()
        {
            m_Timer.Stop();
            onSlotContentChanged(new SlotContentEventArgs(m_PlayerMove.ToSlotButton.Key, m_FromSlotContent));
            m_CheckerMenPicture.Visible = false;
            onAnimationDone(EventArgs.Empty);
        }

        private void onAnimationDone(EventArgs i_EventArgs)
        {
            if(Done != null)
            {
                Done.Invoke(this, i_EventArgs);
            }
        }

        private void onSlotContentChanged(SlotContentEventArgs i_SlotContentEventArgs)
        {
            SlotContentChanged.Invoke(this, i_SlotContentEventArgs);
        }

        internal void Start()
        {
            setAnimationParams();
            m_FromSlotContent = m_PlayerMove.FromSlotButton.Content.Value;
            onSlotContentChanged(new SlotContentEventArgs(m_PlayerMove.FromSlotButton.Key, null));
            m_Timer.Start();
        }

        private void setAnimationParams()
        {
            setDirection();
            m_TickCounter = 0;
            m_CheckerMenPicture.BackgroundImage = m_PlayerMove.FromSlotButton.BackgroundImage;
            m_CheckerMenPicture.Location = m_PlayerMove.FromSlotButton.Location;
            m_ToSlotPicture.Location = m_PlayerMove.ToSlotButton.Location;
            m_CheckerMenPicture.Visible = true;
            m_ToSlotPicture.Visible = m_ShowSelectAnimation;
            if(m_ShowSelectAnimation)
            {
                m_CheckerMenPicture.BorderStyle = BorderStyle.FixedSingle;
                m_Timer.Interval = r_SelectedSlotInterval;
            }
            else
            {
                m_CheckerMenPicture.BorderStyle = BorderStyle.None;
                m_Timer.Interval = r_CheckerMenMoveInterval;
            }
        }

        private void setAnimation()
        {
            m_CheckerMenPicture.Left += m_Direction.X;
            m_CheckerMenPicture.Top += m_Direction.Y;
            if(m_PlayerMove.Type == SlotButtonPlayerMove.eMoveType.Eat)
            {
                if(PointEquals(m_CheckerMenPicture.Location, m_PlayerMove.SlotButtonToEat.Location))
                {
                    onSlotContentChanged(new SlotContentEventArgs(m_PlayerMove.SlotButtonToEat.Key, null));
                    Thread.Sleep(300);
                }
            }
        }

        private bool PointEquals(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        private bool isPictureCanMove()
        {
            return !PointEquals(m_CheckerMenPicture.Location, m_PlayerMove.ToSlotButton.Location);
        }

        private void setDirection()
        {
            int deltaX = m_PlayerMove.ToSlotButton.Location.X - m_PlayerMove.FromSlotButton.Location.X;
            int deltaY = m_PlayerMove.ToSlotButton.Location.Y - m_PlayerMove.FromSlotButton.Location.Y;

            m_Direction.X = getDirectionByDelta(deltaX);
            m_Direction.Y = getDirectionByDelta(deltaY);
        }

        private int getDirectionByDelta(int i_Delta)
        {
            int direction = 0;

            if(i_Delta != 0)
            {
                if(i_Delta > 0)
                {
                    direction = 1;
                }
                else
                {
                    direction = -1;
                }
            }

            return direction;
        }
    }
}

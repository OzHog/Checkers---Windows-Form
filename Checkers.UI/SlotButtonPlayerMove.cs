using System;
using System.Collections.Generic;
using System.Text;

namespace C20_Ex05_Oz_203596275
{
    internal readonly struct SlotButtonPlayerMove
    {
        private readonly SlotButton r_FromSlotButton;
        private readonly SlotButton r_ToSlotButton;
        private readonly SlotButton r_SlotButtonToEat;

        public SlotButtonPlayerMove(SlotButton i_FromSlotButton, SlotButton i_ToSlotButton, SlotButton i_SlotButtonToEat = null)
        {
            r_FromSlotButton = i_FromSlotButton;
            r_ToSlotButton = i_ToSlotButton;
            r_SlotButtonToEat = i_SlotButtonToEat;
        }

        public SlotButton FromSlotButton
        {
            get
            {
                return r_FromSlotButton;
            }
        }
        
        public SlotButton ToSlotButton
        {
            get
            {
                return r_ToSlotButton;
            }
        }

        public SlotButton SlotButtonToEat
        {
            get
            {
                return r_SlotButtonToEat;
            }
        }
        
        public enum eMoveType
        {
            NoEat,
            Eat
        }

        public eMoveType Type
        {
            get
            {
                eMoveType value = eMoveType.NoEat;
                if (r_SlotButtonToEat != null)
                {
                    value = eMoveType.Eat;
                }

                return value;
            }
        }
    }
}

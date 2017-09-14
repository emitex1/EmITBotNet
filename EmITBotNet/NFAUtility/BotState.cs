using System;

namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public class BotState
    {
        public int Number;
        public string Name;
        
        public BotState(int Number, string Name)
        {
            this.Number = Number;
            this.Name = Name;
        }

        public override string ToString()
        {
            return Number + " - " + Name;
        }

        public static bool operator ==(BotState bs1, int bs2)
        {
            return bs1.Number == bs2;
        }

        public static bool operator !=(BotState bs1, int bs2)
        {
            return bs1.Number != bs2;
        }

        public override bool Equals(object obj)
        {
            return
                (obj.GetType() == typeof(int) && (int)obj == this.Number)
                ||
                (obj.GetType() == typeof(BotState) && ((BotState)obj).Number == this.Number);
        }
    }
}

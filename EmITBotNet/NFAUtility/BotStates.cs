namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public class BotStates
    {
        //public static int Start = 1; // شروع برنامه
        public static BotState Start = new BotState(1, "شروع برنامه");
        public static BotState Invalid = new BotState(-1, "غیر معتبر");
    }
}

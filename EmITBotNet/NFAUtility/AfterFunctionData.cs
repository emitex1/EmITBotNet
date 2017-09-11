using Telegram.Bot.Types;

namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public class AfterFunctionData
    {
        public Message m;
        public UserData ud;
        public string action;

        public long target;

        public AfterFunctionData(Message m, UserData ud, string action)
        {
            this.m = m;
            this.ud = ud;
            this.action = action;
            this.target = m.Chat.Id;
        }
    }
}

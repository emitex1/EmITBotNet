using Telegram.Bot.Types;

namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public class PostFunctionData
    {
        public Message m;
        public SessionData bd;

        public string action;
        public long target;

        public PostFunctionData(Message m, SessionData bd)
        {
            this.m = m;
            this.bd = bd;

            action = m.Text;
            target = m.Chat.Id;
        }
    }
}

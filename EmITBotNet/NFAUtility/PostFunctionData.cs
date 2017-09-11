using Telegram.Bot.Types;

namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public class PostFunctionData
    {
        public Message m;
        public UserData ud;

        public string action;
        public long target;

        public PostFunctionData(Message m, UserData ud)
        {
            this.m = m;
            this.ud = ud;

            action = m.Text;
            target = m.Chat.Id;
        }
    }
}

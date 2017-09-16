using Telegram.Bot.Types;

namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public class PostFunctionData
    {
        public Message m;
        public BotDataBase bd;

        public string action;
        public long target;

        public PostFunctionData(Message m, BotDataBase bd)
        {
            this.m = m;
            this.bd = bd;

            action = m.Text;
            target = m.Chat.Id;
        }
    }
}

using Telegram.Bot;
using Telegram.Bot.Types;

namespace ir.EmIT.EmITBotNet
{
    //todo گذاشتن کتابخانه در نیوگت

    public abstract class EmITBotNetBase
    {
        public TelegramBotClient bot;

        //public List<UserData> userData;
        //public UserData currentUserData;

        public abstract void HandleMessage(Message m);

        public void setBot(TelegramBotClient bot)
        {
            this.bot = bot;
        }
    }
}

namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public class SessionData
    {
        // شماره کاربری که این اطلاعات برایش ذخیره میشود
        public long telegramUserID;

        // وضعیت فعلی بات
        public BotState botState;

        // وضعیت قبلی بات
        public BotState preBotState;
        internal string nextCustomAction;

        public SessionData(long userID)
        {
            this.telegramUserID = userID;

            // تعیین وضعیت اولیه در تابع سازنده
            botState = BotStates.Start;
        }

        public override string ToString()
        {
            return "UserID : " + telegramUserID + " - State : " + botState.ToString();
        }
    }
}

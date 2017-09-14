namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public class UserData
    {
        // شماره کاربری که این اطلاعات برایش ذخیره میشود
        public long userID;

        // وضعیت فعلی بات
        public BotState botState;

        // وضعیت قبلی بات
        public BotState preBotState;

        public UserData(long userID)
        {
            this.userID = userID;

            // تعیین وضعیت اولیه در تابع سازنده
            botState = BotStates.Start;
        }

        public override string ToString()
        {
            return "UserID : " + userID + " - State : " + botState.ToString();
        }
    }
}

namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public abstract class UserData
    {
        // شماره کاربری که این اطلاعات برایش ذخیره میشود
        public long userID;

        public int botState;
        public int preBotState;

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

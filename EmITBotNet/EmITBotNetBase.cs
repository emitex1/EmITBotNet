using ir.EmIT.EmITBotNet.NFAUtility;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using System;

namespace ir.EmIT.EmITBotNet
{
    //todo گذاشتن کتابخانه در نیوگت

    public abstract class EmITBotNetBase
    {
        public TelegramBotClient bot;

        public List<UserData> userData;
        public UserData currentUserData;

        public EmITNFA nfa;
        // لیست کاربران مجاز به استفاده از بات
        public List<long> authenticatedUsers;

        public EmITBotNetContext db;

        public EmITBotNetBase()
        {
            // ست کردن لیست کاربران مجاز
            authenticatedUsers = getAuthenticatedUsers();

            // تعریف شیئ دلخواه برای کار با دیتابیس
            initDatabase();

            // تعریف nfa
            nfa = new EmITNFA();

            // تعریف لیست جلسه ها برای کاربران مختلف
            //userData = new List<MohammadArianUserData>();
            userData = new List<UserData>();

            // تعریف قواعد حرکت بین وضعیت ها، براساس عمل دریافتی
            defineNFARules();

            // تعریف قواعد انجام کار، پس از رسیدن به هر وضعیت
            defineNFARulePostFunctions();
        }

        public void HandleMessage(Message m)
        {
            // بررسی وجود جلسه (سشن) برای کاربر جاری
            getConvertedUserData(m);

            if (m.Text == null)
                return;

            // بررسی کاربرانی که حق دسترسی به بات را دارند
            if (!isAuthenticated(m))
                return;

            m = convertData(m);

            // عمل ورودی
            string action = m.Text;
            //nfa.move(currentUserData.botState, action)(new PostFunctionData(m, currentUserData, action));
            //nfa.move(currentUserData.botState, action);
            nfa.move(m, currentUserData);
        }

        /// <summary>
        /// تعریف شیئ دلخواه برای کار با دیتابیس
        /// </summary>
        public abstract void initDatabase();

        public abstract Message convertData(Message m);

        public void setBot(TelegramBotClient bot)
        {
            this.bot = bot;
        }

        /// <summary>
        /// بررسی وجود جلسه (سشن) برای کاربر جاری
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public UserData checkSessionAndGetCurrentUserData(Message m)
        {
            long currentUserID = m.Chat.Id;
            if (userData.Where<UserData>(ud => ud.userID == currentUserID).Count() == 0)
            {
                // ساخت جلسه (سشن) برای کاربر جاری با تنظیمات اولیه
                addNewUserSession(currentUserID);
            }
            // پیدا کردن سشن مربوط به کاربر جاری
            //currentUserData = (MohammadArianUserData)userData.Where<UserData>(ud => ud.userID == currentUserID).First();
            return userData.Where<UserData>(ud => ud.userID == currentUserID).First();
        }

        public abstract void getConvertedUserData(Message m);

        /// <summary>
        /// افزودن جلسه جدید برای کاربر جدید
        /// </summary>
        /// <param name="currentUserID">شناسه کاربر جدید</param>
        public abstract void addNewUserSession(long currentUserID);

        /// <summary>
        /// بررسی کاربرانی که حق دسترسی به بات را دارند
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool isAuthenticated(Message m)
        {
            if (!authenticatedUsers.Contains(m.Chat.Id))
            {
                //await bot.SendTextMessageAsync(target, "با عرض معذرت، شما مجوز دسترسی به این بات را ندارید");
                bot.SendTextMessageAsync(m.Chat.Id, "با عرض معذرت، شما مجوز دسترسی به این بات را ندارید");
                return false;
            }
            return true;
        }

        /// <summary>
        /// گرفتن لیست کاربران مجاز به کار
        /// </summary>
        /// <returns>لیست شناسه کاربران مجاز به کار</returns>
        public abstract List<long> getAuthenticatedUsers();

        /// <summary>
        /// تعیین قواعد بررسی وضعیت فعلی و ورودی دریافتی و تعیین وضعیت بعدی
        /// </summary>
        public abstract void defineNFARules();

        /// <summary>
        /// بررسی وضعیت جدید و انجام کاری که پس از رسیدن به وضعیت جدید باید انجام شود
        /// </summary>
        public abstract void defineNFARulePostFunctions();
    }
}

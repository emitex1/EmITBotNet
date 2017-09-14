using ir.EmIT.EmITBotNet.Models;
using System;
using Telegram.Bot.Types;

namespace ir.EmIT.EmITBotNet
{
    public class LogRegisterar
    {
        public static void saveLog(Message m, EmITBotNetContext db)
        {
            string log = string.Format("{0}\t{1}\tFrom {2} {3} ({4}, {5}) : {6}", new PersianDateTime(m.Date).Date.ToString("yyyy/MM/dd"), m.Date.TimeOfDay.ToHHMMSS(), m.Chat.FirstName, m.Chat.LastName, m.Chat.Username, m.Chat.Id, m.Text);
            Console.WriteLine(log);
            // ثبت لاگ سیستم در پایگاه داده
            db.MessageLogs.Add(new MessageLog()
            {
                SenderID = m.From.Id,
                SenderUserName = m.From.Username,
                Message = m.Text,
                MessageDateTime = m.Date
            });
            db.SaveChanges();
        }
    }
}

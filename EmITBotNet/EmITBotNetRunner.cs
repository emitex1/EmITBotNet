using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ir.EmIT.EmITBotNet
{
    public class EmITBotNetRunner
    {
        private TelegramBotClient bot;
        private EmITBotNetBase botBase;

        public EmITBotNetRunner(EmITBotNetBase botBase)
        {
            string apikey;
            try
            {
                apikey = System.IO.File.ReadAllText("ApiKey.txt");
            }
            catch
            {
                Console.WriteLine("Error in reading Bot Api Key");
                Console.ReadLine();
                return;
            }

            bot = new TelegramBotClient(apikey);
            botBase.setBot(bot);            

            try
            {
                //string userName = await bot.GetMeAsync().Result.Username;
                Console.WriteLine("I'm a Telegram Bot and my Name is " +
                    bot.GetMeAsync().Result.Username +
                    " and I'm ready");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                Console.ReadLine();
                return;
            }

            this.botBase = botBase;
            bot.OnMessage += Bot_OnMessage;
            bot.OnCallbackQuery += Bot_OnCallbackQuery;
            bot.StartReceiving();

            Console.ReadLine();
        }

        private void Bot_OnCallbackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            Message m = e.CallbackQuery.Message;
            m.Text = e.CallbackQuery.Data;

            // ثبت لاگ دستورات وارد شده
            LogRegisterar.saveLog(m);

            // ارجاع دستور دریافتی به بات
            botBase.HandleMessage(m);
        }

        private void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Message m = e.Message;

            // ثبت لاگ دستورات وارد شده
            LogRegisterar.saveLog(m);

            // ارجاع دستور دریافتی به بات
            botBase.HandleMessage(m);
        }
    }
}

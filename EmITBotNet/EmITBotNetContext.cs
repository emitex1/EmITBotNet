using ir.EmIT.EmITBotNet.Models;
using System;
using System.Data.Entity;

namespace ir.EmIT.EmITBotNet
{
    public class EmITBotNetContext : DbContext
    {
        public EmITBotNetContext()
        {
            // ست کردن مقدار داده ای DataDirectory با مقدار مناسب، برای تعیین محل پایگاه داده
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }

        public DbSet<MessageLog> MessageLogs { get; set; }
    }
}
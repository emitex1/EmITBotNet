using System;

namespace ir.EmIT.EmITBotNet.Models
{
    internal class MessageLog
    {
        public int MessageLogId { get; set; }
        public DateTime MessageDateTime { get; set; }
        public int SenderID { get; set; }
        public string SenderUserName { get; set; }
        public string Message { get; set; }
    }
}

using System;

namespace ProductManagerApp.Domain.Core
{
    public class Log
    {
        public int LogId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int UserId { get; set; }
        public string ActionDescription { get; set; }
        public string SerializedRequest { get; set; }
    }
}

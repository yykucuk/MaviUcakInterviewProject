using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public string ClassName { get; set; }
        public DateTime DateTime { get; set; }
    }
}

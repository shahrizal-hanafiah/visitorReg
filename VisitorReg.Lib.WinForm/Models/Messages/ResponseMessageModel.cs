using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorReg.Lib.WinForm.Enum;

namespace VisitorReg.Lib.WinForm.Models.Messages
{
    public class ResponseMessageModel
    {
        public MessageType MessageType { get; set; }
        public string Message { get; set; }
        public Error Error { get; set; }
    }

    public class Error
    {
        public string Message { get; set; }
        public string Details { get; set; }
    }
}

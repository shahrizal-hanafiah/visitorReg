using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorReg.Lib.WinForm.Models.User
{
    public class LoginUserModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
    public class LoginResponseModel
    {
        public string Username { get; set; }

        public string Role { get; set; }

        public string Name { get; set; }
        public int UserId { get; set; }
    }
}

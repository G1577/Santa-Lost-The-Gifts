using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Modols
{
    public class GameUser
    {
        public int UserId { get; set; } = 0;
        public string UserName { get; set; }
        public string UserMail { get; set; } = "None Email";
        public int MaxLevel { get; set; } = 1;
        public string UsingProduct { get; set; }
    }
}

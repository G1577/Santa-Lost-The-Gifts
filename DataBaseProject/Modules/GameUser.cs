using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProject.Modules
{
    public class GameUser
    {
        public int UserId { get; set; } = 0;
        public string UserName { get; set; }
        public string UserMail { get; set; } = "None Email";
        public int LastLevel { get; set; } = 0;
        public string CurrentProduct { get; set; }
        public string LevelType { get; set; }
        public int Money { get; set; }
    }
}

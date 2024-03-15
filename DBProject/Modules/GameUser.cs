using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Modols
{
    public class GameUser
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public string Email { get; set; } = "None Email";
    }
}

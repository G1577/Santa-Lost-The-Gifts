using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoProject.Modules;

namespace MongoProject.Modules
{
    public class EnemyInfo
    {
        // doesn't save name cause the enemy is picked by the level env
        public int row;
        public int column;
        public int width;
        public int height;
    }
}
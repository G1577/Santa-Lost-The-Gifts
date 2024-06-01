using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace GameEngine.GameServices
{
    public class GameEvents
    {
        public Action OnRun;//הארוע שגורם לעצמים לזוז
        public Action<VirtualKey> OnKeyDown;//הארוע ללחיצה על המקש
        public Action<VirtualKey> OnKeyUp;//הארוע לעזיבת המקש
        public Action<int> removeLives; //ארוע שבאמצאותו אפשר למחוק חיים
        public Action<int> addLives; //ארוע שבאמצאותו אפשר למחוק חיים
        public Action OnWin;//הארועה יפעל כשהשחקן הגיע לסוף
    }
}

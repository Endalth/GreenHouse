using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.UI
{
    public class ClientVariables
    {
        //Should this be static?
        public static Color[] textColorsByRiskSeviye { get; set; } = new Color[] { Color.White, Color.OliveDrab, Color.Yellow, Color.Coral, Color.Red };

        public static int LoggedInUserId { get; set; }
    }
}

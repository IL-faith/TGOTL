using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGOTL
{
    public class LoadingScreen
    {
        int screenNumber;
        Image screen;
        bool unlocked = false;

        public LoadingScreen(Image i, int n) 
        {
            screen = i;
            screenNumber = n;
        }

        public int ScreenNumber { get; set; }
        public Image Screen { get; }
        public bool Unlocked { get; set; }
    }
}

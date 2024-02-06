using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGOTL
{
    public class Car
    {
        // 4 speeds, speed limit -10, -5, +0 (equal to), +5
        int speed;
        public Car(int carSpeed)
        {
            speed = carSpeed;
        }
        public Car() { }
    }
}

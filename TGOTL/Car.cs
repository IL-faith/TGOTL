using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TGOTL
{
    public class Car
    {
        // 4 speeds, speed limit -10, -5, +0 (equal to), +5
        int speed, timeStopped;
        Color color;
        public Car(int carSpeed)
        {
            speed = carSpeed;
            SetColor();
        }
        public Car()
        {
            SetColor();
        }

        public int Speed { get; }
        public int TimeStopped { get; set; }
        public Color Color { get; }

        private void SetColor()
        {
            Random rnd = new Random();

            switch(rnd.Next(4) + 1)
            {
                case 1:
                    color = Color.White; break;
                case 2: 
                    color = Color.Red; break;
                case 3:
                    color = Color.Orange; break;
                case 4: 
                    color = Color.Cyan; break;
            }
        }
        public void SetSpeed(int speedLimit)
        {
            Random rnd = new Random();

            switch (rnd.Next(4) + 1)
            {
                case 1:
                    speed = speedLimit - 10; break;
                case 2:
                    speed = speedLimit - 5; break;
                case 3:
                    speed = speedLimit; break;
                case 4:
                    speed = speedLimit; break;
            }
        }
    }
}

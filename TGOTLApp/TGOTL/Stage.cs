using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGOTL
{
    public class Stage
    {
        TrafficLight[] trafficLights;
        Car[] cars;
        int initialScore, currentPlayerScore, bestPlayerScore, speedLimit;

        public Stage(TrafficLight[] tl) 
        {
            trafficLights = tl;
        }

        public TrafficLight[] TrafficLights { get; }
        public Car[] Cars { get; set; }
        public int InitialScore { get; set; }
        public int CurrentPlayerScore { get; set; }
        public int BestPlayerScore { get; set; }
        public int SpeedLimit { get; set; }
    }
}

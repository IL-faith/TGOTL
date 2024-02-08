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
        string stageName;
        Car[] cars;
        int initialScore, currentPlayerScore, bestPlayerScore, speedLimit;
        bool unlocked;

        public Stage(string stageName, TrafficLight[] tl, bool unlockedAlready = false) 
        {
            trafficLights = tl;
            this.stageName = stageName;
            unlocked = unlockedAlready;
        }

        public TrafficLight[] TrafficLights { get; }
        public string StageName { get; }
        public bool Unlocked { get; set; }
        public Car[] Cars { get; set; }
        public int InitialScore { get; set; }
        public int CurrentPlayerScore { get; set; }
        public int BestPlayerScore { get; set; }
        public int SpeedLimit { get; set; }
    }
}

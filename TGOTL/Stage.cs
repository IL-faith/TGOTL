using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGOTL
{
    public class Stage
    {
        TrafficLight[] oldTrafficLights, newTrafficLights;
        string stageName;
        Car[] cars;
        int initialScore, currentPlayerScore, bestPlayerScore, speedLimit;
        bool unlocked;

        public Stage(string stageName, TrafficLight[] tl, bool unlockedAlready = false) 
        {
            oldTrafficLights = tl;
            newTrafficLights = tl;
            this.stageName = stageName;
            unlocked = unlockedAlready;
        }

        

        public TrafficLight[] OldTrafficLights { get { return oldTrafficLights; } }
        public TrafficLight[] NewTrafficLights { get { return newTrafficLights; } set { newTrafficLights = value; } }
        public string StageName { get; }
        public bool Unlocked { get; set; }
        public Car[] Cars { get { return cars; } set { cars = value; } }
        public int InitialScore { get; set; }
        public int CurrentPlayerScore { get; set; }
        public int BestPlayerScore { get; set; }
        public int SpeedLimit { get; set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGOTL
{
    public partial class Stage1Prep : Form
    {
        struct CCar
        {
            internal PictureBox car;
            // 4 speeds, speed limit -10, -5, +0 (equal to), +5
            internal int speed, speedDirection, timeStopped;
            internal bool inUse, wasUsed, speedAffectsX;
        };
        private void SetCarColor(PictureBox car)
        {
            switch (rnd.Next(4) + 1)
            {
                case 1:
                    car.BackColor = Color.White; break;
                case 2:
                    car.BackColor = Color.Red; break;
                case 3:
                    car.BackColor = Color.Orange; break;
                case 4:
                    car.BackColor = Color.Cyan; break;
            }
        }
        private int SetCarSpeed(CCar c)
        {
            switch (rnd.Next(4) + 1)
            {
                case 1:
                    c.speed = stageSpeedLimit - 10; break;
                case 2:
                    c.speed = stageSpeedLimit - 5; break;
                case 3:
                    c.speed = stageSpeedLimit; break;
                case 4:
                    c.speed = stageSpeedLimit + 5; break;
            }
            return c.speed;
        }
        //determines which sample car to use
        private void GenerateCars()
        {
            for (int i = 0; i < numCarsToMake; i++)
            {
                CCar c = new CCar();
                c.inUse = c.wasUsed = false;
                c.car = new PictureBox();
                c.car.Visible = false;
                SetCarColor(c.car);
                c.speed = SetCarSpeed(c); // carspeed() needs to return int cuz it isn't in cars array yet
                c.timeStopped = 0;

                //determine starting position of car
                int carDirection = rnd.Next(4) + 1;
                //MessageBox.Show(carDirection + "");
                switch (carDirection)
                {
                    case 1:
                        c.car.Location = pbH1Car1.Location;
                        c.car.Size = pbH1Car1.Size;
                        c.speedDirection = -1;
                        c.speedAffectsX = true;
                        //MessageBox.Show(c.speedDirection + "-" + c.speedAffectsX);
                        break;
                    case 2:
                        c.car.Location = pbH2Car1.Location;
                        c.car.Size = pbH2Car1.Size;
                        c.speedDirection = 1;
                        c.speedAffectsX = true;
                        //MessageBox.Show(c.speedDirection + "-" + c.speedAffectsX);
                        break;
                    case 3:
                        c.car.Location = pbV1Car1.Location;
                        c.car.Size = pbV1Car1.Size;
                        c.speedDirection = -1;
                        c.speedAffectsX = false;
                        //MessageBox.Show(c.speedDirection + "-" + c.speedAffectsX);
                        break;
                    case 4:
                        c.car.Location = pbV2Car1.Location;
                        c.car.Size = pbV2Car1.Size;
                        c.speedDirection = 1;
                        c.speedAffectsX = false;
                        //MessageBox.Show(c.speedDirection + "-" + c.speedAffectsX);
                        break;
                }

                cars.Add(c);
                this.Controls.Add(c.car);
            }
            //allCarsGenerated = true;
            //foreach (CCar c in cars)
              //  MessageBox.Show(c.speedDirection + "-" + c.speedAffectsX);
        }
        private void GroupCars()
        {
            Predicate<CCar> h1CarFinder = (CCar c) => { return (c.speedAffectsX == true && c.speedDirection == -1); };
            Predicate<CCar> h2CarFinder = (CCar c) => { return (c.speedAffectsX == true && c.speedDirection == 1); };
            Predicate<CCar> v1CarFinder = (CCar c) => { return (c.speedAffectsX == false && c.speedDirection == -1); };
            Predicate<CCar> v2CarFinder = (CCar c) => { return (c.speedAffectsX == false && c.speedDirection == 1); };
            h1Cars = cars.FindAll(h1CarFinder).ToArray();
            h2Cars = cars.FindAll(h2CarFinder).ToArray();
            v1Cars = cars.FindAll(v1CarFinder).ToArray();
            v2Cars = cars.FindAll(v2CarFinder).ToArray();
            h1CarsEndIndex = h1Cars.Length;
            h2CarsEndIndex = h2Cars.Length;
            v1CarsEndIndex = v1Cars.Length;
            v2CarsEndIndex = v2Cars.Length;
        }
        private void IncreaseTimeStopped(bool vCarsStopped, int time)
        {
            //MessageBox.Show("increasing time");
            lblBackBtn.Text = "time++";
            if (vCarsStopped)
            {
                //MessageBox.Show("vcars");
                for (int i = 0; i < v1Cars.Length; i++)
                {
                    if (v1Cars[i].car.Visible && !v1Cars[i].wasUsed)
                        v1Cars[i].timeStopped += time;
                }
                for (int j = 0; j < v2Cars.Length; j++)
                {
                        if (v2Cars[j].car.Visible && !v2Cars[j].wasUsed)
                        v2Cars[j].timeStopped += time;
                }
            }
            else
            {
                //MessageBox.Show("hcars");
                for (int i = 0; i < h1Cars.Length; i++)
                {
                    if (h1Cars[i].car.Visible && !h1Cars[i].wasUsed)
                        h1Cars[i].timeStopped += time;
                }
                for (int j = 0; j < h2Cars.Length; j++)
                { 
                    if (h2Cars[j].car.Visible && !h2Cars[j].wasUsed)
                        h2Cars[j].timeStopped += time;
                }
                //MessageBox.Show("end hcars");
            }
            lblBackBtn.Text = "back";
        }

        struct TrafficLightSettings
        {
            internal int[] time;
            internal string[] timeUnit;
            internal int xOfMenu;
            internal int yOfMenu;
        };

        enum StagePhase { PRE, MID, POST };
        enum TrafficLightColor { RED, GREEN, YELLOW };

        int numCarsToMake, numCarsMade = 0, numCarsInUse, stageSpeedLimit;
        List<CCar> cars = new List<CCar>();
        CCar[] h1Cars, h2Cars, v1Cars, v2Cars;
        int h1CarsIndex = 0, h2CarsIndex = 0, v1CarsIndex = 0, v2CarsIndex = 0;
        int h1CarsEndIndex = 0, h2CarsEndIndex = 0, v1CarsEndIndex = 0, v2CarsEndIndex = 0;
        bool h1CarsPresent = false, h2CarsPresent = false, v1CarsPresent = false, v2CarsPresent = false, allCarsGenerated = false;
        TrafficLightSettings[] trafficLightSettings;
        int trafficLightSelected = -1;
        TrafficLightColor signalColorH = TrafficLightColor.RED, signalColorV = TrafficLightColor.GREEN;
        bool lightTimerPass2 = false;
        //int[] lightTimesH = new int[3], lightTimesV = new int[3]; 
        StagePhase stagePhase = StagePhase.PRE;
        Game game;
        Random rnd = new Random();
        int HYLTimeRemaining, VYLTimeRemaining;

        public Stage1Prep(Point formPosition, Game g)
        {
            InitializeComponent();
            
            StopTimers();

            this.Location = formPosition;
            game = g;

            flpTimerTrafficLightMenu.Visible = false;
            SetUpInitialTrafficLightSettings();
            lblPrep.Text = "Pre-Prep";
            lblFinishPrepBtn.Text = "Continue";
            pbV2Car1.Visible = false;
            pbV1Car1.Visible = false;
            pbH1Car1.Visible = false;
            pbH2Car1.Visible = false;

            stageSpeedLimit = 50;
            numCarsToMake = 3;//25;//rnd.Next(100) + 60;
            GenerateCars();
            GroupCars();

            MessageBox.Show("total cars = " + numCarsToMake + "; h1 = " + h1Cars.Length + ", h2 = " + h2Cars.Length + ", v1 = " + v1Cars.Length + ", v2 = " + v2Cars.Length);

            SetUpTrafficLightTimers();
            //timeStageTimer.Enabled = true;

            numCarsInUse = 0;
            numCarsMade = 0;
            timeStageTimer.Start();
        }

        private void SetUpTrafficLightTimers()
        {
            // h = 0,1 v = 2,3
            int redLightTime, yellowLightTime, greenLightTime;
            redLightTime = trafficLightSettings[0].time[0] * (trafficLightSettings[0].timeUnit[0].Equals("min")? 60:1) * 17;
            yellowLightTime = trafficLightSettings[0].time[1] * (trafficLightSettings[0].timeUnit[1].Equals("min") ? 60 : 1) * 17;
            greenLightTime = trafficLightSettings[0].time[2] * (trafficLightSettings[0].timeUnit[2].Equals("min") ? 60 : 1) * 17;
            //yellowLightTime = int.Parse(txtLightTime2.Text) * (cmbTimeUnit2.Text.Equals("min")? 60:1);
            //greenLightTime = int.Parse(txtLightTime3.Text) * (cmbTimeUnit3.Text.Equals("min")? 60:1);

            timeRedLightTimerH.Interval /*= timeYellowLightTimerH.Interval = timeGreenLightTimerH.Interval*/ = redLightTime;
            timeYellowLightTimerH.Interval = yellowLightTime;
            timeGreenLightTimerH.Interval = greenLightTime;

            redLightTime = trafficLightSettings[2].time[0] * (trafficLightSettings[2].timeUnit.Equals("min") ? 60 : 1) * 17;
            yellowLightTime = trafficLightSettings[2].time[1] * (trafficLightSettings[2].timeUnit[1].Equals("min") ? 60 : 1) * 17;
            greenLightTime = trafficLightSettings[2].time[2] * (trafficLightSettings[2].timeUnit[2].Equals("min") ? 60 : 1) * 17;
            //yellowLightTime = int.Parse(txtLightTime2.Text) * (cmbTimeUnit2.Text.Equals("min")? 60:1);
            //greenLightTime = int.Parse(txtLightTime3.Text) * (cmbTimeUnit3.Text.Equals("min")? 60:1);

            timeRedLightTimerV.Interval /*= timeYellowLightTimerV.Interval = timeGreenLightTimerV.Interval*/ =  redLightTime;
            timeYellowLightTimerV.Interval = yellowLightTime;
            timeGreenLightTimerV.Interval = greenLightTime;

            timeRedLightTimerH.Start();
        }

        private void LightIsRedH(object sender, EventArgs e)
        {
            //lblPrep.Text = "redhv";
            if (lightTimerPass2)
            {
                timeRedLightTimerH.Stop();
                //IncreaseTimeStopped(false, timeRedLightTimerH.Interval);
                lightTimerPass2 = false;
                //lblPrep.Text += " 2nd pass";
                signalColorH = TrafficLightColor.GREEN; //signalColorV = red
                timeGreenLightTimerH.Start();
            }
            else
                lightTimerPass2 = true;
        }
        private void LightIsGreenH(object sender, EventArgs e)
        {
            lblPrep.Text = "redv";
            if (lightTimerPass2)
            {
                timeGreenLightTimerH.Stop();
                lightTimerPass2 = false;
                //IncreaseTimeStopped(true, timeGreenLightTimerH.Interval);
                signalColorH = TrafficLightColor.YELLOW; //signalColorV = red
                timeYellowLightTimerH.Start();
            }
            else
                lightTimerPass2 = true;
        }

        private void LightIsYellowH(object sender, EventArgs e)
        {
            lblPrep.Text = "redv";
            if (lightTimerPass2)
            {
                timeYellowLightTimerH.Stop();
                lightTimerPass2 = false;
                //IncreaseTimeStopped(true, timeYellowLightTimerH.Interval);
                signalColorH = TrafficLightColor.RED; //signalColorV = red
                timeRedLightTimerV.Start(); //transition time from h lights to v lights
            }
            else
            {
                lightTimerPass2 = true;
                HYLTimeRemaining = timeYellowLightTimerH.Interval*2;
            }
        }
        private void LightIsRedV(object sender, EventArgs e)
        {
            lblPrep.Text = "redvh";
            if (lightTimerPass2)
            {
                timeRedLightTimerV.Stop();
                lightTimerPass2 = false;
                //IncreaseTimeStopped(true, timeRedLightTimerV.Interval);
                signalColorV = TrafficLightColor.GREEN; //signalColorH = red
                timeGreenLightTimerV.Start();
            }
            else
                lightTimerPass2 = true;
        }
        private void LightIsGreenV(object sender, EventArgs e)
        {
            lblPrep.Text = "redh";
            if (lightTimerPass2)
            {
                timeGreenLightTimerV.Stop();
                lightTimerPass2 = false;
                //IncreaseTimeStopped(false, timeGreenLightTimerV.Interval);
                signalColorV = TrafficLightColor.YELLOW; //signalColorH = red
                timeYellowLightTimerV.Start();
            }
            else
                lightTimerPass2 = true;
        }

        private void LightIsYellowV(object sender, EventArgs e)
        {
            lblPrep.Text = "redh";
            if (lightTimerPass2)
            {
                timeYellowLightTimerV.Stop();
                lightTimerPass2 = false;
                //IncreaseTimeStopped(false, timeYellowLightTimerV.Interval);
                signalColorV = TrafficLightColor.RED; //signalColorH = red
                timeRedLightTimerH.Start(); //transition time from v lights to h lights
            }
            else
                lightTimerPass2 = true;
        }

        private void TrafficGeneration(object sender, EventArgs e)
        {
            //works better without drawing control?
            //DrawingControl.SuspendDrawing(this);
            // if there are cars left to spawn, spawn car in random lane
            if (numCarsMade < numCarsToMake) //check cars are left to spawn
            {
                // pick random direction
                int hOrVDirection = rnd.Next(2); //pick whether to spawn hcar or vcar
                int bOrFLane = rnd.Next(2); //pick which lane out of hOrVDirection to use

                // confirm direction to spawn car in
                if (hOrVDirection == 0) // check if hCar left to spawn
                {
                    if (h1CarsEndIndex == h1Cars.Length && h2CarsEndIndex == h2Cars.Length)
                        hOrVDirection = 1; // no hcars left so spawn vcar
                }
                else // check if vCar left to spawn
                {
                    if (v1CarsEndIndex == v1Cars.Length && v2CarsEndIndex == v2Cars.Length)
                        hOrVDirection = 0;
                }

                // confirm lane to spawn car in
                if (hOrVDirection == 0) // check if h1Car left to spawn
                {
                    if (bOrFLane == 0 && h1CarsEndIndex == h1Cars.Length) // no h1Cars left so spawn h2car instead
                        bOrFLane = 1; 
                    else if (bOrFLane == 1 && h2CarsEndIndex == h2Cars.Length) //no h2Cars left so spawn h1Car instead
                        bOrFLane = 0;
                }
                else // check if v1Car left to spawn
                {
                    if (bOrFLane == 0 && v1CarsEndIndex == v1Cars.Length) // no v1Cars left so spawn v2car instead
                        bOrFLane = 1;
                    else if (bOrFLane == 1 && v2CarsEndIndex == v2Cars.Length) //no v2Cars left so spawn v1Car instead
                        bOrFLane = 0;
                }

                // finalize spawning destination of car
                bool carMade = true;
                if (hOrVDirection == 0)
                {
                    if (bOrFLane == 0)
                    {
                        if (h1CarsEndIndex < h1Cars.Length - 1)
                            h1CarsEndIndex++;
                        else
                            carMade = false;
                    }
                    else
                    {
                        if (h2CarsEndIndex < h2Cars.Length - 1)
                            h2CarsEndIndex++;
                        else
                            carMade = false;
                    }
                }
                else
                {
                    if (bOrFLane == 0)
                    {
                        if (v1CarsEndIndex < v1Cars.Length - 1)
                            v1CarsEndIndex++;
                        else
                            carMade = false;
                    }
                    else
                    {
                        if (v2CarsEndIndex < v2Cars.Length - 1)
                            v2CarsEndIndex++;
                        else
                            carMade = false;
                    }
                }

                if (carMade)
                    numCarsMade++;
            }

            //lblPrep.Text = h1Cars.Length + ";" + h2Cars.Length + ";" + v1Cars.Length + ";" + v2Cars.Length;
            //lblPrep.Text = h1CarsIndex + ";" + h2CarsIndex + ";" + v1CarsIndex + ";" + v2CarsIndex;
            //lblPrep.Text = h1CarsEndIndex + ";" + h2CarsEndIndex + ";" + v1CarsEndIndex + ";" + v2CarsEndIndex;

            // move all visible cars (cars still in use)
            //MOVING ONE CAR/LANE AT A TIME
            if (h1CarsIndex != h1CarsEndIndex)
            {
                //lblStageScore.Text = "";
                if (h1Cars[h1CarsIndex].car.Visible)
                {
                    if (signalColorH == TrafficLightColor.GREEN)
                        h1Cars[h1CarsIndex].car.Left -= h1Cars[h1CarsIndex].speed;
                    else /*if (signalColorH == TrafficLightColor.RED)*/
                    {
                        int currentSpeed = h1Cars[h1CarsIndex].speed;
                        int dummyX = h1Cars[h1CarsIndex].car.Location.X - currentSpeed/*, dummyY = h1Cars[h1CarsIndex].car.Location.Y*/;
                        if (dummyX < lblIntersectionArea.Bounds.Right && dummyX > lblIntersectionArea.Bounds.Left)
                        {
                            h1Cars[h1CarsIndex].car.Left = lblIntersectionArea.Bounds.Right;
                            h1Cars[h1CarsIndex].timeStopped += timeStageTimer.Interval;
                        }
                        else
                            h1Cars[h1CarsIndex].car.Left -= h1Cars[h1CarsIndex].speed;
                    }
                    //else
                    //{
                    //    //HYLTimeRemaining -= timeStageTimer.Interval;
                    //    int chancesLeft = (int)(HYLTimeRemaining / timeStageTimer.Interval)+1;
                    //    bool goAhead = false;
                    //    int currentSpeed = h1Cars[h1CarsIndex].speed;
                    //    int dummyX = h1Cars[h1CarsIndex].car.Location.X;
                    //    for (int i = 0; i < chancesLeft; i++)
                    //    {
                    //        dummyX -= currentSpeed;
                    //        if (dummyX < lblIntersectionArea.Location.X)
                    //            goAhead = true;
                    //    }
                    //    if (goAhead)
                    //        h1Cars[h1CarsIndex].car.Left -= h1Cars[h1CarsIndex].speed;
                    //    else
                    //        h1Cars[h1CarsIndex].car.Left = lblIntersectionArea.Bounds.Right;
                    //}

                    //check that car is still visible on stage
                    if (h1Cars[h1CarsIndex].car.Bounds.Right < this.Bounds.Left - 500)
                    {
                        // car has left stage
                        h1Cars[h1CarsIndex].car.Visible = false;
                        h1Cars[h1CarsIndex].wasUsed = true;
                        h1Cars[h1CarsIndex].inUse = false;

                        h1Cars[h1CarsIndex].car.Location = pbH1Car1.Location;
                        //this.Controls.Remove(h1Cars[h1CarsIndex].car); //?
                        //if (h1CarsIndex < h1CarsEndIndex - 1)
                        h1CarsIndex++;


                    }
                }
                else
                    h1Cars[h1CarsIndex].car.Visible = true;
            }
            else
                //lblStageScore.Text = "same";

            if (h2CarsIndex != h2CarsEndIndex)
            {
                if (h2Cars[h2CarsIndex].car.Visible)
                {
                    if (signalColorH == TrafficLightColor.GREEN)
                        h2Cars[h2CarsIndex].car.Left += h2Cars[h2CarsIndex].speed;
                    else /*if (signalColorH == TrafficLightColor.RED)*/
                    {
                        int currentSpeed = h2Cars[h2CarsIndex].speed;
                        int dummyX = h2Cars[h2CarsIndex].car.Location.X + currentSpeed/*, dummyY = h1Cars[h1CarsIndex].car.Location.Y*/;
                        if (dummyX < lblIntersectionArea.Bounds.Right && dummyX > lblIntersectionArea.Bounds.Left - 100)
                        { 
                            h2Cars[h2CarsIndex].car.Left = lblIntersectionArea.Bounds.Left - 100;
                            h2Cars[h2CarsIndex].timeStopped += timeStageTimer.Interval;
                        }
                        else
                            h2Cars[h2CarsIndex].car.Left += h2Cars[h2CarsIndex].speed;
                    }

                    //check that car is still visible on stage
                    if (h2Cars[h2CarsIndex].car.Bounds.Left > this.Bounds.Right + 500)
                    {
                        // car has left stage
                        h2Cars[h2CarsIndex].car.Visible = false;
                        h2Cars[h2CarsIndex].wasUsed = true;
                        h2Cars[h2CarsIndex].inUse = false;

                        h2Cars[h2CarsIndex].car.Location = pbH2Car1.Location;
                        //this.Controls.Remove(h2Cars[h2CarsIndex].car); //?
                        //if (h2CarsIndex < h2CarsEndIndex - 1)
                        h2CarsIndex++;
                    }
                }
                else
                    h2Cars[h2CarsIndex].car.Visible = true;
            }

            if (v1CarsIndex != v1CarsEndIndex)
            {
                if (v1Cars[v1CarsIndex].car.Visible)
                {
                    if (signalColorV == TrafficLightColor.GREEN)
                        v1Cars[v1CarsIndex].car.Top -= v1Cars[v1CarsIndex].speed;
                    else /*if (signalColorH == TrafficLightColor.RED)*/
                    {
                        int currentSpeed = v1Cars[v1CarsIndex].speed;
                        int dummyY = v1Cars[v1CarsIndex].car.Location.Y - currentSpeed/*, dummyY = h1Cars[h1CarsIndex].car.Location.Y*/;
                        if (dummyY < lblIntersectionArea.Bounds.Bottom && dummyY > lblIntersectionArea.Bounds.Top)
                        { 
                            v1Cars[v1CarsIndex].car.Top = lblIntersectionArea.Bounds.Bottom;
                            v1Cars[v1CarsIndex].timeStopped += timeStageTimer.Interval;
                        }
                        else
                            v1Cars[v1CarsIndex].car.Top -= v1Cars[v1CarsIndex].speed;
                    }

                    //check that car is still visible on stage
                    if (v1Cars[v1CarsIndex].car.Bounds.Bottom < this.Bounds.Top - 500)
                    {
                        // car has left stage
                        v1Cars[v1CarsIndex].car.Visible = false;
                        v1Cars[v1CarsIndex].wasUsed = true;
                        v1Cars[v1CarsIndex].inUse = false;

                        v1Cars[v1CarsIndex].car.Location = pbV1Car1.Location;
                        //this.Controls.Remove(v1Cars[v1CarsIndex].car); //?
                        //if (v1CarsIndex < v1CarsEndIndex - 1)
                        v1CarsIndex++;
                    }
                }
                else
                    v1Cars[v1CarsIndex].car.Visible = true;
            }

            if (v2CarsIndex != v2CarsEndIndex)
            {
                if (v2Cars[v2CarsIndex].car.Visible)
                {
                    if (signalColorV == TrafficLightColor.GREEN)
                        v2Cars[v2CarsIndex].car.Top += v2Cars[v2CarsIndex].speed;
                    else /*if (signalColorH == TrafficLightColor.RED)*/
                    {
                        int currentSpeed = v2Cars[v2CarsIndex].speed;
                        int dummyY = v2Cars[v2CarsIndex].car.Location.Y + currentSpeed/*, dummyY = h1Cars[h1CarsIndex].car.Location.Y*/;
                        if (dummyY < lblIntersectionArea.Bounds.Bottom && dummyY > lblIntersectionArea.Bounds.Top - 100)
                        {
                            v2Cars[v2CarsIndex].car.Top = lblIntersectionArea.Bounds.Top - 100;
                            v2Cars[v2CarsIndex].timeStopped += timeStageTimer.Interval;
                        }
                        else
                            v2Cars[v2CarsIndex].car.Top += v2Cars[v2CarsIndex].speed;
                    }

                    //check that car is still visible on stage
                    if (v2Cars[v2CarsIndex].car.Bounds.Top > this.Bounds.Bottom + 500)
                    {
                        // car has left stage
                        v2Cars[v2CarsIndex].car.Visible = false;
                        v2Cars[v2CarsIndex].wasUsed = true;
                        v2Cars[v2CarsIndex].inUse = false;

                        v2Cars[v2CarsIndex].car.Location = pbV2Car1.Location;
                        //this.Controls.Remove(v2Cars[v2CarsIndex].car); //?
                        //if (v2CarsIndex < v2CarsEndIndex - 1)
                        v2CarsIndex++;
                    }
                }
                else
                    v2Cars[v2CarsIndex].car.Visible = true;
            }

            // if all cars have left stage, stop timers
            if (h1CarsIndex == h1CarsEndIndex && h2CarsIndex == h2CarsEndIndex && v1CarsIndex == v1CarsEndIndex && v2CarsIndex == v2CarsEndIndex)
                StopTimers();

            // move all visible h1Cars
            //lblPrep.Text = "";
            //for (int i = h1CarsIndex; i < h1CarsEndIndex; i++)
            //{
            //    if (h1Cars[i].car.Visible)
            //    {
            //        int currentCarSpeed = /*h1Cars[i].speedDirection * */h1Cars[i].speed;
            //        if (i == h1CarsIndex)// if current car is 1st car, no need to check for collision with another car
            //        {
            //            h1Cars[i].car.Left -= currentCarSpeed;

            //            // check that car is still visible on stage
            //            if (h1Cars[i].car.Bounds.Right < this.Bounds.Left - 500)
            //            {
            //                // car has left stage
            //                h1Cars[i].car.Visible = false;
            //                h1Cars[i].wasUsed = true;
            //                h1Cars[i].inUse = false;
            //                this.Controls.Remove(h1Cars[i].car); //?
            //                h1CarsIndex++;
            //            }
            //        }
            //        else
            //        {
            //            //Point oldLocation = h1Cars[i].car.Location;
            //            //h1Cars[i].car.Visible = false;
            //            //// check current car won't collide with car in front of it
            //            ////PictureBox dummyCar = new PictureBox();
            //            ////dummyCar.Location = pbH1Car1.Location;
            //            ////dummyCar.Size = h1Cars[i].car.Size;
            //            ////dummyCar.Visible = true; //just to make sure
            //            ////dummyCar.BackColor = Color.Violet;
            //            ////this.Controls.Add(dummyCar);
            //            //////dummyCar.Visible = true;
            //            ////dummyCar.Left -= currentCarSpeed;
            //            //while (currentCarSpeed > 0 && Math.Abs(h1Cars[i].car.Bounds.Left - h1Cars[i - 1].car.Bounds.Right) < 100)
            //            //{
            //            //    h1Cars[i].car.Location = oldLocation;
            //            //    //dummyCar.Location = h1Cars[i].car.Location;
            //            //    currentCarSpeed -= 5;
            //            //    //dummyCar.Left -= currentCarSpeed;
            //            //    if (currentCarSpeed < 0)
            //            //        currentCarSpeed = 0;
            //            //    h1Cars[i].car.Left -= currentCarSpeed;
            //            //}
            //            ////this.Controls.Remove(dummyCar);
            //            //h1Cars[i].car.Visible = true;
            //        }
            //    }
            //    else if (i == h1CarsEndIndex - 1) //check if next car to be spawned has enough space to be spawned
            //    {
            //        if (i == 0 || Math.Abs(pbH1Car1.Bounds.Left - h1Cars[i - 1].car.Bounds.Right) >= 20)
            //            h1Cars[i].car.Visible = true;
            //    }
            //}
            ////move all visible h2Cars
            //for (int i = h2CarsIndex; i < h2CarsEndIndex; i++)
            //{
            //    if (h2Cars[i].car.Visible)
            //    {
            //        int currentCarSpeed = /*h2Cars[i].speedDirection * */h2Cars[i].speed;
            //        if (i == h2CarsIndex)// if current car is 1st car, no need to check for collision with another car
            //        {
            //            h2Cars[i].car.Left += currentCarSpeed;

            //            // check that car is still visible on stage
            //            if (!h2Cars[i].car.Bounds.IntersectsWith(this.ClientRectangle))
            //            {
            //                // car has left stage
            //                h2Cars[i].car.Visible = false;
            //                h2Cars[i].wasUsed = true;
            //                h2Cars[i].inUse = false;
            //                this.Controls.Remove(h2Cars[i].car); //?
            //                h2CarsIndex++;
            //            }
            //        }
            //        else
            //        {
            //            // check current car won't collide with car in front of it
            //            PictureBox dummyCar = h2Cars[i].car;
            //            dummyCar.Visible = false; //just to make sure
            //            this.Controls.Add(dummyCar);
            //            dummyCar.Left += currentCarSpeed;
            //            while (currentCarSpeed > 0 && (dummyCar.Bounds.IntersectsWith(h2Cars[i - 1].car.Bounds) /*|| Math.Abs(dummyCar.Bounds.Right - h2Cars[i - 1].car.Bounds.Left) < 20*/))
            //            {
            //                currentCarSpeed -= 5;
            //                dummyCar.Left += currentCarSpeed;
            //                if (currentCarSpeed < 0)
            //                    currentCarSpeed = 0;
            //            }
            //            this.Controls.Remove(dummyCar);
            //            h2Cars[i].car.Left += currentCarSpeed;
            //        }
            //    }
            //    else if (i == h2CarsEndIndex - 1) //check if next car to be spawned has enough space to be spawned
            //    {
            //        if (i == 0 || Math.Abs(pbH2Car1.Bounds.Right - h2Cars[i - 1].car.Bounds.Left) >= 20)
            //            h2Cars[i].car.Visible = true;
            //    }
            //}
            ////move all visible v1Cars
            //for (int i = v1CarsIndex; i < v1CarsEndIndex; i++)
            //{
            //    if (v1Cars[i].car.Visible)
            //    {
            //        int currentCarSpeed = /*v1Cars[i].speedDirection * */v1Cars[i].speed;
            //        if (i == v1CarsIndex)// if current car is 1st car, no need to check for collision with another car
            //        {
            //            v1Cars[i].car.Top -= currentCarSpeed;

            //            // check that car is still visible on stage
            //            if (!v1Cars[i].car.Bounds.IntersectsWith(this.ClientRectangle))
            //            {
            //                // car has left stage
            //                v1Cars[i].car.Visible = false;
            //                v1Cars[i].wasUsed = true;
            //                v1Cars[i].inUse = false;
            //                this.Controls.Remove(v1Cars[i].car); //?
            //                v1CarsIndex++;
            //            }
            //        }
            //        else
            //        {
            //            // check current car won't collide with car in front of it
            //            PictureBox dummyCar = v1Cars[i].car;
            //            dummyCar.Visible = false; //just to make sure
            //            this.Controls.Add(dummyCar);
            //            dummyCar.Left -= currentCarSpeed;
            //            while (currentCarSpeed > 0 && (dummyCar.Bounds.IntersectsWith(v1Cars[i - 1].car.Bounds) /*|| Math.Abs(dummyCar.Bounds.Top - v1Cars[i - 1].car.Bounds.Bottom) < 20*/))
            //            {
            //                currentCarSpeed -= 5;
            //                dummyCar.Left -= currentCarSpeed;
            //                if (currentCarSpeed < 0)
            //                    currentCarSpeed = 0;
            //            }
            //            this.Controls.Remove(dummyCar);
            //            v1Cars[i].car.Left -= currentCarSpeed;
            //        }
            //    }
            //    else if (i == v1CarsEndIndex - 1) //check if next car to be spawned has enough space to be spawned
            //    {
            //        if (i == 0 || Math.Abs(pbV1Car1.Bounds.Top - v1Cars[i - 1].car.Bounds.Bottom) >= 20)
            //            v1Cars[i].car.Visible = true;
            //    }
            //}
            ////move all visible v2Cars
            //for (int i = v2CarsIndex; i < v2CarsEndIndex; i++)
            //{
            //    if (v2Cars[i].car.Visible)
            //    {
            //        int currentCarSpeed = /*v2Cars[i].speedDirection * */v2Cars[i].speed;
            //        if (i == v2CarsIndex)// if current car is 1st car, no need to check for collision with another car
            //        {
            //            v2Cars[i].car.Top += currentCarSpeed;

            //            // check that car is still visible on stage
            //            if (!v2Cars[i].car.Bounds.IntersectsWith(this.ClientRectangle))
            //            {
            //                // car has left stage
            //                v2Cars[i].car.Visible = false;
            //                v2Cars[i].wasUsed = true;
            //                v2Cars[i].inUse = false;
            //                this.Controls.Remove(v2Cars[i].car); //?
            //                v2CarsIndex++;
            //            }
            //        }
            //        else
            //        {
            //            // check current car won't collide with car in front of it
            //            PictureBox dummyCar = v2Cars[i].car;
            //            dummyCar.Visible = false; //just to make sure
            //            this.Controls.Add(dummyCar);
            //            dummyCar.Top -= currentCarSpeed;
            //            while (currentCarSpeed > 0 && (dummyCar.Bounds.IntersectsWith(v2Cars[i - 1].car.Bounds) /*|| Math.Abs(dummyCar.Bounds.Bottom - v2Cars[i - 1].car.Bounds.Top) < 20*/))
            //            {
            //                currentCarSpeed -= 5;
            //                dummyCar.Top += currentCarSpeed;
            //                if (currentCarSpeed < 0)
            //                    currentCarSpeed = 0;
            //            }
            //            this.Controls.Remove(dummyCar);
            //            v2Cars[i].car.Top += currentCarSpeed;
            //        }
            //    }
            //    else if (i == v2CarsEndIndex - 1) //check if next car to be spawned has enough space to be spawned
            //    {
            //        if (i == 0 || Math.Abs(pbV2Car1.Bounds.Bottom - v2Cars[i - 1].car.Bounds.Top) >= 20)
            //            v2Cars[i].car.Visible = true;
            //    }
            //}

            //cars[0].car.Visible = true;
            //    if (cars[0].speedAffectsX)
            //        cars[0].car.Left += cars[0].speedDirection * cars[0].speed;
            //    else
            //        cars[0].car.Top += cars[0].speedDirection * cars[0].speed;


            //DrawingControl.ResumeDrawing(this);
        }

        //private void TrafficGeneration(object sender, EventArgs e)
        //{
        //    DrawingControl.SuspendDrawing(this);

        //    //check which lanes can move
        //    if (signalColorV == TrafficLightColor.GREEN || signalColorV == TrafficLightColor.YELLOW) 
        //    {
        //        lblPrep.Text = "1";
        //        // v lanes can move
        //        // if green light, cars don't need to stop soon
        //        while (signalColorV == TrafficLightColor.GREEN)
        //        {
        //            // pick which lane to potentially spawn from
        //            int lane = rnd.Next(16) % 2;

        //            //MessageBox.Show("lane = " + lane);
        //            int firstLaneNum;
        //            bool noCarsInLaneLeft = true;
        //            //do
        //            //{
        //            //    firstLaneNum = lane;

        //            //    if (lane == 0 && v1CarsEndIndex == v1Cars.Length) //all v1Cars have gone
        //            //        lane++; //try to spawn v2car
        //            //    else if (lane == 1 && v2CarsEndIndex == v2Cars.Length) //all v2cars have gone
        //            //        lane = 0; //try to spawn v1car
        //            //    noCarsInLaneLeft = !noCarsInLaneLeft; //if this is true by end of loop, then loop executed twice; since there's only 2 lanes, loop only needs to execute twice at most
        //            //} while (firstLaneNum != lane && !noCarsInLaneLeft); //true when (1) one lane has no cars but the other lane hasn't been checked or (2) both lanes have been checked and both have no cars

        //            //MessageBox.Show(numCarsToMake + ". " + v1Cars.Length + ":" + v1CarsIndex + "-" + v2Cars.Length + ":" + v2CarsIndex);
        //            lblPrep.Text = "2";

        //            //    // spawn in next car if able
        //            //    if (lane == 0)
        //            //    {
        //            //        if (v1Cars.Length > 0 && v1CarsIndex < v1CarsEndIndex)  //there are cars to be spawned
        //            //        {
        //            //            if (v1CarsIndex == 0) //no cars have been spawned
        //            //            {
        //            //                //MessageBox.Show("2-1");
        //            //                v1Cars[0].car.Visible = true;
        //            //                v1Cars[0].inUse = true;
        //            //                v1CarsIndex++;
        //            //            }
        //            //            else if (v1Cars.Length > 1)
        //            //            {
        //            //                //check there's space to spawn car in lane
        //            //                if (!v1Cars[v1CarsIndex].car.Bounds.IntersectsWith(v1Cars[v1CarsIndex - 1].car.Bounds))
        //            //                {
        //            //                    v1Cars[v1CarsIndex].car.Visible = true;
        //            //                    v1Cars[v1CarsIndex].inUse = true;
        //            //                    v1CarsIndex++;
        //            //                }
        //            //            }
        //            //        }
        //            //        else
        //            //            v1CarsIndex = -1;
        //            //    }
        //            //    else
        //            //    {
        //            //        if (v2Cars.Length > 0 && v2CarsIndex < v2CarsEndIndex)
        //            //        {
        //            //            if (v2CarsIndex == 0)
        //            //            {
        //            //                //MessageBox.Show("2-2");
        //            //                v2Cars[0].car.Visible = true;
        //            //                v2Cars[0].inUse = true;
        //            //                v2CarsIndex++;
        //            //            }
        //            //            else if (v2Cars.Length > 1)
        //            //            {
        //            //                //check there's space to spawn car in lane
        //            //                if (!v2Cars[v2CarsIndex].car.Bounds.IntersectsWith(v2Cars[v2CarsIndex - 1].car.Bounds))
        //            //                {
        //            //                    v2Cars[v2CarsIndex].car.Visible = true;
        //            //                    v2Cars[v2CarsIndex].inUse = true;
        //            //                    v2CarsIndex++;
        //            //                }
        //            //            }
        //            //        }
        //            //        else
        //            //            v2CarsIndex = -1;
        //            //    }

        //            //    //move all visible cars in v lanes
        //            //    for (int i = v1CarsIndex, j = v2CarsIndex, test = 0; (i != -1 && i < v1CarsIndex) || (j != -1 && j < v2CarsIndex); test++)
        //            //    {
        //            //        //check v1Car hasn't been used
        //            //        if (!v1Cars[i].wasUsed)
        //            //        {
        //            //            //check there isn't a car in front that'll be hit going normal speed
        //            //            if (i == v1CarsIndex && i >= 0) //no car in front
        //            //            {
        //            //                if (signalColorV == TrafficLightColor.YELLOW) //check if car will still be in intersection at end of yellow light
        //            //                {
        //            //                    int check = v1Cars[i].car.Top + v1Cars[i].speed * v1Cars[i].speedDirection;
        //            //                    PictureBox dummyCar = v1Cars[i].car;
        //            //                    dummyCar.Visible = false;
        //            //                    dummyCar.Top = check;
        //            //                    this.Controls.Add(dummyCar);
        //            //                    while (dummyCar.Bounds.IntersectsWith(lblIntersectionArea.Bounds)) //true when car will be in intersection
        //            //                    {
        //            //                        check += v1Cars[i].speedDirection;
        //            //                        dummyCar.Top = check;
        //            //                    }
        //            //                    v1Cars[i].car.Top = check;
        //            //                    this.Controls.Remove(dummyCar);
        //            //                }
        //            //                else
        //            //                    v1Cars[i].car.Top += v1Cars[i].speed * v1Cars[i].speedDirection;
        //            //            }
        //            //            else if (i > 0)//car in front
        //            //            {
        //            //                //check if car will hit car in front if it goes normal speed
        //            //                int check = v1Cars[i].car.Top + v1Cars[i].speed * v1Cars[i].speedDirection;
        //            //                PictureBox dummyCar = v1Cars[i].car;
        //            //                dummyCar.Visible = false;
        //            //                dummyCar.Top = check;
        //            //                this.Controls.Add(dummyCar);
        //            //                while (dummyCar.Bounds.IntersectsWith(v1Cars[i - 1].car.Bounds)) //true when car will hit other car
        //            //                {
        //            //                    check += v1Cars[i].speedDirection * v1Cars[i].speed;
        //            //                    dummyCar.Top = check;
        //            //                }
        //            //                //check if car will still be in intersection at end of yellow light
        //            //                if (signalColorV == TrafficLightColor.YELLOW)
        //            //                {
        //            //                    while (dummyCar.Bounds.IntersectsWith(lblIntersectionArea.Bounds)) //true when car will be in intersection
        //            //                    {
        //            //                        check += v1Cars[i].speedDirection;
        //            //                        dummyCar.Top = check;
        //            //                    }
        //            //                }
        //            //                v1Cars[i].car.Top = check;
        //            //                this.Controls.Remove(dummyCar);
        //            //            }

        //            //            //check car is still visible on stage
        //            //            if (i >= 0 && i < v1CarsEndIndex)
        //            //            {
        //            //                if (v1Cars[i].car.Bounds.Top > this.ClientSize.Height || v1Cars[i].car.Bounds.Bottom < 0) //car isn't visible
        //            //                {
        //            //                    v1CarsEndIndex++;
        //            //                    v1Cars[i].wasUsed = true;
        //            //                    v1Cars[i].inUse = false;
        //            //                    i++;
        //            //                }
        //            //            }

        //            //        }

        //            //        //check v2Car hasn't been used
        //            //        if (!v2Cars[j].wasUsed)
        //            //        {
        //            //            //check there isn't a car in front that'll be hit going normal speed
        //            //            if (j == v2CarsIndex && j >= 0) //no car in front
        //            //            {
        //            //                if (signalColorV == TrafficLightColor.YELLOW) //check if car will still be in intersection at end of yellow light
        //            //                {
        //            //                    int check = v2Cars[j].car.Top + v2Cars[j].speed * v2Cars[j].speedDirection;
        //            //                    PictureBox dummyCar = v2Cars[j].car;
        //            //                    dummyCar.Visible = false;
        //            //                    dummyCar.Top = check;
        //            //                    this.Controls.Add(dummyCar);
        //            //                    while (dummyCar.Bounds.IntersectsWith(lblIntersectionArea.Bounds)) //true when car will be in intersection
        //            //                    {
        //            //                        check += v2Cars[j].speedDirection;
        //            //                        dummyCar.Top = check;
        //            //                    }
        //            //                    v2Cars[j].car.Top = check;
        //            //                    this.Controls.Remove(dummyCar);
        //            //                }
        //            //                else
        //            //                    v2Cars[j].car.Top += v2Cars[j].speed * v2Cars[j].speedDirection;
        //            //            }
        //            //            else if (j > 0)//car in front
        //            //            {
        //            //                //check if car will hit car in front if it goes normal speed
        //            //                int check = v2Cars[j].car.Top + v2Cars[j].speed * v2Cars[j].speedDirection;
        //            //                PictureBox dummyCar = v2Cars[j].car;
        //            //                dummyCar.Visible = false;
        //            //                dummyCar.Top = check;
        //            //                this.Controls.Add(dummyCar);
        //            //                while (dummyCar.Bounds.IntersectsWith(v2Cars[j - 1].car.Bounds)) //true when car will hit other car
        //            //                {
        //            //                    check += v2Cars[j].speedDirection * v2Cars[j].speed;
        //            //                    dummyCar.Top = check;
        //            //                }
        //            //                //check if car will still be in intersection at end of yellow light
        //            //                if (signalColorV == TrafficLightColor.YELLOW)
        //            //                {
        //            //                    while (dummyCar.Bounds.IntersectsWith(lblIntersectionArea.Bounds)) //true when car will be in intersection
        //            //                    {
        //            //                        check += v2Cars[j].speedDirection;
        //            //                        dummyCar.Top = check;
        //            //                    }
        //            //                }
        //            //                v2Cars[j].car.Top = check;
        //            //                this.Controls.Remove(dummyCar);
        //            //            }

        //            //            //check car is still visible on stage
        //            //            if (j >= 0 && i < v2CarsEndIndex)
        //            //            {
        //            //                if (v2Cars[j].car.Bounds.Top > this.ClientSize.Height || v2Cars[j].car.Bounds.Bottom < 0) //car isn't visible
        //            //                {
        //            //                    v2CarsEndIndex++;
        //            //                    v2Cars[j].wasUsed = true;
        //            //                    v2Cars[j].inUse = false;
        //            //                    j++;
        //            //                }
        //            //            }
        //            //        }
        //            //    }
        //            }
        //            //    if (signalColorV == TrafficLightColor.YELLOW)
        //            //        MessageBox.Show("yellow");
        //        }
        //    else if (signalColorH == TrafficLightColor.GREEN || signalColorH == TrafficLightColor.YELLOW) 
        //    {
        //        //MessageBox.Show("one");
        //        // h lanes can move
        //        // if green light, cars don't need to stop soon
        //        while (signalColorH == TrafficLightColor.GREEN)
        //        {
        //            // pick which lane to potentially spawn from
        //            int lane = rnd.Next(16) % 2;

        //            int firstLaneNum;
        //            bool noCarsInLaneLeft = true;
        //            do
        //            {
        //                firstLaneNum = lane;

        //                if (lane == 0 && h1CarsEndIndex == h1Cars.Length) //all h1Cars have gone
        //                    lane++; //try to spawn v2car
        //                else if (lane == 1 && h2CarsEndIndex == h2Cars.Length) //all h2cars have gone
        //                    lane = 0; //try to spawn v1car
        //                noCarsInLaneLeft = !noCarsInLaneLeft; //if this is true by end of loop, then loop executed twice; since there's only 2 lanes, loop only needs to execute twice at most
        //            } while (firstLaneNum != lane && !noCarsInLaneLeft); //true when (1) one lane has no cars but the other lane hasn't been checked or (2) both lanes have been checked and both have no cars

        //            //MessageBox.Show(numCarsToMake+". "+v1Cars.Length+":"+v1CarsIndex + "-" + v2Cars.Length + ":" + v2CarsIndex);

        //            // spawn in next car if able
        //            if (lane == 0)
        //            {
        //                if (h1Cars.Length > 0)  //there are cars to be spawned
        //                {
        //                    if (h1CarsIndex == 0) //no cars have been spawned
        //                    {
        //                        h1Cars[0].car.Visible = true;
        //                        h1Cars[0].inUse = true;
        //                        h1CarsIndex++;
        //                    }
        //                    else
        //                    {
        //                        //check there's space to spawn car in lane
        //                        if (!h1Cars[v1CarsIndex].car.Bounds.IntersectsWith(h1Cars[h1CarsIndex - 1].car.Bounds))
        //                        {
        //                            h1Cars[h1CarsIndex].car.Visible = true;
        //                            h1Cars[h1CarsIndex].inUse = true;
        //                            h1CarsIndex++;
        //                        }
        //                    }
        //                }
        //                else
        //                    h1CarsIndex = -1;
        //            }
        //            else
        //            {
        //                if (h2Cars.Length > 0)
        //                {
        //                    if (h2CarsIndex == 0)
        //                    {
        //                        h2Cars[0].car.Visible = true;
        //                        h2Cars[0].inUse = true;
        //                        h2CarsIndex++;
        //                    }
        //                    else
        //                    {
        //                        //check there's space to spawn car in lane
        //                        if (!h2Cars[h2CarsIndex].car.Bounds.IntersectsWith(h2Cars[h2CarsIndex - 1].car.Bounds))
        //                        {
        //                            h2Cars[v2CarsIndex].car.Visible = true;
        //                            h2Cars[v2CarsIndex].inUse = true;
        //                            h2CarsIndex++;
        //                        }
        //                    }
        //                }
        //                else
        //                    h2CarsIndex = -1;
        //            }

        //            //move all visible cars in v lanes
        //            for (int i = h1CarsIndex, j = h2CarsIndex, test = 0; (i != -1 && i < h1CarsIndex) || (j != -1 && j < h2CarsIndex); test++)
        //            {
        //                //check v1Car hasn't been used
        //                if (!h1Cars[i].wasUsed)
        //                {
        //                    //check there isn't a car in front that'll be hit going normal speed
        //                    if (i == h1CarsIndex && i >= 0) //no car in front
        //                    {
        //                        if (signalColorH == TrafficLightColor.YELLOW) //check if car will still be in intersection at end of yellow light
        //                        {
        //                            int check = h1Cars[i].car.Top + h1Cars[i].speed * h1Cars[i].speedDirection;
        //                            PictureBox dummyCar = h1Cars[i].car;
        //                            dummyCar.Visible = false;
        //                            dummyCar.Top = check;
        //                            this.Controls.Add(dummyCar);
        //                            while (dummyCar.Bounds.IntersectsWith(lblIntersectionArea.Bounds)) //true when car will be in intersection
        //                            {
        //                                check += h1Cars[i].speedDirection;
        //                                dummyCar.Top = check;
        //                            }
        //                            h1Cars[i].car.Top = check;
        //                            this.Controls.Remove(dummyCar);
        //                        }
        //                        else
        //                            h1Cars[i].car.Top += h1Cars[i].speed * h1Cars[i].speedDirection;
        //                    }
        //                    else if (i > 0)//car in front
        //                    {
        //                        //check if car will hit car in front if it goes normal speed
        //                        int check = h1Cars[i].car.Top + h1Cars[i].speed * h1Cars[i].speedDirection;
        //                        PictureBox dummyCar = h1Cars[i].car;
        //                        dummyCar.Visible = false;
        //                        dummyCar.Top = check;
        //                        this.Controls.Add(dummyCar);
        //                        while (dummyCar.Bounds.IntersectsWith(h1Cars[i - 1].car.Bounds)) //true when car will hit other car
        //                        {
        //                            check += h1Cars[i].speedDirection * h1Cars[i].speed;
        //                            dummyCar.Top = check;
        //                        }
        //                        //check if car will still be in intersection at end of yellow light
        //                        if (signalColorH == TrafficLightColor.YELLOW)
        //                        {
        //                            while (dummyCar.Bounds.IntersectsWith(lblIntersectionArea.Bounds)) //true when car will be in intersection
        //                            {
        //                                check += h1Cars[i].speedDirection;
        //                                dummyCar.Top = check;
        //                            }
        //                        }
        //                        h1Cars[i].car.Top = check;
        //                        this.Controls.Remove(dummyCar);
        //                    }

        //                    //check car is still visible on stage
        //                    if (i >= 0 && i < h1CarsEndIndex)
        //                    {
        //                        if (h1Cars[i].car.Bounds.Top > this.ClientSize.Height || h1Cars[i].car.Bounds.Bottom < 0) //car isn't visible
        //                        {
        //                            h1CarsEndIndex++;
        //                            h1Cars[i].wasUsed = true;
        //                            h1Cars[i].inUse = false;
        //                            i++;
        //                        }
        //                    }

        //                }

        //                //check h2Car hasn't been used
        //                if (!h2Cars[j].wasUsed)
        //                {
        //                    //check there isn't a car in front that'll be hit going normal speed
        //                    if (j == h2CarsIndex && j >= 0) //no car in front
        //                    {
        //                        if (signalColorH == TrafficLightColor.YELLOW) //check if car will still be in intersection at end of yellow light
        //                        {
        //                            int check = h2Cars[j].car.Top + h2Cars[j].speed * h2Cars[j].speedDirection;
        //                            PictureBox dummyCar = h2Cars[j].car;
        //                            dummyCar.Visible = false;
        //                            dummyCar.Top = check;
        //                            this.Controls.Add(dummyCar);
        //                            while (dummyCar.Bounds.IntersectsWith(lblIntersectionArea.Bounds)) //true when car will be in intersection
        //                            {
        //                                check += h2Cars[j].speedDirection;
        //                                dummyCar.Top = check;
        //                            }
        //                            h2Cars[j].car.Top = check;
        //                            this.Controls.Remove(dummyCar);
        //                        }
        //                        else
        //                            h2Cars[j].car.Top += h2Cars[j].speed * h2Cars[j].speedDirection;
        //                    }
        //                    else if (j > 0)//car in front
        //                    {
        //                        //check if car will hit car in front if it goes normal speed
        //                        int check = h2Cars[j].car.Top + h2Cars[j].speed * h2Cars[j].speedDirection;
        //                        PictureBox dummyCar = h2Cars[j].car;
        //                        dummyCar.Visible = false;
        //                        dummyCar.Top = check;
        //                        this.Controls.Add(dummyCar);
        //                        while (dummyCar.Bounds.IntersectsWith(h2Cars[j - 1].car.Bounds)) //true when car will hit other car
        //                        {
        //                            check += h2Cars[j].speedDirection * h2Cars[j].speed;
        //                            dummyCar.Top = check;
        //                        }
        //                        //check if car will still be in intersection at end of yellow light
        //                        if (signalColorH == TrafficLightColor.YELLOW)
        //                        {
        //                            while (dummyCar.Bounds.IntersectsWith(lblIntersectionArea.Bounds)) //true when car will be in intersection
        //                            {
        //                                check += h2Cars[j].speedDirection;
        //                                dummyCar.Top = check;
        //                            }
        //                        }
        //                        h2Cars[j].car.Top = check;
        //                        this.Controls.Remove(dummyCar);
        //                    }

        //                    //check car is still visible on stage
        //                    if (j >= 0 && i < h2CarsEndIndex)
        //                    {
        //                        if (h2Cars[j].car.Bounds.Top > this.ClientSize.Height || h2Cars[j].car.Bounds.Bottom < 0) //car isn't visible
        //                        {
        //                            h2CarsEndIndex++;
        //                            h2Cars[j].wasUsed = true;
        //                            h2Cars[j].inUse = false;
        //                            j++;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    //MessageBox.Show("hu");
        //    lblBackBtn.Text = "hu";

        //    DrawingControl.ResumeDrawing(this);
        //}

        private void KeyboardKeyDown(object sender, KeyEventArgs e)
        {
            //if (playstyle.Equals("keyboard"))
            //{
            //    int previousChoice = menuChoiceSelected;
            //    bool arrowKeyPressed = true;

            //    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            //    {
            //        menuChoiceSelected += (menuChoiceSelected == 4 ? -4 : 1);
            //        while (menuChoices[menuChoiceSelected].Font.Strikeout)
            //            menuChoiceSelected++;
            //    }
            //    else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            //    {
            //        menuChoiceSelected -= (menuChoiceSelected == 0 ? -4 : (menuChoiceSelected == -1 ? -5 : 1));
            //        while (menuChoices[menuChoiceSelected].Font.Strikeout)
            //            menuChoiceSelected--;
            //    }
            //    else
            //        arrowKeyPressed = false;

            //    if (arrowKeyPressed)
            //    {
            //        if (previousChoice != -1)
            //            menuChoices[previousChoice].ForeColor = Color.Black;
            //        menuChoices[menuChoiceSelected].ForeColor = Color.DeepSkyBlue;
            //    }
            //    else if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space) && menuChoiceSelected != -1)
            //    {
            //        if (menuChoices[menuChoiceSelected].Name.Equals("lblPlaystyleButton"))
            //        {
            //            playstyle = "mouse";
            //            lblMenu5PlaystyleBtn.Text = "Mode: " + playstyle;
            //            menuChoiceSelected = -1;
            //            lblMenu5PlaystyleBtn.ForeColor = Color.Black;
            //        }
            //        switch (menuChoiceSelected)
            //        {
            //            case 0:
            //                StoryScreen newGame = new StoryScreen(this.Location, playstyle, false);
            //                newGame.Show();
            //                this.Close();
            //                break;
            //            case 1:
            //                StageSelectionScreen loadGame = new StageSelectionScreen(this.Location/*, LoadGameSave()*/);
            //                loadGame.Show();
            //                this.Close();
            //                break;
            //            case 2:
            //                AlbumScreen viewAlbum = new AlbumScreen(this.Location);
            //                viewAlbum.Show();
            //                this.Close();
            //                break;
            //            case 3:
            //                TutorialScreen viewTutorial = new TutorialScreen(this.Location);
            //                viewTutorial.Show();
            //                this.Close();
            //                break;
            //            case 4:
            //                playstyle = "mouse";
            //                lblMenu5PlaystyleBtn.Text = "Mode: " + playstyle;
            //                menuChoiceSelected = -1;
            //                break;
            //        }
            //    }
            //}
        }

        private void BackBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                StageSelectionScreen stageSelect = new StageSelectionScreen(this.Location, game);
                stageSelect.Show();
                this.Close();
            }
        }

        private bool CheckLegality()
        {
            bool[] timesMatch = new bool[2]; //timesMatch[0] = hTimes, timesMatch[1] = vTimes

            for (int i = 0, j = 0; i < 3; i+=2, j++)
            {
                int lightNum = 0;
                bool timesMatched = true;
                while (lightNum < 3)
                {
                    int time1 = trafficLightSettings[i].time[lightNum] * (trafficLightSettings[i].timeUnit[lightNum].Equals("sec") ? 1 : 60);
                    int time2 = trafficLightSettings[i+1].time[lightNum] * (trafficLightSettings[i+1].timeUnit[lightNum].Equals("sec") ? 1 : 60);
                    if (time1 != time2)
                    {
                        timesMatched = false;
                        break;
                    }
                    lightNum++;
                }
                timesMatch[j] = timesMatched;
            }

            if (!timesMatch[0])
                MessageBox.Show("Error: The traffic lights facing horizontal traffic (cars going left-to-right and right-to-left) need to have the same settings.");
            if (!timesMatch[1])
                MessageBox.Show("Error: The traffic lights facing vertical traffic (cars going top-to-bottom and bottom-to-top) need to have the same settings.");
            
            return (timesMatch[0] && timesMatch[1]);
        }

        private void StopTimers()
        {
            timeGreenLightTimerH.Stop();
            timeGreenLightTimerV.Stop();
            timeRedLightTimerH.Stop();
            timeRedLightTimerV.Stop();
            timeYellowLightTimerH.Stop();
            timeYellowLightTimerV.Stop();
            timeStageTimer.Stop();
            MessageBox.Show("stopp");
        }

        private void ReStartTimers()
        {
            timeRedLightTimerH.Interval = 17 * trafficLightSettings[0].time[0] * (trafficLightSettings[0].timeUnit[0].Equals("sec") ? 1 : 60);
            timeYellowLightTimerH.Interval = 17 * trafficLightSettings[0].time[1] * (trafficLightSettings[0].timeUnit[1].Equals("sec") ? 1 : 60);
            timeGreenLightTimerH.Interval = 17 * trafficLightSettings[0].time[2] * (trafficLightSettings[0].timeUnit[2].Equals("sec") ? 1 : 60);
            timeRedLightTimerV.Interval = 17 * trafficLightSettings[2].time[0] * (trafficLightSettings[2].timeUnit[0].Equals("sec") ? 1 : 60);
            timeYellowLightTimerV.Interval = 17 * trafficLightSettings[2].time[1] * (trafficLightSettings[2].timeUnit[1].Equals("sec") ? 1 : 60);
            timeGreenLightTimerV.Interval = 17 * trafficLightSettings[2].time[2] * (trafficLightSettings[2].timeUnit[2].Equals("sec") ? 1 : 60);

            timeGreenLightTimerH.Start();
            timeStageTimer.Start();
        }

        private void CalculateAvgTimeStopped()
        {
            int avg = 0;

            //cars.Clear();
            //cars.AddRange(h1Cars);
            //cars.AddRange(h2Cars);
            //cars.AddRange(v1Cars);
            //cars.AddRange(v2Cars);

            foreach (CCar c in h1Cars)
                avg += c.timeStopped;
            foreach (CCar c in h2Cars)
                avg += c.timeStopped;
            foreach (CCar c in v1Cars)
                avg += c.timeStopped;
            foreach (CCar c in v2Cars)
                avg += c.timeStopped;
            avg = (int)(avg / (h1Cars.Length + h2Cars.Length + v1Cars.Length + v2Cars.Length));

            if (stagePhase == StagePhase.PRE)
            {
                game.Stages[0].InitialScore = avg;
                lblStageScore.Text += avg + "";
            }
            else
                game.Stages[0].CurrentPlayerScore = avg;

            //for (int i = 0; i < cars.Count; i++)
            //{
            //    CCar c = cars[i];
            //    c.timeStopped = 0;
            //    cars[i] = c;
            //}
        }

        private void ResetCars()
        {
            h1CarsIndex = h2CarsIndex = v1CarsIndex = v2CarsIndex = 0;
            //h1CarsEndIndex = h2CarsEndIndex = v1CarsEndIndex = v2CarsEndIndex = 0;

            //for  (int i = 0; i < cars.Count; i++)
            //{
            //    PictureBox c = new PictureBox();
            //    c = cars[i].car;
            //    c.Visible = false;
            //    this.Controls.Add(c);
            //    //cars[i].car = c;
            //}
            //GroupCars();

            //MessageBox.Show("total cars = " + numCarsToMake + "; h1 = " + h1Cars.Length + ", h2 = " + h2Cars.Length + ", v1 = " + v1Cars.Length + ", v2 = " + v2Cars.Length);

            numCarsMade = 0;

            for (int i = 0; i < h1Cars.Length; i++)
            //{
            //    h1Cars[i].car.Location = pbH1Car1.Location;
            //    h1Cars[i].car.Visible = false;
                h1Cars[i].timeStopped = 0;
            //}
            for (int i = 0; i < h2Cars.Length; i++)
            //{
            //    h2Cars[i].car.Location = pbH2Car1.Location;
            //    h2Cars[i].car.Visible = false;
                h2Cars[i].timeStopped = 0;
            //}
            for (int i = 0; i < v1Cars.Length; i++)
            //{
            //    v1Cars[i].car.Location = pbV1Car1.Location;
            //    v1Cars[i].car.Visible = false;
                v1Cars[i].timeStopped = 0;
            //}
            for (int i = 0; i < v2Cars.Length; i++)
            //{
            //    v2Cars[i].car.Location = pbV2Car1.Location;
            //    v2Cars[i].car.Visible = false;
                v2Cars[i].timeStopped = 0;
            //}
        }

        private void FinishPrepBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                if (stagePhase == StagePhase.PRE)
                {
                    CalculateAvgTimeStopped();
                    stagePhase = StagePhase.MID;
                    lblPrep.Text = "Prep";
                    lblFinishPrepBtn.Text = "Finish";
                    //timeStageTimer.Enabled = false;
                    //StopTimers();
                }
                else if (stagePhase == StagePhase.MID)
                {
                    if (CheckLegality())
                    {
                        flpTimerTrafficLightMenu.Visible = false;
                        stagePhase = StagePhase.POST;
                        lblPrep.Text = "Post-Prep";
                        lblFinishPrepBtn.Text = "Continue";
                        //timeStageTimer.Enabled = true;
                        ResetCars();
                        ReStartTimers();
                    }
                }
                else
                {
                    CalculateAvgTimeStopped();
                    ResultsScreen results = new ResultsScreen(this.Location, game);
                    results.Show();
                    this.Close();
                }
            }
        }

        private void PauseBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                PauseScreen pause = new PauseScreen(this, this.Location, game);
                pause.Show();
                this.Hide();
            }
        }

        private void ShowTrafficLightSettingsClick(object sender, MouseEventArgs e)
        {
            PictureBox trafficLight = (PictureBox)sender;

            if (trafficLight.Name.EndsWith("H1"))
                trafficLightSelected = 0;
            else if (trafficLight.Name.EndsWith("H2"))
                trafficLightSelected = 1;
            else if (trafficLight.Name.EndsWith("V1"))
                trafficLightSelected = 2;
            else if (trafficLight.Name.EndsWith("V2"))
                trafficLightSelected = 3;
            else
                trafficLightSelected = -1;

            SetUpTrafficLightSettingsMenu(trafficLightSettings[trafficLightSelected]);
            flpTimerTrafficLightMenu.Visible = true;
        }

        private void HideTrafficLightSettingsClick(object sender, MouseEventArgs e)
        {
            flpTimerTrafficLightMenu.Visible = false;
        }

        private void TimeInputted(object sender, EventArgs e)
        {
            TextBox trafficLightTime = (TextBox)sender;
            if (!String.IsNullOrEmpty(trafficLightTime.Text.Trim()))
            {
                int trafficLightTimeSelected = int.Parse(trafficLightTime.Name.Substring(trafficLightTime.Name.Length - 1));
                bool isNumber = true;

                foreach (char c in trafficLightTime.Text)
                {
                    if (!Char.IsDigit(c))
                    {
                        isNumber = false;
                        break;
                    }
                } 

                if (isNumber)
                {
                    int trafficLightTimeNum = int.Parse(trafficLightTime.Text);

                    if (trafficLightTimeNum > 0)
                        trafficLightSettings[trafficLightSelected].time[trafficLightTimeSelected - 1] = trafficLightTimeNum;
                }
            }
        }

        private void TimeUnitChanged(object sender, EventArgs e)
        {
            ComboBox trafficLightUnit = (ComboBox)sender;
            int trafficLightUnitSelected = int.Parse(trafficLightUnit.Name.Substring(trafficLightUnit.Name.Length - 1));
            string trafficLightUnitType = (trafficLightUnit.SelectedIndex == 1? "min":"sec");

            //MessageBox.Show(trafficLightUnitType);

            if (trafficLightUnitType.Equals("sec") || trafficLightUnitType.Equals("min"))
                trafficLightSettings[trafficLightSelected].timeUnit[trafficLightUnitSelected - 1] = trafficLightUnitType;
        }

        private void SetUpTrafficLightSettingsMenu(TrafficLightSettings tlSettings)
        {
            txtLightTime1.Text = tlSettings.time[0].ToString();
            txtLightTime2.Text = tlSettings.time[1].ToString();
            txtLightTime3.Text = tlSettings.time[2].ToString();
            cmbTimeUnit1.SelectedIndex = (tlSettings.timeUnit[0].Equals("min") ? 1 : 0); 
            cmbTimeUnit2.SelectedIndex = (tlSettings.timeUnit[1].Equals("min") ? 1 : 0);
            cmbTimeUnit3.SelectedIndex = (tlSettings.timeUnit[2].Equals("min") ? 1 : 0);
            flpTimerTrafficLightMenu.Location = new Point(tlSettings.xOfMenu, tlSettings.yOfMenu);
        }

        private void SetUpInitialTrafficLightSettings()
        {
            //menu locations : h1 (487,196) h2 (366, 196) v1 (372, 255) v2 (372, 199)
            TrafficLightSettings[] hTrafficLightSettings = new TrafficLightSettings[2];
            TrafficLightSettings[] vTrafficLightSettings = new TrafficLightSettings[2];

            for (int i = 0; i < hTrafficLightSettings.Length; i++)
            {
                hTrafficLightSettings[i].time = new int[3] { 1, 1, 1 };
                hTrafficLightSettings[i].timeUnit = new string[3] { "min", "min", "min" };
                hTrafficLightSettings[i].yOfMenu = 196;
            }
            hTrafficLightSettings[0].xOfMenu = 487;
            hTrafficLightSettings[1].xOfMenu = 366;

            for (int i = 0; i < vTrafficLightSettings.Length; i++)
            {
                vTrafficLightSettings[i].time = new int[3] { 1, 1, 1 };
                vTrafficLightSettings[i].timeUnit = new string[3] { "min", "min", "min" };
                vTrafficLightSettings[i].xOfMenu = 372;
            }
            vTrafficLightSettings[0].yOfMenu = 255;
            vTrafficLightSettings[1].yOfMenu = 199;

            trafficLightSettings = new TrafficLightSettings[hTrafficLightSettings.Length + vTrafficLightSettings.Length];
            int tlsIndex = 0;
            for (int i = 0; i < hTrafficLightSettings.Length && tlsIndex < trafficLightSettings.Length; i++, tlsIndex++)
                trafficLightSettings[tlsIndex] = hTrafficLightSettings[i];
            for (int i = 0; i < vTrafficLightSettings.Length && tlsIndex < trafficLightSettings.Length; i++, tlsIndex++)
                trafficLightSettings[tlsIndex] = vTrafficLightSettings[i];
        }
    }
    class DrawingControl
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }
    }
}

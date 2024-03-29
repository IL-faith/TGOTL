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
    public partial class Stage5Prep : Form
    {
        struct CCar
        {
            internal PictureBox car;
            // 4 speeds, speed limit -10, -5, +0 (equal to), +5
            internal int speed, speedDirection, timeStopped;
            internal bool inUse, wasUsed, speedAffectsX;
        };

        struct TrafficLightSettings
        {
            internal int[] time;
            internal string[] timeUnit;
            internal int xOfMenu;
            internal int yOfMenu;
        };

        enum StagePhase { PRE, MID, POST };
        enum TrafficLightColor { RED, GREEN, YELLOW };
        enum CarType { H1, H2, V1, V2 };

        List<CCar> cars = new List<CCar>();
        CCar[] h1Cars, h2Cars, v1Cars, v2Cars;
        int h1CarsIndex = 0, h2CarsIndex = 0, v1CarsIndex = 0, v2CarsIndex = 0;
        int h1CarsEndIndex = 0, h2CarsEndIndex = 0, v1CarsEndIndex = 0, v2CarsEndIndex = 0;

        CarType[] carsSecondRun;
        int carsIndex = 0;

        TrafficLightSettings[] trafficLightSettings;
        int trafficLightSelected = -1;
        bool lightTimerPass2 = false;

        TrafficLightColor signalColorH = TrafficLightColor.RED, signalColorV = TrafficLightColor.GREEN;
        StagePhase stagePhase = StagePhase.PRE;

        Game game;
        Random rnd = new Random();
        int numCarsToMake, numCarsMade = 0, stageSpeedLimit;

        public Stage5Prep(Point formPosition, Game g)
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

            stageSpeedLimit = 70;
            numCarsToMake = 15;//rnd.Next(100) + 60;
            GenerateCars();
            GroupCars();

            MessageBox.Show("total cars = " + numCarsToMake + "; h1 = " + h1Cars.Length + ", h2 = " + h2Cars.Length + ", v1 = " + v1Cars.Length + ", v2 = " + v2Cars.Length);

            SetUpTrafficLightTimers();

            carsSecondRun = new CarType[numCarsToMake];
            numCarsMade = 0;
            timeRedLightTimerH.Start();
            timeStageTimer.Start();
        }

        private void SetUpTrafficLightTimers()
        {
            // h = 0,1 v = 2,3
            int redLightTime, yellowLightTime, greenLightTime;
            redLightTime = trafficLightSettings[0].time[0] * (trafficLightSettings[0].timeUnit[0].Equals("min")? 60:1) * 17;
            yellowLightTime = trafficLightSettings[0].time[1] * (trafficLightSettings[0].timeUnit[1].Equals("min") ? 60 : 1) * 17;
            greenLightTime = trafficLightSettings[0].time[2] * (trafficLightSettings[0].timeUnit[2].Equals("min") ? 60 : 1) * 17;

            timeRedLightTimerH.Interval = redLightTime;
            timeYellowLightTimerH.Interval = yellowLightTime;
            timeGreenLightTimerH.Interval = greenLightTime;

            redLightTime = trafficLightSettings[2].time[0] * (trafficLightSettings[2].timeUnit.Equals("min") ? 60 : 1) * 17;
            yellowLightTime = trafficLightSettings[2].time[1] * (trafficLightSettings[2].timeUnit[1].Equals("min") ? 60 : 1) * 17;
            greenLightTime = trafficLightSettings[2].time[2] * (trafficLightSettings[2].timeUnit[2].Equals("min") ? 60 : 1) * 17;

            timeRedLightTimerV.Interval =  redLightTime;
            timeYellowLightTimerV.Interval = yellowLightTime;
            timeGreenLightTimerV.Interval = greenLightTime;

            //timeRedLightTimerH.Start();
        }

        private void LightIsRedH(object sender, EventArgs e)
        {
            lblPrep.Text = "redhv";
            if (lightTimerPass2)
            {
                timeRedLightTimerH.Stop();
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
                signalColorH = TrafficLightColor.RED; //signalColorV = red
                timeRedLightTimerV.Start(); //transition time from h lights to v lights
            }
            else
            {
                lightTimerPass2 = true;
            }
        }
        private void LightIsRedV(object sender, EventArgs e)
        {
            lblPrep.Text = "redvh";
            if (lightTimerPass2)
            {
                timeRedLightTimerV.Stop();
                lightTimerPass2 = false;
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
                signalColorV = TrafficLightColor.RED; //signalColorH = red
                timeRedLightTimerH.Start(); //transition time from v lights to h lights
            }
            else
                lightTimerPass2 = true;
        }

        private void TrafficGeneration1(object sender, EventArgs e)
        {
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
                {
                    numCarsMade++;

                    if (hOrVDirection == 0 && bOrFLane == 0)
                        carsSecondRun[carsIndex] = CarType.H1;
                    else if (hOrVDirection == 0 && bOrFLane == 1)
                        carsSecondRun[carsIndex] = CarType.H2;
                    else if (hOrVDirection == 1 && bOrFLane == 0)
                        carsSecondRun[carsIndex] = CarType.V1;
                    else
                        carsSecondRun[carsIndex] = CarType.V2;
                    carsIndex++;
                }
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
            //else
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
        }

        private void TrafficGeneration2(object sender, EventArgs e)
        {
            //lblStageScore.Text = h1CarsIndex + ";" + h2CarsIndex + ";" + v1CarsIndex + ";" + v2CarsIndex;
            //lblStageScore.Text += "\n"+h1CarsEndIndex + ";" + h2CarsEndIndex + ";" + v1CarsEndIndex + ";" + v2CarsEndIndex;

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

                    //check that car is still visible on stage
                    if (h1Cars[h1CarsIndex].car.Bounds.Right < this.Bounds.Left - 500)
                    {
                        // car has left stage
                        h1Cars[h1CarsIndex].car.Visible = false;
                        h1Cars[h1CarsIndex].wasUsed = true;
                        h1Cars[h1CarsIndex].inUse = false;

                        h1Cars[h1CarsIndex].car.Location = pbH1Car1.Location;
                        h1CarsIndex++;


                    }
                }
                else
                    h1Cars[h1CarsIndex].car.Visible = true;
            }

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
        }

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
            timeStageTimer2.Stop();
            //MessageBox.Show("stopp");
        }

        private void ReStartTimers()
        {
            timeRedLightTimerH.Interval = 17 * trafficLightSettings[0].time[0] * (trafficLightSettings[0].timeUnit[0].Equals("sec") ? 1 : 60);
            timeYellowLightTimerH.Interval = 17 * trafficLightSettings[0].time[1] * (trafficLightSettings[0].timeUnit[1].Equals("sec") ? 1 : 60);
            timeGreenLightTimerH.Interval = 17 * trafficLightSettings[0].time[2] * (trafficLightSettings[0].timeUnit[2].Equals("sec") ? 1 : 60);
            timeRedLightTimerV.Interval = 17 * trafficLightSettings[2].time[0] * (trafficLightSettings[2].timeUnit[0].Equals("sec") ? 1 : 60);
            timeYellowLightTimerV.Interval = 17 * trafficLightSettings[2].time[1] * (trafficLightSettings[2].timeUnit[1].Equals("sec") ? 1 : 60);
            timeGreenLightTimerV.Interval = 17 * trafficLightSettings[2].time[2] * (trafficLightSettings[2].timeUnit[2].Equals("sec") ? 1 : 60);

            lightTimerPass2 = false;
        }

        private void CalculateAvgTimeStopped()
        {
            int avg = 0;

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
        }

        private void ResetCars()
        {
            h1CarsIndex = h2CarsIndex = v1CarsIndex = v2CarsIndex = 0;

            //MessageBox.Show("total cars = " + numCarsToMake + "; h1 = " + h1Cars.Length + ", h2 = " + h2Cars.Length + ", v1 = " + v1Cars.Length + ", v2 = " + v2Cars.Length);

            numCarsMade = 0;

            for (int i = 0; i < h1Cars.Length; i++)
                h1Cars[i].timeStopped = 0;
            for (int i = 0; i < h2Cars.Length; i++)
                h2Cars[i].timeStopped = 0;
            for (int i = 0; i < v1Cars.Length; i++)
                v1Cars[i].timeStopped = 0;
            for (int i = 0; i < v2Cars.Length; i++)
                v2Cars[i].timeStopped = 0;
        }
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
                }
                else if (stagePhase == StagePhase.MID)
                {
                    if (CheckLegality())
                    {
                        flpTimerTrafficLightMenu.Visible = false;
                        stagePhase = StagePhase.POST;
                        lblPrep.Text = "Post-Prep";
                        lblFinishPrepBtn.Text = "Continue";
                        ResetCars();
                        ReStartTimers();
                        timeRedLightTimerH.Start();
                        timeStageTimer2.Start();
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
                hTrafficLightSettings[i].time = new int[3] { 40, 40, 40 };
                hTrafficLightSettings[i].timeUnit = new string[3] { "sec", "sec", "sec" };
                hTrafficLightSettings[i].yOfMenu = 196;
            }
            hTrafficLightSettings[0].xOfMenu = 487;
            hTrafficLightSettings[1].xOfMenu = 366;

            for (int i = 0; i < vTrafficLightSettings.Length; i++)
            {
                vTrafficLightSettings[i].time = new int[3] { 40, 40, 40 };
                vTrafficLightSettings[i].timeUnit = new string[3] { "sec", "sec", "sec" };
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
}

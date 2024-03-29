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
    public partial class Stage4Prep : Form
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
            internal int lightStart;
        };

        enum StagePhase { PRE, MID, POST };
        enum TrafficLightColor { RED, GREEN, YELLOW };
        enum CarType { H1, H2, V1, V2 };

        List<CCar> cars = new List<CCar>();
        CCar[] h1Cars, h2Cars;
        int h1CarsIndex = 0, h2CarsIndex = 0;
        int h1CarsEndIndex = 0, h2CarsEndIndex = 0;

        CarType[] carsSecondRun;
        int carsIndex = 0;

        TrafficLightSettings[] trafficLightSettings;
        int trafficLightSelected = -1;
        bool lightTimerPass2 = false;

        TrafficLightColor signalColorH1 = TrafficLightColor.RED, signalColorH2 = TrafficLightColor.GREEN;
        StagePhase stagePhase = StagePhase.PRE;

        Game game;
        Random rnd = new Random();
        int numCarsToMake, numCarsMade = 0, stageSpeedLimit;

        List<PictureBox> npcHCars = new List<PictureBox>();
        List<int> npcHCarsSpeeds = new List<int>();

        public Stage4Prep(Point formPosition, Game g)
        {
            InitializeComponent();
            
            StopTimers();

            this.Location = formPosition;
            game = g;

            flpTimerTrafficLightMenu.Visible = false;
            SetUpInitialTrafficLightSettings();
            lblPrep.Text = "Pre-Prep";
            lblFinishPrepBtn.Text = "Continue";
            pbH1Car1.Visible = false;
            pbH2Car2.Visible = false;


            stageSpeedLimit = 100;
            numCarsToMake = 15;//rnd.Next(100) + 60;
            GenerateCars();
            GroupCars();

            MessageBox.Show("total cars = " + numCarsToMake + "; h1 = " + h1Cars.Length + ", h2 = " + h2Cars.Length);

            SetUpTrafficLightTimers();

            carsSecondRun = new CarType[numCarsToMake];
            numCarsMade = 0;
            timeRedLightTimerH1.Start();
            timeStageTimer.Start();
        }

        private void SetUpTrafficLightTimers()
        {
            // h = 0,1 v = 2,3
            int redLightTime, yellowLightTime, greenLightTime;
            redLightTime = trafficLightSettings[0].time[0] * (trafficLightSettings[0].timeUnit[0].Equals("min")? 60:1) * 20;
            yellowLightTime = trafficLightSettings[0].time[1] * (trafficLightSettings[0].timeUnit[1].Equals("min") ? 60 : 1) * 20;
            greenLightTime = trafficLightSettings[0].time[2] * (trafficLightSettings[0].timeUnit[2].Equals("min") ? 60 : 1) * 20;

            timeRedLightTimerH1.Interval = redLightTime;
            timeYellowLightTimerH1.Interval = yellowLightTime;
            timeGreenLightTimerH1.Interval = greenLightTime;

            redLightTime = trafficLightSettings[1].time[0] * (trafficLightSettings[1].timeUnit.Equals("min") ? 60 : 1) * 20;
            yellowLightTime = trafficLightSettings[1].time[1] * (trafficLightSettings[1].timeUnit[1].Equals("min") ? 60 : 1) * 20;
            greenLightTime = trafficLightSettings[1].time[2] * (trafficLightSettings[1].timeUnit[2].Equals("min") ? 60 : 1) * 20;

            timeRedLightTimerH2.Interval = redLightTime;
            timeYellowLightTimerH2.Interval = yellowLightTime;
            timeGreenLightTimerH2.Interval = greenLightTime;
        }

        private void LightIsRedH(object sender, EventArgs e)
        {
            //lblPrep.Text = "red";
            if (lightTimerPass2)
            {
                timeRedLightTimerH1.Stop();
                lightTimerPass2 = false;
                //lblPrep.Text += " 2nd pass";
                signalColorH1 = TrafficLightColor.GREEN; //signalColorH2 = red
                timeGreenLightTimerH1.Start();
            }
            else
                lightTimerPass2 = true;
        }
        private void LightIsGreenH(object sender, EventArgs e)
        {
            //lblPrep.Text = "green";
            if (lightTimerPass2)
            {
                timeGreenLightTimerH1.Stop();
                lightTimerPass2 = false;
                signalColorH1 = TrafficLightColor.YELLOW; //signalColorH2 = red
                timeYellowLightTimerH1.Start();
            }
            else
                lightTimerPass2 = true;
        }

        private void LightIsYellowH(object sender, EventArgs e)
        {
            //lblPrep.Text = "yellow";
            if (lightTimerPass2)
            {
                timeYellowLightTimerH1.Stop();
                lightTimerPass2 = false;
                signalColorH1 = TrafficLightColor.RED; //signalColorH2 = red
                timeRedLightTimerH1.Start(); 
            }
            else
            {
                lightTimerPass2 = true;
            }
        }
        private void LightIsRedH2(object sender, EventArgs e)
        {
            //lblPrep.Text = "redvh";
            if (lightTimerPass2)
            {
                timeRedLightTimerH2.Stop();
                lightTimerPass2 = false;
                signalColorH2 = TrafficLightColor.GREEN; //signalColorH1 = red
                timeGreenLightTimerH2.Start();
            }
            else
                lightTimerPass2 = true;
        }
        private void LightIsGreenH2(object sender, EventArgs e)
        {
            //lblPrep.Text = "redh";
            if (lightTimerPass2)
            {
                timeGreenLightTimerH2.Stop();
                lightTimerPass2 = false;
                signalColorH2 = TrafficLightColor.YELLOW; //signalColorH1 = red
                timeYellowLightTimerH2.Start();
            }
            else
                lightTimerPass2 = true;
        }

        private void LightIsYellowH2(object sender, EventArgs e)
        {
            //lblPrep.Text = "redh";
            if (lightTimerPass2)
            {
                timeYellowLightTimerH2.Stop();
                lightTimerPass2 = false;
                signalColorH2 = TrafficLightColor.RED; //signalColorH1 = red
                timeRedLightTimerH2.Start(); //transition time from v lights to h lights
            }
            else
                lightTimerPass2 = true;
        }

        private void AddCar(object sender, EventArgs e)
        {
            PictureBox h = new PictureBox();
            h.Size = pbH2Car1.Size;
            h.Location = (rnd.Next(2) == 1? pbH2Car1.Location : pbH2Car2.Location);
            SetCarColor(h);
            npcHCars.Add(h);
            this.Controls.Add(h);
            npcHCarsSpeeds.Add(rnd.Next(50, stageSpeedLimit + 11));

            timeMakeNPCCar.Interval = rnd.Next(10, 50) * 10;
        }

        private void TrafficGeneration1(object sender, EventArgs e)
        {
            // if there are cars left to spawn, spawn car in random lane
            if (numCarsMade < numCarsToMake) //check cars are left to spawn
            {
                // pick random lane (h1-1 or h1-2)
                int lane = rnd.Next(2);

                // confirm direction to spawn car in
                if (lane == 0) // check if h1-1 car left to spawn
                {
                    if (h1CarsEndIndex == h1Cars.Length)
                        lane = 1; // no h1-1 cars left so spawn h1-2 car
                }
                else // check if h2-2 Car left to spawn
                {
                    if (h2CarsEndIndex == h2Cars.Length)
                        lane = 0;
                }
                numCarsMade++;

                if (lane == 0)
                    carsSecondRun[carsIndex] = CarType.H1;
                else
                    carsSecondRun[carsIndex] = CarType.H2;
                carsIndex++;
            }

            //lblPrep.Text = h1Cars.Length + ";" + h2Cars.Length;
            //lblPrep.Text = h1CarsIndex + ";" + h2CarsIndex;
            //lblPrep.Text = h1CarsEndIndex + ";" + h2CarsEndIndex;

            // move all visible pc cars (cars still in use and playable)
            //MOVING ONE CAR/LANE AT A TIME
            if (h1CarsIndex != h1CarsEndIndex)
            {
                //check which intersection is up ahead [intersection right boundary > car x]
                int intersectionLeft, intersectionRight;
                bool checkH1SignalColor = true;
                if (h1Cars[h1CarsIndex].car.Location.X < lblIntersectionArea1.Bounds.Right)
                {
                    lblStageScore.Text = "1";
                    intersectionLeft = lblIntersectionArea1.Bounds.Left;
                    intersectionRight = lblIntersectionArea1.Bounds.Right;
                }
                else
                {
                    lblStageScore.Text = "2";
                    intersectionLeft = lblIntersectionArea2.Bounds.Left;
                    intersectionRight = lblIntersectionArea2.Bounds.Right;
                    checkH1SignalColor = false;
                }

                //lblStageScore.Text = "";
                if (h1Cars[h1CarsIndex].car.Visible)
                {
                    if (checkH1SignalColor)
                    {
                        if (signalColorH1 == TrafficLightColor.GREEN)
                            h1Cars[h1CarsIndex].car.Left -= h1Cars[h1CarsIndex].speed;
                        else /*if (signalColorH1 == TrafficLightColor.RED)*/
                        {
                            int currentSpeed = h1Cars[h1CarsIndex].speed;
                            int dummyX = h1Cars[h1CarsIndex].car.Location.X - currentSpeed/*, dummyY = h1Cars[h1CarsIndex].car.Location.Y*/;
                            if (dummyX < intersectionRight - 50 && dummyX > intersectionLeft + 50)
                            {
                                h1Cars[h1CarsIndex].car.Left = intersectionRight;
                                h1Cars[h1CarsIndex].timeStopped += timeStageTimer.Interval;
                            }
                            else
                                h1Cars[h1CarsIndex].car.Left -= h1Cars[h1CarsIndex].speed;
                        }
                    }
                    else
                    {
                        if (signalColorH2 == TrafficLightColor.GREEN)
                            h1Cars[h1CarsIndex].car.Left -= h1Cars[h1CarsIndex].speed;
                        else /*if (signalColorH1 == TrafficLightColor.RED)*/
                        {
                            int currentSpeed = h1Cars[h1CarsIndex].speed;
                            int dummyX = h1Cars[h1CarsIndex].car.Location.X - currentSpeed/*, dummyY = h1Cars[h1CarsIndex].car.Location.Y*/;
                            if (dummyX < intersectionRight - 50 && dummyX > intersectionLeft + 50)
                            {
                                h1Cars[h1CarsIndex].car.Left = intersectionRight;
                                h1Cars[h1CarsIndex].timeStopped += timeStageTimer.Interval;
                            }
                            else
                                h1Cars[h1CarsIndex].car.Left -= h1Cars[h1CarsIndex].speed;
                        }
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

            if (h2CarsIndex != h2CarsEndIndex)
            {
                //check which intersection is up ahead [intersection right boundary > car x]
                int intersectionLeft, intersectionRight;
                bool checkH1SignalColor = true;
                if (h2Cars[h2CarsIndex].car.Location.X < lblIntersectionArea1.Bounds.Right)
                {
                    lblStageScore.Text = "1";
                    intersectionLeft = lblIntersectionArea1.Bounds.Left;
                    intersectionRight = lblIntersectionArea1.Bounds.Right;
                }
                else
                {
                    lblStageScore.Text = "2";
                    intersectionLeft = lblIntersectionArea2.Bounds.Left;
                    intersectionRight = lblIntersectionArea2.Bounds.Right;
                    checkH1SignalColor = false;
                }

                if (h2Cars[h2CarsIndex].car.Visible)
                {
                    if (checkH1SignalColor)
                    {
                        if (signalColorH1 == TrafficLightColor.GREEN)
                            h2Cars[h2CarsIndex].car.Left -= h2Cars[h2CarsIndex].speed;
                        else /*if (signalColorH1 == TrafficLightColor.RED)*/
                        {
                            int currentSpeed = h2Cars[h2CarsIndex].speed;
                            int dummyX = h2Cars[h2CarsIndex].car.Location.X + currentSpeed/*, dummyY = h1Cars[h1CarsIndex].car.Location.Y*/;
                            if (dummyX < intersectionRight - 50 && dummyX > intersectionLeft + 50)
                            {
                                h2Cars[h2CarsIndex].car.Left = intersectionRight;
                                h2Cars[h2CarsIndex].timeStopped += timeStageTimer.Interval;
                            }
                            else
                                h2Cars[h2CarsIndex].car.Left -= h2Cars[h2CarsIndex].speed;
                        }
                    }
                    else
                    {
                        if (signalColorH2 == TrafficLightColor.GREEN)
                            h2Cars[h2CarsIndex].car.Left -= h2Cars[h2CarsIndex].speed;
                        else /*if (signalColorH1 == TrafficLightColor.RED)*/
                        {
                            int currentSpeed = h2Cars[h2CarsIndex].speed;
                            int dummyX = h2Cars[h2CarsIndex].car.Location.X + currentSpeed/*, dummyY = h1Cars[h1CarsIndex].car.Location.Y*/;
                            if (dummyX < intersectionRight - 50 && dummyX > intersectionLeft + 50)
                            {
                                h2Cars[h2CarsIndex].car.Left = intersectionRight;
                                h2Cars[h2CarsIndex].timeStopped += timeStageTimer.Interval;
                            }
                            else
                                h2Cars[h2CarsIndex].car.Left -= h2Cars[h2CarsIndex].speed;
                        }
                    }

                        //check that car is still visible on stage
                        if (h2Cars[h2CarsIndex].car.Bounds.Right < this.Bounds.Left - 500)
                        {
                            // car has left stage
                            h2Cars[h2CarsIndex].car.Visible = false;
                            h2Cars[h2CarsIndex].wasUsed = true;
                            h2Cars[h2CarsIndex].inUse = false;

                            h2Cars[h2CarsIndex].car.Location = pbH1Car2.Location;
                            //this.Controls.Remove(h2Cars[h2CarsIndex].car); //?
                            //if (h2CarsIndex < h2CarsEndIndex - 1)
                            h2CarsIndex++;
                        }
                }
                else
                    h2Cars[h2CarsIndex].car.Visible = true;
            }

            // if all cars have left stage, stop timers
            if (h1CarsIndex == h1CarsEndIndex && h2CarsIndex == h2CarsEndIndex)
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
                //check which intersection is up ahead [intersection right boundary > car x]
                int intersectionLeft, intersectionRight;
                bool checkH1SignalColor = true;
                if (h1Cars[h1CarsIndex].car.Location.X < lblIntersectionArea1.Bounds.Right)
                {
                    lblStageScore.Text = "1";
                    intersectionLeft = lblIntersectionArea1.Bounds.Left;
                    intersectionRight = lblIntersectionArea1.Bounds.Right;
                }
                else
                {
                    lblStageScore.Text = "2";
                    intersectionLeft = lblIntersectionArea2.Bounds.Left;
                    intersectionRight = lblIntersectionArea2.Bounds.Right;
                    checkH1SignalColor = false;
                }

                //lblStageScore.Text = "";
                if (h1Cars[h1CarsIndex].car.Visible)
                {
                    if (checkH1SignalColor)
                    {
                        if (signalColorH1 == TrafficLightColor.GREEN)
                            h1Cars[h1CarsIndex].car.Left -= h1Cars[h1CarsIndex].speed;
                        else /*if (signalColorH1 == TrafficLightColor.RED)*/
                        {
                            int currentSpeed = h1Cars[h1CarsIndex].speed;
                            int dummyX = h1Cars[h1CarsIndex].car.Location.X - currentSpeed/*, dummyY = h1Cars[h1CarsIndex].car.Location.Y*/;
                            if (dummyX < intersectionRight - 50 && dummyX > intersectionLeft + 50)
                            {
                                h1Cars[h1CarsIndex].car.Left = intersectionRight;
                                h1Cars[h1CarsIndex].timeStopped += timeStageTimer.Interval;
                            }
                            else
                                h1Cars[h1CarsIndex].car.Left -= h1Cars[h1CarsIndex].speed;
                        }
                    }
                    else
                    {
                        if (signalColorH2 == TrafficLightColor.GREEN)
                            h1Cars[h1CarsIndex].car.Left -= h1Cars[h1CarsIndex].speed;
                        else /*if (signalColorH1 == TrafficLightColor.RED)*/
                        {
                            int currentSpeed = h1Cars[h1CarsIndex].speed;
                            int dummyX = h1Cars[h1CarsIndex].car.Location.X - currentSpeed/*, dummyY = h1Cars[h1CarsIndex].car.Location.Y*/;
                            if (dummyX < intersectionRight - 50 && dummyX > intersectionLeft + 50)
                            {
                                h1Cars[h1CarsIndex].car.Left = intersectionRight;
                                h1Cars[h1CarsIndex].timeStopped += timeStageTimer.Interval;
                            }
                            else
                                h1Cars[h1CarsIndex].car.Left -= h1Cars[h1CarsIndex].speed;
                        }
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

            if (h2CarsIndex != h2CarsEndIndex)
            {
                //check which intersection is up ahead [intersection right boundary > car x]
                int intersectionLeft, intersectionRight;
                bool checkH1SignalColor = true;
                if (h2Cars[h2CarsIndex].car.Location.X < lblIntersectionArea1.Bounds.Right)
                {
                    lblStageScore.Text = "1";
                    intersectionLeft = lblIntersectionArea1.Bounds.Left;
                    intersectionRight = lblIntersectionArea1.Bounds.Right;
                }
                else
                {
                    lblStageScore.Text = "2";
                    intersectionLeft = lblIntersectionArea2.Bounds.Left;
                    intersectionRight = lblIntersectionArea2.Bounds.Right;
                    checkH1SignalColor = false;
                }

                if (h2Cars[h2CarsIndex].car.Visible)
                {
                    if (checkH1SignalColor)
                    {
                        if (signalColorH1 == TrafficLightColor.GREEN)
                            h2Cars[h2CarsIndex].car.Left -= h2Cars[h2CarsIndex].speed;
                        else /*if (signalColorH1 == TrafficLightColor.RED)*/
                        {
                            int currentSpeed = h2Cars[h2CarsIndex].speed;
                            int dummyX = h2Cars[h2CarsIndex].car.Location.X + currentSpeed/*, dummyY = h1Cars[h1CarsIndex].car.Location.Y*/;
                            if (dummyX < intersectionRight - 50 && dummyX > intersectionLeft + 50)
                            {
                                h2Cars[h2CarsIndex].car.Left = intersectionRight;
                                h2Cars[h2CarsIndex].timeStopped += timeStageTimer.Interval;
                            }
                            else
                                h2Cars[h2CarsIndex].car.Left -= h2Cars[h2CarsIndex].speed;
                        }
                    }
                    else
                    {
                        if (signalColorH2 == TrafficLightColor.GREEN)
                            h2Cars[h2CarsIndex].car.Left -= h2Cars[h2CarsIndex].speed;
                        else /*if (signalColorH1 == TrafficLightColor.RED)*/
                        {
                            int currentSpeed = h2Cars[h2CarsIndex].speed;
                            int dummyX = h2Cars[h2CarsIndex].car.Location.X + currentSpeed/*, dummyY = h1Cars[h1CarsIndex].car.Location.Y*/;
                            if (dummyX < intersectionRight - 50 && dummyX > intersectionLeft + 50)
                            {
                                h2Cars[h2CarsIndex].car.Left = intersectionRight;
                                h2Cars[h2CarsIndex].timeStopped += timeStageTimer.Interval;
                            }
                            else
                                h2Cars[h2CarsIndex].car.Left -= h2Cars[h2CarsIndex].speed;
                        }
                    }

                    //check that car is still visible on stage
                    if (h2Cars[h2CarsIndex].car.Bounds.Right < this.Bounds.Left - 500)
                    {
                        // car has left stage
                        h2Cars[h2CarsIndex].car.Visible = false;
                        h2Cars[h2CarsIndex].wasUsed = true;
                        h2Cars[h2CarsIndex].inUse = false;

                        h2Cars[h2CarsIndex].car.Location = pbH1Car2.Location;
                        //this.Controls.Remove(h2Cars[h2CarsIndex].car); //?
                        //if (h2CarsIndex < h2CarsEndIndex - 1)
                        h2CarsIndex++;
                    }
                }
                else
                    h2Cars[h2CarsIndex].car.Visible = true;
            }

            // if all cars have left stage, stop timers
            if (h1CarsIndex == h1CarsEndIndex && h2CarsIndex == h2CarsEndIndex)
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
            timeGreenLightTimerH1.Stop();
            timeGreenLightTimerH2.Stop();
            timeRedLightTimerH1.Stop();
            timeRedLightTimerH2.Stop();
            timeYellowLightTimerH1.Stop();
            timeYellowLightTimerH2.Stop();
            timeMakeNPCCar.Stop();
            timeStageTimer.Stop();
            timeStageTimer2.Stop();
            //MessageBox.Show("stopp");
        }

        private void ReStartTimers()
        {
            timeRedLightTimerH1.Interval = 20 * trafficLightSettings[0].time[0] * (trafficLightSettings[0].timeUnit[0].Equals("sec") ? 1 : 60);
            timeYellowLightTimerH1.Interval = 20 * trafficLightSettings[0].time[1] * (trafficLightSettings[0].timeUnit[1].Equals("sec") ? 1 : 60);
            timeGreenLightTimerH1.Interval = 20 * trafficLightSettings[0].time[2] * (trafficLightSettings[0].timeUnit[2].Equals("sec") ? 1 : 60);
            timeRedLightTimerH2.Interval = 20 * trafficLightSettings[1].time[0] * (trafficLightSettings[1].timeUnit[0].Equals("sec") ? 1 : 60);
            timeYellowLightTimerH2.Interval = 20 * trafficLightSettings[1].time[1] * (trafficLightSettings[1].timeUnit[1].Equals("sec") ? 1 : 60);
            timeGreenLightTimerH2.Interval = 20 * trafficLightSettings[1].time[2] * (trafficLightSettings[1].timeUnit[2].Equals("sec") ? 1 : 60);

            lightTimerPass2 = false;
        }

        private void CalculateAvgTimeStopped()
        {
            int avg = 0;

            foreach (CCar c in h1Cars)
                avg += c.timeStopped;
            foreach (CCar c in h2Cars)
                avg += c.timeStopped;
            avg = (int)(avg / (h1Cars.Length + h2Cars.Length));

            if (stagePhase == StagePhase.PRE)
            {
                game.Stages[3].InitialScore = avg;
                lblStageScore.Text += avg + "";
            }
            else
                game.Stages[3].CurrentPlayerScore = avg;
        }

        private void ResetCars()
        {
            h1CarsIndex = h2CarsIndex = 0;

            //MessageBox.Show("total cars = " + numCarsToMake + "; h1 = " + h1Cars.Length + ", h2 = " + h2Cars.Length + ", v1 = " + v1Cars.Length + ", v2 = " + v2Cars.Length);

            numCarsMade = 0;

            for (int i = 0; i < h1Cars.Length; i++)
                h1Cars[i].timeStopped = 0;
            for (int i = 0; i < h2Cars.Length; i++)
                h2Cars[i].timeStopped = 0;
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
                        c.speedDirection = -1;
                        c.speedAffectsX = true;

                //determine starting position of car
                int carDirection = rnd.Next(2) + 1;
                //MessageBox.Show(carDirection + "");
                switch (carDirection)
                {
                    case 1:
                        c.car.Location = pbH1Car1.Location;
                        c.car.Size = pbH1Car1.Size;
                        //MessageBox.Show(c.speedDirection + "-" + c.speedAffectsX);
                        break;
                    case 2:
                        c.car.Location = pbH1Car2.Location;
                        c.car.Size = pbH1Car2.Size;
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
            Predicate<CCar> h1CarFinder = (CCar c) => { return (c.car.Location == pbH1Car1.Location); };
            Predicate<CCar> h2CarFinder = (CCar c) => { return (c.car.Location == pbH1Car2.Location); };
            h1Cars = cars.FindAll(h1CarFinder).ToArray();
            h2Cars = cars.FindAll(h2CarFinder).ToArray();
            h1CarsEndIndex = h1Cars.Length;
            h2CarsEndIndex = h2Cars.Length;
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
                    //if (CheckLegality())
                    //{
                        flpTimerTrafficLightMenu.Visible = false;
                        stagePhase = StagePhase.POST;
                        lblPrep.Text = "Post-Prep";
                        lblFinishPrepBtn.Text = "Continue";
                        ResetCars();
                        ReStartTimers();
                        PrioritizeTimers();
                        timeStageTimer2.Start();
                    //}
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

        private void PrioritizeTimers()
        {
            //if (trafficLightSelected == 0)
            //{
                switch (trafficLightSettings[0].lightStart)
                {
                    case 0:
                        timeRedLightTimerH1.Start();
                        break;
                    case 1:
                        timeYellowLightTimerH1.Start();
                        break;
                    default:
                        timeGreenLightTimerH1.Start();
                        break;
                }
            //}
            //else
            //{
                switch (trafficLightSettings[1].lightStart)
                {
                    case 0:
                        timeRedLightTimerH2.Start();
                        break;
                    case 1:
                        timeYellowLightTimerH2.Start();
                        break;
                    default:
                        timeGreenLightTimerH2.Start();
                        break;
                }
            //}
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

            if (trafficLight.Name.EndsWith("1"))
                trafficLightSelected = 0;
            else if (trafficLight.Name.EndsWith("2"))
                trafficLightSelected = 1;
            else
                trafficLightSelected = -1;

            SetUpTrafficLightSettingsMenu(trafficLightSettings[trafficLightSelected]);
            flpTimerTrafficLightMenu.Visible = true;
        }

        private void HideTrafficLightSettingsClick(object sender, MouseEventArgs e)
        {
            flpTimerTrafficLightMenu.Visible = false;
        }

        private void LightStartChanged(object sender, MouseEventArgs e)
        {
            RadioButton lightStartButton = (RadioButton)sender;
            if (lightStartButton.Checked)
                trafficLightSettings[trafficLightSelected].lightStart = lightStartButton.TabIndex - rbRed1.TabIndex;
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
            switch (tlSettings.lightStart)
            {
                case 0:
                    rbRed1.Checked = true;
                    break;

                case 1:
                    rbYellow1.Checked = true;
                    break;

                default:
                    rbGreen1.Checked = true;
                    break;

            }
            flpTimerTrafficLightMenu.Location = new Point(tlSettings.xOfMenu, tlSettings.yOfMenu);
        }

        private void SetUpInitialTrafficLightSettings()
        {
            //menu locations : h1 (491, 238) h2 (344, 238)
            TrafficLightSettings[] hTrafficLightSettings = new TrafficLightSettings[2];

            for (int i = 0; i < hTrafficLightSettings.Length; i++)
            {
                hTrafficLightSettings[i].time = new int[3] { 40, 40, 40 };
                hTrafficLightSettings[i].timeUnit = new string[3] { "sec", "sec", "sec" };
                hTrafficLightSettings[i].yOfMenu = 238;
            }
            hTrafficLightSettings[0].xOfMenu = 491;
            hTrafficLightSettings[1].xOfMenu = 344;
            hTrafficLightSettings[0].lightStart = 0;
            hTrafficLightSettings[1].lightStart = 2;

            trafficLightSettings = new TrafficLightSettings[hTrafficLightSettings.Length];
            int tlsIndex = 0;
            for (int i = 0; i < hTrafficLightSettings.Length && tlsIndex < trafficLightSettings.Length; i++, tlsIndex++)
                trafficLightSettings[tlsIndex] = hTrafficLightSettings[i];
        }
    }
}

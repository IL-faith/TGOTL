using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGOTL
{
    public partial class PauseScreen : Form
    {
        Game game;
        Form previousScreen;
        public PauseScreen(Form prev, Point formPosition, Game g)
        {
            InitializeComponent();
            this.Location = formPosition;
            previousScreen = prev;
            game = g;
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
            //
        }

        private void SaveGame()
        {
            /* save file structure:
             * playstyle=[PLAYSTYLE]
             * stagesUnlocked=[#STAGES_UNLOCKED]
             * s1=[#CARS],[#CARSGOING-10],[#CARSGOING-5],[#CARSGOING-0],[#CARSGOING+5],[STAGESCORE],[PLAYER_HIGHSCORE]
             * ...
             * s[STAGE#OFLAST_UNLOCKED_STAGE]=[#CARS],[#CARSGOING-10],[#CARSGOING-5],[#CARSGOING-0],[#CARSGOING+5],[STAGESCORE],[PLAYER_HIGHSCORE]
             * album:
             * [LOADINGSCREEN#]
             * ...
             * [LOADINGSCREEN#]
             */

            List<string> saveInfo = new List<string>();
            saveInfo.Add("playstyle=" + (game.PlaystyleIsMouse ? "mouse" : "keyboard")); //playstyle
            int stagesUnlocked = game.GetNumStagesUnlocked();
            saveInfo.Add("stagesUnlocked=" + stagesUnlocked); //stagesUnlocked
            string stageStats = "";
            for (int i = 0; i < stagesUnlocked; i++) 
            {
                Car[] cars = game.Stages[i].Cars;
                int carsGoing10Below = 0, carsGoing5Below = 0, carsGoing0Below = 0, carsGoing5Above = 0;
                foreach (Car car in cars) 
                {
                    if (car.Speed == game.Stages[i].SpeedLimit - 10)
                        carsGoing10Below++;
                    else if (car.Speed == game.Stages[i].SpeedLimit - 5)
                        carsGoing5Below++;
                    else if (car.Speed == game.Stages[i].SpeedLimit)
                        carsGoing0Below++;
                    else if (car.Speed == game.Stages[i].SpeedLimit + 5)
                        carsGoing5Above++;
                }
                int totalCars = carsGoing0Below + carsGoing10Below + carsGoing5Below + carsGoing5Above;
                stageStats = String.Format("s{0}={1},{2},{3},{4},{5},{6},{7}", i+1, totalCars, carsGoing10Below, carsGoing5Below, carsGoing0Below, carsGoing5Above, game.Stages[i].InitialScore, game.Stages[i].BestPlayerScore);
            }
            saveInfo.Add(stageStats);
            saveInfo.Add("album:");
            foreach (LoadingScreen ls in game.LoadingScreens)
            {
                if (ls.Unlocked)
                    saveInfo.Add(ls.ScreenNumber + "");
            }
            SaveGameToFile(saveInfo.ToArray());
        }

        private void SaveGameToFile(string[] saveInfo)
        {
            string saveFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "save.txt");
            StreamWriter saveFile = new StreamWriter(saveFilePath, false);
            foreach (string saveLine in saveInfo)
                saveFile.WriteLine(saveLine);
            saveFile.Close();
        }

        private void SaveBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
                SaveGame();
        }

        private void ResumeBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                previousScreen.Show();
                this.Close();
            }
        }

        private void QuitBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                previousScreen.Close();
                this.Close();
            }
        }
    }
}

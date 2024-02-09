using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGOTL
{
    public partial class TitleScreen : Form
    {
        bool firstLoad = true;
        Label[] menuChoices = new Label[5];
        string playstyle;
        int menuChoiceSelected = -1;
        Game game;

        public TitleScreen(string p = "mouse")
        {
            InitializeComponent();

            SortMenuChoices();
            playstyle = p;
            game = new Game();
            //game.PlaystyleIsMouse = true;
            CheckSaveFile();
        }
        public TitleScreen(Point formPosition, Game g)
        {
            InitializeComponent();

            SortMenuChoices();
            game = g;
            playstyle = (game.PlaystyleIsMouse? "mouse":"keyboard");
            this.StartPosition = FormStartPosition.Manual;
            this.Location = formPosition;
            lblMenu3AlbumBtn.Font = lblMenu1StartBtn.Font;
            lblMenu3AlbumBtn.ForeColor = Color.Black;
            lblMenu5PlaystyleBtn.Text = "Mode: " + playstyle;
            firstLoad = false;
            //CheckSaveFile();
        }

        private void CheckSaveFile()
        {
            string saveFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "save.txt");
            if (File.Exists(saveFilePath))
            {
                if (firstLoad)
                {
                    StreamReader save = new StreamReader(saveFilePath);
                    string savedPlaystyle = save.ReadLine();
                    save.Close();

                    playstyle = (savedPlaystyle.Split('='))[1].ToLower();
                    game.PlaystyleIsMouse = (playstyle.Equals("mouse")? true : false);
                    lblMenu5PlaystyleBtn.Text = "Mode: " + playstyle;
                }
                else
                    playstyle = (game.PlaystyleIsMouse ? "mouse" : "keyboard");

                lblMenu2LoadBtn.Font = lblMenu1StartBtn.Font;
            }
        }

        private void SortMenuChoices()
        {
            int i = 0;
            foreach (Label menuChoice in this.Controls)
            {
                if (menuChoice.Tag != null && menuChoice.Tag.Equals("menu"))
                    menuChoices[i++] = menuChoice;
            }
            
            for (i = 0; i < menuChoices.Length; i++)
            {
                for (int j = i+1; j < menuChoices.Length; j++)
                {
                    if (menuChoices[i].Name.CompareTo(menuChoices[j].Name) > 0)
                    {
                        Label temp = menuChoices[i];
                        menuChoices[i] = menuChoices[j];
                        menuChoices[j] = temp;
                    }
                }
            }
        }

        private void LoadGameSave()
        {
            //game = new Game();
            string saveFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "save.txt");
            if (File.Exists(saveFilePath)) 
            {
                string[] lines = File.ReadAllLines(saveFilePath);
                List<string> saveInfo = lines.ToList();
                foreach (string line in saveInfo) 
                {
                    MessageBox.Show(line);
                }
                while (saveInfo.Count > 0)
                {
                    string saveLine = saveInfo[0];
                    if (saveLine.StartsWith("playstlye"))
                        continue; //game.PlaystyleIsMouse = (playstyle.Equals("mouse")? true:false); DONE ELSEWHERE SO SKIP
                    else if (saveLine.StartsWith("album"))
                    {
                        saveInfo.RemoveAt(0);
                        List<int> unlockedLoadingScreens = new List<int>();
                        while (saveInfo.Count != 0)
                        {
                            unlockedLoadingScreens.Add(int.Parse(saveLine));
                            saveInfo.RemoveAt(0);
                        }
                        saveInfo.Add("end of save");
                    }
                    else
                    {
                        //s# = #carsGoing-10, #carsGoing-5, #carsGoing-0, #carsGoing+5, stageScore, highScore (WITHOUT SPACES)
                        string[] stage = saveLine.Split('=');
                        string[] stageStats = stage[1].Split(',');
                        int stageNum = int.Parse(stage[0].Substring(1));
                        if (stageNum < game.Stages.Count())
                        {
                            List<Car> cars = new List<Car>();
                            for (int i = 0, carSpeed = -10; i < 4; i++, carSpeed += 5)
                            {
                                int j = 0;
                                int speed = game.Stages[stageNum].SpeedLimit + carSpeed;
                                while (j < int.Parse(stageStats[i]))
                                {
                                    cars.Add(new Car(speed));
                                    j++;
                                }
                            }
                            game.Stages[stageNum].Cars = cars.ToArray();
                            game.Stages[stageNum].InitialScore = int.Parse(stageStats[stageStats.Length - 2]);
                            game.Stages[stageNum].BestPlayerScore = int.Parse(stageStats[stageStats.Length - 1]);
                        }
                    }
                    saveInfo.RemoveAt(0);
                }
            }
            //MessageBox.Show(saveFilePath);
        }

        private void StartGameClick(object sender, EventArgs e)
        {
            if (playstyle.Equals("mouse"))
            {
                game.PlaystyleIsMouse = (playstyle.Equals("mouse") ? true : false);
                StoryScreen newGame = new StoryScreen(this.Location, game, false);
                newGame.Show();
                this.Close();
            }
        }

        private void LoadGameClick(object sender, EventArgs e)
        {
            if (playstyle.Equals("mouse"))
            {
                if (!lblMenu2LoadBtn.Font.Strikeout)
                {
                    LoadGameSave();
                    StageSelectionScreen loadGame = new StageSelectionScreen(this.Location, game);
                    loadGame.Show();
                    this.Close();
                }
            }
        }

        private void ViewAlbumClick(object sender, EventArgs e)
        {
            if (playstyle.Equals("mouse"))
            {
                if (!lblMenu3AlbumBtn.Font.Strikeout)
                {
                    AlbumScreen viewAlbum = new AlbumScreen(this.Location, game);
                    viewAlbum.Show();
                    this.Close();
                }
            }
        }

        private void ViewTutorialClick(object sender, EventArgs e)
        {
            if (playstyle.Equals("mouse"))
            {
                TutorialScreen viewTutorial = new TutorialScreen(this.Location, game);
                viewTutorial.Show();
                this.Close();
            }
        }

        private void ChangePlaystyleClick(object sender, EventArgs e)
        {
            if (playstyle.Equals("mouse"))
            {
                playstyle = "keyboard";
                lblMenu5PlaystyleBtn.Text = "Mode: " + playstyle;
                lblMenu5PlaystyleBtn.ForeColor = Color.Black;
                game.PlaystyleIsMouse = false;
            }
        }

        private void MouseOnMenuChoice(object sender, EventArgs e)
        {
            if (playstyle.Equals("mouse") && sender is Label && !((Label)sender).Font.Strikeout)
                ((Label)sender).ForeColor = Color.DeepSkyBlue;
        }

        private void MouseOffMenuChoice(object sender, EventArgs e)
        {
            if (playstyle.Equals("mouse") && sender is Label && !((Label)sender).Font.Strikeout)
                ((Label)sender).ForeColor = Color.Black;
        }

        private void KeyboardKeyDown(object sender, KeyEventArgs e)
        {
            if (playstyle.Equals("keyboard"))
            {
                int previousChoice = menuChoiceSelected;
                bool arrowKeyPressed = true;

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
                {
                    menuChoiceSelected += (menuChoiceSelected == 4 ? -4 : 1);
                    while (menuChoices[menuChoiceSelected].Font.Strikeout)
                        menuChoiceSelected++;
                }
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
                {
                    menuChoiceSelected -= (menuChoiceSelected == 0 ? -4 : (menuChoiceSelected == -1 ? -5 : 1));
                    while (menuChoices[menuChoiceSelected].Font.Strikeout)
                        menuChoiceSelected--;
                }
                else
                    arrowKeyPressed = false;

                if (arrowKeyPressed)
                {
                    if (previousChoice != -1)
                         menuChoices[previousChoice].ForeColor = Color.Black;
                    menuChoices[menuChoiceSelected].ForeColor = Color.DeepSkyBlue;
                }
                else if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space) && menuChoiceSelected != -1)
                {
                    //if (menuChoices[menuChoiceSelected].Name.Equals("lblPlaystyleButton"))
                    //{
                    //    playstyle = "mouse";
                    //    lblMenu5PlaystyleBtn.Text = "Mode: " + playstyle;
                    //    menuChoiceSelected = -1;
                    //    lblMenu5PlaystyleBtn.ForeColor = Color.Black;
                    //}
                    switch (menuChoiceSelected)
                    {
                        case 0:
                            game.PlaystyleIsMouse = (playstyle.Equals("mouse") ? true : false);
                            StoryScreen newGame = new StoryScreen(this.Location, game, false);
                            newGame.Show();
                            this.Close();
                            break;
                        case 1:
                            if (!lblMenu2LoadBtn.Font.Strikeout)
                            {
                                LoadGameSave();
                                StageSelectionScreen loadGame = new StageSelectionScreen(this.Location, game);
                                loadGame.Show();
                                this.Close();
                            }
                            break;
                        case 2:
                            if (!lblMenu3AlbumBtn.Font.Strikeout)
                            {
                                AlbumScreen viewAlbum = new AlbumScreen(this.Location, game);
                                viewAlbum.Show();
                                this.Close();
                            }
                            break;
                        case 3:
                            TutorialScreen viewTutorial = new TutorialScreen(this.Location, game);
                            viewTutorial.Show();
                            this.Close();
                            break;
                        case 4:
                            playstyle = "mouse";
                            lblMenu5PlaystyleBtn.Text = "Mode: " + playstyle;
                            menuChoiceSelected = -1;
                            lblMenu5PlaystyleBtn.ForeColor = Color.Black;
                            game.PlaystyleIsMouse = true;
                            break;
                    }
                }
            }
        }
    }
}

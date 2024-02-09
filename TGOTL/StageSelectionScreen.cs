using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGOTL
{
    public partial class StageSelectionScreen : Form
    {
        int bestScore, stageScore, stageNum = 1;
        Game game; 

        public StageSelectionScreen(Point formPosition, Game g)
        {
            InitializeComponent();
            lblSelect0BackBtn.Visible = false;
            this.Location = formPosition;
            game = g;
            lblStageLockedMessage.Visible = false;
            pbPrevArrow.Visible = false;
            ClearSelects();

            if (game.BeatGame && !game.ShownEnding)
                game.ShownEnding = true;
        }

        private void ClearSelects()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Label && control.Tag != null && control.Tag.Equals("select"))
                    control.Visible = false;
            }
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
                stageNum--;
                TitleScreen titleScreen = new TitleScreen(this.Location, game);
                titleScreen.Show();
                this.Close();
            }
        }

        private void StageClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                game.CurrentStage = stageNum-1;
                NonPrepScreen prePrep = new NonPrepScreen(this.Location, game);
                prePrep.Show();
                this.Close();
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

        private void NextBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                stageNum++;
                if (stageNum == 5)
                    pbNextArrow.Visible = false;
                if (stageNum == 2)
                {
                    pbPrevArrow.Visible = true;
                    lblStageLockedMessage.Visible = true;
                }
            }
        }

        private void PrevBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                stageNum--;
                if (stageNum == 0)
                {
                    pbPrevArrow.Visible = false;
                    lblStageLockedMessage.Visible = false;
                }
                if (stageNum == 4)
                    pbNextArrow.Visible = true;
            }
        }

        public int BestScore { get; set; }
        public int StageScore { get; set; }
    }
}

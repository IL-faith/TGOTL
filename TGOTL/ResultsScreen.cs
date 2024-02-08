using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace TGOTL
{
    public partial class ResultsScreen : Form
    {
        Game game;
        public ResultsScreen(Point formPosition, Game g)
        {
            InitializeComponent();
            this.Location = formPosition;
            game = g;

            Random rnd = new Random();
            if (rnd.Next(2) == 1)
            {
                lblPassed.Visible = false;
                lblNextStageBtn.Visible = false;
                lblSelect1NextStageBtn.Visible = false;
                lblSelect2RetryBtn.Size = lblSelect1NextStageBtn.Size;
                lblSelect2RetryBtn.Location = lblSelect1NextStageBtn.Location;
                pbRetryBtn.Size = lblNextStageBtn.Size;
                pbRetryBtn.Location = lblNextStageBtn.Location;
            }
            else
                lblFailed.Visible = false;
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

        private void StageSelectBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                StageSelectionScreen stageSelect = new StageSelectionScreen(this.Location, game);
                stageSelect.Show();
                this.Close();
            }
        }

        private void NextStageBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                NonPrepScreen nextStage = new NonPrepScreen(this.Location, game);
                nextStage.Show();
                this.Close();
            }
        }

        private void RetryStageBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                NonPrepScreen retryStage = new NonPrepScreen(this.Location, game);
                retryStage.Show();
                this.Close();
            }
        }
    }
}

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
    public partial class NonPrepScreen : Form
    {
        bool inPostPrep;
        Game game;
        public NonPrepScreen(Point formPosition, Game g, bool postPrep = false)
        {
            InitializeComponent();
            this.Location = formPosition;
            game = g;
            inPostPrep = postPrep;

            if (!inPostPrep)
                lblPlayerScore.Visible = false;
            else
                lblNonPrep.Text = "Post-Prep";
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

        private void FinishNonPrepBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                if (!inPostPrep)
                {
                    PrepScreen prep = new PrepScreen(this.Location, game);
                    prep.Show();
                }
                else
                {
                    ResultsScreen results = new ResultsScreen(this.Location, game);
                    results.Show();
                }
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
    }
}

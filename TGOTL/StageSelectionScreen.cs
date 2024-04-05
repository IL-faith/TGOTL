using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TGOTL.Properties;

namespace TGOTL
{
    public partial class StageSelectionScreen : Form
    {
        int stageNum = 1;
        Game game;
        Label[] selectChoices = new Label[5];
        int selectChoiceSelected = -1;

        public StageSelectionScreen(Point formPosition, Game g)
        {
            InitializeComponent();
            this.Location = formPosition;
            game = g;
            //pbStagePreview.BackColor = Color.DarkSeaGreen; //pbStagePreview = game.Stages[stageNum-1].Image;
            //lblPlayerScore.Text = "Best Score: "+ game.Stages[stageNum - 1].BestPlayerScore + "");
            //lblPlayerScore.Text = "Best Score: "+ game.Stages[stageNum - 1].InitialScore + "");
            //ClearSelects();

            SortSelectChoices();

            if (game.BeatGame && !game.ShownEnding)
                game.ShownEnding = true;

            if (game.Stages[stageNum - 1].BestPlayerScore > -1)
                lblStageScore.Text = "Best Score: " + game.Stages[stageNum - 1].BestPlayerScore;

            game.PlaystyleIsMouse = true;
        }

        private void SortSelectChoices()
        {
            int i = 0;
            foreach (Control control in this.Controls)
            {
                if (control is Label && control.Tag != null && control.Tag.Equals("select"))
                {
                    control.Visible = false;
                    selectChoices[i] = (Label)control;
                    i++;
                }
            }

            for (i = 0; i < selectChoices.Length; i++)
            {
                for (int j = i + 1; j < selectChoices.Length; j++)
                {
                    if (selectChoices[i].Name.CompareTo(selectChoices[j].Name) > 0)
                    {
                        Label temp = selectChoices[i];
                        selectChoices[i] = selectChoices[j];
                        selectChoices[j] = temp;
                    }
                }
            }
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
            if (!game.PlaystyleIsMouse)
            {
                int previousChoice = selectChoiceSelected;
                bool arrowKeyPressed = true;

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
                {
                    selectChoiceSelected += (selectChoiceSelected == 4 ? -4 : 1);
                    if ((selectChoiceSelected == 3 && !pbPrevArrow.Visible) || (selectChoiceSelected == 4 && !pbNextArrow.Visible))
                        selectChoiceSelected += (selectChoiceSelected == 4? -4:1);
                }
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
                { 
                    selectChoiceSelected -= (selectChoiceSelected == 0 ? -4 : (selectChoiceSelected == -1 ? -5 : 1));
                    if ((selectChoiceSelected == 3 && !pbPrevArrow.Visible) || (selectChoiceSelected == 4 && !pbNextArrow.Visible))
                        selectChoiceSelected--;
                }
                else
                    arrowKeyPressed = false;

                if (arrowKeyPressed)
                {
                    if (previousChoice != -1)
                        selectChoices[previousChoice].Visible = false;
                    selectChoices[selectChoiceSelected].Visible = true;
                }
                else if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space) && selectChoiceSelected != -1)
                {
                    switch (selectChoiceSelected)
                    {
                        case 0:
                            TitleScreen titleScreen = new TitleScreen(this.Location, game);
                            titleScreen.Show();
                            this.Close();
                            break;
                        case 1:
                            PauseScreen pause = new PauseScreen(this, this.Location, game);
                            pause.Show();
                            this.Hide();
                            break;
                        case 2:
                            game.CurrentStage = stageNum - 1;
                            if (game.Stages[game.CurrentStage].Unlocked)
                            {
                                NonPrepScreen prePrep = new NonPrepScreen(this.Location, game);
                                prePrep.Show();
                                this.Close();
                            }
                            break;
                        case 3:
                            stageNum--;
                            if (stageNum == 1)
                            {
                                pbPrevArrow.Visible = false;
                                lblSelect3PrevArrow.Visible = false;
                                selectChoiceSelected = 2;
                            }
                            else if (stageNum == game.Stages.Length - 1)
                                pbNextArrow.Visible = true;

                            if (game.Stages[stageNum - 1].Unlocked)
                            {
                                if (lblStageLockedMessage.Visible)
                                {
                                    lblStageLockedMessage.Visible = false;
                                    pbStagePreview.BackgroundImage = game.Stages[stageNum - 1].GetImage;
                                }
                                //lblPlayerScore.Text = lblPlayerScore.Text.Replace(game.Stages[stageNum - 2].BestPlayerScore + "", game.Stages[stageNum - 1].BestPlayerScore + "");
                                //lblStageScore.Text = lblStageScore.Text.Replace(game.Stages[stageNum - 2].InitialScore + "", game.Stages[stageNum - 1].InitialScore + "");
                            }
                            else
                            { 
                                pbStagePreview.BackgroundImage = Resources._lock;
                                lblStageLockedMessage.Visible = true;
                            }

                            if (game.Stages[stageNum-1].BestPlayerScore > -1)
                                lblStageScore.Text = "Best Score: "+ game.Stages[stageNum - 1].BestPlayerScore;
                            else
                                lblStageScore.Text = "Best Score: #";

                            break;
                        case 4:
                            stageNum++;
                            if (stageNum == game.Stages.Length)
                            {
                                pbNextArrow.Visible = false;
                                lblSelect4NextArrow.Visible = false;
                                selectChoiceSelected = 2;
                            }
                            else if (stageNum == 2)
                                pbPrevArrow.Visible = true;

                            if (!game.Stages[stageNum - 1].Unlocked)
                            {
                                if (!lblStageLockedMessage.Visible)
                                {
                                    lblStageLockedMessage.Visible = true;
                                    pbStagePreview.BackgroundImage = Resources._lock;
                                    //lblPlayerScore.Text = lblPlayerScore.Text.Replace(game.Stages[stageNum - 2].BestPlayerScore + "", "- -");
                                    //lblStageScore.Text = lblStageScore.Text.Replace(game.Stages[stageNum - 2].InitialScore + "", "- -");
                                }
                            }
                            else
                            {
                                pbStagePreview.BackgroundImage = game.Stages[stageNum - 1].GetImage;
                                lblStageLockedMessage.Visible = true;
                                //lblPlayerScore.Text = lblPlayerScore.Text.Replace(game.Stages[stageNum - 2].BestPlayerScore + "", game.Stages[stageNum - 1].BestPlayerScore + "");
                                //lblStageScore.Text = lblStageScore.Text.Replace(game.Stages[stageNum - 2].InitialScore + "", game.Stages[stageNum - 1].InitialScore + "");
                            }

                            if (game.Stages[stageNum - 1].BestPlayerScore > -1)
                                lblStageScore.Text = "Best Score: "+ game.Stages[stageNum - 1].BestPlayerScore;
                            else
                                lblStageScore.Text = "Best Score: #";

                            break;
                    }
                }
            }
        }

        private void BackBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
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
                if (stageNum == 1)
                {
                    Stage1Prep s1 = new Stage1Prep(this.Location, game);
                    s1.Show();
                    this.Close();
                }
                else if (game.Stages[game.CurrentStage].Unlocked)
                {
                    //NonPrepScreen prePrep = new NonPrepScreen(this.Location, game);
                    //prePrep.Show();
                    //this.Close();

                    if (stageNum == 2)
                    {
                        Stage2Prep s2 = new Stage2Prep(this.Location, game);
                        s2.Show();
                        this.Close();
                    }
                    else if (stageNum == 3)
                    {
                        Stage3Prep s3 = new Stage3Prep(this.Location, game);
                        s3.Show();
                        this.Close();
                    }
                    else if (stageNum == 4)
                    {
                        Stage4Prep s4 = new Stage4Prep(this.Location, game);
                        s4.Show();
                        this.Close();
                    }
                    else if (stageNum == 5)
                    {
                        Stage5Prep s5 = new Stage5Prep(this.Location, game);
                        s5.Show();
                        this.Close();
                    }
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

        private void NextBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                stageNum++;
                if (stageNum == game.Stages.Length)
                    pbNextArrow.Visible = false;
                else if (stageNum == 2)
                    pbPrevArrow.Visible = true;

                if (!game.Stages[stageNum - 1].Unlocked)
                {
                    if (!lblStageLockedMessage.Visible)
                    {
                        pbStagePreview.BackgroundImage = Resources._lock;
                        lblStageLockedMessage.Visible = true;
                        pbStagePreview.BackColor = Color.Black; //pbStagePreview.Image = //lock.png
                        //lblPlayerScore.Text = lblPlayerScore.Text.Replace(game.Stages[stageNum - 2].BestPlayerScore + "", "- -");
                        //lblStageScore.Text = lblStageScore.Text.Replace(game.Stages[stageNum - 2].InitialScore + "", "- -");
                    }
                }
                else
                {
                    pbStagePreview.BackgroundImage = game.Stages[stageNum - 1].GetImage;
                    lblStageLockedMessage.Visible = false;
                    //lblPlayerScore.Text = lblPlayerScore.Text.Replace(game.Stages[stageNum - 2].BestPlayerScore + "", game.Stages[stageNum - 1].BestPlayerScore + "");
                    //lblStageScore.Text = lblStageScore.Text.Replace(game.Stages[stageNum - 2].InitialScore + "", game.Stages[stageNum - 1].InitialScore + "");
                }

                if (game.Stages[stageNum - 1].BestPlayerScore > -1)
                    lblStageScore.Text = "Best Score: " + game.Stages[stageNum - 1].BestPlayerScore;
                else
                    lblStageScore.Text = "Best Score: #";

            }
        }

        private void PrevBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                stageNum--;
                if (stageNum == 1)
                    pbPrevArrow.Visible = false;
                else if (stageNum == game.Stages.Length-1)
                    pbNextArrow.Visible = true;

                if (game.Stages[stageNum - 1].Unlocked)
                {
                    if (lblStageLockedMessage.Visible)
                    {
                        lblStageLockedMessage.Visible = false;
                        pbStagePreview.BackColor = Color.DarkSeaGreen; //pbStagePreview.Image = //lock.png
                    }
                        pbStagePreview.BackgroundImage = game.Stages[stageNum - 1].GetImage;
                    //pbStagePreview.BackgroundImage = game.Stages[stageNum - 1].GetImage;
                    //lblPlayerScore.Text = lblPlayerScore.Text.Replace(game.Stages[stageNum - 2].BestPlayerScore + "", game.Stages[stageNum - 1].BestPlayerScore + "");
                    //lblStageScore.Text = lblStageScore.Text.Replace(game.Stages[stageNum - 2].InitialScore + "", game.Stages[stageNum - 1].InitialScore + "");
                }
                else
                {
                    pbStagePreview.BackgroundImage = Resources._lock;
                    lblStageLockedMessage.Visible = true;
                }

                if (game.Stages[stageNum - 1].BestPlayerScore > -1)
                    lblStageScore.Text = "Best Score: "+ game.Stages[stageNum - 1].BestPlayerScore;
                else
                    lblStageScore.Text = "Best Score: #";

            }
        }
    }
}

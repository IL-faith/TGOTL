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
        Label[] selectChoices = new Label[3];
        int selectChoiceSelected = -1;
        public ResultsScreen(Point formPosition, Game g)
        {
            InitializeComponent();
            this.Location = formPosition;
            game = g;
            
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
            SortSelectChoices();

            GetResults();

            if (game.CurrentStage == game.Stages.Length - 1)
            {
                lblSelect2RetryBtn.Size = lblSelect1NextStageBtn.Size;
                lblSelect2RetryBtn.Location = lblSelect1NextStageBtn.Location;
                pbRetryBtn.Size = lblNextStageBtn.Size;
                pbRetryBtn.Location = lblNextStageBtn.Location;
            }
        }

        private void GetResults()
        {
            int playerScore = game.Stages[game.CurrentStage].CurrentPlayerScore, stageScore = game.Stages[game.CurrentStage].InitialScore;

            lblPlayerScore.Text = lblPlayerScore.Text.Replace("#", playerScore+"");
            lblStageScore.Text = lblStageScore.Text.Replace("#", stageScore+"");

            if (Math.Abs(playerScore - stageScore) <= 1500 )
            {
                lblFailed.Visible = false;
                if (game.CurrentStage != game.Stages.Length - 1)
                    game.Stages[game.CurrentStage+1].Unlocked = true;
                else if (!game.BeatGame)
                        game.BeatGame = true;
            }
            else
            {
                lblPassed.Visible = false;
                lblNextStageBtn.Visible = false;
                lblSelect2RetryBtn.Size = lblSelect1NextStageBtn.Size;
                lblSelect2RetryBtn.Location = lblSelect1NextStageBtn.Location;
                pbRetryBtn.Size = lblNextStageBtn.Size;
                pbRetryBtn.Location = lblNextStageBtn.Location;
            }

            if (playerScore < game.Stages[game.CurrentStage].BestPlayerScore || game.Stages[game.CurrentStage].BestPlayerScore == -1)
            {
                game.Stages[game.CurrentStage].BestPlayerScore = playerScore;
                //MessageBox.Show("new high score");
            }
            else { }
                //MessageBox.Show("no new high score");
        }

        private void SortSelectChoices()
        {
            for (int i = 0; i < selectChoices.Length; i++)
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

        private void KeyboardKeyDown(object sender, KeyEventArgs e)
        {
            if (!game.PlaystyleIsMouse)
            {
                int previousChoice = selectChoiceSelected;
                bool arrowKeyPressed = true;

                int lastChoiceAvailable = (lblFailed.Visible? 1 : 2);

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
                    selectChoiceSelected += (selectChoiceSelected == lastChoiceAvailable ? -lastChoiceAvailable : 1);
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
                    selectChoiceSelected -= (selectChoiceSelected == 0 ? -lastChoiceAvailable : (selectChoiceSelected == -1 ? -(lastChoiceAvailable+1) : 1));
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
                            StageSelectionScreen stageSelect = new StageSelectionScreen(this.Location, game);
                            stageSelect.Show();
                            this.Close();
                            break;
                        case 1:
                            game.CurrentStage += 1;
                            if (game.CurrentStage == 1)
                            {
                                Stage2Prep s2 = new Stage2Prep(this.Location, game);
                                s2.Show();
                                this.Close();
                            }
                            else if (game.CurrentStage == 2)
                            {
                                Stage3Prep s3 = new Stage3Prep(this.Location, game);
                                s3.Show();
                                this.Close();
                            }
                            else if (game.CurrentStage == 3)
                            {
                                Stage4Prep s4 = new Stage4Prep(this.Location, game);
                                s4.Show();
                                this.Close();
                            }
                            else if (game.CurrentStage == 4)
                            {
                                Stage5Prep s5 = new Stage5Prep(this.Location, game);
                                s5.Show();
                                this.Close();
                            }
                            break;
                        case 2:
                            if (game.CurrentStage == 0)
                            {
                                Stage1Prep s1 = new Stage1Prep(this.Location, game);
                                s1.Show();
                                this.Close();
                            }
                            else if (game.CurrentStage == 1)
                            {
                                Stage2Prep s2 = new Stage2Prep(this.Location, game);
                                s2.Show();
                                this.Close();
                            }
                            else if (game.CurrentStage == 2)
                            {
                                Stage3Prep s3 = new Stage3Prep(this.Location, game);
                                s3.Show();
                                this.Close();
                            }
                            else if (game.CurrentStage == 3)
                            {
                                Stage4Prep s4 = new Stage4Prep(this.Location, game);
                                s4.Show();
                                this.Close();
                            }
                            else if (game.CurrentStage == 4)
                            {
                                Stage5Prep s5 = new Stage5Prep(this.Location, game);
                                s5.Show();
                                this.Close();
                            }
                            break;
                    }
                }
            }
        }

        private void StageSelectBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                if (game.BeatGame && !game.ShownEnding)
                {
                    StoryScreen showEnd = new StoryScreen(this.Location, game, false);
                    showEnd.Show();
                    this.Close();
                }
                else
                {
                    StageSelectionScreen stageSelect = new StageSelectionScreen(this.Location, game);
                    stageSelect.Show();
                    this.Close();
                }
            }
        }

        private void NextStageBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                game.CurrentStage += 1;
                if (game.CurrentStage == 1)
                {
                    Stage2Prep s2 = new Stage2Prep(this.Location, game);
                    s2.Show();
                    this.Close();
                }
                else if (game.CurrentStage == 2)
                {
                    Stage3Prep s3 = new Stage3Prep(this.Location, game);
                    s3.Show();
                    this.Close();
                }
                else if (game.CurrentStage == 3)
                {
                    Stage4Prep s4 = new Stage4Prep(this.Location, game);
                    s4.Show();
                    this.Close();
                }
                else if (game.CurrentStage == 4)
                {
                    Stage5Prep s5 = new Stage5Prep(this.Location, game);
                    s5.Show();
                    this.Close();
                }
            }
        }

        private void RetryStageBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                if (game.CurrentStage == 0)
                {
                    Stage1Prep s1 = new Stage1Prep(this.Location, game);
                    s1.Show();
                    this.Close();
                }
                else if (game.CurrentStage == 1)
                {
                    Stage2Prep s2 = new Stage2Prep(this.Location, game);
                    s2.Show();
                    this.Close();
                }
                else if (game.CurrentStage == 2)
                {
                    Stage3Prep s3 = new Stage3Prep(this.Location, game);
                    s3.Show();
                    this.Close();
                }
                else if (game.CurrentStage == 3)
                {
                    Stage4Prep s4 = new Stage4Prep(this.Location, game);
                    s4.Show();
                    this.Close();
                }
                else if (game.CurrentStage == 4)
                {
                    Stage5Prep s5 = new Stage5Prep(this.Location, game);
                    s5.Show();
                    this.Close();
                }
            }
        }
    }
}

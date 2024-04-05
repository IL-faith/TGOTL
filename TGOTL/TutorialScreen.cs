using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGOTL.Properties;

namespace TGOTL
{
    public partial class TutorialScreen : Form
    {
        Game game;
        int pageNum = 0, choiceSelected = -1;
        Label[] choices = new Label[3];
        Image[] tutorialPages;
        Form prevScreen; 

        public TutorialScreen(Point formPosition, Game g, Form ps)
        {
            InitializeComponent();

            prevScreen = ps;
            this.Location = formPosition;
            game = g;
            tutorialPages = new Image[8];
            tutorialPages[0] = Resources.tutorial_one;
            tutorialPages[1] = Resources.tutorial_two;
            tutorialPages[2] = Resources.tutorial_3;
            tutorialPages[3] = Resources.tutorial_4;
            tutorialPages[4] = Resources.tutorial_5;
            tutorialPages[5] = Resources.tutorial_6;
            tutorialPages[6] = Resources.tutorial_7;
            tutorialPages[7] = Resources.tutorial_8;
            SortChoices();
        }

        private void SortChoices()
        {
            int i = 0;
            foreach (Control choice in this.Controls)
            {
                if (choice.Tag != null && choice.Tag.Equals("select"))
                    choices[i++] = (Label)choice;
            }

            for (i = 0; i < choices.Length; i++)
            {
                for (int j = i + 1; j < choices.Length; j++)
                {
                    if (choices[i].Name.CompareTo(choices[j].Name) > 0)
                    {
                        Label temp = choices[i];
                        choices[i] = choices[j];
                        choices[j] = temp;
                    }
                }
            }
            MessageBox.Show("complete");
        }

        private void KeyboardKeyDown(object sender, KeyEventArgs e)
        {
            if (!game.PlaystyleIsMouse)
            {
                int previousChoice = choiceSelected; 

                bool arrowKeyPressed = true;

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
                {
                    if (choiceSelected == -1)
                        choiceSelected++;
                    else if (choiceSelected == 0)
                    {
                        if (pbPrevArrow.Visible)
                            choiceSelected++;
                        else
                            choiceSelected = 2;
                    }
                    else if (choiceSelected == 1)
                    {
                        if (pbNextArrow.Visible)
                            choiceSelected++;
                        else
                            choiceSelected = 0;
                    }
                    else if (choiceSelected == 2)
                        choiceSelected = 0;
                }
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
                {
                    if (choiceSelected == -1)
                        choiceSelected = 2;
                    else if (choiceSelected == 2)
                    {
                        if (pbPrevArrow.Visible)
                            choiceSelected--;
                        else
                            choiceSelected = 0;
                    }
                    else if (choiceSelected == 0)
                    {
                        if (pbNextArrow.Visible)
                            choiceSelected = 2;
                        else
                            choiceSelected = 1;
                    }
                    else if (choiceSelected == 1)
                        choiceSelected--;
                }
                else
                    arrowKeyPressed = false;

                if (arrowKeyPressed)
                {
                    if (previousChoice != -1)
                        choices[previousChoice].Visible = false;
                    choices[choiceSelected].Visible = true;
                }
                else if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space) && choiceSelected != -1)
                {
                    switch (choiceSelected)
                    {
                        case 0:
                            prevScreen.Show();
                            this.Close();
                            break;
                        case 1:
                            pbTutorialImage.BackgroundImage = tutorialPages[--pageNum];
                            if (pageNum == 0)
                            {
                                pbPrevArrow.Visible = false;
                                lblSelect1PrevArrow.Visible = false;
                            }
                            else if (pageNum == 6)
                                pbNextArrow.Visible = true;
                            break;
                        case 2:
                            pbTutorialImage.BackgroundImage = tutorialPages[++pageNum];
                            if (pageNum == 7)
                            {
                                pbNextArrow.Visible = false;
                                lblSelect2NextArrow.Visible = false;
                            }
                            else if (pageNum == 1)
                                pbPrevArrow.Visible = true;
                            break;
                    }
                }
            }
        }

        private void BackBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                prevScreen.Show();
                this.Close();
            }
        }

        private void pbNextArrow_Click(object sender, EventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                pbTutorialImage.BackgroundImage = tutorialPages[++pageNum];
                if (pageNum == 7)
                    pbNextArrow.Visible = false;
                else if (pageNum == 1)
                    pbPrevArrow.Visible = true;
            }
        }

        private void pbPrevArrow_Click(object sender, EventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                pbTutorialImage.BackgroundImage = tutorialPages[--pageNum];
                if (pageNum == 0)
                    pbPrevArrow.Visible = false;
                else if (pageNum == 6)
                    pbNextArrow.Visible = true;
            }
        }
    }
}

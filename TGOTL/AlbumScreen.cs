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
    public partial class AlbumScreen : Form
    {
        Game game;
        int pageNum = 1;
        Label[] selectChoices = new Label[10];
        PictureBox[] galleryChoices = new PictureBox[6];
        int selectChoiceSelected = -1;
        bool inGalleryMode = true;
        public AlbumScreen(Point formPosition, Game g)
        {
            InitializeComponent();
            //lblSelect0BackBtn.Visible = false;
            game = g;
            this.Location = formPosition;
            lblGalleryModeBtn.Visible = false;
            //lblSelect9GalleryModeBtn.Visible = false;
            pbSelectedTrivia.Visible = false;

            int i = 0;
            foreach (Label control in this.Controls)
            {
                if (/*control is Label && */control.Tag != null && control.Tag.Equals("select"))
                {
                    control.Visible = false;
                    selectChoices[i] = control;
                    i++;
                }
            }
            SortSelectChoices();

            i = 0;
            foreach (PictureBox trivia in this.Controls)
            {
                if (trivia.Name.StartsWith("pbTrivia"))
                {
                    galleryChoices[i] = trivia;
                    i++;
                }
            }
            SortGalleryChoices();
        }

        private void SortGalleryChoices()
        {
            for (int i = 0; i < galleryChoices.Length; i++)
            {
                for (int j = i + 1; j < galleryChoices.Length; j++)
                {
                    if (galleryChoices[i].Name.CompareTo(galleryChoices[j].Name) > 0)
                    {
                        PictureBox temp = galleryChoices[i];
                        galleryChoices[i] = galleryChoices[j];
                        galleryChoices[j] = temp;
                    }
                }
            }
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

                if (lblGalleryModeBtn.Visible)
                    inGalleryMode = false;
                else
                    inGalleryMode = true;

                if (inGalleryMode)
                {
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
                        selectChoiceSelected += (selectChoiceSelected == 8 ? -8 : 1);
                    else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
                        selectChoiceSelected -= (selectChoiceSelected == 0 ? -8 : (selectChoiceSelected == -1 ? -9 : 1));
                    else
                        arrowKeyPressed = false;
                }
                else
                {
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
                    {
                        selectChoiceSelected += (selectChoiceSelected == 9 ? -9 : 1);
                        while (selectChoices[selectChoiceSelected].Size == lblSelect1Trivia1.Size)
                            selectChoiceSelected++;
                    }
                    else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
                    {
                        selectChoiceSelected -= (selectChoiceSelected == 0 ? -9 : (selectChoiceSelected == -1 ? -10 : 1));
                        while (selectChoices[selectChoiceSelected].Size == lblSelect1Trivia1.Size)
                            selectChoiceSelected--;
                    }
                    else
                        arrowKeyPressed = false;
                }


                if (arrowKeyPressed)
                {
                    if (previousChoice != -1)
                        selectChoices[previousChoice].Visible = false;
                    selectChoices[selectChoiceSelected].Visible = true;
                }
                else if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space) && selectChoiceSelected != -1)
                {
                    if (selectChoices[selectChoiceSelected].Name.Contains("Trivia"))
                    {
                        pbSelectedTrivia.Image = galleryChoices[selectChoiceSelected].Image;
                        foreach (PictureBox trivia in galleryChoices)
                            trivia.Visible = false;
                        selectChoices[selectChoiceSelected].Visible = false;

                        selectChoiceSelected = 9;
                        lblGalleryModeBtn.Visible = true;
                        lblSelect9GalleryModeBtn.Visible = true;
                        pbSelectedTrivia.Visible = true;
                    }
                    else
                    {
                        switch (selectChoiceSelected)
                        {
                            case 0:
                                TitleScreen title = new TitleScreen(this.Location, game);
                                title.Show();
                                this.Close();
                                break;
                            case 7: //load previous page of gallery
                                break;
                            case 8: //load next page of gallery
                                break;
                            case 9: //switch to gallery view
                                bool foundSelectSchoice = false;
                                selectChoiceSelected = 1;
                                foreach (PictureBox trivia in galleryChoices)
                                {
                                    trivia.Visible = true;
                                    if (trivia.Image == pbSelectedTrivia.Image)
                                        foundSelectSchoice = true;
                                    else if (!foundSelectSchoice)
                                        selectChoiceSelected++;
                                }
                                selectChoices[selectChoiceSelected].Visible = false;

                                lblSelect9GalleryModeBtn.Visible = false;
                                lblGalleryModeBtn.Visible = false;
                                pbSelectedTrivia.Visible = false;
                                break;
                        }
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

        private void TriviaClick(object sender, MouseEventArgs e)
        {
            foreach (Control control in this.Controls) 
            {
                if (control is PictureBox && control.Tag != null && control.Tag.Equals("gallery"))
                    control.Visible = false;
            }
            pbSelectedTrivia.Visible = true;
            lblGalleryModeBtn.Visible = true;
            pageNum = game.GetScreenNumber(((PictureBox)sender).Image);
        }

        private void GalleryBtnClick(object sender, MouseEventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox && control.Tag != null && control.Tag.Equals("gallery"))
                    control.Visible = true;
            }
            pbSelectedTrivia.Visible = false;
            lblGalleryModeBtn.Visible = false;
            LoadAlbumPage(1);
        }

        private void NextBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                pageNum++;
                if (inGalleryMode)
                {
                    if (pageNum == 3)
                        pbNextArrow.Visible = false;
                    if (pageNum == 2)
                        pbPrevArrow.Visible = true;
                }
                else
                {
                    if (pageNum == game.LoadingScreens.Length - 1)
                        pbNextArrow.Visible = false;
                    if (pageNum == 1)
                        pbPrevArrow.Visible = true;
                }
                LoadAlbumPage(1);
            }
        }

        private void PrevBtnClick(object sender, MouseEventArgs e)
        {
            if (game.PlaystyleIsMouse)
            {
                pageNum--;
                if (inGalleryMode)
                {
                    if (pageNum == 1)
                        pbPrevArrow.Visible = false;
                    if (pageNum == 2)
                        pbNextArrow.Visible = true;
                }
                else
                {
                    if (pageNum == 0)
                        pbPrevArrow.Visible = false;
                    if (pageNum == game.LoadingScreens.Length-1)
                        pbNextArrow.Visible = true;
                }
            }
            LoadAlbumPage(-1);
        }

        private void LoadAlbumPage(int direction)
        {
            if (inGalleryMode)
            {
                Image[] albumPage = game.GetGalleryAlbumPage(6, direction);
                for (int i = 0; i < 6; i++)
                    galleryChoices[i].Image = albumPage[i];
            }
            else
                pbSelectedTrivia.Image = game.GetScreen(game.GetScreenNumber(pbSelectedTrivia.Image) + direction);
        }
    }
}

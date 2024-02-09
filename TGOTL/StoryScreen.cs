using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGOTL
{
    public partial class StoryScreen : Form
    {
        bool playstyleIsMouse, isLoadingScreen;
        int dialogueNum = 0;
        string[] dialogues;
        Game game;

        public StoryScreen(Point formPosition, Game g, bool ls = true)
        {
            InitializeComponent();
            this.Location = formPosition;
            isLoadingScreen = ls;
            game = g;
            SetUpDialogues();
        }

        public void DisplayLoadingScreen()
        {
            //Image[] images = new
        }

        private void SetUpDialogues() 
        {
            dialogues = new string[2];
            dialogues[0] = "Click/Press Enter to continue.";
            dialogues[1] = "This is a test.";

            if (game.BeatGame && !game.ShownEnding)
            {
                dialogues[0] = "You beat the game!";
                dialogues[1] = "Congrats!!";
            }

            lblDialogueBox.Text = dialogues[0];
        }

        private void GetNextDialog()
        {
            dialogueNum++;
            if (dialogueNum < dialogues.Length) 
                lblDialogueBox.Text = dialogues[dialogueNum];
            else
            {
                StageSelectionScreen stageSelection = new StageSelectionScreen(this.Location, game);
                stageSelection.Show();
                this.Close();
            }
        }

        private void DialogueClicked(object sender, MouseEventArgs e)
        {
            GetNextDialog();
        }

        private void KeyboardKeyPressed(object sender, KeyEventArgs e)
        {
            if (!playstyleIsMouse)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
                {
                    if (isLoadingScreen)
                        this.Close();
                    else
                        GetNextDialog();
                }
            }
        }
    }
}

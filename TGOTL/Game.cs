using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGOTL.Properties;

namespace TGOTL
{
    public class Game
    {
        bool playstyleIsMouse = true, beatGame = false, shownEnding;
        int albumIndex = 0, currentStage = -1;
        List<LoadingScreen> loadingScreens = new List<LoadingScreen>();
        Stage[] stages = new Stage[5];

        public Game()
        {
            // i have to use a file with all the names?
            //string[] imageNames = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames().Where(r => r.EndsWith(".png")).ToArray(); //? THIS ISN;T IT
            //System.Reflection.Assembly.GetExecutingAssembly().
            //Properties.Resources.reso
            //foreach (var resource in resourceSet)
            //{
            //    MessageBox.Show(resource + "");
            //}
            //Resources
            //for (int i = 0; i < imageNames.Length; i++) 
            //{
            //    loadingScreens.Add(new LoadingScreen(Image.FromFile(imageNames[i]), i + 1));
            //}
            //foreach (string s in  imageNames) { MessageBox.Show(s); }
            for (int i = 1; i <= 5; i++)
            {
                TrafficLight[] test = new TrafficLight[0];
                stages[i - 1] = new Stage("s" + i, test);
            }
            stages[0].Unlocked = true;

            stages[0].InitialScore = 10;
            stages[1].InitialScore = 30;
            stages[2].InitialScore = 50;
            stages[0].CurrentPlayerScore = 0;
            stages[1].CurrentPlayerScore = 20;
            stages[2].CurrentPlayerScore = 400;
            stages[0].BestPlayerScore = 0;
            stages[1].BestPlayerScore = 25;
            stages[2].BestPlayerScore = 10;
            stages[2].CurrentPlayerScore = 1;
            stages[3].CurrentPlayerScore = 1;
            stages[4].CurrentPlayerScore = 1;
            stages[2].InitialScore = 2;
            stages[3].InitialScore = 2;
            stages[4].InitialScore = 2;
        }

        //it seems { get; set; } doesn't work with (abstract) object types, only primitives...

        public bool PlaystyleIsMouse { get; set; }
        public bool BeatGame { get; set; }
        public bool ShownEnding { get; set; }
        public Stage[] Stages { get { return stages; } set { stages = value; } }
        public int CurrentStage { get; set; }
        public LoadingScreen[] LoadingScreens { get { return loadingScreens.ToArray(); } }

        public int GetNumStagesUnlocked()
        {
            int stagesUnlocked = 0;
            for (int i = 0; i < stages.Length; i++, stagesUnlocked++)
            {
                if (stages[i].Unlocked == false)
                    break;
            }
            return stagesUnlocked;
        }
        public int GetScreenNumber(Image image)
        {
            for (int i = 0; i < loadingScreens.Count; i++) 
            {
                if (loadingScreens[i].Screen == image)
                    return i;
            }
            return -1;
        }

        public Image GetScreen(int screenNumber)
        {
            return loadingScreens[screenNumber].Screen;
        }

        public Image[] GetGalleryAlbumPage(int numPerPage, int direction)
        {
            Image[] albumPage = new Image[numPerPage];
            for (int i = 0; i < albumPage.Length; i++, albumIndex += direction)
                albumPage[i] = loadingScreens[albumIndex].Screen;
            return albumPage;
        }
    }
}

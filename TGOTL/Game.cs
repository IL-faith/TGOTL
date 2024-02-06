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
        bool playstyleIsMouse = true;
        int stagesUnlocked = 1, albumIndex = 0;
        List<LoadingScreen> loadingScreens = new List<LoadingScreen>();
        Stage[] stages = new Stage[0];

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
        }

        public bool PlaystyleIsMouse { get; set; }
        public int StagesUnlocked { get; set; }
        public Stage[] Stages { get; set; }
        public LoadingScreen[] LoadingScreens { get { return loadingScreens.ToArray(); } }

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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MyMovieLibrary
{
    public partial class MainScreen : Form
    {
        APIConnection con = new APIConnection();
        DBConnection DBCon = new DBConnection();
        List<LibraryMovie> libraryMovies = new List<LibraryMovie>();
        LibraryMovie actualMovie;

        public MainScreen()
        {
            InitializeComponent();
            libraryMovies = DBCon.getMovieLibrary(1);
            libraryMovies = libraryMovies.OrderBy(o => o.title).ToList();
            foreach (LibraryMovie libraryMovie in libraryMovies)
            {
                var item = libraryList.Items.Add(libraryMovie.idMovie.ToString(), libraryMovie.title, "");
                libraryList.LargeImageList = moviesImages;
                if (!String.IsNullOrEmpty(libraryMovie.image_path))
                {
                    moviesImages.Images.Add(libraryMovie.idMovie.ToString(), Image.FromFile(Constants.libraryImagesPath + libraryMovie.image_path));
                    item.ImageKey = libraryMovie.idMovie.ToString();
                }
                else
                {
                    item.ImageKey = "No-photo";
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            AddMovieForm addMovieForm = new AddMovieForm();
            addMovieForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlPlatforms.Visible = false;
        }

        private void libraryList_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem currentItem = libraryList.SelectedItems[0];
            actualMovie = libraryMovies.First(o => o.idMovie.ToString().Equals(currentItem.Name));
            listPlatforms.Items.Clear();
            platformsImages.Images.Clear();
            listPlatforms.LargeImageList = platformsImages;
            foreach (string platform in actualMovie.platforms)
            {
                var item = listPlatforms.Items.Add(platform, platform, "");
                Image image = (Image)Properties.Resources.ResourceManager.GetObject(platform.ToLower().Replace(" ", "_").Replace("-", "_"));
                platformsImages.Images.Add(platform, image);
                item.ImageKey = platform;
            }
            pnlPlatforms.Visible = true;
        }
    }
}

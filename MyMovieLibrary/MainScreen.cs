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
        DBConnection DBCon;
        List<LibraryMovie> libraryMovies = new List<LibraryMovie>();

        public MainScreen()
        {
            InitializeComponent();
            DBCon = new DBConnection();
            libraryMovies = DBCon.getMovieLibrary(1);
            libraryMovies = libraryMovies.OrderBy(o => o.title).ToList();
            foreach (LibraryMovie libraryMovie in libraryMovies)
            {
                var item = libraryList.Items.Add(libraryMovie.id.ToString(), libraryMovie.title, "");
                libraryList.LargeImageList = moviesImages;
                if (!String.IsNullOrEmpty(libraryMovie.image_path))
                {
                    moviesImages.Images.Add(libraryMovie.id.ToString(), Image.FromFile(Constants.libraryImagesPath + libraryMovie.image_path));
                    item.ImageKey = libraryMovie.id.ToString();
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
    }
}

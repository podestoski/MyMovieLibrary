using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMovieLibrary
{
    public partial class Form1 : Form
    {
        List<Movie> moviesList = new List<Movie>();
        APIConnection con = new APIConnection();
       // bool refreshAutoComplete = true;

        private const string NO_POSTER_IMAGE_PATH = @"Images\no-photo.jpg";

        public Form1()
        {
            InitializeComponent();
            /*txtMovie.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtMovie.AutoCompleteSource = AutoCompleteSource.CustomSource;*/
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<Results> results = con.searchMovie(txtMovie.Text);
            listMoviesResults.Clear();
            moviesImages.Images.Add("No-photo", Properties.Resources.no_photo);
            foreach (Results result in results)
            {
                var item = listMoviesResults.Items.Add(result.title);
                listMoviesResults.LargeImageList = moviesImages;
                if (!String.IsNullOrEmpty(result.poster_path))
                {
                    string imagePath = @"c:\MyMovieLibrary\temp" + result.poster_path;
                    moviesImages.Images.Add(result.title, Image.FromFile(imagePath));
                    item.ImageKey = result.title;
                }
                else
                {
                    item.ImageKey = "No-photo";
                }

            }
        }

        private void txtMovie_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (txtMovie.Text.Length > 2 && refreshAutoComplete)
            {
                if (txtMovie.AutoCompleteCustomSource.Count > 0)
                    txtMovie.AutoCompleteCustomSource.Clear();
                txtMovie.AutoCompleteCustomSource = con.preSearchMovie(txtMovie.Text);
                refreshAutoComplete = false;
            }*/
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

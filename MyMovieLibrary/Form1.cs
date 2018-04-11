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
        bool refreshAutoComplete = true;

        public Form1()
        {
            InitializeComponent();
            /*txtMovie.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtMovie.AutoCompleteSource = AutoCompleteSource.CustomSource;*/
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*moviesList.Add(new Movie(txtMovie.Text, txtPlatform.Text));

            listMovies.Clear();
            foreach (Movie movie in moviesList)
            {
                listMovies.Items.Add(movie.title);
            }*/

            //txtResult.Text =  con.searchMovie(txtMovie.Text);
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
    }
}

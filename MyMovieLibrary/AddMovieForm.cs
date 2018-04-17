using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMovieLibrary
{
    public partial class AddMovieForm : Form
    {
        APIConnection con = new APIConnection();
        SearchMovieRootResult searchResults;
        SearchMovieResult movie;
        MovieVideosRootResult videosResults;
        string imagePath = @"c:\MyMovieLibrary\temp";
        private const string NO_POSTER_IMAGE_PATH = @"Images\no-photo.jpg";
        DBConnection DBCon;
        private int ActualMovie;

        public AddMovieForm()
        {
            SetBrowserFeatureControl();
            InitializeComponent();
            DBCon = new DBConnection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            searchResults = con.searchMovie(txtMovie.Text);
            listMoviesResults.Clear();
            moviesImages.Images.Add("No-photo", Properties.Resources.no_photo);
            searchResults.results = searchResults.results.OrderBy(o => o.title).ToList();
            foreach (SearchMovieResult movie in searchResults.results)
            {
                var item = listMoviesResults.Items.Add(movie.id.ToString(),movie.title,"");
                listMoviesResults.LargeImageList = moviesImages;
                if (!String.IsNullOrEmpty(movie.poster_path))
                {
                    moviesImages.Images.Add(movie.id.ToString(), Image.FromFile(imagePath + movie.poster_path));
                    item.ImageKey = movie.id.ToString();
                }
                else
                {
                    item.ImageKey = "No-photo";
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void listMoviesResults_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            cbVideos.Items.Clear();
            ListViewItem listItem = listMoviesResults.Items[listMoviesResults.SelectedItems[0].Index];
            movie = searchResults.results.First(item => item.id.ToString().Equals(listItem.Name));
            ActualMovie = movie.id;
            if (String.IsNullOrEmpty(movie.poster_path))
            {
                imgDetailsPoster.Image = Properties.Resources.no_photo;
            }
            else
            {
                imgDetailsPoster.Image = Image.FromFile(imagePath + movie.poster_path);
            }
            lblDetailsMovieOverview.Text = movie.overview;
            lblDetailsMovieTitle.Text = movie.title;
            videosResults = con.getVideos(movie.id);
            videosResults.results = videosResults.results.OrderBy(o => o.name).ToList();
            if (videosResults.results.Count > 0)
            {
                foreach (MovieVideosResult video in videosResults.results)
                {
                    cbVideos.Items.Add(video.name);
                }

                cbVideos.SelectedIndex = 0;
                //string video_path = "https://www.youtube.com/embed/" + videosResults.results[0].key + "?autoplay=1";
                string video_path = "https://www.youtube.com/embed/" + videosResults.results[0].key;
                webDetailsMovieVideo.Navigate(video_path);
                picNoVideo.Visible = false;
                webDetailsMovieVideo.Visible = true;
                cbVideos.Visible = true;
                lblVideos.Visible = true;
            }
            else
            {
                webDetailsMovieVideo.Navigate("");
                picNoVideo.Visible = true;
                webDetailsMovieVideo.Visible = false;
                cbVideos.Visible = false;
                lblVideos.Visible = false;
            }
            pnlDetails.Visible = true;
            this.Cursor = Cursors.Default;
        }

        private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(
                String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
            }
        }

        private void SetBrowserFeatureControl()
        {
            // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx

            // FeatureControl settings are per-process
            var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            // make the control is not running inside Visual Studio Designer
            if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
                return;

            SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode()); // Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
            SetBrowserFeatureControlKey("FEATURE_AJAX_CONNECTIONEVENTS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_MANAGE_SCRIPT_CIRCULAR_REFS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_DOMSTORAGE ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_GPU_RENDERING ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_IVIEWOBJECTDRAW_DMLT9_WITH_GDI  ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_LEGACY_COMPRESSION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_LOCALMACHINE_LOCKDOWN", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_OBJECT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_SCRIPT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_NAVIGATION_SOUNDS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SCRIPTURL_MITIGATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SPELLCHECKING", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_STATUS_BAR_THROTTLING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_TABBED_BROWSING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_VALIDATE_NAVIGATE_URL", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_DOCUMENT_ZOOM", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_POPUPMANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_MOVESIZECHILD", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ADDON_MANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBSOCKET", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WINDOW_RESTRICTIONS ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_XMLHTTP", fileName, 1);
        }

        private UInt32 GetBrowserEmulationMode()
        {
            int browserVersion = 7;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }

            UInt32 mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode. Default value for Internet Explorer 11.
            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
                    break;
                case 8:
                    mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 mode. Default value for Internet Explorer 10.
                    break;
                default:
                    // use IE11 mode by default
                    break;
            }

            return mode;
        }

        #region pnlDetails

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlDetails.Visible = false;
        }

        #endregion pnlDetails

        private void cbVideos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string video_path = "https://www.youtube.com/embed/" + videosResults.results[cbVideos.SelectedIndex].key;
            webDetailsMovieVideo.Navigate(video_path);
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlPlatform.Visible = true;
            List<Platform> platforms = DBCon.getPlatforms();
            int i = 1;
            foreach (Platform platform in platforms)
            {
                CheckBox check = new CheckBox();
                check.Name = "check_" + platform.id.ToString();
                check.Text = platform.name;
                check.Location = new Point(7, 22 * i);
                platformGroup.Controls.Add(check);
                i++;
            }
        }

        private void bntConfirm_Click(object sender, EventArgs e)
        {
            int idJustInserted = DBCon.saveToLibrary(ActualMovie, 1, movie.poster_path.Replace(@"/",@"\"), movie.title);
            System.IO.File.Copy(imagePath + movie.poster_path.Replace(@"/", @"\"), Constants.libraryImagesPath + movie.poster_path.Replace(@"/", @"\"), true);
            foreach (CheckBox check in platformGroup.Controls)
            {
                if (check.Checked)
                {
                    int idPlatform = Int32.Parse(check.Name.Substring(6, check.Name.Length - 6));
                    DBCon.insertPlatformRelation(idJustInserted, idPlatform);
                }
            }

            MessageBox.Show("Movie succesfully added to your library!!");
            pnlDetails.Dispose();
            pnlPlatform.Dispose();
            this.Hide();
            MainScreen main = new MainScreen();
            main.Show();
        }
    }
}

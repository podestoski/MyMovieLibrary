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
    public partial class Form1 : Form
    {
        APIConnection con = new APIConnection();
        SearchMovieRootResult searchResults;
        string imagePath = @"c:\MyMovieLibrary\temp";
        // bool refreshAutoComplete = true;

        private const string NO_POSTER_IMAGE_PATH = @"Images\no-photo.jpg";

        public Form1()
        {
            SetBrowserFeatureControl();
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            searchResults = con.searchMovie(txtMovie.Text);
            listMoviesResults.Clear();
            moviesImages.Images.Add("No-photo", Properties.Resources.no_photo);
            foreach (SearchMovieResult movie in searchResults.results)
            {
                var item = listMoviesResults.Items.Add(movie.id.ToString(),movie.title,"");
                listMoviesResults.LargeImageList = moviesImages;
                if (!String.IsNullOrEmpty(movie.poster_path))
                {
                    moviesImages.Images.Add(movie.title, Image.FromFile(imagePath + movie.poster_path));
                    item.ImageKey = movie.title;
                }
                else
                {
                    item.ImageKey = "No-photo";
                }

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void listMoviesResults_DoubleClick(object sender, EventArgs e)
        {
            
            ListViewItem listItem = listMoviesResults.Items[listMoviesResults.SelectedItems[0].Index];
            SearchMovieResult movie = searchResults.results.First(item => item.id.ToString().Equals(listItem.Name));
            //SearchMovieResult movie = movies[0];
            imgDetailsPoster.Image = Image.FromFile(imagePath + movie.poster_path);
            lblDetailsMovieOverview.Text = movie.overview;
            lblDetailsMovieTitle.Text = movie.title;
            MovieVideosRootResult videosResult = con.getVideos(movie.id);
            //string video_path = "https://www.youtube.com/watch?v=" + videosResult.results[0].key;
            //string video_path = "https://www.youtube.com/v/" + videosResult.results[0].key + "?version=3";
            /*string video_path = "<body><iframe width='800' height='800' src='http://www.youtube.com/embed/O6WLkyxySA0' " +
                                "frameborder='0' allowfullscreen></iframe><body>";*/
            //string video_path = "http://www.youtube.com/apiplayer?video_id=xitHF0IPJSQ&version=3";
            string video_path = "https://www.youtube.com/embed/" + videosResult.results[1].key + "?autoplay=1";

            webDetailsMovieVideo.Navigate(video_path);
            pnlDetails.Visible = true;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlDetails.Visible = false;
        }
    }
}

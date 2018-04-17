using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MyMovieLibrary
{
    public partial class MessageDialog : Form
    {
        public MessageDialog(Image image, string message)
        {
            InitializeComponent();
            imgDialog.Image = image;
            lblMessage.Text = message;
        }


    }
}
namespace MyMovieLibrary
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listMoviesResults = new System.Windows.Forms.ListView();
            this.txtMovie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesImages = new System.Windows.Forms.ImageList(this.components);
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.webDetailsMovieVideo = new System.Windows.Forms.WebBrowser();
            this.lblDetailsMovieOverview = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDetailsMovieTitle = new System.Windows.Forms.Label();
            this.imgDetailsPoster = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDetailsPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(245, 39);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Search";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listMoviesResults
            // 
            this.listMoviesResults.Location = new System.Drawing.Point(12, 78);
            this.listMoviesResults.Name = "listMoviesResults";
            this.listMoviesResults.Size = new System.Drawing.Size(1327, 679);
            this.listMoviesResults.TabIndex = 1;
            this.listMoviesResults.UseCompatibleStateImageBehavior = false;
            this.listMoviesResults.DoubleClick += new System.EventHandler(this.listMoviesResults_DoubleClick);
            // 
            // txtMovie
            // 
            this.txtMovie.Location = new System.Drawing.Point(51, 42);
            this.txtMovie.Name = "txtMovie";
            this.txtMovie.Size = new System.Drawing.Size(188, 20);
            this.txtMovie.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Movie";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1351, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // moviesImages
            // 
            this.moviesImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.moviesImages.ImageSize = new System.Drawing.Size(92, 138);
            this.moviesImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.btnClose);
            this.pnlDetails.Controls.Add(this.webDetailsMovieVideo);
            this.pnlDetails.Controls.Add(this.lblDetailsMovieOverview);
            this.pnlDetails.Controls.Add(this.label2);
            this.pnlDetails.Controls.Add(this.lblDetailsMovieTitle);
            this.pnlDetails.Controls.Add(this.imgDetailsPoster);
            this.pnlDetails.Location = new System.Drawing.Point(423, 128);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(540, 599);
            this.pnlDetails.TabIndex = 5;
            this.pnlDetails.Visible = false;
            // 
            // webDetailsMovieVideo
            // 
            this.webDetailsMovieVideo.Location = new System.Drawing.Point(38, 297);
            this.webDetailsMovieVideo.MinimumSize = new System.Drawing.Size(20, 20);
            this.webDetailsMovieVideo.Name = "webDetailsMovieVideo";
            this.webDetailsMovieVideo.Size = new System.Drawing.Size(469, 285);
            this.webDetailsMovieVideo.TabIndex = 4;
            // 
            // lblDetailsMovieOverview
            // 
            this.lblDetailsMovieOverview.Location = new System.Drawing.Point(38, 227);
            this.lblDetailsMovieOverview.Name = "lblDetailsMovieOverview";
            this.lblDetailsMovieOverview.Size = new System.Drawing.Size(469, 55);
            this.lblDetailsMovieOverview.TabIndex = 3;
            this.lblDetailsMovieOverview.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Overview";
            // 
            // lblDetailsMovieTitle
            // 
            this.lblDetailsMovieTitle.AutoSize = true;
            this.lblDetailsMovieTitle.Location = new System.Drawing.Point(242, 20);
            this.lblDetailsMovieTitle.Name = "lblDetailsMovieTitle";
            this.lblDetailsMovieTitle.Size = new System.Drawing.Size(35, 13);
            this.lblDetailsMovieTitle.TabIndex = 1;
            this.lblDetailsMovieTitle.Text = "label2";
            // 
            // imgDetailsPoster
            // 
            this.imgDetailsPoster.Location = new System.Drawing.Point(218, 46);
            this.imgDetailsPoster.Name = "imgDetailsPoster";
            this.imgDetailsPoster.Size = new System.Drawing.Size(92, 138);
            this.imgDetailsPoster.TabIndex = 0;
            this.imgDetailsPoster.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(438, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 769);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMovie);
            this.Controls.Add(this.listMoviesResults);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDetailsPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView listMoviesResults;
        private System.Windows.Forms.TextBox txtMovie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ImageList moviesImages;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.WebBrowser webDetailsMovieVideo;
        private System.Windows.Forms.Label lblDetailsMovieOverview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDetailsMovieTitle;
        private System.Windows.Forms.PictureBox imgDetailsPoster;
        private System.Windows.Forms.Button btnClose;
    }
}


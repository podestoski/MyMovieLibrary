namespace MyMovieLibrary
{
    partial class MainScreen
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.myLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesImages = new System.Windows.Forms.ImageList(this.components);
            this.libraryList = new System.Windows.Forms.ListView();
            this.pnlPlatforms = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.listPlatforms = new System.Windows.Forms.ListView();
            this.platformsImages = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnlPlatforms.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myLibraryToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1351, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // myLibraryToolStripMenuItem
            // 
            this.myLibraryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.myLibraryToolStripMenuItem.Name = "myLibraryToolStripMenuItem";
            this.myLibraryToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.myLibraryToolStripMenuItem.Text = "My Library";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.addToolStripMenuItem.Text = "Add Movie";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // moviesImages
            // 
            this.moviesImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.moviesImages.ImageSize = new System.Drawing.Size(92, 138);
            this.moviesImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // libraryList
            // 
            this.libraryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.libraryList.ForeColor = System.Drawing.Color.Black;
            this.libraryList.LargeImageList = this.moviesImages;
            this.libraryList.Location = new System.Drawing.Point(14, 116);
            this.libraryList.MultiSelect = false;
            this.libraryList.Name = "libraryList";
            this.libraryList.Size = new System.Drawing.Size(1322, 641);
            this.libraryList.TabIndex = 5;
            this.libraryList.UseCompatibleStateImageBehavior = false;
            this.libraryList.DoubleClick += new System.EventHandler(this.libraryList_DoubleClick);
            // 
            // pnlPlatforms
            // 
            this.pnlPlatforms.Controls.Add(this.btnClose);
            this.pnlPlatforms.Controls.Add(this.listPlatforms);
            this.pnlPlatforms.Location = new System.Drawing.Point(227, 176);
            this.pnlPlatforms.Name = "pnlPlatforms";
            this.pnlPlatforms.Size = new System.Drawing.Size(420, 323);
            this.pnlPlatforms.TabIndex = 6;
            this.pnlPlatforms.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::MyMovieLibrary.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(379, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(37, 32);
            this.btnClose.TabIndex = 7;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // listPlatforms
            // 
            this.listPlatforms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPlatforms.Location = new System.Drawing.Point(0, 0);
            this.listPlatforms.Name = "listPlatforms";
            this.listPlatforms.Size = new System.Drawing.Size(420, 323);
            this.listPlatforms.TabIndex = 0;
            this.listPlatforms.UseCompatibleStateImageBehavior = false;
            // 
            // platformsImages
            // 
            this.platformsImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.platformsImages.ImageSize = new System.Drawing.Size(64, 64);
            this.platformsImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(503, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 54);
            this.label1.TabIndex = 7;
            this.label1.Text = "My Library";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1351, 769);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlPlatforms);
            this.Controls.Add(this.libraryList);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calisto MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Movie Library";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlPlatforms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ImageList moviesImages;
        private System.Windows.Forms.ToolStripMenuItem myLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ListView libraryList;
        private System.Windows.Forms.Panel pnlPlatforms;
        private System.Windows.Forms.ListView listPlatforms;
        private System.Windows.Forms.ImageList platformsImages;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}


namespace HangManV1
{
    partial class HangManFormV1
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tSGame = new System.Windows.Forms.ToolStripMenuItem();
            this.tSNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.tSNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tSHighscore = new System.Windows.Forms.ToolStripMenuItem();
            this.tSHighscoreList = new System.Windows.Forms.ToolStripMenuItem();
            this.tSNewHsDB = new System.Windows.Forms.ToolStripMenuItem();
            this.pbErrorImages = new System.Windows.Forms.PictureBox();
            this.lblCurrentLogin = new System.Windows.Forms.Label();
            this.lblSolveWord = new System.Windows.Forms.Label();
            this.panelForButtons = new System.Windows.Forms.Panel();
            this.lblCoveredWord = new System.Windows.Forms.Label();
            this.lblErrorCount = new System.Windows.Forms.Label();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorImages)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSGame,
            this.tSHighscore});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip";
            // 
            // tSGame
            // 
            this.tSGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSNewGame,
            this.tSNewUser,
            this.exitToolStripMenuItem});
            this.tSGame.Name = "tSGame";
            this.tSGame.Size = new System.Drawing.Size(50, 20);
            this.tSGame.Text = "Game";
            // 
            // tSNewGame
            // 
            this.tSNewGame.Name = "tSNewGame";
            this.tSNewGame.Size = new System.Drawing.Size(180, 22);
            this.tSNewGame.Text = "New Game";
            this.tSNewGame.Click += new System.EventHandler(this.tSNewGame_Click);
            // 
            // tSNewUser
            // 
            this.tSNewUser.Name = "tSNewUser";
            this.tSNewUser.Size = new System.Drawing.Size(180, 22);
            this.tSNewUser.Text = "New User";
            this.tSNewUser.Click += new System.EventHandler(this.tSNewUser_Click);
            // 
            // tSHighscore
            // 
            this.tSHighscore.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSHighscoreList,
            this.tSNewHsDB});
            this.tSHighscore.Name = "tSHighscore";
            this.tSHighscore.Size = new System.Drawing.Size(73, 20);
            this.tSHighscore.Text = "Highscore";
            // 
            // tSHighscoreList
            // 
            this.tSHighscoreList.Name = "tSHighscoreList";
            this.tSHighscoreList.Size = new System.Drawing.Size(173, 22);
            this.tSHighscoreList.Text = "Highscore List";
            this.tSHighscoreList.Click += new System.EventHandler(this.tSHighscoreList_Click);
            // 
            // tSNewHsDB
            // 
            this.tSNewHsDB.Name = "tSNewHsDB";
            this.tSNewHsDB.Size = new System.Drawing.Size(173, 22);
            this.tSNewHsDB.Text = "New Highscore DB";
            this.tSNewHsDB.Click += new System.EventHandler(this.tSNewHsDB_Click);
            // 
            // pbErrorImages
            // 
            this.pbErrorImages.InitialImage = global::HangManV1.Properties.Resources._0;
            this.pbErrorImages.Location = new System.Drawing.Point(504, 37);
            this.pbErrorImages.Name = "pbErrorImages";
            this.pbErrorImages.Size = new System.Drawing.Size(284, 288);
            this.pbErrorImages.TabIndex = 4;
            this.pbErrorImages.TabStop = false;
            // 
            // lblCurrentLogin
            // 
            this.lblCurrentLogin.AutoSize = true;
            this.lblCurrentLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentLogin.Location = new System.Drawing.Point(12, 339);
            this.lblCurrentLogin.Name = "lblCurrentLogin";
            this.lblCurrentLogin.Size = new System.Drawing.Size(89, 16);
            this.lblCurrentLogin.TabIndex = 5;
            this.lblCurrentLogin.Text = "Current Login:";
            // 
            // lblSolveWord
            // 
            this.lblSolveWord.AutoSize = true;
            this.lblSolveWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolveWord.Location = new System.Drawing.Point(12, 37);
            this.lblSolveWord.Name = "lblSolveWord";
            this.lblSolveWord.Size = new System.Drawing.Size(49, 18);
            this.lblSolveWord.TabIndex = 6;
            this.lblSolveWord.Text = "Solve:";
            // 
            // panelForButtons
            // 
            this.panelForButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForButtons.Location = new System.Drawing.Point(15, 209);
            this.panelForButtons.Name = "panelForButtons";
            this.panelForButtons.Size = new System.Drawing.Size(468, 116);
            this.panelForButtons.TabIndex = 7;
            // 
            // lblCoveredWord
            // 
            this.lblCoveredWord.AutoSize = true;
            this.lblCoveredWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoveredWord.Location = new System.Drawing.Point(95, 39);
            this.lblCoveredWord.Name = "lblCoveredWord";
            this.lblCoveredWord.Size = new System.Drawing.Size(25, 16);
            this.lblCoveredWord.TabIndex = 8;
            this.lblCoveredWord.Text = "_ _";
            // 
            // lblErrorCount
            // 
            this.lblErrorCount.AutoSize = true;
            this.lblErrorCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorCount.Location = new System.Drawing.Point(340, 339);
            this.lblErrorCount.Name = "lblErrorCount";
            this.lblErrorCount.Size = new System.Drawing.Size(77, 16);
            this.lblErrorCount.TabIndex = 9;
            this.lblErrorCount.Text = "Error Count:";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // HangManFormV1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 364);
            this.Controls.Add(this.lblErrorCount);
            this.Controls.Add(this.lblCoveredWord);
            this.Controls.Add(this.panelForButtons);
            this.Controls.Add(this.lblSolveWord);
            this.Controls.Add(this.lblCurrentLogin);
            this.Controls.Add(this.pbErrorImages);
            this.Controls.Add(this.menuStrip);
            this.Name = "HangManFormV1";
            this.Text = "HangManFormV1";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorImages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tSGame;
        private System.Windows.Forms.ToolStripMenuItem tSNewGame;
        private System.Windows.Forms.ToolStripMenuItem tSHighscore;
        private System.Windows.Forms.ToolStripMenuItem tSHighscoreList;
        private System.Windows.Forms.ToolStripMenuItem tSNewHsDB;
        private System.Windows.Forms.PictureBox pbErrorImages;
        private System.Windows.Forms.Label lblSolveWord;
        private System.Windows.Forms.Panel panelForButtons;
        private System.Windows.Forms.Label lblCoveredWord;
        private System.Windows.Forms.Label lblErrorCount;
        private System.Windows.Forms.ToolStripMenuItem tSNewUser;
        public System.Windows.Forms.Label lblCurrentLogin;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}
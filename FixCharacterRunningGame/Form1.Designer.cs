namespace FixCharacterRunningGame
{
    partial class Sky
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
            this.txtScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TestObstacleSpawner = new System.Windows.Forms.Label();
            this.MovementDebug = new System.Windows.Forms.Label();
            this.HighScore = new System.Windows.Forms.Label();
            this.NewBearStatusJump = new System.Windows.Forms.Label();
            this.PlayerTimer = new System.Windows.Forms.Timer(this.components);
            this.BearLocation1 = new System.Windows.Forms.Label();
            this.BearLocation0 = new System.Windows.Forms.Label();
            this.BearLocation2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.BackColor = System.Drawing.Color.Transparent;
            this.txtScore.Font = new System.Drawing.Font("Nirmala UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.Location = new System.Drawing.Point(3, 1);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(115, 38);
            this.txtScore.TabIndex = 4;
            this.txtScore.Text = "Score: 0";
            this.txtScore.Click += new System.EventHandler(this.txtScore_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.MainGameTimerEvent);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SeaGreen;
            this.pictureBox1.Location = new System.Drawing.Point(-15, 403);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1209, 56);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TestObstacleSpawner
            // 
            this.TestObstacleSpawner.AutoSize = true;
            this.TestObstacleSpawner.BackColor = System.Drawing.Color.Transparent;
            this.TestObstacleSpawner.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TestObstacleSpawner.Location = new System.Drawing.Point(529, 33);
            this.TestObstacleSpawner.Name = "TestObstacleSpawner";
            this.TestObstacleSpawner.Size = new System.Drawing.Size(158, 20);
            this.TestObstacleSpawner.TabIndex = 12;
            this.TestObstacleSpawner.Tag = "debugTxt";
            this.TestObstacleSpawner.Text = "OOD Coordinates: ---";
            this.TestObstacleSpawner.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // MovementDebug
            // 
            this.MovementDebug.AutoSize = true;
            this.MovementDebug.BackColor = System.Drawing.Color.Transparent;
            this.MovementDebug.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MovementDebug.Location = new System.Drawing.Point(529, 53);
            this.MovementDebug.Name = "MovementDebug";
            this.MovementDebug.Size = new System.Drawing.Size(142, 20);
            this.MovementDebug.TabIndex = 13;
            this.MovementDebug.Tag = "debugTxt";
            this.MovementDebug.Text = "Obstacle Count: ---";
            // 
            // HighScore
            // 
            this.HighScore.AutoSize = true;
            this.HighScore.BackColor = System.Drawing.Color.Transparent;
            this.HighScore.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighScore.Location = new System.Drawing.Point(5, 39);
            this.HighScore.Name = "HighScore";
            this.HighScore.Size = new System.Drawing.Size(118, 25);
            this.HighScore.TabIndex = 14;
            this.HighScore.Text = "High Score: 0";
            this.HighScore.Click += new System.EventHandler(this.HighScore_Click);
            // 
            // NewBearStatusJump
            // 
            this.NewBearStatusJump.AutoSize = true;
            this.NewBearStatusJump.BackColor = System.Drawing.Color.Transparent;
            this.NewBearStatusJump.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NewBearStatusJump.Location = new System.Drawing.Point(529, 87);
            this.NewBearStatusJump.Name = "NewBearStatusJump";
            this.NewBearStatusJump.Size = new System.Drawing.Size(195, 20);
            this.NewBearStatusJump.TabIndex = 16;
            this.NewBearStatusJump.Tag = "debugTxt";
            this.NewBearStatusJump.Text = "New Bear Jump Status: ---";
            // 
            // PlayerTimer
            // 
            this.PlayerTimer.Enabled = true;
            this.PlayerTimer.Interval = 20;
            this.PlayerTimer.Tick += new System.EventHandler(this.PlayerTimer_Tick);
            // 
            // BearLocation1
            // 
            this.BearLocation1.AutoSize = true;
            this.BearLocation1.BackColor = System.Drawing.Color.Transparent;
            this.BearLocation1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BearLocation1.Location = new System.Drawing.Point(529, 156);
            this.BearLocation1.Name = "BearLocation1";
            this.BearLocation1.Size = new System.Drawing.Size(148, 20);
            this.BearLocation1.TabIndex = 17;
            this.BearLocation1.Tag = "debugTxt";
            this.BearLocation1.Text = "Bear[1] Location: ---";
            // 
            // BearLocation0
            // 
            this.BearLocation0.AutoSize = true;
            this.BearLocation0.BackColor = System.Drawing.Color.Transparent;
            this.BearLocation0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BearLocation0.Location = new System.Drawing.Point(529, 136);
            this.BearLocation0.Name = "BearLocation0";
            this.BearLocation0.Size = new System.Drawing.Size(148, 20);
            this.BearLocation0.TabIndex = 18;
            this.BearLocation0.Tag = "debugTxt";
            this.BearLocation0.Text = "Bear[0] Location: ---";
            // 
            // BearLocation2
            // 
            this.BearLocation2.AutoSize = true;
            this.BearLocation2.BackColor = System.Drawing.Color.Transparent;
            this.BearLocation2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BearLocation2.Location = new System.Drawing.Point(529, 176);
            this.BearLocation2.Name = "BearLocation2";
            this.BearLocation2.Size = new System.Drawing.Size(148, 20);
            this.BearLocation2.TabIndex = 19;
            this.BearLocation2.Tag = "debugTxt";
            this.BearLocation2.Text = "Bear[2] Location: ---";
            // 
            // Sky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1191, 450);
            this.Controls.Add(this.BearLocation2);
            this.Controls.Add(this.BearLocation0);
            this.Controls.Add(this.BearLocation1);
            this.Controls.Add(this.NewBearStatusJump);
            this.Controls.Add(this.HighScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.MovementDebug);
            this.Controls.Add(this.TestObstacleSpawner);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Sky";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label TestObstacleSpawner;
        private System.Windows.Forms.Label MovementDebug;
        private System.Windows.Forms.Label HighScore;
        private System.Windows.Forms.Label NewBearStatusJump;
        private System.Windows.Forms.Timer PlayerTimer;
        private System.Windows.Forms.Label BearLocation1;
        private System.Windows.Forms.Label BearLocation0;
        private System.Windows.Forms.Label BearLocation2;
    }
}


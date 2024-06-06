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
            this.debugHover = new System.Windows.Forms.Label();
            this.fallSpeedDebug = new System.Windows.Forms.Label();
            this.hoverDebug = new System.Windows.Forms.Label();
            this.forceDebug = new System.Windows.Forms.Label();
            this.OnGround = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.robotBear = new System.Windows.Forms.PictureBox();
            this.robotCoordinatesDebug = new System.Windows.Forms.Label();
            this.TestObstacleSpawner = new System.Windows.Forms.Label();
            this.MovementDebug = new System.Windows.Forms.Label();
            this.HighScore = new System.Windows.Forms.Label();
            this.BearLocation = new System.Windows.Forms.Label();
            this.NewBearStatusJump = new System.Windows.Forms.Label();
            this.PlayerTimer = new System.Windows.Forms.Timer(this.components);
            this.OldBearJumpStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.robotBear)).BeginInit();
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
            // debugHover
            // 
            this.debugHover.AutoSize = true;
            this.debugHover.BackColor = System.Drawing.Color.Transparent;
            this.debugHover.ForeColor = System.Drawing.SystemColors.ControlText;
            this.debugHover.Location = new System.Drawing.Point(342, 9);
            this.debugHover.Name = "debugHover";
            this.debugHover.Size = new System.Drawing.Size(148, 20);
            this.debugHover.TabIndex = 5;
            this.debugHover.Tag = "debugTxt";
            this.debugHover.Text = "hoverTester: Not on";
            // 
            // fallSpeedDebug
            // 
            this.fallSpeedDebug.AutoSize = true;
            this.fallSpeedDebug.BackColor = System.Drawing.Color.Transparent;
            this.fallSpeedDebug.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fallSpeedDebug.Location = new System.Drawing.Point(342, 33);
            this.fallSpeedDebug.Name = "fallSpeedDebug";
            this.fallSpeedDebug.Size = new System.Drawing.Size(181, 20);
            this.fallSpeedDebug.TabIndex = 6;
            this.fallSpeedDebug.Tag = "debugTxt";
            this.fallSpeedDebug.Text = "FallSpeedTester: Not on";
            this.fallSpeedDebug.Click += new System.EventHandler(this.label1_Click);
            // 
            // hoverDebug
            // 
            this.hoverDebug.AutoSize = true;
            this.hoverDebug.BackColor = System.Drawing.Color.Transparent;
            this.hoverDebug.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hoverDebug.Location = new System.Drawing.Point(342, 53);
            this.hoverDebug.Name = "hoverDebug";
            this.hoverDebug.Size = new System.Drawing.Size(74, 20);
            this.hoverDebug.TabIndex = 7;
            this.hoverDebug.Tag = "debugTxt";
            this.hoverDebug.Text = "Hover: ---";
            // 
            // forceDebug
            // 
            this.forceDebug.AutoSize = true;
            this.forceDebug.BackColor = System.Drawing.Color.Transparent;
            this.forceDebug.ForeColor = System.Drawing.SystemColors.ControlText;
            this.forceDebug.Location = new System.Drawing.Point(343, 73);
            this.forceDebug.Name = "forceDebug";
            this.forceDebug.Size = new System.Drawing.Size(73, 20);
            this.forceDebug.TabIndex = 8;
            this.forceDebug.Tag = "debugTxt";
            this.forceDebug.Text = "Force: ---";
            this.forceDebug.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // OnGround
            // 
            this.OnGround.AutoSize = true;
            this.OnGround.BackColor = System.Drawing.Color.Transparent;
            this.OnGround.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OnGround.Location = new System.Drawing.Point(343, 93);
            this.OnGround.Name = "OnGround";
            this.OnGround.Size = new System.Drawing.Size(107, 20);
            this.OnGround.TabIndex = 9;
            this.OnGround.Tag = "debugTxt";
            this.OnGround.Text = "OnGround: ---";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SeaGreen;
            this.pictureBox1.Location = new System.Drawing.Point(-15, 403);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(884, 56);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // robotBear
            // 
            this.robotBear.BackColor = System.Drawing.Color.Transparent;
            this.robotBear.Image = global::FixCharacterRunningGame.Properties.Resources.Running;
            this.robotBear.Location = new System.Drawing.Point(72, 368);
            this.robotBear.Name = "robotBear";
            this.robotBear.Size = new System.Drawing.Size(40, 43);
            this.robotBear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.robotBear.TabIndex = 1;
            this.robotBear.TabStop = false;
            // 
            // robotCoordinatesDebug
            // 
            this.robotCoordinatesDebug.AutoSize = true;
            this.robotCoordinatesDebug.BackColor = System.Drawing.Color.Transparent;
            this.robotCoordinatesDebug.ForeColor = System.Drawing.SystemColors.ControlText;
            this.robotCoordinatesDebug.Location = new System.Drawing.Point(529, 9);
            this.robotCoordinatesDebug.Name = "robotCoordinatesDebug";
            this.robotCoordinatesDebug.Size = new System.Drawing.Size(146, 20);
            this.robotCoordinatesDebug.TabIndex = 11;
            this.robotCoordinatesDebug.Tag = "debugTxt";
            this.robotCoordinatesDebug.Text = "Old Coordinates: ---";
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
            // BearLocation
            // 
            this.BearLocation.AutoSize = true;
            this.BearLocation.BackColor = System.Drawing.Color.Transparent;
            this.BearLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BearLocation.Location = new System.Drawing.Point(343, 113);
            this.BearLocation.Name = "BearLocation";
            this.BearLocation.Size = new System.Drawing.Size(131, 20);
            this.BearLocation.TabIndex = 15;
            this.BearLocation.Tag = "debugTxt";
            this.BearLocation.Text = "Bear Location: ---";
            // 
            // NewBearStatusJump
            // 
            this.NewBearStatusJump.AutoSize = true;
            this.NewBearStatusJump.BackColor = System.Drawing.Color.Transparent;
            this.NewBearStatusJump.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NewBearStatusJump.Location = new System.Drawing.Point(475, 181);
            this.NewBearStatusJump.Name = "NewBearStatusJump";
            this.NewBearStatusJump.Size = new System.Drawing.Size(162, 20);
            this.NewBearStatusJump.TabIndex = 16;
            this.NewBearStatusJump.Tag = "debugTxt";
            this.NewBearStatusJump.Text = "NewBear Location: ---";
            // 
            // PlayerTimer
            // 
            this.PlayerTimer.Enabled = true;
            this.PlayerTimer.Interval = 1;
            this.PlayerTimer.Tick += new System.EventHandler(this.PlayerTimer_Tick);
            // 
            // OldBearJumpStatus
            // 
            this.OldBearJumpStatus.AutoSize = true;
            this.OldBearJumpStatus.BackColor = System.Drawing.Color.Transparent;
            this.OldBearJumpStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OldBearJumpStatus.Location = new System.Drawing.Point(343, 133);
            this.OldBearJumpStatus.Name = "OldBearJumpStatus";
            this.OldBearJumpStatus.Size = new System.Drawing.Size(138, 20);
            this.OldBearJumpStatus.TabIndex = 17;
            this.OldBearJumpStatus.Tag = "debugTxt";
            this.OldBearJumpStatus.Text = "Bear Jump Set: ---";
            // 
            // Sky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OldBearJumpStatus);
            this.Controls.Add(this.NewBearStatusJump);
            this.Controls.Add(this.BearLocation);
            this.Controls.Add(this.HighScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.MovementDebug);
            this.Controls.Add(this.TestObstacleSpawner);
            this.Controls.Add(this.robotCoordinatesDebug);
            this.Controls.Add(this.OnGround);
            this.Controls.Add(this.forceDebug);
            this.Controls.Add(this.hoverDebug);
            this.Controls.Add(this.fallSpeedDebug);
            this.Controls.Add(this.debugHover);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.robotBear);
            this.Name = "Sky";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.robotBear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox robotBear;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label debugHover;
        private System.Windows.Forms.Label fallSpeedDebug;
        private System.Windows.Forms.Label hoverDebug;
        private System.Windows.Forms.Label forceDebug;
        private System.Windows.Forms.Label OnGround;
        private System.Windows.Forms.Label robotCoordinatesDebug;
        private System.Windows.Forms.Label TestObstacleSpawner;
        private System.Windows.Forms.Label MovementDebug;
        private System.Windows.Forms.Label HighScore;
        private System.Windows.Forms.Label BearLocation;
        private System.Windows.Forms.Label NewBearStatusJump;
        private System.Windows.Forms.Timer PlayerTimer;
        private System.Windows.Forms.Label OldBearJumpStatus;
    }
}


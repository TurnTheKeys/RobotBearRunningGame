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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.robotBear = new System.Windows.Forms.PictureBox();
            this.PurpleHand = new System.Windows.Forms.PictureBox();
            this.Umbrella = new System.Windows.Forms.PictureBox();
            this.txtScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.robotBear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurpleHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Umbrella)).BeginInit();
            this.SuspendLayout();
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
            // PurpleHand
            // 
            this.PurpleHand.BackColor = System.Drawing.Color.Transparent;
            this.PurpleHand.Image = global::FixCharacterRunningGame.Properties.Resources.obstacle_1;
            this.PurpleHand.Location = new System.Drawing.Point(428, 357);
            this.PurpleHand.Name = "PurpleHand";
            this.PurpleHand.Size = new System.Drawing.Size(23, 46);
            this.PurpleHand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PurpleHand.TabIndex = 2;
            this.PurpleHand.TabStop = false;
            this.PurpleHand.Tag = "Obstacles";
            // 
            // Umbrella
            // 
            this.Umbrella.BackColor = System.Drawing.Color.Transparent;
            this.Umbrella.Image = global::FixCharacterRunningGame.Properties.Resources.obstacle_2;
            this.Umbrella.Location = new System.Drawing.Point(564, 357);
            this.Umbrella.Name = "Umbrella";
            this.Umbrella.Size = new System.Drawing.Size(32, 33);
            this.Umbrella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Umbrella.TabIndex = 3;
            this.Umbrella.TabStop = false;
            this.Umbrella.Tag = "Obstacles";
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Nirmala UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.Location = new System.Drawing.Point(12, 24);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(121, 38);
            this.txtScore.TabIndex = 4;
            this.txtScore.Text = "Score: 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.MainGameTimerEvent);
            // 
            // Sky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.Umbrella);
            this.Controls.Add(this.PurpleHand);
            this.Controls.Add(this.robotBear);
            this.Name = "Sky";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.robotBear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurpleHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Umbrella)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox robotBear;
        private System.Windows.Forms.PictureBox PurpleHand;
        private System.Windows.Forms.PictureBox Umbrella;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Timer gameTimer;
    }
}


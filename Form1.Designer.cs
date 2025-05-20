namespace PingPongGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelGame = new Panel();
            aiPaddle = new PictureBox();
            picBall = new PictureBox();
            playerPaddle = new PictureBox();
            labelScore = new Label();
            timer = new System.Windows.Forms.Timer(components);
            timerColor = new System.Windows.Forms.Timer(components);
            panelGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)aiPaddle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBall).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playerPaddle).BeginInit();
            SuspendLayout();
            // 
            // panelGame
            // 
            panelGame.Controls.Add(aiPaddle);
            panelGame.Controls.Add(picBall);
            panelGame.Controls.Add(playerPaddle);
            panelGame.Location = new Point(29, 23);
            panelGame.Name = "panelGame";
            panelGame.Size = new Size(1467, 668);
            panelGame.TabIndex = 0;
            // 
            // aiPaddle
            // 
            aiPaddle.BackColor = Color.Cyan;
            aiPaddle.Location = new Point(1435, 281);
            aiPaddle.Name = "aiPaddle";
            aiPaddle.Size = new Size(20, 60);
            aiPaddle.TabIndex = 2;
            aiPaddle.TabStop = false;
            // 
            // picBall
            // 
            picBall.BackColor = Color.Red;
            picBall.Location = new Point(716, 304);
            picBall.Name = "picBall";
            picBall.Size = new Size(15, 15);
            picBall.TabIndex = 1;
            picBall.TabStop = false;
            // 
            // playerPaddle
            // 
            playerPaddle.BackColor = Color.Green;
            playerPaddle.Location = new Point(12, 266);
            playerPaddle.Name = "playerPaddle";
            playerPaddle.Size = new Size(20, 60);
            playerPaddle.TabIndex = 0;
            playerPaddle.TabStop = false;
            // 
            // labelScore
            // 
            labelScore.Font = new Font("Elephant", 26F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelScore.ForeColor = Color.White;
            labelScore.Location = new Point(29, 694);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(1467, 87);
            labelScore.TabIndex = 1;
            labelScore.Text = "0 : 0";
            labelScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 20;
            timer.Tick += timer_Tick;
            // 
            // timerColor
            // 
            timerColor.Tick += timerColor_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1522, 790);
            Controls.Add(labelScore);
            Controls.Add(panelGame);
            Name = "Form1";
            Text = "PingPong";
            KeyDown += Form1_KeyDown;
            panelGame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)aiPaddle).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBall).EndInit();
            ((System.ComponentModel.ISupportInitialize)playerPaddle).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelGame;
        private PictureBox playerPaddle;
        private PictureBox aiPaddle;
        private PictureBox picBall;
        private Label labelScore;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timerColor;
    }
}

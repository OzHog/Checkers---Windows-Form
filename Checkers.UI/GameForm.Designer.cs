namespace C20_Ex05_Oz_203596275
{
    partial class GameForm
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
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.timerComputerPlay = new System.Windows.Forms.Timer(this.components);
            this.timerCheckerMenAnimation = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxCheckerMen = new System.Windows.Forms.PictureBox();
            this.pictureBoxToSlotAnimation = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCheckerMen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToSlotAnimation)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1.Location = new System.Drawing.Point(128, 31);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(60, 16);
            this.labelPlayer1.TabIndex = 0;
            this.labelPlayer1.Text = "Player 1";
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer2.Location = new System.Drawing.Point(426, 31);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(60, 16);
            this.labelPlayer2.TabIndex = 1;
            this.labelPlayer2.Text = "Player 2";
            // 
            // timerComputerPlay
            // 
            this.timerComputerPlay.Interval = 1000;
            this.timerComputerPlay.Tick += new System.EventHandler(this.timerComputerPlay_Tick);
            // 
            // timerCheckerMenAnimation
            // 
            this.timerCheckerMenAnimation.Interval = 200;
            // 
            // pictureBoxCheckerMen
            // 
            this.pictureBoxCheckerMen.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCheckerMen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxCheckerMen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCheckerMen.Location = new System.Drawing.Point(248, 12);
            this.pictureBoxCheckerMen.Name = "pictureBoxCheckerMen";
            this.pictureBoxCheckerMen.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxCheckerMen.TabIndex = 2;
            this.pictureBoxCheckerMen.TabStop = false;
            this.pictureBoxCheckerMen.Visible = false;
            // 
            // pictureBoxToSlotAnimation
            // 
            this.pictureBoxToSlotAnimation.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxToSlotAnimation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxToSlotAnimation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxToSlotAnimation.Location = new System.Drawing.Point(314, 12);
            this.pictureBoxToSlotAnimation.Name = "pictureBoxToSlotAnimation";
            this.pictureBoxToSlotAnimation.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxToSlotAnimation.TabIndex = 3;
            this.pictureBoxToSlotAnimation.TabStop = false;
            this.pictureBoxToSlotAnimation.Visible = false;
            // 
            // GameForm
            // 
            this.ClientSize = new System.Drawing.Size(596, 542);
            this.Controls.Add(this.pictureBoxToSlotAnimation);
            this.Controls.Add(this.pictureBoxCheckerMen);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Damka";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCheckerMen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToSlotAnimation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Timer timerComputerPlay;
        private System.Windows.Forms.Timer timerCheckerMenAnimation;
        private System.Windows.Forms.PictureBox pictureBoxCheckerMen;
        private System.Windows.Forms.PictureBox pictureBoxToSlotAnimation;
    }
}
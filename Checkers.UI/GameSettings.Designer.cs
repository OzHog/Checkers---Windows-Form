namespace C20_Ex05_Oz_203596275
{
    partial class GameSettings
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
            this.buttonDone = new System.Windows.Forms.Button();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.checkBoxPlayer2Human = new System.Windows.Forms.CheckBox();
            this.textBoxPlayerName1 = new C20_Ex05_Oz_203596275.TextBoxPlayerName();
            this.textBoxPlayerName2 = new C20_Ex05_Oz_203596275.TextBoxPlayerName();
            this.radioButtonBoardSize6 = new C20_Ex05_Oz_203596275.RadioButtonBoardSize();
            this.radioButtonBoardSize8 = new C20_Ex05_Oz_203596275.RadioButtonBoardSize();
            this.radioButtonBoardSize10 = new C20_Ex05_Oz_203596275.RadioButtonBoardSize();
            this.SuspendLayout();
            // 
            // buttonDone
            // 
            this.buttonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDone.Location = new System.Drawing.Point(118, 125);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(75, 23);
            this.buttonDone.TabIndex = 0;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(12, 9);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(61, 13);
            this.labelBoardSize.TabIndex = 1;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(12, 56);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(44, 13);
            this.labelPlayers.TabIndex = 2;
            this.labelPlayers.Text = "Players:";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(22, 75);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(48, 13);
            this.labelPlayer1.TabIndex = 3;
            this.labelPlayer1.Text = "Player 1:";
            // 
            // checkBoxPlayer2Human
            // 
            this.checkBoxPlayer2Human.AutoSize = true;
            this.checkBoxPlayer2Human.Location = new System.Drawing.Point(25, 100);
            this.checkBoxPlayer2Human.Name = "checkBoxPlayer2Human";
            this.checkBoxPlayer2Human.Size = new System.Drawing.Size(67, 17);
            this.checkBoxPlayer2Human.TabIndex = 8;
            this.checkBoxPlayer2Human.Text = "Player 2:";
            this.checkBoxPlayer2Human.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2Human.CheckStateChanged += new System.EventHandler(this.checkBoxPlayer2Human_CheckedStateChanged);
            // 
            // textBoxPlayerName1
            // 
            this.textBoxPlayerName1.DefaultNameWhenEnable = "Player 1";
            this.textBoxPlayerName1.DefaultNameWhenUnEnable = "Player 1";
            this.textBoxPlayerName1.Location = new System.Drawing.Point(97, 72);
            this.textBoxPlayerName1.Name = "textBoxPlayerName1";
            this.textBoxPlayerName1.Size = new System.Drawing.Size(96, 20);
            this.textBoxPlayerName1.TabIndex = 9;
            // 
            // textBoxPlayerName2
            // 
            this.textBoxPlayerName2.DefaultNameWhenEnable = "Player 2";
            this.textBoxPlayerName2.DefaultNameWhenUnEnable = "Computer";
            this.textBoxPlayerName2.Enabled = false;
            this.textBoxPlayerName2.Location = new System.Drawing.Point(97, 98);
            this.textBoxPlayerName2.Name = "textBoxPlayerName2";
            this.textBoxPlayerName2.Size = new System.Drawing.Size(96, 20);
            this.textBoxPlayerName2.TabIndex = 10;
            this.textBoxPlayerName2.Text = "[Computer]";
            // 
            // radioButtonBoardSize6
            // 
            this.radioButtonBoardSize6.AutoSize = true;
            this.radioButtonBoardSize6.Location = new System.Drawing.Point(25, 25);
            this.radioButtonBoardSize6.Name = "radioButtonBoardSize6";
            this.radioButtonBoardSize6.Size = new System.Drawing.Size(48, 17);
            this.radioButtonBoardSize6.TabIndex = 11;
            this.radioButtonBoardSize6.TabStop = true;
            this.radioButtonBoardSize6.Text = "6 x 6";
            this.radioButtonBoardSize6.UseVisualStyleBackColor = true;
            this.radioButtonBoardSize6.Value = 6;
            this.radioButtonBoardSize6.CheckedChanged += new System.EventHandler(this.radioButtonBoardSize_CheckedChanged);
            // 
            // radioButtonBoardSize8
            // 
            this.radioButtonBoardSize8.AutoSize = true;
            this.radioButtonBoardSize8.Location = new System.Drawing.Point(79, 25);
            this.radioButtonBoardSize8.Name = "radioButtonBoardSize8";
            this.radioButtonBoardSize8.Size = new System.Drawing.Size(48, 17);
            this.radioButtonBoardSize8.TabIndex = 12;
            this.radioButtonBoardSize8.TabStop = true;
            this.radioButtonBoardSize8.Text = "8 x 8";
            this.radioButtonBoardSize8.UseVisualStyleBackColor = true;
            this.radioButtonBoardSize8.Value = 8;
            this.radioButtonBoardSize8.CheckedChanged += new System.EventHandler(this.radioButtonBoardSize_CheckedChanged);
            // 
            // radioButtonBoardSize10
            // 
            this.radioButtonBoardSize10.AutoSize = true;
            this.radioButtonBoardSize10.Location = new System.Drawing.Point(133, 25);
            this.radioButtonBoardSize10.Name = "radioButtonBoardSize10";
            this.radioButtonBoardSize10.Size = new System.Drawing.Size(60, 17);
            this.radioButtonBoardSize10.TabIndex = 13;
            this.radioButtonBoardSize10.TabStop = true;
            this.radioButtonBoardSize10.Text = "10 x 10";
            this.radioButtonBoardSize10.UseVisualStyleBackColor = true;
            this.radioButtonBoardSize10.Value = 10;
            this.radioButtonBoardSize10.CheckedChanged += new System.EventHandler(this.radioButtonBoardSize_CheckedChanged);
            // 
            // GameSettings
            // 
            this.AcceptButton = this.buttonDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 160);
            this.Controls.Add(this.radioButtonBoardSize10);
            this.Controls.Add(this.radioButtonBoardSize8);
            this.Controls.Add(this.radioButtonBoardSize6);
            this.Controls.Add(this.textBoxPlayerName2);
            this.Controls.Add(this.textBoxPlayerName1);
            this.Controls.Add(this.checkBoxPlayer2Human);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.buttonDone);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settigs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.CheckBox checkBoxPlayer2Human;
        private TextBoxPlayerName textBoxPlayerName1;
        private TextBoxPlayerName textBoxPlayerName2;
        private RadioButtonBoardSize radioButtonBoardSize6;
        private RadioButtonBoardSize radioButtonBoardSize8;
        private RadioButtonBoardSize radioButtonBoardSize10;
    }
}


namespace WordSearchGame
{
    partial class GameBoard
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_wordList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_startGame = new System.Windows.Forms.Button();
            this.comboBox_gridSize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_seeWinningLocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(937, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ordsøgning";
            // 
            // textBox_wordList
            // 
            this.textBox_wordList.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_wordList.Location = new System.Drawing.Point(837, 104);
            this.textBox_wordList.Multiline = true;
            this.textBox_wordList.Name = "textBox_wordList";
            this.textBox_wordList.Size = new System.Drawing.Size(352, 138);
            this.textBox_wordList.TabIndex = 1;
            this.textBox_wordList.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_wordList_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(837, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ordliste";
            // 
            // button_startGame
            // 
            this.button_startGame.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_startGame.Location = new System.Drawing.Point(837, 292);
            this.button_startGame.Name = "button_startGame";
            this.button_startGame.Size = new System.Drawing.Size(118, 42);
            this.button_startGame.TabIndex = 3;
            this.button_startGame.Text = "Start spil";
            this.button_startGame.UseVisualStyleBackColor = true;
            this.button_startGame.Click += new System.EventHandler(this.Button_startGame_Click);
            // 
            // comboBox_gridSize
            // 
            this.comboBox_gridSize.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox_gridSize.FormattingEnabled = true;
            this.comboBox_gridSize.Location = new System.Drawing.Point(837, 263);
            this.comboBox_gridSize.Name = "comboBox_gridSize";
            this.comboBox_gridSize.Size = new System.Drawing.Size(121, 22);
            this.comboBox_gridSize.TabIndex = 4;
            this.comboBox_gridSize.Validating += new System.ComponentModel.CancelEventHandler(this.ComboBox_gridSize_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(837, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Grid størrelse";
            // 
            // button_seeWinningLocation
            // 
            this.button_seeWinningLocation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_seeWinningLocation.Location = new System.Drawing.Point(967, 292);
            this.button_seeWinningLocation.Name = "button_seeWinningLocation";
            this.button_seeWinningLocation.Size = new System.Drawing.Size(118, 42);
            this.button_seeWinningLocation.TabIndex = 6;
            this.button_seeWinningLocation.Text = "Snyd";
            this.button_seeWinningLocation.UseVisualStyleBackColor = true;
            this.button_seeWinningLocation.Click += new System.EventHandler(this.Button_seeWinningLocation_Click);
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 774);
            this.Controls.Add(this.button_seeWinningLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_gridSize);
            this.Controls.Add(this.button_startGame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_wordList);
            this.Controls.Add(this.label1);
            this.Name = "GameBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBox_wordList;
        private Label label2;
        private Button button_startGame;
        private ComboBox comboBox_gridSize;
        private Label label3;
        private Button button_seeWinningLocation;
    }
}
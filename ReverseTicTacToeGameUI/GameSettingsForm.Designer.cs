namespace ReverseTicTacToeGameUI
{
    public partial class GameSettingsForm
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
            this.m_LabelPlayers = new System.Windows.Forms.Label();
            this.m_LabelPlayer1 = new System.Windows.Forms.Label();
            this.m_CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.m_LabelBoardSize = new System.Windows.Forms.Label();
            this.m_LabelRows = new System.Windows.Forms.Label();
            this.m_RowNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_ColNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_LabelCols = new System.Windows.Forms.Label();
            this.m_TextBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.m_TextBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.m_StartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_RowNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ColNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // m_LabelPlayers
            // 
            this.m_LabelPlayers.AutoSize = true;
            this.m_LabelPlayers.Location = new System.Drawing.Point(27, 26);
            this.m_LabelPlayers.Name = "m_LabelPlayers";
            this.m_LabelPlayers.Size = new System.Drawing.Size(64, 20);
            this.m_LabelPlayers.TabIndex = 0;
            this.m_LabelPlayers.Text = "Players:";
            // 
            // m_LabelPlayer1
            // 
            this.m_LabelPlayer1.AutoSize = true;
            this.m_LabelPlayer1.Location = new System.Drawing.Point(45, 68);
            this.m_LabelPlayer1.Name = "m_LabelPlayer1";
            this.m_LabelPlayer1.Size = new System.Drawing.Size(69, 20);
            this.m_LabelPlayer1.TabIndex = 1;
            this.m_LabelPlayer1.Text = "Player 1:";
            // 
            // m_CheckBoxPlayer2
            // 
            this.m_CheckBoxPlayer2.AutoSize = true;
            this.m_CheckBoxPlayer2.Location = new System.Drawing.Point(47, 99);
            this.m_CheckBoxPlayer2.Name = "m_CheckBoxPlayer2";
            this.m_CheckBoxPlayer2.Size = new System.Drawing.Size(95, 24);
            this.m_CheckBoxPlayer2.TabIndex = 2;
            this.m_CheckBoxPlayer2.Text = "Player 2:";
            this.m_CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.m_CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.m_CheckBoxPlayer2_CheckedChanged);
            // 
            // m_LabelBoardSize
            // 
            this.m_LabelBoardSize.AutoSize = true;
            this.m_LabelBoardSize.Location = new System.Drawing.Point(27, 145);
            this.m_LabelBoardSize.Name = "m_LabelBoardSize";
            this.m_LabelBoardSize.Size = new System.Drawing.Size(91, 20);
            this.m_LabelBoardSize.TabIndex = 3;
            this.m_LabelBoardSize.Text = "Board Size:";
            // 
            // m_LabelRows
            // 
            this.m_LabelRows.AutoSize = true;
            this.m_LabelRows.Location = new System.Drawing.Point(45, 175);
            this.m_LabelRows.Name = "m_LabelRows";
            this.m_LabelRows.Size = new System.Drawing.Size(53, 20);
            this.m_LabelRows.TabIndex = 4;
            this.m_LabelRows.Text = "Rows:";
            // 
            // m_RowNumericUpDown
            // 
            this.m_RowNumericUpDown.Location = new System.Drawing.Point(102, 173);
            this.m_RowNumericUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.m_RowNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_RowNumericUpDown.Name = "m_RowNumericUpDown";
            this.m_RowNumericUpDown.Size = new System.Drawing.Size(54, 26);
            this.m_RowNumericUpDown.TabIndex = 5;
            this.m_RowNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_RowNumericUpDown.ValueChanged += new System.EventHandler(this.m_RowNumericUpDown_ValueChanged);
            // 
            // m_ColNumericUpDown
            // 
            this.m_ColNumericUpDown.Location = new System.Drawing.Point(226, 173);
            this.m_ColNumericUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.m_ColNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_ColNumericUpDown.Name = "m_ColNumericUpDown";
            this.m_ColNumericUpDown.Size = new System.Drawing.Size(54, 26);
            this.m_ColNumericUpDown.TabIndex = 7;
            this.m_ColNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_ColNumericUpDown.ValueChanged += new System.EventHandler(this.m_ColNumericUpDown_ValueChanged);
            // 
            // m_LabelCols
            // 
            this.m_LabelCols.AutoSize = true;
            this.m_LabelCols.Location = new System.Drawing.Point(176, 175);
            this.m_LabelCols.Name = "m_LabelCols";
            this.m_LabelCols.Size = new System.Drawing.Size(44, 20);
            this.m_LabelCols.TabIndex = 6;
            this.m_LabelCols.Text = "Cols:";
            // 
            // m_TextBoxPlayer1
            // 
            this.m_TextBoxPlayer1.Location = new System.Drawing.Point(148, 65);
            this.m_TextBoxPlayer1.MaxLength = 20;
            this.m_TextBoxPlayer1.Name = "m_TextBoxPlayer1";
            this.m_TextBoxPlayer1.Size = new System.Drawing.Size(132, 26);
            this.m_TextBoxPlayer1.TabIndex = 8;
            // 
            // m_TextBoxPlayer2
            // 
            this.m_TextBoxPlayer2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.m_TextBoxPlayer2.Enabled = false;
            this.m_TextBoxPlayer2.ForeColor = System.Drawing.Color.DimGray;
            this.m_TextBoxPlayer2.Location = new System.Drawing.Point(148, 97);
            this.m_TextBoxPlayer2.MaxLength = 20;
            this.m_TextBoxPlayer2.Name = "m_TextBoxPlayer2";
            this.m_TextBoxPlayer2.Size = new System.Drawing.Size(132, 26);
            this.m_TextBoxPlayer2.TabIndex = 9;
            this.m_TextBoxPlayer2.Text = "[Computer]";
            // 
            // m_StartButton
            // 
            this.m_StartButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_StartButton.Location = new System.Drawing.Point(31, 226);
            this.m_StartButton.Name = "m_StartButton";
            this.m_StartButton.Size = new System.Drawing.Size(249, 30);
            this.m_StartButton.TabIndex = 10;
            this.m_StartButton.Text = "Start!";
            this.m_StartButton.UseVisualStyleBackColor = true;
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 279);
            this.Controls.Add(this.m_StartButton);
            this.Controls.Add(this.m_TextBoxPlayer2);
            this.Controls.Add(this.m_TextBoxPlayer1);
            this.Controls.Add(this.m_ColNumericUpDown);
            this.Controls.Add(this.m_LabelCols);
            this.Controls.Add(this.m_RowNumericUpDown);
            this.Controls.Add(this.m_LabelRows);
            this.Controls.Add(this.m_LabelBoardSize);
            this.Controls.Add(this.m_CheckBoxPlayer2);
            this.Controls.Add(this.m_LabelPlayer1);
            this.Controls.Add(this.m_LabelPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.m_RowNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ColNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_LabelPlayers;
        private System.Windows.Forms.Label m_LabelPlayer1;
        private System.Windows.Forms.CheckBox m_CheckBoxPlayer2;
        private System.Windows.Forms.Label m_LabelBoardSize;
        private System.Windows.Forms.Label m_LabelRows;
        private System.Windows.Forms.NumericUpDown m_RowNumericUpDown;
        private System.Windows.Forms.NumericUpDown m_ColNumericUpDown;
        private System.Windows.Forms.Label m_LabelCols;
        private System.Windows.Forms.TextBox m_TextBoxPlayer1;
        private System.Windows.Forms.TextBox m_TextBoxPlayer2;
        private System.Windows.Forms.Button m_StartButton;
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReverseTicTacToeGameUI
{
    public partial class GameSettingsForm : Form
    {
        private const string k_DefaultTextBoxPlayer2Disable = "[Computer]";
        public GameSettingsForm()
        {
            InitializeComponent();
        }

        public string Player1Name
        {
            get
            {
                return m_TextBoxPlayer1.Text;
            }
        }

        public string Player2Name
        {
            get
            {
                string player2Name = m_TextBoxPlayer2.Text;

                if(Equals(m_TextBoxPlayer2.Text, "[Computer]"))
                {
                    player2Name = m_TextBoxPlayer2.Text.Trim(new char[] { '[', ']' });
                }

                return player2Name;
            }
        }

        public string NumberOfRows
        {
            get
            {
                return m_RowNumericUpDown.Text;
            }
        }

        public string NumberOfCols
        {
            get
            {
                return m_ColNumericUpDown.Text;
            }
        }

        public bool IsOpponentHuman
        {
            get
            {
                return m_CheckBoxPlayer2.Checked;
            }
        }

        // $G$ CSS-013 (-5) Bad input variable name (should be in the form of i_PascalCased)
        // $G$ CSS-011 (-3) Bad private method name. Should be pascalCased.
        private void m_CheckBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if((sender as CheckBox).Checked)
            {
                m_TextBoxPlayer2.ResetText();
                m_TextBoxPlayer2.ForeColor = Color.Black;
                m_TextBoxPlayer2.BackColor = Color.White;
            }
            else
            {
                m_TextBoxPlayer2.Text = k_DefaultTextBoxPlayer2Disable;
                m_TextBoxPlayer2.ForeColor = Color.DimGray;
                m_TextBoxPlayer2.BackColor = Color.LightGray;
            }

            m_TextBoxPlayer2.Enabled = !m_TextBoxPlayer2.Enabled;
        }

        private void m_RowNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            m_ColNumericUpDown.Value = (sender as NumericUpDown).Value;
        }

        private void m_ColNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            m_RowNumericUpDown.Value = (sender as NumericUpDown).Value;
        }
    }
}
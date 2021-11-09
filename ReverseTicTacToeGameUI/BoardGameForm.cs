using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ReverseTicTacToeGameLogic;

namespace ReverseTicTacToeGameUI
{
    public class BoardGameForm : Form
    {
        private const int k_ButtonWidth = 50;
        private const int k_SpaceWidthBetweenButton = 10;
        private const bool k_Player1Computer = true;
        private const string k_TieTitleBanner = "A Tie!";
        private const string k_WinTitleBanner = "A Win!";
        private const string k_TieMsgBanner = @"Tie!
Would you like to play another round?";
        private const string k_WinMsgBanner = @"The winner is {0}!
Would you like to play another round?";
        private const string k_FormTitle = "TicTacToeMisere";
        private const string k_InitScore = "0";
        private const string k_DefaultPlayer1Name = "Player 1";
        private const string k_DefaultPlayer2Name = "Player 2";
        private readonly GameState r_GameState;
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private readonly BoardGame r_BoardGame;
        private readonly BoardButton[,] r_BoardButtons;
        private readonly BoardLabel r_LabelPlayer1;
        private readonly BoardLabel r_LabelPlayer2;
        private readonly BoardLabel r_LabelPlayer1Score;
        private readonly BoardLabel r_LabelPlayer2Score;

        public BoardGameForm(
            int i_RowNumber,
            int i_ColNumber,
            string i_NamePlayer1,
            string i_NamePlayer2,
            bool i_IsPlayer2Human)
        {
            string player1Name = string.IsNullOrEmpty(i_NamePlayer1) ? k_DefaultPlayer1Name : i_NamePlayer1;
            string player2Name = string.IsNullOrEmpty(i_NamePlayer2) ? k_DefaultPlayer2Name : i_NamePlayer2;

            r_Player1 = new Player(player1Name, Cell.eCellSign.Player1, !k_Player1Computer);
            r_Player2 = new Player(player2Name, Cell.eCellSign.Player2, !i_IsPlayer2Human);
            r_GameState = new GameState(r_Player1, r_Player2);
            r_BoardGame = new BoardGame(i_RowNumber, i_ColNumber);
            r_GameState.WinnerUpdated += r_GameState_WinnerUpdated;
            r_GameState.GameEndedWithATie += r_GameState_GameEndedWithATie;
            this.Text = k_FormTitle;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(
                k_ButtonWidth * (i_RowNumber) + (i_RowNumber + 1) * k_SpaceWidthBetweenButton,
                k_ButtonWidth * (i_ColNumber + 1) + (i_ColNumber + 1) * k_SpaceWidthBetweenButton);
            r_BoardButtons = new BoardButton[i_RowNumber, i_ColNumber];
            StringBuilder buttonName = new StringBuilder();

            for(int i = 0; i < i_RowNumber; i++)
            {
                for(int j = 0; j < i_ColNumber; j++)
                {
                    Cell currentCellOnBoard = r_BoardGame.Board[i, j];
                    BoardButton currentButtonOnBoardPosIJ = new BoardButton(i, j, currentCellOnBoard);

                    currentButtonOnBoardPosIJ.Size = new Size(k_ButtonWidth, k_ButtonWidth);
                    currentButtonOnBoardPosIJ.Location = new Point(
                        this.Top + j * k_ButtonWidth + (j + 1) * k_SpaceWidthBetweenButton,
                        this.Top + i * k_ButtonWidth + (i + 1) * k_SpaceWidthBetweenButton);
                    buttonName.AppendFormat("Button{0},{1}", i, j);
                    currentButtonOnBoardPosIJ.Name = buttonName.ToString();
                    currentButtonOnBoardPosIJ.Click += boardButton_Click;
                    r_BoardButtons[i, j] = currentButtonOnBoardPosIJ;
                    this.Controls.Add(currentButtonOnBoardPosIJ);
                    buttonName.Clear();
                }
            }

            bool isFontBold = true;

            r_LabelPlayer1 = new BoardLabel(r_GameState, isFontBold);
            r_LabelPlayer1Score = new BoardLabel(r_GameState, isFontBold);
            r_LabelPlayer2 = new BoardLabel(r_GameState, !isFontBold);
            r_LabelPlayer2Score = new BoardLabel(r_GameState, !isFontBold);
            updateLabelSettings(r_LabelPlayer1, r_Player1.Name + ":");
            updateLabelSettings(r_LabelPlayer1Score, k_InitScore);
            updateLabelSettings(r_LabelPlayer2, r_Player2.Name + ":");
            updateLabelSettings(r_LabelPlayer2Score, k_InitScore);
            int labelsWidth = r_LabelPlayer1.PreferredWidth + r_LabelPlayer1Score.PreferredWidth
                                                            + r_LabelPlayer2.PreferredWidth
                                                            + r_LabelPlayer2Score.PreferredWidth + 15;
            int labelTopPosition =
                this.Top + k_ButtonWidth * (i_ColNumber) + (i_ColNumber + 1) * k_SpaceWidthBetweenButton;

            r_LabelPlayer1.Location = new Point(this.ClientSize.Width / 2 - labelsWidth / 2, labelTopPosition);
            r_LabelPlayer1Score.Location = new Point(r_LabelPlayer1.Right, labelTopPosition);
            r_LabelPlayer2.Location = new Point(r_LabelPlayer1Score.Right + 15, labelTopPosition);
            r_LabelPlayer2Score.Location = new Point(r_LabelPlayer2.Right, labelTopPosition);
        }
        // $G$ CSS-013 (-5) Bad input variable name (should be in the form of i_PascalCased)
        private void updateLabelSettings(BoardLabel io_BoardLabel, string i_LabelNameText)
        {
            io_BoardLabel.Text = i_LabelNameText;
            io_BoardLabel.AutoSize = true;
            this.Controls.Add(io_BoardLabel);
        }

        private void r_GameState_GameEndedWithATie()
        {
            endGameShowBannerAndResetGameIfAnotherRound(k_TieMsgBanner, k_TieTitleBanner);
        }

        private void r_GameState_WinnerUpdated()
        {
            StringBuilder endRoundMsg = new StringBuilder();

            endRoundMsg.AppendFormat(k_WinMsgBanner, r_GameState.Winner.Name);
            endGameShowBannerAndResetGameIfAnotherRound(endRoundMsg.ToString(), k_WinTitleBanner);
        }

        private void boardButton_Click(object sender, EventArgs e)
        {
            BoardButton button = sender as BoardButton;
            int buttonRow = button.PositionOnBoard.Y;
            int buttonCol = button.PositionOnBoard.X;

            r_GameState.MakeMoveAndCheckGameStatus(buttonRow, buttonCol, r_BoardGame);
        }

        private void endGameShowBannerAndResetGameIfAnotherRound(string i_MsgBoxText, string i_MsgBoxTitle)
        {
            if (MessageBox.Show(i_MsgBoxText, i_MsgBoxTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(string.Equals(i_MsgBoxTitle, k_WinTitleBanner))
                {
                    updateScoreLabelOfWinner();
                }

                r_GameState.ResetGameStateForAnotherRound(r_BoardGame);
            }
            else
            {
                this.Close();
            }
        }

        private void updateScoreLabelOfWinner()
        {
            string newScore = r_GameState.Winner.Score.ToString();

            if (r_GameState.Winner == r_Player1)
            {
                r_LabelPlayer1Score.Text = newScore;
            }
            else
            {
                r_LabelPlayer2Score.Text = newScore;
            }
        }

        private void initializeComponent()
        {
            this.SuspendLayout();
            // 
            // BoardGameForm
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "BoardGameForm";
            this.ResumeLayout(false);
        }
    }
}

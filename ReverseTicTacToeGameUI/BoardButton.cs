using System;
using System.Drawing;
using System.Windows.Forms;
using ReverseTicTacToeGameLogic;

namespace ReverseTicTacToeGameUI
{
    public class BoardButton : Button
    {
        private const string k_DefaultPlayer1Sign = "X";
        private const string k_DefaultPlayer2Sign = "O";
        private readonly Point r_PositionOnBoard;

        public BoardButton(int i_Row, int i_Col, Cell i_MatchedCellOnBoardGame)
        {
            r_PositionOnBoard = new Point(i_Col, i_Row);
            i_MatchedCellOnBoardGame.CellSignChanged += cell_CellSignChanged;
        }

        public Point PositionOnBoard
        {
            get
            {
                return r_PositionOnBoard;
            }
        }

        private void cell_CellSignChanged(Cell.eCellSign i_Sign)
        {
            string sign = i_Sign == Cell.eCellSign.Player1 ? k_DefaultPlayer1Sign : k_DefaultPlayer2Sign;

            if (i_Sign == Cell.eCellSign.Empty)
            {
                this.Text = "";
                this.Enabled = true;
            }
            else 
            { 
                this.Text = sign;
                this.Enabled = false;
            }
        }
    }
}

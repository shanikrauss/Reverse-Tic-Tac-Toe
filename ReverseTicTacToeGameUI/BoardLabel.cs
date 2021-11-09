using System;
using System.Drawing;
using System.Windows.Forms;
using ReverseTicTacToeGameLogic;

namespace ReverseTicTacToeGameUI
{
    public class BoardLabel : Label
    {
        private readonly Font r_BoldText;
        private readonly Font r_UnBoldText;
        public event Action BoldTextChanged;

        public BoardLabel(GameState i_GameState, bool i_IsBold)
        {
            r_BoldText = new Font(Label.DefaultFont, FontStyle.Bold);
            r_UnBoldText = new Font(Label.DefaultFont, FontStyle.Regular);
            i_GameState.CurrentPlayerSwitched += gameState_SwitchPlayer;
            this.Font = i_IsBold ? r_BoldText : r_UnBoldText;
        }

        protected virtual void OnBoldTextChanged()
        {
            if (BoldTextChanged != null)
            {
                BoldTextChanged.Invoke();
            }
        }

        private void gameState_SwitchPlayer()
        {
            this.Font = this.Font == r_BoldText ? r_UnBoldText : r_BoldText;
        }
    }
}

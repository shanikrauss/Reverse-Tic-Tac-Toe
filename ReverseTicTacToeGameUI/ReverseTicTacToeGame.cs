using System;
using System.Windows.Forms;

namespace ReverseTicTacToeGameUI
{
    public class ReverseTicTacToeGame
    {
        public static void StartGame()
        {
            GameSettingsForm gameSettingForm = new GameSettingsForm();
            gameSettingForm.ShowDialog();

            if(gameSettingForm.DialogResult == DialogResult.OK)
            {
                BoardGameForm boardGameForm = new BoardGameForm(
                    int.Parse(gameSettingForm.NumberOfRows),
                    int.Parse(gameSettingForm.NumberOfCols),
                    gameSettingForm.Player1Name,
                    gameSettingForm.Player2Name,
                    gameSettingForm.IsOpponentHuman);

                boardGameForm.ShowDialog();
            }
        }
    }
}

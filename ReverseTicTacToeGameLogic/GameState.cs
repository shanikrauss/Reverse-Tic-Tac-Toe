using System;

namespace ReverseTicTacToeGameLogic
{
    //The class 'GameState' is a logic class , it holds data about the current state of the game
    //And perform various actions such as swapping turns between players, update winner and checking if the game is over
    public class GameState
    {
        private bool m_IsGameOver;
        private Player m_CurrentPlayer;
        private Player m_Winner;
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        public event Action CurrentPlayerSwitched;
        public event Action WinnerUpdated;
        public event Action GameEndedWithATie;

        public GameState(Player i_Player1, Player i_Player2)
        {
            m_IsGameOver = false;
            m_CurrentPlayer = i_Player1;
            r_Player1 = i_Player1;
            r_Player2 = i_Player2;
            m_Winner = null;
        }

        public Player Winner
        {
            get
            {
                return m_Winner;
            }
            set
            {
                m_Winner = value;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
            set
            {
                m_CurrentPlayer = value;
            }
        }

        public bool IsGameOver
        {
            get
            {
                return m_IsGameOver;
            }
            set
            {
                m_IsGameOver = value;
            }
        }

        protected virtual void OnCurrentPlayerSwitched()
        {
            if (CurrentPlayerSwitched != null)
            {
                CurrentPlayerSwitched.Invoke();
            }
        }

        protected virtual void OnWinnerUpdated()
        {
            if (WinnerUpdated != null)
            {
                WinnerUpdated.Invoke();
            }
        }

        protected virtual void OnGameEndedWithATie()
        {
            if (GameEndedWithATie != null)
            {
                GameEndedWithATie.Invoke();
            }
        }

        public void MakeMoveAndCheckGameStatus(int i_Row, int i_Col, BoardGame io_BoardGame)
        {
            io_BoardGame.SetCell(i_Row, i_Col, m_CurrentPlayer.Sign);
            checkGameStatus(i_Row, i_Col, io_BoardGame);
            switchPlayers();

            if (!m_IsGameOver && m_CurrentPlayer.IsComputer)
            {
                int rowComputerMove;
                int colComputerMove;

                m_CurrentPlayer.ChooseCellForMoveComputer(out rowComputerMove, out colComputerMove, io_BoardGame);
                MakeMoveAndCheckGameStatus(rowComputerMove, colComputerMove, io_BoardGame);
            }
        }

        private void checkGameStatus(int i_Row, int i_Col, BoardGame i_BoardGame)
        {
            if(CheckIfLoseGame(i_BoardGame, i_Row, i_Col))
            {
                UpdateWinner();
            }
            else if(CheckIfTie(i_BoardGame))
            {
                OnGameEndedWithATie();
            }
        }

        private void resetGame()
        {
            m_IsGameOver = false;
            m_Winner = null;
        }

        public void ResetGameStateForAnotherRound(BoardGame i_Board)
        {
            resetGame();
            i_Board.ResetBoard();
        }

        public void UpdateWinner()
        {
            m_Winner = CurrentPlayer == r_Player1 ? r_Player2 : r_Player1;
            m_Winner.Score++;
            OnWinnerUpdated();
        }

        private void switchPlayers()
        {
            m_CurrentPlayer = m_CurrentPlayer == r_Player1 ? r_Player2 : r_Player1;
            OnCurrentPlayerSwitched();
        }

        public bool CheckIfLoseGame(BoardGame i_Board, int i_Row, int i_Column)
        {
            m_IsGameOver = CheckIfThereSequence(i_Board, i_Row, i_Column);

            return m_IsGameOver;
        }

        public bool CheckIfThereSequence(BoardGame i_Board, int i_Row, int i_Column)
        {
            bool isThereSequence = checkSequenceColumn(i_Board, i_Row, i_Column)
                                   || checkSequenceRow(i_Board, i_Row, i_Column)
                                   || checkSequenceLeftDownDiagonal(i_Board, i_Row, i_Column)
                                   || checkSequenceRightDownDiagonal(i_Board, i_Row, i_Column);

            return isThereSequence;
        }

        public bool CheckIfTie(BoardGame i_Board)
        {
            m_IsGameOver = i_Board.IsBoardFull();

            return m_IsGameOver;
        }

        private bool checkSequenceRow(BoardGame i_Board, int i_Row, int i_Column)
        {
            bool isSequence = true;
            Cell.eCellSign sign = i_Board.Board[i_Row, i_Column].Sign;
            int curColToCheck = 0;

            while (curColToCheck < i_Board.Width)
            {
                Cell.eCellSign curSignToCheck = i_Board.Board[i_Row, curColToCheck].Sign;

                if (curSignToCheck != sign)
                {
                    isSequence = false;
                    break;
                }

                curColToCheck++;
            }

            return isSequence;
        }

        private bool checkSequenceColumn(BoardGame i_Board, int i_Row, int i_Column)
        {
            bool isSequence = true;
            Cell.eCellSign sign = i_Board.Board[i_Row, i_Column].Sign;

            int curRowToCheck = 0;

            while (curRowToCheck < i_Board.Length)
            {
                Cell.eCellSign curSignToCheck = i_Board.Board[curRowToCheck, i_Column].Sign;

                if (curSignToCheck != sign)
                {
                    isSequence = false;
                    break;
                }

                curRowToCheck++;
            }

            return isSequence;
        }

        private bool checkSequenceLeftDownDiagonal(BoardGame i_Board, int i_Row, int i_Column)
        {
            bool isCellOnDiagonal = i_Row == i_Column;
            Cell.eCellSign sign = i_Board.Board[i_Row, i_Column].Sign;
            int curRowToCheck = 0;
            int curColToCheck = 0;
            bool isSequence = false;

            if (isCellOnDiagonal)
            {
                isSequence = true;

                while (curRowToCheck < i_Board.Length && curColToCheck < i_Board.Width)
                {
                    Cell.eCellSign curSignToCheck = i_Board.Board[curRowToCheck, curColToCheck].Sign;

                    if (curSignToCheck != sign)
                    {
                        isSequence = false;
                        break;
                    }

                    curRowToCheck++;
                    curColToCheck++;
                }
            }

            return isSequence;
        }

        private bool checkSequenceRightDownDiagonal(BoardGame i_Board, int i_Row, int i_Column)
        {
            bool isCellOnDiagonal = i_Row + i_Column + 1 == i_Board.Length;
            Cell.eCellSign sign = i_Board.Board[i_Row, i_Column].Sign;
            int curRowToCheck = 0;
            int curColToCheck = i_Board.Width - 1;
            bool isSequence = false;

            if (isCellOnDiagonal)
            {
                isSequence = true;

                while (curRowToCheck < i_Board.Length && curColToCheck >= 0)
                {
                    Cell.eCellSign curSignToCheck = i_Board.Board[curRowToCheck, curColToCheck].Sign;

                    if (curSignToCheck != sign)
                    {
                        isSequence = false;
                        break;
                    }

                    curRowToCheck++;
                    curColToCheck--;
                }
            }

            return isSequence;
        }
    }
}


using System;

namespace ReverseTicTacToeGameLogic
{
    // The class manages the board game
    public class BoardGame
    {
        private const int k_BoardMaxSizePossible = 9;
        private const int k_BoardMinSizePossible = 3;
        private Cell[,] m_Board;
        private readonly int r_Width;
        private readonly int r_Length;
        private readonly int r_Size;
        private int m_NumberOfElementsInBoard;

        public BoardGame(int i_Length, int i_Width)
        {
            r_Width = i_Width;
            r_Length = i_Length;
            r_Size = i_Width * i_Length;
            m_NumberOfElementsInBoard = 0;
            m_Board = new Cell[i_Length, i_Width];

            for(int i = 0; i < i_Length; i++)
            {
                for(int j = 0; j < i_Width; j++)
                {
                    m_Board[i, j] = new Cell();
                }
            }
        }

        public int NumberOfElementsInBoard
        {
            get
            {
                return m_NumberOfElementsInBoard;
            }
            set
            {
                m_NumberOfElementsInBoard = value;
            }
        }

        public int Width
        {
            get
            {
                return r_Width;
            }
        }

        public int Length
        {
            get
            {
                return r_Length;
            }
        }

        public Cell[,] Board
        {
            get
            {
                return m_Board;
            }
            set
            {
                m_Board = value;
            }
        }

        public void ResetBoard()
        {
            for (int i = 0; i < r_Length; i++)
            {
                for (int j = 0; j < r_Width; j++)
                {
                    m_Board[i, j].Sign = Cell.eCellSign.Empty;
                }
            }

            m_NumberOfElementsInBoard = 0;
        }

        public void SetCell(int i_Row, int i_Column, Cell.eCellSign i_Sign)
        {
            m_Board[i_Row, i_Column].Sign = i_Sign;
            m_NumberOfElementsInBoard++;
        }

        public bool IsCellFree(int i_Row, int i_Column)
        {
            bool isCellFree = m_Board[i_Row, i_Column].IsCellEmpty();

            return isCellFree;
        }

        public bool IsBoardFull()
        {
            bool isBoardFull = (m_NumberOfElementsInBoard == r_Size);

            return isBoardFull;
        }
    }
}

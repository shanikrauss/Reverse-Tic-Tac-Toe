using System;

namespace ReverseTicTacToeGameLogic
{
    //The class is a logic class, and holds data about the player
    public class Player
    {
        private readonly Cell.eCellSign r_Sign;
        private readonly string r_Name;
        private readonly bool r_IsComputer;
        private readonly Random r_RandomNumber;
        private int m_Score;

        public Player(string i_Name, Cell.eCellSign i_Sign, bool i_IsComputer)
        {
            r_Sign = i_Sign;
            r_Name = i_Name;
            r_IsComputer = i_IsComputer;
            m_Score = 0;
            r_RandomNumber = new Random();
        }

        public bool IsComputer
        {
            get
            {
                return r_IsComputer;
            }
        }
        
        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        public Cell.eCellSign Sign
        {
            get
            {
                return r_Sign;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }

        public void ChooseCellForMoveComputer(out int o_Row, out int o_Column, BoardGame i_Board)
        {
            o_Row = r_RandomNumber.Next(0, i_Board.Length);
            o_Column = r_RandomNumber.Next(0, i_Board.Width);

            while (!i_Board.IsCellFree(o_Row, o_Column))
            {
                o_Row = r_RandomNumber.Next(0, i_Board.Length);
                o_Column = r_RandomNumber.Next(0, i_Board.Width);
            }
        }
    }
}


using System;

namespace ReverseTicTacToeGameLogic
{
    //The class represents a cell in the board game
    public class Cell
    {
        private eCellSign m_Sign;
        public event Action<eCellSign> CellSignChanged;

        public enum eCellSign
        {
            Empty,
            Player1,
            Player2
        }

        public Cell()
        {
            m_Sign = eCellSign.Empty;
        }

        public eCellSign Sign
        {
            get
            {
                return m_Sign;
            }
            set
            {
                m_Sign = value;
                OnCellSignChanged();
            }
        }

        protected virtual void OnCellSignChanged()
        {
            if(CellSignChanged != null)
            {
                CellSignChanged.Invoke(m_Sign);
            }
        }

        public bool IsCellEmpty()
        {
            return m_Sign == eCellSign.Empty;
        }
    }
}

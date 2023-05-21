namespace Ex02
{
    internal class PersonPlayer
    {
        private readonly string m_Name;
        private int m_Score = 0;
        private BoardSymbol m_Symbol;

        public PersonPlayer(string i_Name, BoardSymbol i_Symbol)
        {
            m_Name = i_Name;
            m_Symbol = i_Symbol;
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

        public BoardSymbol Symbol
        {
            get
            {
                return m_Symbol;
            }
        }

        public string Name
        {
            get 
            { 
                return m_Name;
            }
        }
    }
}

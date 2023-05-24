namespace Ex02
{
    internal class Player
    {
        // Should we change this class to a struct? 
        private static int s_NumOfPlayersCreated = 0;
        private readonly string r_Name;
        private readonly eBoardSymbol r_Symbol;
        private int m_Score = 0;
        private bool m_IsComputer;

        public Player(string i_Name, eBoardSymbol i_Symbol, bool i_IsComputer)
        {
            s_NumOfPlayersCreated++;
            r_Name = i_Name;
            r_Symbol = i_Symbol;
            m_IsComputer = i_IsComputer;
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

        public eBoardSymbol Symbol
        {
            get
            {
                return r_Symbol;
            }
        }

        public string Name
        {
            get 
            { 
                return r_Name;
            }
        }

        public bool IsComputer
        {
            get 
            {
                return m_IsComputer;
            }
        }
        //I don't think it related to this class

        // It's needed for accessing the static varaible 's_NumOfPlayersCreated' from outside this class. 
        // In my opinion, 's_NumOfPlayersCreated' is a legit (and totally optional) static variable of the class that counts 
        // the number of 'Player' instances created. In particular, I needed it in 'addPersonPlayer()'.
        public static int GetNumPlayersCreated()
        {
            return s_NumOfPlayersCreated;
        }
    }
}

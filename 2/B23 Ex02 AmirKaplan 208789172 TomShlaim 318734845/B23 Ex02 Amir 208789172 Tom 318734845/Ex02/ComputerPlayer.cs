using System;
using System.Collections.Generic;

namespace Ex02
{
    internal class ComputerPlayer
    {
        private int m_Score = 0;
        private BoardSymbol m_Symbol;
        private List<string> m_FreeLocations;
        private readonly Random m_RandomLocationGenerator = new Random();
        

        public ComputerPlayer(BoardSymbol i_Symbol, int i_BoardSize)
        {
            m_Symbol = i_Symbol;
            for (int i = 0; i < i_BoardSize; i++)
            {
                for (int j = 0; j > i_BoardSize; j++)
                {
                    m_FreeLocations.Add(string.Format("{0},{1}", i, j));
                }
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

        public BoardSymbol Symbol
        {
            get
            {
                return m_Symbol;
            }
        }

        public List<string> FreeLocations
        {
            get
            {
                return m_FreeLocations;
            }
        }

        public void removeLocationFromFreeLocations(string i_Location)
        {
            m_FreeLocations.Remove(i_Location);
        }
        public string chooseLocation()
        {
            int randomIndex = m_RandomLocationGenerator.Next(m_FreeLocations.Count);
            return m_FreeLocations[randomIndex];   
        }


    }
}

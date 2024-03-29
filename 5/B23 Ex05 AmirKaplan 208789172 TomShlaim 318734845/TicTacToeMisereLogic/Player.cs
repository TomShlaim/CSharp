﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMisereLogic
{
    public class Player
    {
        private readonly string r_Name;
        private readonly eBoardSymbol r_Symbol;
        private int m_Score = 0;
        private bool m_IsComputer;

        public Player(string i_Name, eBoardSymbol i_Symbol, bool i_IsComputer)
        {
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
    }
}

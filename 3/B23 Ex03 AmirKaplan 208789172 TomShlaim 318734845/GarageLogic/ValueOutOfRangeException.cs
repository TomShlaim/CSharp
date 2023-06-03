using System;

namespace GarageLogic
{
    internal class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
                       : base(string.Format("Value out of range error! the value range should be between {0} to {1}", i_MinValue, i_MaxValue))

        {}
        public float MaxValue
        {
            get { return r_MaxValue; }
        }
        public float MinValue
        {
            get { return r_MinValue; }
        }
    }
}

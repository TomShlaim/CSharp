using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_RegistrationNumber;
        private readonly List<Wheel> r_Wheels;
        private readonly Engine r_Engine;
        private readonly eVehicleType r_VehicleType;

        public Vehicle(string i_RegistrationNumber,string i_ModelName, Engine i_Engine, int i_NumberOfWheels, float i_MaxAirPressure, eVehicleType r_VehicleType)
        {
            r_RegistrationNumber = i_RegistrationNumber;
            r_ModelName = i_ModelName;
            r_Engine = i_Engine;
            r_Wheels = new List<Wheel>();
            AttachWheels(i_NumberOfWheels, i_MaxAirPressure);
            this.r_VehicleType = r_VehicleType;
        }
        public string RegistrationNumber
        {
            get { return r_RegistrationNumber; }
        }
        public Engine Engine
        {
            get { return r_Engine; }
        }
        public void AttachWheels(int i_NumberOfWheels, float i_WheelMaxPressure)
        {
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                r_Wheels.Add(new Wheel(i_WheelMaxPressure));
            }
        }
        public void InflateWheelsToMaximumPressure()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }
        public void InflateWheels(float wheelPressure)
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.Inflate(wheelPressure);
            }
        }
        public string WheelsToString()
        {
            StringBuilder wheelsInfo = new StringBuilder();

            foreach (Wheel wheel in r_Wheels)
            {
                wheelsInfo.Append(wheel.ToString());
                wheelsInfo.Append(Environment.NewLine);
            }

            return wheelsInfo.ToString();
        }
        public override string ToString()
        {
            return string.Format(
@"
Vehicle Type : {0}
Registration Number: {1}
Model Name: {2}

Engine: 
=======
{3}

Wheels information: 
===================
{4}
"
     ,r_VehicleType, r_RegistrationNumber, r_ModelName, r_Engine.ToString(), WheelsToString());
        }

    }
}

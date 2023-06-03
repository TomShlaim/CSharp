using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class GarageUI
    {
        public static void OpenGarage()
        {
            MessageGenerator.DisplayWelcomeMessage();
            bool isQuit = false;

            while (isQuit)
            {
                MessageGenerator.DisplayMenu();
                eGarageFunctions chosenGarageFunctionNumber = getGarageFunctionNumber();

                if (chosenGarageFunctionNumber == eGarageFunctions.Close)
                {
                    isQuit = true;
                }
                else
                {
                    executeGarageFunction(chosenGarageFunctionNumber);
                }
            }

            CloseGarage();
        }
        
        private static void CloseGarage()
        {
            MessageGenerator.DisplayCloseMessage();
            Environment.Exit(0);
        }
        private static eGarageFunctions getGarageFunctionNumber()
        {
            string inputGarageFunctionNumber = Console.ReadLine();

            while (!UIValidator.isValidGarageFunction(inputGarageFunctionNumber))
            {
                MessageGenerator.DisplayInvalidFieldMessage("function number", "Must be a positive integer");
                inputGarageFunctionNumber = Console.ReadLine();
            }

            return (eGarageFunctions)Enum.Parse(typeof(eGarageFunctions), inputGarageFunctionNumber);
        }
        private static void executeGarageFunction(eGarageFunctions i_GarageFunctionNumber)
        {
            switch (i_GarageFunctionNumber)
            {
                case eGarageFunctions.AddVehicle:
                    addVehicle();
                    break;
                case eGarageFunctions.ShowVehiclesRegisterationsNumbers:
                    showVehiclesRegisterationsNumbers();
                    break;
                case eGarageFunctions.ChangeVehicleStatus:
                    changeVehicleStatus();
                    break;
                case eGarageFunctions.InflateWheelsToMaximum:
                    inflateWheelsToMaximum();
                    break;
                case eGarageFunctions.FuelVehicle:
                    fuelVehicle();
                    break;
                case eGarageFunctions.ChargeVehicle:
                    chargeVehicle();
                    break;
                case eGarageFunctions.ShowVehicleData:
                    showVehicleData();
                    break;
            }
        }
        private static void addVehicle()
        {

        }
        private static void showVehiclesRegisterationsNumbers()
        {

        }
        private static void changeVehicleStatus()
        {

        }
        private static void inflateWheelsToMaximum()
        {

        }
        private static void fuelVehicle()
        {

        }
        private static void chargeVehicle()
        {

        }
        private static void showVehicleData()
        {

        }
    }
}

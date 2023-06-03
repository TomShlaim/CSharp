﻿using GarageLogic;
using System;
using System.Collections.Generic;
using System.Threading;
using static GarageLogic.VehicleGenerator;

namespace ConsoleUI
{
    internal class GarageUI
    {
        public static void OpenGarage()
        {
            MessageGenerator.DisplayWelcomeMessage();
            bool isQuit = false;

            while (!isQuit)
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

            closeGarage();
        }
        
        private static void closeGarage()
        {
            MessageGenerator.DisplayCloseMessage();
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
        private static eGarageFunctions getGarageFunctionNumber()
        {
            string inputGarageFunctionNumber = Console.ReadLine();

            while (!UIValidator.IsValidGarageFunction(inputGarageFunctionNumber))
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
            try
            {
                MessageGenerator.DisplayInsertFieldMessage("registeration number");
                string registerationNumber = getRegisterationNumber();

                if(GarageManager.isVehicleInGarage(registerationNumber)) {
                    GarageManager.UpdateVehicleStatus(registerationNumber, eVehicleStatus.InRepair);
                    MessageGenerator.DisplayChangeVehicleStatusMessage(eVehicleStatus.InRepair, "Vehicle is already in garage!");
                }
                else
                {
                    MessageGenerator.DisplayInsertFieldMessage("model name");
                    string modelName = Console.ReadLine();

                    MessageGenerator.DisplayInsertFieldWithValidEnumValuesMessage("vehicle type", typeof(eVehicleType));
                    eVehicleType vehicleType = getVehicleType();

                    Vehicle newVehicle = CreateVehicle(vehicleType, registerationNumber, modelName);
                    populateVehicleFields(newVehicle, vehicleType);
                }
            }
            catch (Exception e)
            {
                MessageGenerator.DisplayInvalidFieldMessage(e.Message);
            }
        }
        private static void populateVehicleFields(Vehicle i_Vehicle, eVehicleType i_VehicleType)
        {
            VehicleGenerator.GetVehicleAdditionalFields(i_VehicleType).ForEach(field =>
            {
                Dictionary<eVehicleAdditionalFields, string> vehicleAdditionalFields = new Dictionary<eVehicleAdditionalFields, string>();

                MessageGenerator.DisplayInsertFieldMessage(field.ToString());
                string vehicleFieldValue = Console.ReadLine();

                vehicleAdditionalFields.Add(field, vehicleFieldValue);
                VehicleGenerator.SetVehicleAdditionalFields(i_Vehicle, i_VehicleType, vehicleAdditionalFields);
            });
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
        private static string getRegisterationNumber()
        {
            string inputRegisterationNumber = Console.ReadLine();
            LogicValidator.IsValidRegisterationNumber(inputRegisterationNumber);

            return inputRegisterationNumber;
        }
        private static eVehicleType getVehicleType()
        {
            string inputVehicleType = Console.ReadLine();
            eVehicleType vehicleType = LogicValidator.ValidateAndParseStringToVehicleType(inputVehicleType);

            return vehicleType;
        }
    }
}

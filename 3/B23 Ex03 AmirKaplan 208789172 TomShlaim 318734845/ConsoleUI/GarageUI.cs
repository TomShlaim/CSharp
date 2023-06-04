using GarageLogic;
using System;
using System.Threading;

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
                    try
                    {
                        executeGarageFunction(chosenGarageFunctionNumber);
                        MessageGenerator.DisplayFunctionExecutionMessage(chosenGarageFunctionNumber, true);
                    }
                    catch(Exception ex)
                    {
                        MessageGenerator.DisplayInvalidFieldMessage(ex.Message);
                        MessageGenerator.DisplayFunctionExecutionMessage(chosenGarageFunctionNumber, false);
                    }
                }
            }

            quitGarage();
        }
        
        private static void quitGarage()
        {
            MessageGenerator.DisplayCloseMessage();
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
        private static eGarageFunctions getGarageFunctionNumber()
        {
            string inputGarageFunctionNumber = Console.ReadLine();
            int numOfFunctionsAvailable = Enum.GetValues(typeof(eGarageFunctions)).Length;

            while (!UIValidator.IsValidGarageFunction(inputGarageFunctionNumber))
            {
                MessageGenerator.DisplayInvalidFieldMessage("function number", string.Format("must be an integer in the range 1-{0}", numOfFunctionsAvailable));
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
                    showVehiclesRegisterationsNumbersByVehicleStatus();
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

                Vehicle newVehicle = GarageManager.CreateVehicle(vehicleType, registerationNumber, modelName);
                populateVehicleFields(newVehicle, vehicleType);
                insertVehicleIntoGarage(newVehicle);
            } 
        }
        private static void populateVehicleFields(Vehicle i_Vehicle, eVehicleType i_VehicleType)
        {
            GarageManager.GetVehicleAdditionalFields(i_VehicleType).ForEach(field =>
            {
                MessageGenerator.DisplayFieldMessage(field);
                string vehicleFieldValue = Console.ReadLine();

                GarageManager.SetVehicleAdditionalField(i_Vehicle, field, vehicleFieldValue);
            });
        }
        private static void insertVehicleIntoGarage(Vehicle i_Vehicle)
        {
            string ownerName = getOwnerName();
            string ownerPhone = getOwnerPhoneNumber();

            GarageManager.AddVehicle(i_Vehicle, ownerName, ownerPhone);
        }
        private static void showVehiclesRegisterationsNumbersByVehicleStatus()
        {
            eVehicleStatus vehicleStatus = getVehicleStatus();

            MessageGenerator.DisplayVehiclesInGarage(GarageManager.GetVehiclesRegisterationNumbersByVehicleStatus(vehicleStatus));        
        }
        private static void changeVehicleStatus()
        {
            string registerationNumber = getRegisterationNumber();
            eVehicleStatus vehicleStatus = getVehicleStatus();

            GarageManager.UpdateVehicleStatus(registerationNumber, vehicleStatus);
            MessageGenerator.DisplayChangeVehicleStatusMessage(vehicleStatus); 
        }
        private static void inflateWheelsToMaximum()
        {
            string registerationNumber = getRegisterationNumber();

            GarageManager.InflateVehicleWheelsToMaximum(registerationNumber);
        }
        private static void fuelVehicle()
        {
            string registerationNumber = getRegisterationNumber();
            eFuelType fuelType = getFuelType();
            float amountOfFuelToFill = getAmountOfFuelToFill();

            GarageManager.FuelVehicle(registerationNumber, fuelType, amountOfFuelToFill);
        }
        private static void chargeVehicle()
        {
            string registerationNumber = getRegisterationNumber();
            float minutesToCharge = getMinutesToCharge();

            GarageManager.ChargeVehicle(registerationNumber, minutesToCharge);
        }
        private static void showVehicleData()
        {
            string registerationNumber = getRegisterationNumber();

            Console.WriteLine(GarageManager.GetAllVehicleData(registerationNumber));
        }
        private static string getRegisterationNumber()
        {
            MessageGenerator.DisplayInsertFieldMessage("registeration number");
            string inputRegisterationNumber = Console.ReadLine();

            LogicValidator.IsValidRegisterationNumber(inputRegisterationNumber);

            return inputRegisterationNumber;
        }
        private static string getOwnerName()
        {
            MessageGenerator.DisplayInsertFieldMessage("owner name");
            string inputOwnerName = Console.ReadLine();

            return inputOwnerName;
        }
        private static string getOwnerPhoneNumber()
        {
            MessageGenerator.DisplayInsertFieldMessage("owner phone number");
            string inputOwnerPhoneNumber = Console.ReadLine();

            LogicValidator.IsValidPhoneNumber(inputOwnerPhoneNumber);

            return inputOwnerPhoneNumber;
        }
        private static eVehicleType getVehicleType()
        {
            string inputVehicleType = Console.ReadLine();
            eVehicleType vehicleType = LogicValidator.ValidateAndParseStringToVehicleType(inputVehicleType);

            return vehicleType;
        }
        private static eVehicleStatus getVehicleStatus()
        {
            MessageGenerator.DisplayInsertFieldWithValidEnumValuesMessage("vehicle status", typeof(eVehicleStatus));
            string inputVehicleStatus = Console.ReadLine();

            eVehicleStatus vehicleStatus = LogicValidator.ValidateAndParseStringToVehicleStatus(inputVehicleStatus);

            return vehicleStatus;
        }
        private static eFuelType getFuelType()
        {
            MessageGenerator.DisplayInsertFieldWithValidEnumValuesMessage("fuel type", typeof(eFuelType));
            string inputFuelType = Console.ReadLine();

            eFuelType fuelType = LogicValidator.ValidateAndParseStringToFuelType(inputFuelType);

            return fuelType;
        }
        private static float getAmountOfFuelToFill()
        {
            return getFloatValue("amount of fuel to fill");
        }
        private static float getMinutesToCharge()
        {
            return getFloatValue("minutes to charge");
        }
        private static float getFloatValue(string i_FieldName)
        {
            MessageGenerator.DisplayInsertFieldMessage(i_FieldName);
            string inputValue = Console.ReadLine();

            float value = LogicValidator.ValidateAndParseStringToPositiveFloat(inputValue);

            return value;
        }
    }
}

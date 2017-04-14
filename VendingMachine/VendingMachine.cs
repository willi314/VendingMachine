using System;

namespace PillarVendingMachine
{
    public class VendingMachine
    {
        private double insertedCurrencyCount;
        private string nextMesasgeForDisplay;

        public VendingMachine()
        {
            insertedCurrencyCount = 0;
            nextMesasgeForDisplay = "";
        }

        public string checkDisplay()
        {
            if(!nextMesasgeForDisplay.Equals(""))
            {
                string displayMessage = nextMesasgeForDisplay;
                nextMesasgeForDisplay = "";
                return displayMessage;
            }
            if(insertedCurrencyCount == 0)
                return "INSERT COIN";
            return insertedCurrencyCount.ToString("$##0.00");
        }

        public void insertCoin(string coinString)
        {
            switch(coinString.ToLower())
            {
                case "quarter":
                    insertedCurrencyCount += 0.25;
                    break;
                case "dime":
                    insertedCurrencyCount += 0.1;
                    break;
                case "nickel":
                    insertedCurrencyCount += 0.05;
                    break;
                default:
                    insertedCurrencyCount += 0.0;
                    break;
            }
        }

        public void selectCola()
        {
            if(insertedCurrencyCount < 1.0)
            {
                nextMesasgeForDisplay = "PRICE: $1.00";
                return;
            }
            nextMesasgeForDisplay = "THANK YOU";
            insertedCurrencyCount = 0.0;
        }

        public void selectChips()
        {
            if (insertedCurrencyCount < 0.5)
            {
                nextMesasgeForDisplay = "PRICE: $0.50";
                return;
            }
            nextMesasgeForDisplay = "THANK YOU";
            insertedCurrencyCount = 0.0;
        }

        public void selectCandy()
        {
            if(insertedCurrencyCount < 0.5)
            {
                nextMesasgeForDisplay = "PRICE: $0.65";
                return;
            } 
            nextMesasgeForDisplay = "THANK YOU";
            insertedCurrencyCount = 0.0;
        }
    }
}
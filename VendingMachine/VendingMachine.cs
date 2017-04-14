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
            nextMesasgeForDisplay = "PRICE: $1.00";
        }

        public void selectChips()
        {
            nextMesasgeForDisplay = "PRICE: $0.50";
        }

        public void selectCandy()
        {
            nextMesasgeForDisplay = "PRICE: $0.65";
        }
    }
}
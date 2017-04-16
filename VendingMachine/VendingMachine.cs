using System;

namespace PillarVendingMachine
{
    public class VendingMachine
    {
        private double insertedCurrencyCount;
        private string nextMesasgeForDisplay;
        private int[] coinsInCoinReturn;
        private int[] itemsInStock;

        public VendingMachine()
        {
            insertedCurrencyCount = 0;
            nextMesasgeForDisplay = "";
            coinsInCoinReturn = new int[]{ 0, 0, 0 };
            itemsInStock = new int[]{ 0, 0, 0 };
        }

        public VendingMachine(int amountOfCola, int amountOfChips, int amountOfCandy)
        {
            insertedCurrencyCount = 0;
            nextMesasgeForDisplay = "";
            coinsInCoinReturn = new int[] { 0, 0, 0 };
            itemsInStock = new int[] { amountOfCola, amountOfChips, amountOfCandy };
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
            if(itemsInStock[0] == 0)
            {
                nextMesasgeForDisplay = "SOLD OUT";
                return;
            }

            if(insertedCurrencyCount < 1.0)
            {
                nextMesasgeForDisplay = "PRICE: $1.00";
                return;
            }

            itemsInStock[0]--;
            nextMesasgeForDisplay = "THANK YOU";
            returnCoins(insertedCurrencyCount - 1.0);
            insertedCurrencyCount = 0.0;
        }

        public void selectChips()
        {
            if (itemsInStock[1] == 0)
            {
                nextMesasgeForDisplay = "SOLD OUT";
                return;
            }

            if (insertedCurrencyCount < 0.5)
            {
                nextMesasgeForDisplay = "PRICE: $0.50";
                return;
            }

            itemsInStock[1]--;
            nextMesasgeForDisplay = "THANK YOU";
            returnCoins(insertedCurrencyCount - 0.5);
            insertedCurrencyCount = 0.0;
        }

        public void selectCandy()
        {
            if (itemsInStock[2] == 0)
            {
                nextMesasgeForDisplay = "SOLD OUT";
                return;
            }

            if (insertedCurrencyCount < 0.5)
            {
                nextMesasgeForDisplay = "PRICE: $0.65";
                return;
            }

            itemsInStock[2]--;
            nextMesasgeForDisplay = "THANK YOU";
            returnCoins(insertedCurrencyCount - 0.65);
            insertedCurrencyCount = 0.0;
        }

        private void returnCoins(double differenceFromTransaction)
        {
            while(differenceFromTransaction >= 0.25)
            {
                coinsInCoinReturn[0]++;
                differenceFromTransaction = Math.Round(differenceFromTransaction - 0.25, 2);
            }
            while (differenceFromTransaction >= 0.1)
            {
                coinsInCoinReturn[1]++;
                differenceFromTransaction = Math.Round(differenceFromTransaction - 0.1, 2);
            }
            while (differenceFromTransaction >= 0.05)
            {
                coinsInCoinReturn[2]++;
                differenceFromTransaction = Math.Round(differenceFromTransaction - 0.05, 2);
            }
        }

        public string checkCoinReturn()
        {
            if (coinsInCoinReturn[0] == 0 && coinsInCoinReturn[1] == 0 && coinsInCoinReturn[2] == 0)
                return "Coin return is empty";
            string coinReturnString = string.Format("Retrieved {0} quarters, {1} dimes, and {2} nickels", coinsInCoinReturn[0], coinsInCoinReturn[1],coinsInCoinReturn[2]);
            Array.Clear(coinsInCoinReturn, 0, 3);
            return coinReturnString;
        }
    }
}
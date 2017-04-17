using System;

namespace PillarVendingMachine
{
    public class VendingMachine
    {
        private double insertedCurrencyCount;
        private string nextMesasgeForDisplay;
        private int[] coinsInCoinReturn;
        private int[] itemsInStock;
        private string invalidObjectsInCoinReturn;
        private int[] coinsInMachine;

        public VendingMachine()
        {
            insertedCurrencyCount = 0;
            nextMesasgeForDisplay = "";
            invalidObjectsInCoinReturn = "";
            coinsInCoinReturn = new int[]{ 0, 0, 0 };
            itemsInStock = new int[]{ 0, 0, 0 };
            coinsInMachine = new int[] { 0, 0, 0 };
        }

        public VendingMachine(int amountOfCola, int amountOfChips, int amountOfCandy)
        {
            insertedCurrencyCount = 0;
            nextMesasgeForDisplay = "";
            invalidObjectsInCoinReturn = "";
            coinsInCoinReturn = new int[] { 0, 0, 0 };
            itemsInStock = new int[] { amountOfCola, amountOfChips, amountOfCandy };
            coinsInMachine = new int[] { 0, 0, 0 };
        }

        public VendingMachine(int amountOfCola, int amountOfChips, int amountOfCandy, int amountOfQuarters, int amountOfDimes, int amountOfNickels)
        {
            insertedCurrencyCount = 0;
            nextMesasgeForDisplay = "";
            invalidObjectsInCoinReturn = "";
            coinsInCoinReturn = new int[] { 0, 0, 0 };
            itemsInStock = new int[] { amountOfCola, amountOfChips, amountOfCandy };
            coinsInMachine = new int[] { amountOfQuarters, amountOfDimes, amountOfNickels };
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
            {
                if (coinsInMachine[1] == 0 && coinsInMachine[2] == 0)
                    return "EXACT CHANGE ONLY";
                return "INSERT COIN";
            }
                
            return insertedCurrencyCount.ToString("$##0.00");
        }

        public void insertCoin(string coinString)
        {
            switch(coinString.ToLower())
            {
                case "quarter":
                    coinsInMachine[0]++;
                    insertedCurrencyCount += 0.25;
                    break;
                case "dime":
                    coinsInMachine[1]++;
                    insertedCurrencyCount += 0.1;
                    break;
                case "nickel":
                    coinsInMachine[2]++;
                    insertedCurrencyCount += 0.05;
                    break;
                default:
                    insertedCurrencyCount += 0.0;
                    if (!String.IsNullOrWhiteSpace(coinString))
                    {
                        if (String.IsNullOrEmpty(invalidObjectsInCoinReturn))
                        {
                            invalidObjectsInCoinReturn = "a " + coinString;
                            break;
                        }
                        invalidObjectsInCoinReturn += ", a " + coinString;
                    }
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
            returnCoins(Math.Round(insertedCurrencyCount - 1.0, 2));
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
            returnCoins(Math.Round(insertedCurrencyCount - 0.5, 2));
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
            returnCoins(Math.Round(insertedCurrencyCount - 0.65, 2));
            insertedCurrencyCount = 0.0;
        }

        private void returnCoins(double differenceFromTransaction)
        {
            while(differenceFromTransaction >= 0.25 && coinsInMachine[0] > 0)
            {
                coinsInCoinReturn[0]++;
                coinsInMachine[0]--;
                differenceFromTransaction = Math.Round(differenceFromTransaction - 0.25, 2);
            }
            while (differenceFromTransaction >= 0.1 && coinsInMachine[1] > 0)
            {
                coinsInCoinReturn[1]++;
                coinsInMachine[1]--;
                differenceFromTransaction = Math.Round(differenceFromTransaction - 0.1, 2);
            }
            while (differenceFromTransaction >= 0.05 && coinsInMachine[2] > 0)
            {
                coinsInCoinReturn[2]++;
                coinsInMachine[2]--;
                differenceFromTransaction = Math.Round(differenceFromTransaction - 0.05, 2);
            }
        }

        public string checkCoinReturn()
        {
            string coinReturnString;
            if (coinsInCoinReturn[0] == 0 && coinsInCoinReturn[1] == 0 && coinsInCoinReturn[2] == 0)
            {
                if (String.IsNullOrEmpty(invalidObjectsInCoinReturn))
                    return "Coin return is empty";
                else
                    coinReturnString = "Retrieved " + invalidObjectsInCoinReturn;
            }
            else if (!String.IsNullOrEmpty(invalidObjectsInCoinReturn))
                coinReturnString = string.Format("Retrieved {0}, {1} quarters, {2} dimes, and {3} nickels", invalidObjectsInCoinReturn, coinsInCoinReturn[0], coinsInCoinReturn[1],coinsInCoinReturn[2]);
            else
                coinReturnString = string.Format("Retrieved {0} quarters, {1} dimes, and {2} nickels", coinsInCoinReturn[0], coinsInCoinReturn[1], coinsInCoinReturn[2]);
            Array.Clear(coinsInCoinReturn, 0, 3);
            invalidObjectsInCoinReturn = "";
            return coinReturnString;
        }

        public void returnCoins()
        {
            returnCoins(insertedCurrencyCount);
        }
    }
}
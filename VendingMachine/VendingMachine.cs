using System;

namespace PillarVendingMachine
{
    public class VendingMachine
    {
        private double insertedCurrencyCount;

        public VendingMachine()
        {
            insertedCurrencyCount = 0;
        }

        public string checkDisplay()
        {
            if(insertedCurrencyCount == 0)
                return "INSERT COIN";
            return insertedCurrencyCount.ToString("##0.00");
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
    }
}
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
            if (coinString.ToLower().Equals("quarter"))
                insertedCurrencyCount += 0.25;
            else
                insertedCurrencyCount += 0.10;
        }
    }
}
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
            return "" + insertedCurrencyCount;
        }

        public void insertCoin(string coinString)
        {
            insertedCurrencyCount += 0.25;
        }
    }
}
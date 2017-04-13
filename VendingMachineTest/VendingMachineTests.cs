using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PillarVendingMachine;

namespace PillarVendingMachineTests
{
    [TestClass]
    public class VendingMachineTest
    {
        VendingMachine vendingMachine;

        [TestInitialize()]
        public void Initialize()
        {
            vendingMachine = new VendingMachine();
        }
        [TestMethod]
        public void InitialDisplayShowsInsertCoin()
        {
            Assert.AreEqual("INSERT COIN", vendingMachine.checkDisplay());
        }

        [TestMethod]
        public void DisplayShowsCurrencyCountAfterInsertingQuarter()
        {
            vendingMachine.insertCoin("Quarter");
            Assert.AreEqual("0.25", vendingMachine.checkDisplay());
        }

        [TestMethod]
        public void DisplayShowsCurrencyCountAfterInsertingDime()
        {
            vendingMachine.insertCoin("Dime");
            Assert.AreEqual("0.10", vendingMachine.checkDisplay());
        }
    }
}

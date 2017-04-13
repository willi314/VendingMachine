using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PillarVendingMachine;

namespace PillarVendingMachineTests
{
    [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        public void CheckInitialDisplay()
        {
            VendingMachine vendingMachine = new VendingMachine();
            Assert.AreEqual(vendingMachine.checkDisplay(), "INSERT COIN");
        }

        [TestMethod]
        public void CheckDisplayAfterInsertingQuarter()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.insertCoin("Quarter");
            Assert.AreEqual(vendingMachine.checkDisplay(), "0.25");
        }
    }
}

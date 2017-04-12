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
    }
}

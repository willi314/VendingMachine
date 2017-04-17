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
            vendingMachine = new VendingMachine(1, 1, 1, 5, 5, 5);
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
            Assert.AreEqual("$0.25", vendingMachine.checkDisplay());
        }

        [TestMethod]
        public void DisplayShowsCurrencyCountAfterInsertingDime()
        {
            vendingMachine.insertCoin("Dime");
            Assert.AreEqual("$0.10", vendingMachine.checkDisplay());
        }

        [TestMethod]
        public void DisplayShowsCurrencyCountAfterInsertingNickel()
        {
            vendingMachine.insertCoin("Nickel");
            Assert.AreEqual("$0.05", vendingMachine.checkDisplay());
        }

        [TestMethod]
        public void DisplayShowsPriceOfItemWhenNoMoneyIsInsertedAndItemIsSelected()
        {
            vendingMachine.selectCola();
            Assert.AreEqual("PRICE: $1.00", vendingMachine.checkDisplay());
            vendingMachine.selectChips();
            Assert.AreEqual("PRICE: $0.50", vendingMachine.checkDisplay());
            vendingMachine.selectCandy();
            Assert.AreEqual("PRICE: $0.65", vendingMachine.checkDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.checkDisplay());
        }

        [TestMethod]
        public void DisplayShowsThankYouAfterColaPurchaseAndBalanceReturnsToZero()
        {
            vendingMachine.insertCoin("QUARTER");
            vendingMachine.selectCola();
            Assert.AreEqual("PRICE: $1.00", vendingMachine.checkDisplay());
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("QuArTeR");
            vendingMachine.insertCoin("qUaRtEr");
            vendingMachine.selectCola();
            Assert.AreEqual("THANK YOU", vendingMachine.checkDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.checkDisplay());
        }

        [TestMethod]
        public void DisplayShowsThankYouAfterChipsPurchaseAndBalanceReturnsToZero()
        {
            vendingMachine.insertCoin("QUARTER");
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("QuArTeR");
            vendingMachine.selectChips();
            Assert.AreEqual("THANK YOU", vendingMachine.checkDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.checkDisplay());
        }

        [TestMethod]
        public void DisplayShowsThankYouAfterCandyPurchaseAndBalanceReturnsToZero()
        {
            vendingMachine.insertCoin("QUARTER");
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("QuArTeR");
            vendingMachine.selectCandy();
            Assert.AreEqual("THANK YOU", vendingMachine.checkDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.checkDisplay());
        }

        [TestMethod]
        public void MachineReturnsCorrectChangeWhenAnItemCostsLessThanTheInsertedChange()
        {
            Assert.AreEqual("Coin return is empty", vendingMachine.checkCoinReturn());
            vendingMachine.insertCoin("QUARTER");
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("QuArTeR");
            vendingMachine.insertCoin("qUaRtEr");
            vendingMachine.insertCoin("qUaRtEr");
            vendingMachine.selectCandy();
            Assert.AreEqual("Retrieved 2 quarters, 1 dimes, and 0 nickels", vendingMachine.checkCoinReturn());
            Assert.AreEqual("Coin return is empty", vendingMachine.checkCoinReturn());
        }

        [TestMethod]
        public void DisplayShowsSoldOutWhenItemThatIsOutOfStockIsSelected()
        {
            vendingMachine.insertCoin("QUARTER");
            vendingMachine.insertCoin("quarter");
            vendingMachine.selectChips();
            Assert.AreEqual("THANK YOU", vendingMachine.checkDisplay());
            vendingMachine.selectChips();
            Assert.AreEqual("SOLD OUT", vendingMachine.checkDisplay());
            vendingMachine.insertCoin("QUARTER");
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("QUARTER");
            vendingMachine.insertCoin("quarter");
            vendingMachine.selectCola();
            vendingMachine.selectCola();
            Assert.AreEqual("SOLD OUT", vendingMachine.checkDisplay());
            vendingMachine.insertCoin("QUARTER");
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("quarter");
            vendingMachine.selectCandy();
            vendingMachine.selectCandy();
            Assert.AreEqual("SOLD OUT", vendingMachine.checkDisplay());
            Assert.AreEqual("INSERT COIN", vendingMachine.checkDisplay());
        }

        [TestMethod]
        public void MachinePutsInvalidObjectsIntoCoinReturn()
        {
            vendingMachine.insertCoin("penny");
            Assert.AreEqual("Retrieved a penny", vendingMachine.checkCoinReturn());
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("quarter");
            vendingMachine.selectChips();
            vendingMachine.insertCoin("penny");
            Assert.AreEqual("Retrieved a penny, 1 quarters, 0 dimes, and 0 nickels", vendingMachine.checkCoinReturn());
        }

        [TestMethod]
        public void MachineDisplaysExactChangeOnlyWhenItCantMakeChangeForAnyOfTheItemsItSells()
        {
            vendingMachine = new VendingMachine();
            Assert.AreEqual("EXACT CHANGE ONLY", vendingMachine.checkDisplay());
            vendingMachine = new VendingMachine(3, 3, 3, 0, 0, 1);
            Assert.AreEqual("INSERT COIN", vendingMachine.checkDisplay());
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("dime");
            vendingMachine.insertCoin("dime");
            vendingMachine.selectCandy();
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("quarter");
            vendingMachine.selectCandy();
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("quarter");
            vendingMachine.selectCandy();
            Assert.AreEqual("THANK YOU", vendingMachine.checkDisplay());
            Assert.AreEqual("EXACT CHANGE ONLY", vendingMachine.checkDisplay());
        }

        [TestMethod]
        public void MachineReturnsCorrectAmountOfMoneyWhenReturnCoinsButtonIsPressed()
        {
            vendingMachine.insertCoin("quarter");
            vendingMachine.insertCoin("dime");
            vendingMachine.insertCoin("nickel");
            vendingMachine.returnCoins();
            Assert.AreEqual("Retrieved 1 quarters, 1 dimes, and 1 nickels", vendingMachine.checkCoinReturn());
        }
    }
}

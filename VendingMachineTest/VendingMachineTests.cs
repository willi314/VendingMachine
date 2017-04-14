﻿using System;
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
    }
}

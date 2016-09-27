using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLib;

namespace UnitTestProject
{
    [TestClass]
    public class Opgave1Test
    {
        Customer c1 = new Customer();
        Account a1 = new Account();
        Account a2 = new Account();
        Account a3 = new Account();

        [TestInitialize]
        public void init()
        {
            a1.MinBalance = 0;
            c1.AddAccount(a1);
        }

        [TestMethod]
        public void TestAddAccount()
        {
            Customer c = new Customer();
            Account a = new Account();

            Assert.AreEqual(0, c.accounts.Count);
            c.AddAccount(a);
            Assert.AreEqual(1, c.accounts.Count);

        }
        [TestMethod]
        public void TestDeposit()
        {
            Assert.AreEqual(0, a1.Balance);
            a1.deposit(100);
            Assert.AreEqual(100, a1.Balance);
        }

        [TestMethod]
        public void TestWithdraw()
        {
            Assert.AreEqual(0, a1.Balance);
            a1.deposit(100);
            Assert.AreEqual(100, a1.Balance);
            a1.withdraw(100);
            Assert.AreEqual(0, a1.Balance);
        }
        [TestMethod]
        [ExpectedException(typeof(IlligalWithdrawException))]
        public void TestWithdrawException()
        {
            a1.withdraw(999);
        }
    }
}

using NUnit.Framework;
using System;

namespace NUnitSample
{
    [TestFixture]  // indicates that this is an NUnit test class
    public class AccountTest
    {
        Account source;
        Account destination;

        [SetUp] // indicates that this method will be applied first to any test method.
        public void Init()
        {
            source = new Account();
            source.Deposit(200m);

            destination = new Account();
            destination.Deposit(150m);
        }

        [Test] // indicates that this is a NUnit test method and it will be run with the NUnit runner.
        public void TransferFunds()
        {
            /*
             * This initialization is now on SetUp
            Account source = new Account();
            source.Deposit(200m);

            Account destination = new Account();
            destination.Deposit(150m);
            */

            source.TransferFunds(destination, 100m);

            Assert.AreEqual(250m, destination.Balance);
            Assert.AreEqual(100m, source.Balance);
        }

        [Test]        
        [Ignore("Decide how to implement transaction management")] // indicates that this method will not be run by the test runner.
        public void TransferWithInsufficientFundsAtomicity()
        {
            try
            {
                source.TransferFunds(destination, 300m);
            }
            catch (InsufficientFundsException expected)
            {
                Console.Write(expected.Message);
            }

            Assert.AreEqual(200m, source.Balance);
            Assert.AreEqual(150m, destination.Balance);            
        }
    }
}
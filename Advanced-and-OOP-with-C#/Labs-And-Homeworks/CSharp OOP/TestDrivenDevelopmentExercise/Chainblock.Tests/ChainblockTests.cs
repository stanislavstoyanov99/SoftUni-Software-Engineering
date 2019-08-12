using NUnit.Framework;
using System;

using Chainblock.Models;
using Chainblock.Contracts;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private Chainblock.Models.Chainblock chainblock;
        private Transaction transaction;

        private const int id = 1;
        private const TransactionStatus ts = TransactionStatus.Successfull;
        private const string from = "Pesho";
        private const string to = "Gosho";
        private const double amount = 650;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Models.Chainblock();
            this.transaction = new Transaction(id, ts, from, to, amount);

            // First add occurs here
            this.chainblock.Add(this.transaction);
        }

        [Test]
        public void Test_If_Add_Works_Correctly()
        {
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void Test_Adding_Same_Transaction_Twice()
        {
            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.Add(this.transaction));
        }

        [Test]
        public void Test_If_ContainsBy_Transaction_Works_Correctly()
        {
            bool actualResult = this.chainblock.Contains(this.transaction);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void Test_If_Contains_Non_Existant_Transaction()
        {
            Transaction nonExistantTr = new Transaction(10, TransactionStatus.Unauthorized, from, to, amount);

            bool result = this.chainblock.Contains(nonExistantTr);

            Assert.IsFalse(result);
        }

        [Test]
        public void Test_Contains_By_Id()
        {
            bool result = this.chainblock.Contains(id);

            Assert.IsTrue(result);
        }

        [Test]
        public void Test_Non_Existant_Id()
        {
            bool result = this.chainblock.Contains(5);

            Assert.IsFalse(result);
        }

        [Test]
        public void Test_Contains_With_Negative_Id()
        {
            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.Contains(-5));
        }

        [Test]
        public void Test_If_Count_Works_Correctly()
        {
            int expectedCount = 2;

            Transaction newTr = new Transaction(2, TransactionStatus.Failed, from, to, amount);

            this.chainblock.Add(newTr);

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void Test_If_Get_By_Id_Works_Correctly()
        {
            ITransaction result = this.chainblock
                .GetById(1);

            Assert.AreSame(this.transaction, result);
        }

        [Test]
        public void Test_Getting_Non_Existant_Transaction()
        {
            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.GetById(5));
        }

        [Test]
        public void Test_If_Change_TransactionStatus_Works_Correctly()
        {
            TransactionStatus newStatus = TransactionStatus.Aborted;

            this.chainblock.ChangeTransactionStatus(id, newStatus);

            ITransaction result = this.chainblock.GetById(id);

            Assert.AreEqual(newStatus, result.Status);
        } 
    }
}

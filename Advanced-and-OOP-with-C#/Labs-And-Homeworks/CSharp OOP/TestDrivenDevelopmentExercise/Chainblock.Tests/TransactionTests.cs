﻿using System;

using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private const int id = 1;
        private const TransactionStatus ts = TransactionStatus.Successfull;
        private const string from = "Pesho";
        private const string to = "Gosho";
        private const double amount = 650;

        [Test]
        public void Test_If_Constructor_Works_Correctly()
        {
            Transaction tr = new Transaction(id, ts, from, to, amount);

            Assert.AreEqual(id, tr.Id);
            Assert.AreEqual(ts, tr.Status);
            Assert.AreEqual(from, tr.From);
            Assert.AreEqual(to, tr.To);
            Assert.AreEqual(amount, tr.Amount);
        }

        [Test]
        public void Test_With_Like_Negative_Id()
        {
            int negativeId = -5;

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(negativeId, ts, from, to, amount);
            });
        }

        [Test]
        public void Test_With_Like_Space_From()
        {
            string whiteSpaceFrom = "    ";

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(id, ts, whiteSpaceFrom, to, amount);
            });
        }

        [Test]
        public void Test_With_Like_White_Space_To()
        {
            string whiteSpaceTo = "    ";

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(id, ts, from, whiteSpaceTo, amount);
            });
        }

        [Test]
        public void Test_With_Like_White_Zero_Amount()
        {
            double zeroAmount = 0;

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(id, ts, from, to, zeroAmount);
            });
        }

        [Test]
        public void Test_With_Like_White_Negative_Amount()
        {
            double negativeAmount = -10;

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(id, ts, from, to, negativeAmount);
            });
        }
    }
}

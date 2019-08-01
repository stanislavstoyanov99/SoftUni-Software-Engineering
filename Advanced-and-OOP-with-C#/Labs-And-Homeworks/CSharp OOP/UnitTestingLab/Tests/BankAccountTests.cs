using NUnit.Framework;

using Tests.Exceptions;

namespace Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount bankAccount;

        [SetUp]
        public void CreateBankAccount()
        {
            this.bankAccount = new BankAccount(100m);
        }

        [TearDown]
        public void DestroyBankAccount()
        {
            this.bankAccount = null;
        }

        [Test]
        public void TestNewBankAccount()
        {
            Assert.That(bankAccount.Balance, Is.EqualTo(100m), "Creating new Bank Account");
        }

        [Test]
        public void TestNewBankAccountWithNegativeBalance()
        {
            Assert.That(() => new BankAccount(-100m),
                Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidBalanceStateException));
        }

        [Test]
        public void TestDeposit()
        {
            bankAccount.Deposit(200m);

            Assert.That(bankAccount.Balance, Is.EqualTo(300m));
        }

        [Test]
        public void TestDepositWithNegativeSum()
        {
            Assert.That(() => bankAccount.Deposit(-100m),
                Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidSumStateException));
        }

        [Test]
        public void TestWithdraw()
        {
            decimal balance = bankAccount.Withdraw(50m);

            Assert.That(balance == bankAccount.Balance);
        }

        [Test]
        public void TestWithdrawWithNegativeSum()
        {
            Assert.That(() => bankAccount.Withdraw(-50m),
                Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidSumStateException));
        }
    }
}

using System;

using Tests.Exceptions;

public class BankAccount
{
    private decimal balance;

    public BankAccount(decimal balance)
    {
        this.Balance = balance;
    }

    public decimal Balance
    {
        get => this.balance;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidBalanceStateException);
            }

            this.balance = value;
        }
    }

    public void Deposit(decimal sum)
    {
        if (sum <= 0)
        {
            throw new ArgumentException(ExceptionMessages.InvalidSumStateException);
        }

        this.Balance += sum;
    }

    public decimal Withdraw(decimal sum)
    {
        if (sum <= 0)
        {
            throw new ArgumentException(ExceptionMessages.InvalidSumStateException);
        }

        this.Balance -= sum;

        return this.Balance;
    }
}

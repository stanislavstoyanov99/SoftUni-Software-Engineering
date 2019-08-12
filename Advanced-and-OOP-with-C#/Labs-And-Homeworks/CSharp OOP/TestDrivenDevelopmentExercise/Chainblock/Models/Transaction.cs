using System;

using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private int id;
        private TransactionStatus transactionStatus;
        private string form;
        private string to;
        private double amount;

        public Transaction(int id, TransactionStatus ts, string from, string to, double amount)
        {
            this.Id = id;
            this.Status = ts;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id
        {
            get => this.id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id value must be greater than zero.");
                }

                this.id = value;
            }
        }
        public TransactionStatus Status
        {
            get => this.transactionStatus;
            set
            {
                this.transactionStatus = value;
            }
        }
        public string From
        {
            get => this.form;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                this.form = value;
            }
        }
        public string To
        {
            get => this.to;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                this.to = value;
            }
        }
        public double Amount
        {
            get => this.amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.amount = value;
            }
        }

        public int CompareTo(ITransaction other)
        {
            throw new NotImplementedException();
        }
    }
}

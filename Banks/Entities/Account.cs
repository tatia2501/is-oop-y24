using System.Collections.Generic;

namespace Banks.Entities
{
    public abstract class Account
    {
        private Bank _bank;
        private int _id;

        public Account(double balance, Bank bank, int id)
        {
            Balance = balance;
            _bank = bank;
            _id = id;
        }

        public double Balance { get; set; }
        public Transaction LastTransaction { get; set; }

        public int ID => _id;

        public void ChangeBalance(double sum)
        {
            Balance += sum;
        }

        public virtual void Withdrawal(double sum)
        {
            var transaction = new Withdrawal(new List<Account> { this }, sum);
            transaction.DoTransaction();
        }

        public virtual void Transfer(double sum, Account account)
        {
            var transaction = new Transfer(new List<Account> { this, account }, sum);
            transaction.DoTransaction();
        }

        public void Replenishment(double sum)
        {
            var transaction = new Replenishment(new List<Account> { this }, sum);
            transaction.DoTransaction();
        }

        public void AddLastWithdrawalTransaction(double sum)
        {
            LastTransaction = new Withdrawal(new List<Account> { this }, sum);
        }

        public void AddLastReplenishmentTransaction(double sum)
        {
            LastTransaction = new Replenishment(new List<Account> { this }, sum);
        }

        public void AddLastTransferTransaction(double sum, Account account)
        {
            LastTransaction = new Transfer(new List<Account> { this, account }, sum);
        }

        public void CancelTransaction()
        {
            LastTransaction.CancelTransaction();
        }

        public virtual void Changes(int days)
        {
        }
    }
}
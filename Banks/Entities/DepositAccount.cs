using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Entities
{
    public class DepositAccount : Account
    {
        private double _percent;
        private int _period;
        private int _date;

        public DepositAccount(double balance, Bank bank, int id, double percent, int period)
            : base(balance, bank, id)
        {
            _percent = percent;
            _period = period;
            _date = 0;
        }

        public override void Withdrawal(double sum)
        {
            if (_date >= _period)
            {
                var transaction = new Withdrawal(new List<Account> { this }, sum);
                transaction.DoTransaction();
            }
            else
            {
                throw new BanksException("You can't withdrawal money");
            }
        }

        public override void Transfer(double sum, Account account)
        {
            if (_date >= _period)
            {
                var transaction = new Transfer(new List<Account> { this, account }, sum);
                transaction.DoTransaction();
            }
            else
            {
                throw new BanksException("You can't transfer money");
            }
        }

        public void ChangePercent(double percent)
        {
            _percent = percent;
        }

        public override void Changes(int days)
        {
            Balance += Balance * _percent * days;
            _date += days;
        }
    }
}
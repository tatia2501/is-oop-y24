using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Entities
{
    public class DebitAccount : Account
    {
        private double _percent;

        public DebitAccount(double balance, Bank bank, int id, double percent)
            : base(balance, bank, id)
        {
            _percent = percent;
        }

        public double Percent => _percent;

        public override void Withdrawal(double sum)
        {
            if (Balance >= sum)
            {
                var transaction = new Withdrawal(new List<Account> { this }, sum);
                transaction.DoTransaction();
            }
            else
            {
                throw new BanksException("You can't withdrawal money");
            }
        }

        public void ChangePercent(double percent)
        {
            _percent = percent;
        }

        public override void Changes(int days)
        {
            Balance += Balance * _percent * days;
        }
    }
}
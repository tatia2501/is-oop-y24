using System.Collections.Generic;

namespace Banks.Entities
{
    public class Withdrawal : Transaction
    {
        public Withdrawal(List<Account> participants, double sum)
            : base(participants, sum)
        {
        }

        public override void DoTransaction()
        {
            Participants[0].ChangeBalance(Sum * (-1));
            Participants[0].AddLastWithdrawalTransaction(Sum);
        }

        public override void CancelTransaction()
        {
            var transaction = new Replenishment(new List<Account> { Participants[0] }, Sum);
            transaction.DoTransaction();
        }
    }
}
using System.Collections.Generic;

namespace Banks.Entities
{
    public class Replenishment : Transaction
    {
        public Replenishment(List<Account> participants, double sum)
            : base(participants, sum)
        {
        }

        public override void DoTransaction()
        {
            Participants[0].ChangeBalance(Sum);
            Participants[0].AddLastReplenishmentTransaction(Sum);
        }

        public override void CancelTransaction()
        {
            var transaction = new Withdrawal(new List<Account> { Participants[0] }, Sum);
            transaction.DoTransaction();
        }
    }
}
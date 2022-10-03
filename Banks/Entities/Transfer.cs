using System.Collections.Generic;

namespace Banks.Entities
{
    public class Transfer : Transaction
    {
        public Transfer(List<Account> participants, double sum)
            : base(participants, sum)
        {
        }

        public override void DoTransaction()
        {
            Participants[0].ChangeBalance(Sum * (-1));
            Participants[1].ChangeBalance(Sum);
            Participants[0].AddLastTransferTransaction(Sum, Participants[1]);
        }

        public override void CancelTransaction()
        {
            var transaction1 = new Replenishment(new List<Account> { Participants[0] }, Sum);
            transaction1.DoTransaction();
            var transaction2 = new Withdrawal(new List<Account> { Participants[1] }, Sum);
            transaction2.DoTransaction();
        }
    }
}
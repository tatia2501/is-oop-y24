using System.Collections.Generic;

namespace Banks.Entities
{
    public abstract class Transaction
    {
        public Transaction(List<Account> participants, double sum)
        {
            Participants = participants;
            Sum = sum;
        }

        public List<Account> Participants { get; set; }
        public double Sum { get; set; }

        public virtual void DoTransaction()
        {
        }

        public virtual void CancelTransaction()
        {
        }
    }
}
namespace Banks.Entities
{
    public class CreditAccount : Account
    {
        private double _fee;
        private double _limit;

        public CreditAccount(double balance, Bank bank, int id, double fee, double limit)
            : base(balance, bank, id)
        {
            _fee = fee;
            _limit = limit;
        }

        public void ChangeFee(double fee)
        {
            _fee = fee;
        }

        public void ChangeLimit(double limit)
        {
            _limit = limit;
        }

        public override void Changes(int days)
        {
            if (Balance <= _limit * (-1))
            {
                Balance -= Balance * _fee * days;
            }
        }
    }
}
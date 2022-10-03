using System.Collections.Generic;

namespace Banks.Entities
{
    public class CentralBank
    {
        private List<Bank> _banks;

        public CentralBank()
        {
            _banks = new List<Bank>();
        }

        public List<Bank> Banks => _banks;
        public void AddBank(Bank bank)
        {
            _banks.Add(bank);
        }

        public void AddClient(Client client, Bank bank)
        {
            bank.AddClient(client);
        }

        public Account AddDebitAccount(Bank bank, Client client, double sum)
        {
            return bank.AddAccountToClient(client, "debit", sum);
        }

        public Account AddCreditAccount(Bank bank, Client client, double sum)
        {
            return bank.AddAccountToClient(client, "credit", sum);
        }

        public Account AddDepositAccount(Bank bank, Client client, double sum)
        {
            return bank.AddAccountToClient(client, "deposit", sum);
        }

        public void ChangePercentDebit(Bank bank, double newPercent)
        {
            bank.ChangePercentDebit(newPercent);
        }

        public void ChangeLimitCredit(Bank bank, double newLimit)
        {
            bank.ChangeLimitCredit(newLimit);
        }

        public void ChangeFeeCredit(Bank bank, double newFee)
        {
            bank.ChangeFeeCredit(newFee);
        }

        public void ChangeLimit(Bank bank, double newLimit)
        {
            bank.ChangeLimit(newLimit);
        }

        public void Replenishment(Bank bank, Client client, Account account, double sum)
        {
            bank.Replenishment(account, client, sum);
        }

        public void Withdrawal(Bank bank, Client client, Account account, double sum)
        {
            bank.Withdrawal(account, client, sum);
        }

        public void Transfer(Bank bank, Client client, Account account1, Account account2, double sum)
        {
            bank.Transfer(account1, account2, client, sum);
        }

        public void CancelTransaction(Account account)
        {
            account.CancelTransaction();
        }

        public void Changes(int days)
        {
            foreach (Bank bank in _banks)
            {
                bank.Changes(days);
            }
        }
    }
}
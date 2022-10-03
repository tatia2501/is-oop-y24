using System;
using System.Collections.Generic;
using Banks.Entities;

namespace Banks.Console
{
    public class Controller
    {
        private CentralBank _centralBank = new CentralBank();

        public void AddClient(Bank bank, string name, string surname, string address, string passport)
        {
            var builder = new Client.ClientBuilder();
            Client client = builder.SetName(name).
                SetSurname(surname).
                SetAddress(address).
                SetPassport(passport).
                SetBank(bank).
                GetClient();
            _centralBank.AddClient(client, bank);
        }

        public void AddBank(string name, double limit, double percentDebit, double percentDepositOne, double percentDepositTwo, double percentDepositThree, int periodDeposit, double limitCredit, double feeCredit)
        {
            var builder = new Bank.BankBuilder();
            Bank bank = builder.SetName(name).
                SetLimit(limit).
                SetPercentDebit(percentDebit)
                .SetPercentDepositOne(percentDepositOne).
                SetPercentDepositTwo(percentDepositTwo)
                .SetPercentDepositThree(percentDepositThree).
                SetPeriodDeposit(periodDeposit).
                SetLimitCredit(limitCredit).
                SetFeeCredit(feeCredit)
                .GetBank();
            _centralBank.AddBank(bank);
        }

        public void AddPassport(string surname, string passport)
        {
            Client client = FindClient(surname);
            client.AddPassport(passport);
        }

        public void AddAddress(string surname, string address)
        {
            Client client = FindClient(surname);
            client.AddAddress(address);
        }

        public List<Bank> GetBanks()
        {
            return _centralBank.Banks;
        }

        public Client FindClient(string surname)
        {
            foreach (Bank bank in _centralBank.Banks)
            {
                foreach (Client client in bank.Clients)
                {
                    if (client.Surname == surname)
                    {
                        return client;
                    }
                }
            }

            return null;
        }

        public List<Account> GetClientsAccounts(string surname)
        {
            Client client = FindClient(surname);
            return client.Accounts;
        }

        public Account FindAccount(Client client, string id)
        {
            foreach (Account acc in client.Accounts)
            {
                if (acc.ID == Convert.ToInt32(id))
                {
                    return acc;
                }
            }

            return null;
        }

        public void Replenishment(string surname, string sum, string id)
        {
            Client client = FindClient(surname);
            Account account = FindAccount(client, id);
            _centralBank.Replenishment(client.Bank, client, account, Convert.ToInt32(sum));
        }

        public void Withdrawal(string surname, string sum, string id)
        {
            Client client = FindClient(surname);
            Account account = FindAccount(client, id);
            _centralBank.Withdrawal(client.Bank, client, account, Convert.ToInt32(sum));
        }

        public void Transfer(string surname, string sum, string id1, string id2, string surname2)
        {
            Client client = FindClient(surname);
            Client client2 = FindClient(surname2);
            Account account = FindAccount(client, id1);
            Account account2 = FindAccount(client2, id2);
            _centralBank.Transfer(client.Bank, client, account, account2, Convert.ToInt32(sum));
        }

        public void AddDebitAccount(string surname, string sum)
        {
            Client client = FindClient(surname);
            _centralBank.AddDebitAccount(client.Bank, client, Convert.ToInt32(sum));
        }

        public void AddDepositAccount(string surname, string sum)
        {
            Client client = FindClient(surname);
            _centralBank.AddDepositAccount(client.Bank, client, Convert.ToInt32(sum));
        }

        public void AddCreditAccount(string surname, string sum)
        {
            Client client = FindClient(surname);
            _centralBank.AddCreditAccount(client.Bank, client, Convert.ToInt32(sum));
        }

        public void ChangePercentDebit(Bank bank, string percent)
        {
            _centralBank.ChangePercentDebit(bank, Convert.ToInt32(percent));
        }

        public void ChangeLimitCredit(Bank bank, string limit)
        {
            _centralBank.ChangeLimitCredit(bank, Convert.ToInt32(limit));
        }

        public void ChangeFeeCredit(Bank bank, string fee)
        {
            _centralBank.ChangeFeeCredit(bank, Convert.ToInt32(fee));
        }

        public void ChangeLimit(Bank bank, string limit)
        {
            _centralBank.ChangeLimit(bank, Convert.ToInt32(limit));
        }

        public void CancelTransaction(string surname, string id)
        {
            Client client = FindClient(surname);
            Account account = FindAccount(client, id);
            _centralBank.CancelTransaction(account);
        }
    }
}
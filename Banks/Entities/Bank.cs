using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Banks.Tools;

namespace Banks.Entities
{
    public class Bank
    {
        private static int id = 1;
        private string _name;
        private List<Client> _clients;
        private List<Account> _accounts;
        private double _limit;
        private double _percentDebit;
        private double _percentDepositOne;
        private double _percentDepositTwo;
        private double _percentDepositThree;
        private int _periodDeposit;
        private double _limitCredit;
        private double _feeCredit;

        private Bank(string name, double limit, double percentDebit, double percentDepositOne, double percentDepositTwo, double percentDepositThree, int periodDeposit, double limitCredit, double feeCredit)
        {
            _name = name;
            _clients = new List<Client>();
            _accounts = new List<Account>();
            _limit = limit;
            _percentDebit = percentDebit;
            _percentDepositOne = percentDepositOne;
            _percentDepositTwo = percentDepositTwo;
            _percentDepositThree = percentDepositThree;
            _periodDeposit = periodDeposit;
            _limitCredit = limitCredit;
            _feeCredit = feeCredit;
        }

        public string Name => _name;
        public List<Client> Clients => _clients;
        public void AddClient(Client client)
        {
            if (_clients.Contains(client))
            {
                throw new BanksException("Client is already exists.");
            }

            _clients.Add(client);
        }

        public Account AddAccountToClient(Client client, string type, double sum)
        {
            switch (type)
            {
                case "credit":
                    var creditAccount = new CreditAccount(sum, this, id, _feeCredit, _limitCredit);
                    id++;
                    client.AddAccount(creditAccount);
                    _accounts.Add(creditAccount);
                    return creditAccount;
                case "debit":
                    var debitAccount = new DebitAccount(sum, this, id, _percentDebit);
                    id++;
                    client.AddAccount(debitAccount);
                    _accounts.Add(debitAccount);
                    return debitAccount;
                case "deposit":
                    if (sum > 500000)
                    {
                        var depositAccount = new DepositAccount(sum, this, id, _percentDepositOne, _periodDeposit);
                        id++;
                        client.AddAccount(depositAccount);
                        _accounts.Add(depositAccount);
                        return depositAccount;
                    }

                    if (sum < 500000 && sum > 100000)
                    {
                        var depositAccount = new DepositAccount(sum, this, id, _percentDepositTwo, _periodDeposit);
                        id++;
                        client.AddAccount(depositAccount);
                        _accounts.Add(depositAccount);
                        return depositAccount;
                    }
                    else
                    {
                        var depositAccount = new DepositAccount(sum, this, id, _percentDepositThree, _periodDeposit);
                        id++;
                        client.AddAccount(depositAccount);
                        _accounts.Add(depositAccount);
                        return depositAccount;
                    }
            }

            return null;
        }

        public void ChangePercentDebit(double percentDebit)
        {
            _percentDebit = percentDebit;
            foreach (DebitAccount account in _accounts.OfType<DebitAccount>())
            {
                account.ChangePercent(percentDebit);
            }

            foreach (Client client in _clients)
            {
                client.News("Percent in debit account changes");
            }
        }

        public void ChangeLimitCredit(double limitCredit)
        {
            _limitCredit = limitCredit;
            foreach (CreditAccount account in _accounts.OfType<CreditAccount>())
            {
                account.ChangeLimit(limitCredit);
            }

            foreach (Client client in _clients)
            {
                client.News("Limit in credit account changes");
            }
        }

        public void ChangeFeeCredit(double feeCredit)
        {
            _feeCredit = feeCredit;
            foreach (CreditAccount account in _accounts.OfType<CreditAccount>())
            {
                account.ChangeFee(feeCredit);
            }

            foreach (Client client in _clients)
            {
                client.News("Fee in credit account changes");
            }
        }

        public void ChangeLimit(double limit)
        {
            _limit = limit;
        }

        public void Replenishment(Account account, Client client, double sum)
        {
            if (!client.Accounts.Contains(account))
            {
                throw new BanksException("Account doesn't exist");
            }

            account.Replenishment(sum);
        }

        public void Withdrawal(Account account, Client client, double sum)
        {
            if (!client.Accounts.Contains(account))
            {
                throw new BanksException("Account doesn't exist");
            }

            if ((client.Passport == null || client.Address == null) && sum > _limit)
            {
                throw new BanksException("You can't do it");
            }

            account.Withdrawal(sum);
        }

        public void Transfer(Account account1, Account account2, Client client, double sum)
        {
            if ((client.Passport == null || client.Address == null) && sum > _limit)
            {
                throw new BanksException("You can't do it");
            }

            account1.Transfer(sum, account2);
        }

        public void Changes(int days)
        {
            foreach (Account account in _accounts)
            {
                account.Changes(days);
            }
        }

        public class BankBuilder
        {
            private string _name;
            private double _limit;
            private double _percentDebit;
            private double _percentDepositOne;
            private double _percentDepositTwo;
            private double _percentDepositThree;
            private int _periodDeposit;
            private double _limitCredit;
            private double _feeCredit;

            public BankBuilder SetName(string name)
            {
                _name = name;
                return this;
            }

            public BankBuilder SetLimit(double limit)
            {
                _limit = limit;
                return this;
            }

            public BankBuilder SetPercentDebit(double percentDebit)
            {
                _percentDebit = percentDebit;
                return this;
            }

            public BankBuilder SetPercentDepositOne(double percentDepositOne)
            {
                _percentDepositOne = percentDepositOne;
                return this;
            }

            public BankBuilder SetPercentDepositTwo(double percentDepositTwo)
            {
                _percentDepositTwo = percentDepositTwo;
                return this;
            }

            public BankBuilder SetPercentDepositThree(double percentDepositThree)
            {
                _percentDepositThree = percentDepositThree;
                return this;
            }

            public BankBuilder SetPeriodDeposit(int periodDeposit)
            {
                _periodDeposit = periodDeposit;
                return this;
            }

            public BankBuilder SetLimitCredit(double limitCredit)
            {
                _limitCredit = limitCredit;
                return this;
            }

            public BankBuilder SetFeeCredit(double feeCredit)
            {
                _feeCredit = feeCredit;
                return this;
            }

            public Bank GetBank() => new Bank(_name, _limit, _percentDebit, _percentDepositOne, _percentDepositTwo, _percentDepositThree, _periodDeposit, _limitCredit, _feeCredit);
        }
    }
}
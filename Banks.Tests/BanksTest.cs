using NUnit.Framework;
using Banks.Entities;
using Banks.Tools;

namespace Banks.Tests
{
    public class BanksTest
    {
        private CentralBank _centralBank;
        
        [SetUp]
        public void Setup()
        {
            _centralBank = new CentralBank();
        }

        [Test]
        public void AddAccount_TryWithdrawalWhenSuspicious()
        {
            var builder = new Bank.BankBuilder();
            Bank bank = builder.SetName("Sber").
                SetLimit(30000).
                SetPercentDebit(0.05)
                .SetPercentDepositOne(0.01).
                SetPercentDepositTwo(0.02)
                .SetPercentDepositThree(0.03).
                SetPeriodDeposit(245).
                SetLimitCredit(30000).
                SetFeeCredit(0.02).
                GetBank();
            _centralBank.AddBank(bank);
            var builder1 = new Client.ClientBuilder();
            Client client = builder1.SetName("Tatiana").
                SetSurname("Golyakova").
                SetBank(bank).
                GetClient();
            _centralBank.AddClient(client, bank);
            Account account =_centralBank.AddDebitAccount(client.Bank, client, 100000);
            Assert.Catch<BanksException>(() =>
            {
                _centralBank.Withdrawal(client.Bank, client, account, 32000);
            });
        }

        [Test]
        public void AddAccount_ChangesAfterTime()
        {
            var builder = new Bank.BankBuilder();
            Bank bank = builder.SetName("VTB").
                SetLimit(200000).
                SetPercentDebit(0.04)
                .SetPercentDepositOne(0.04).
                SetPercentDepositTwo(0.03)
                .SetPercentDepositThree(0.02).
                SetPeriodDeposit(540).
                SetLimitCredit(70000).
                SetFeeCredit(0.04).
                GetBank();
            _centralBank.AddBank(bank);
            var builder1 = new Client.ClientBuilder();
            Client client = builder1.SetName("Anna").
                SetSurname("Komova").
                SetBank(bank).
                GetClient();
            _centralBank.AddClient(client, bank);
            Account account = _centralBank.AddDepositAccount(client.Bank, client, 200000);
            _centralBank.Changes(25);
            Assert.AreEqual(account.Balance, 350000);
        }

        [Test]
        public void DoAndCancelTransaction()
        {
            var builder = new Bank.BankBuilder();
            Bank bank = builder.SetName("BSRB").
                SetLimit(300000).
                SetPercentDebit(0.01)
                .SetPercentDepositOne(0.03).
                SetPercentDepositTwo(0.02)
                .SetPercentDepositThree(0.01).
                SetPeriodDeposit(150).
                SetLimitCredit(80000).
                SetFeeCredit(0.02).
                GetBank();
            _centralBank.AddBank(bank);
            var builder1 = new Client.ClientBuilder();
            Client client = builder1.
                SetName("Maria").
                SetSurname("Teterina").
                SetBank(bank).
                GetClient();
            _centralBank.AddClient(client, bank);
            Account account = _centralBank.AddDebitAccount(client.Bank, client, 700000);
            _centralBank.Withdrawal(client.Bank, client, account, 150000);
            Assert.AreEqual(account.Balance, 550000);
            _centralBank.CancelTransaction(account);
            Assert.AreEqual(account.Balance, 700000);
        }
    }
}
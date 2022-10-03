using System;
using System.Collections.Generic;
using Banks.Entities;

namespace Banks.Console
{
    public class View
    {
        private Controller _controller = new Controller();

        public void Chat()
        {
            System.Console.WriteLine("Hello! Who are you? (bank or person)");
            string who = System.Console.ReadLine();
            switch (who)
            {
                case "bank":
                    BankOptions();
                    Chat();
                    break;
                case "person":
                    PersonOptions();
                    Chat();
                    break;
                default:
                    System.Console.WriteLine("Error. Try again");
                    break;
            }
        }

        public void PersonOptions()
        {
            System.Console.WriteLine("What do you want to do?");
            System.Console.WriteLine("1. Add passport");
            System.Console.WriteLine("2. Add address");
            System.Console.WriteLine("3. Creat profile");
            System.Console.WriteLine("4. Replenishment");
            System.Console.WriteLine("5. Withdrawal");
            System.Console.WriteLine("6. Transfer");
            System.Console.WriteLine("7. Open an account");
            System.Console.WriteLine("8. Exit");
            string aim = System.Console.ReadLine();
            switch (aim)
            {
                case "1":
                    AddPassport();
                    PersonOptions();
                    break;
                case "2":
                    AddAddress();
                    PersonOptions();
                    break;
                case "3":
                    CreatingPerson();
                    PersonOptions();
                    break;
                case "4":
                    Replenishment();
                    PersonOptions();
                    break;
                case "5":
                    Withdrawal();
                    PersonOptions();
                    break;
                case "6":
                    Transfer();
                    PersonOptions();
                    break;
                case "7":
                    CreatingAccount();
                    break;
                case "8":
                    break;
                default:
                    System.Console.WriteLine("Error. Try again");
                    break;
            }
        }

        public void AddPassport()
        {
            System.Console.WriteLine("Write your surname");
            string surname = System.Console.ReadLine();
            System.Console.WriteLine("Write your passport");
            string passport = System.Console.ReadLine();
            _controller.AddPassport(surname, passport);
        }

        public void AddAddress()
        {
            System.Console.WriteLine("Write your surname");
            string surname = System.Console.ReadLine();
            System.Console.WriteLine("Write your address");
            string address = System.Console.ReadLine();
            _controller.AddAddress(surname, address);
        }

        public void CreatingPerson()
        {
            System.Console.WriteLine("Choose bank");
            int num = 1;
            foreach (Bank bank1 in _controller.GetBanks())
            {
                System.Console.WriteLine(num + ". " + bank1.Name);
                num++;
            }

            string answer = System.Console.ReadLine();
            Bank bank = _controller.GetBanks()[Convert.ToInt32(answer) - 1];
            System.Console.WriteLine("Write your name");
            string name = System.Console.ReadLine();
            System.Console.WriteLine("Write your surname");
            string surname = System.Console.ReadLine();
            System.Console.WriteLine("Write your address or nothing");
            string address = System.Console.ReadLine();
            System.Console.WriteLine("Write your passport or nothing");
            string passport = System.Console.ReadLine();
            _controller.AddClient(bank, name, surname, address, passport);
        }

        public void Replenishment()
        {
            System.Console.WriteLine("Write your surname");
            string surname = System.Console.ReadLine();
            System.Console.WriteLine("Write the sum you want to put");
            string sum = System.Console.ReadLine();
            System.Console.WriteLine("Choose the account");
            foreach (Account acc in _controller.GetClientsAccounts(surname))
            {
                System.Console.WriteLine(acc.ID);
            }

            string account = System.Console.ReadLine();
            _controller.Replenishment(surname, sum, account);
        }

        public void Withdrawal()
        {
            System.Console.WriteLine("Write your surname");
            string surname = System.Console.ReadLine();
            System.Console.WriteLine("Write the sum you want to withdrawal");
            string sum = System.Console.ReadLine();
            System.Console.WriteLine("Choose the account");
            foreach (Account acc in _controller.GetClientsAccounts(surname))
            {
                System.Console.WriteLine(acc.ID);
            }

            string account = System.Console.ReadLine();
            _controller.Withdrawal(surname, sum, account);
        }

        public void Transfer()
        {
            System.Console.WriteLine("Write your surname");
            string surname = System.Console.ReadLine();
            System.Console.WriteLine("Write the sum you want to transfer");
            string sum = System.Console.ReadLine();
            System.Console.WriteLine("Choose the account");
            foreach (Account acc in _controller.GetClientsAccounts(surname))
            {
                System.Console.WriteLine(acc.ID);
            }

            string id1 = System.Console.ReadLine();
            System.Console.WriteLine("Write the id of account you want to transfer to");
            string id2 = System.Console.ReadLine();
            System.Console.WriteLine("Write the surname of the person you want to transfer to");
            string surname2 = System.Console.ReadLine();
            _controller.Transfer(surname, sum, id1, id2, surname2);
        }

        public void CreatingAccount()
        {
            System.Console.WriteLine("Write your surname");
            string surname = System.Console.ReadLine();
            System.Console.WriteLine("Write the sum you want to put in account");
            string sum = System.Console.ReadLine();
            System.Console.WriteLine("Write type of account (credit, debit or deposit)");
            string type = System.Console.ReadLine();
            switch (type)
            {
                case "credit":
                    _controller.AddCreditAccount(surname, sum);
                    break;
                case "debit":
                    _controller.AddDebitAccount(surname, sum);
                    break;
                case "deposit":
                    _controller.AddDepositAccount(surname, sum);
                    break;
            }
        }

        public void BankOptions()
        {
            System.Console.WriteLine("What do you want to do?");
            System.Console.WriteLine("1. Open new bank");
            System.Console.WriteLine("2. Change percent in debit account");
            System.Console.WriteLine("3. Change limit in credit account");
            System.Console.WriteLine("4. Change fee in credit account");
            System.Console.WriteLine("5. Change limit");
            System.Console.WriteLine("6. Cancel transaction");
            System.Console.WriteLine("7. Exit");
            string aim = System.Console.ReadLine();
            switch (aim)
            {
                case "1":
                    CreatingBank();
                    BankOptions();
                    break;
                case "2":
                    ChangingPercentDebit();
                    BankOptions();
                    break;
                case "3":
                    ChangingLimitCredit();
                    BankOptions();
                    break;
                case "4":
                    ChangingFeeCredit();
                    BankOptions();
                    break;
                case "5":
                    ChangingLimit();
                    BankOptions();
                    break;
                case "6":
                    CancelTracsaction();
                    BankOptions();
                    break;
                case "7":
                    break;
                default:
                    System.Console.WriteLine("Error. Try again");
                    break;
            }
        }

        public void CreatingBank()
        {
            System.Console.WriteLine("Write name");
            string name = System.Console.ReadLine();
            System.Console.WriteLine("Write limit");
            string limit = System.Console.ReadLine();
            System.Console.WriteLine("Write percent for Debit account");
            string percentDebit = System.Console.ReadLine();
            System.Console.WriteLine("Write percent for deposit account (when sum > 500000)");
            string percentDepositOne = System.Console.ReadLine();
            System.Console.WriteLine("Write percent for deposit account (when 100000 < sum < 500000)");
            string percentDepositTwo = System.Console.ReadLine();
            System.Console.WriteLine("Write  percent for deposit account (when sum < 100000)");
            string percentDepositThree = System.Console.ReadLine();
            System.Console.WriteLine("Write period for deposit account");
            string periodDeposit = System.Console.ReadLine();
            System.Console.WriteLine("Write limit for credit account");
            string limitCredit = System.Console.ReadLine();
            System.Console.WriteLine("Write fee for credit account");
            string feeCredit = System.Console.ReadLine();
            _controller.AddBank(name, Convert.ToDouble(limit), Convert.ToDouble(percentDebit), Convert.ToDouble(percentDepositOne), Convert.ToDouble(percentDepositTwo), Convert.ToDouble(percentDepositThree), Convert.ToInt32(periodDeposit), Convert.ToDouble(limitCredit), Convert.ToDouble(feeCredit));
        }

        public void ChangingPercentDebit()
        {
            System.Console.WriteLine("Choose bank");
            int num = 1;
            foreach (Bank bank1 in _controller.GetBanks())
            {
                System.Console.WriteLine(num + ". " + bank1.Name);
                num++;
            }

            string answer = System.Console.ReadLine();
            Bank bank = _controller.GetBanks()[Convert.ToInt32(answer) - 1];
            System.Console.WriteLine("Write new percent");
            string percent = System.Console.ReadLine();
            _controller.ChangePercentDebit(bank, percent);
        }

        public void ChangingLimitCredit()
        {
            System.Console.WriteLine("Choose bank");
            int num = 1;
            foreach (Bank bank1 in _controller.GetBanks())
            {
                System.Console.WriteLine(num + ". " + bank1.Name);
                num++;
            }

            string answer = System.Console.ReadLine();
            Bank bank = _controller.GetBanks()[Convert.ToInt32(answer) - 1];
            System.Console.WriteLine("Write new limit");
            string limit = System.Console.ReadLine();
            _controller.ChangeLimitCredit(bank, limit);
        }

        public void ChangingFeeCredit()
        {
            System.Console.WriteLine("Choose bank");
            int num = 1;
            foreach (Bank bank1 in _controller.GetBanks())
            {
                System.Console.WriteLine(num + ". " + bank1.Name);
                num++;
            }

            string answer = System.Console.ReadLine();
            Bank bank = _controller.GetBanks()[Convert.ToInt32(answer) - 1];
            System.Console.WriteLine("Write new fee");
            string fee = System.Console.ReadLine();
            _controller.ChangeFeeCredit(bank, fee);
        }

        public void ChangingLimit()
        {
            System.Console.WriteLine("Choose bank");
            int num = 1;
            foreach (Bank bank1 in _controller.GetBanks())
            {
                System.Console.WriteLine(num + ". " + bank1.Name);
                num++;
            }

            string answer = System.Console.ReadLine();
            Bank bank = _controller.GetBanks()[Convert.ToInt32(answer) - 1];
            System.Console.WriteLine("Write new limit");
            string limit = System.Console.ReadLine();
            _controller.ChangeLimit(bank, limit);
        }

        public void CancelTracsaction()
        {
            System.Console.WriteLine("Write your surname");
            string surname = System.Console.ReadLine();
            System.Console.WriteLine("Choose the account");
            foreach (Account acc in _controller.GetClientsAccounts(surname))
            {
                System.Console.WriteLine(acc.ID);
            }

            string id = System.Console.ReadLine();
            _controller.CancelTransaction(surname, id);
        }
    }
}
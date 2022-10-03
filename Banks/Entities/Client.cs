using System.Collections.Generic;

namespace Banks.Entities
{
    public class Client
    {
        private string _name;
        private string _surname;
        private string _address;
        private string _passport;
        private Bank _bank;
        private List<Account> _accounts;

        private Client(string name, string surname, string address, string passport, Bank bank)
        {
            _name = name;
            _surname = surname;
            _address = address;
            _passport = passport;
            _bank = bank;
            _accounts = new List<Account>();
        }

        public string Name => _name;
        public string Surname => _surname;
        public string Address => _address;
        public string Passport => _passport;
        public Bank Bank => _bank;
        public List<Account> Accounts => _accounts;

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public void AddAddress(string address)
        {
            _address = address;
        }

        public void AddPassport(string passport)
        {
            _passport = passport;
        }

        public void News(string text)
        {
            System.Console.WriteLine(text);
        }

        public class ClientBuilder
        {
            private string _name;
            private string _surname;
            private string _address;
            private string _passport;
            private Bank _bank;

            public ClientBuilder SetName(string name)
            {
                _name = name;
                return this;
            }

            public ClientBuilder SetSurname(string surname)
            {
                _surname = surname;
                return this;
            }

            public ClientBuilder SetAddress(string address)
            {
                _address = address;
                return this;
            }

            public ClientBuilder SetPassport(string passport)
            {
                _passport = passport;
                return this;
            }

            public ClientBuilder SetBank(Bank bank)
            {
                _bank = bank;
                return this;
            }

            public Client GetClient() => new Client(_name, _surname, _address, _passport, _bank);
        }
    }
}
namespace Shops.Entities
{
    public class Buyer
    {
        private string _name;
        private int _money;

        public Buyer(string name, int money)
        {
            _name = name;
            _money = money;
        }

        public string Name => _name;
        public int Money => _money;

        public void Paying(int sum)
        {
            _money -= sum;
        }
    }
}

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = CustomerManager.CraeteSingletonInstance();

            Customer customer1 = new Customer("Ali Bozlak");

            customerManager.Save(customer1);
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;

        private CustomerManager()
        {

        }

        public static CustomerManager CraeteSingletonInstance()
        {
            if (_customerManager == null)
            {
                _customerManager = new CustomerManager();
            }
            return _customerManager;
        }

        public void Save(Customer customer)
        {
            Console.WriteLine($"{customer.CustomerName} isimli müşteri veritabanına kaydedildi !!");
        }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public Customer(string customerName)
        {
            CustomerName = customerName;
        }
    }
}
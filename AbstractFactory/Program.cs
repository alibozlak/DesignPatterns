namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProductService service = new ProductManager1(new Factory1());
            service.Save();

            Console.WriteLine("--------");

            IProductService service2 = new ProductManager1(new Factory2());
            service2.Save();
        }
    }

    public interface IProductService
    {
        void Save();
    }

    public class ProductManager1 : IProductService
    {
        private Logger _logger;
        private Caching _caching;

        public ProductManager1(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _logger = crossCuttingConcernsFactory.CreateLogger();
            _caching = crossCuttingConcernsFactory.CreateCaching();
        }

        public void Save()
        {
            Console.WriteLine("Product saved with ProductManager1!");
            _logger.Log("....");
            _caching.Cache("...data...");
        }
    }

    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logger CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logger CreateLogger()
        {
            return new Log4Net();
        }
    }

    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logger CreateLogger()
        {
            return new NLogger();
        }
    }

    public abstract class Logger
    {
        public abstract void Log(string message);
    }

    public class Log4Net : Logger
    {
        public override void Log(string message) {
            Console.WriteLine($"Logged with Log4Net this message : {message}");
        }
    }

    public class NLogger : Logger
    {
        public override void Log(string message)
        {
            Console.WriteLine($"Logged with NLogger this message : {message}");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine($"Cached with MemCache this data : {data}");
        }
    }

    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine($"Cached with RedisCache this data : {data}");
        }
    }
}
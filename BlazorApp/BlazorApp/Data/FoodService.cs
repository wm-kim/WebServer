namespace BlazorApp.Data
{
    public class Food 
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public interface IFoodService
    {
        IEnumerable<Food> GetFoods();
    }


    public class FoodService : IFoodService
    {
        public IEnumerable<Food> GetFoods()
        {
            List<Food> foods = new List<Food>()
            { 
               new Food { Name = "Bibimbap", Price = 7000},
               new Food { Name = "kimbap", Price = 3000},
               new Food { Name = "Bossam", Price = 9000}
            };

            return foods;
        }
    }

    public class FastFoodService : IFoodService
    {
        public IEnumerable<Food> GetFoods()
        {
            List<Food> foods = new List<Food>()
            {
               new Food { Name = "Hamburger", Price = 500},
               new Food { Name = "Fries", Price = 2000},
            };

            return foods;
        }
    }

    // 생성자에서 사용한다고 정의만 내려주면, 실질적으로 PaymentService를 만들어주면서
    // IFoodService를 넣어주지 않아도 자동으로 ASP.NET에서 연동해준다. Dependency Injection 특징
    public class PaymentService
    {
        IFoodService _service;

        public PaymentService(IFoodService service)
        {
            _service = service;
        }

        // TODO
    }

    // 언제 생성되고 소멸되는지 알고싶어서
    public class SingletonService : IDisposable
    { 
        // Guid 간단하게 ID를 생성하는 기능
        public Guid ID { get; set; }

        public SingletonService()
        {
            ID = Guid.NewGuid(); // 랜덤으로 생성
        }

        public void Dispose()
        {
            Console.WriteLine("SingletonService Disposed");
        }
    }

    public class TransientService : IDisposable
    {
        public Guid ID { get; set; }

        public TransientService()
        {
            ID = Guid.NewGuid();
        }

        public void Dispose()
        {
            Console.WriteLine("TransientService Disposed");
        }
    }

    public class ScopedService : IDisposable
    {
        public Guid ID { get; set; }

        public ScopedService()
        {
            ID = Guid.NewGuid();
        }

        public void Dispose()
        {
            Console.WriteLine("ScopedService Disposed");
        }
    }
}

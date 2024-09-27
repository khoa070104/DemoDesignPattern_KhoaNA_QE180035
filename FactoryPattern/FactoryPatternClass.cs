namespace FactoryPattern
{
    public interface IProduct
    {
        void Operation();
    }

    public class ConcreteProductA : IProduct
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteProductA Operation");
        }
    }

    public class ConcreteProductB : IProduct
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteProductB Operation");
        }
    }

    public class ProductFactory
    {
        public static IProduct CreateProduct(string type)
        {
            switch (type)
            {
                case "A":
                    return new ConcreteProductA();
                case "B":
                    return new ConcreteProductB();
                default:
                    throw new ArgumentException("Invalid product type");
            }
        }
    }
}
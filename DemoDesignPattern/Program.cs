using System;
using FactoryPattern;
using AbsFacPattern;
using PrototypePattern;
using FactoryPattern;
using PrototypePattern;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n===== Design Pattern Tester =====");
            Console.WriteLine("1. Factory Pattern");
            Console.WriteLine("2. Abstract Factory Pattern");
            Console.WriteLine("3. Prototype Pattern");
            Console.WriteLine("4. Exit");
            Console.Write("Please choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TestFactoryPattern();
                    break;

                case "2":
                    TestAbstractFactoryPattern();
                    break;

                case "3":
                    TestPrototypePattern();
                    break;

                case "4":
                    exit = true;
                    Console.WriteLine("Exiting the program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
    static void TestFactoryPattern()
    {
        Console.WriteLine("\nFactory Pattern Demo:");
        Console.Write("Enter product type (A/B): ");
        string productType = Console.ReadLine();

        try
        {
            IProduct product = ProductFactory.CreateProduct(productType);
            product.Operation();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    static void TestAbstractFactoryPattern()
    {
        Console.WriteLine("\nAbstract Factory Pattern Demo:");
        Console.Write("Enter operating system (Windows/MacOS): ");
        string osType = Console.ReadLine();

        IGUIFactory factory = osType switch
        {
            "Windows" => new WinFactory(),
            "MacOS" => new MacFactory(),
            _ => null
        };

        if (factory != null)
        {
            var app = new Application(factory);
            app.Render();
        }
        else
        {
            Console.WriteLine("Invalid operating system choice.");
        }
    }

    static void TestPrototypePattern()
    {
        Console.WriteLine("\nPrototype Pattern Demo:");

        ShapeCache.LoadCache();

        Console.Write("Enter shape id (1 for Circle, 2 for Square): ");
        string shapeId = Console.ReadLine();

        try
        {
            Shape clonedShape = ShapeCache.GetShape(shapeId);
            clonedShape.ShowInfo();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}

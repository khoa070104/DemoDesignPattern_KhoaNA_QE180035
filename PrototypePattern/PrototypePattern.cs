namespace PrototypePattern
{
    public abstract class Shape
    {
        public string Id { get; set; }
        public string Type { get; protected set; }

        public abstract Shape Clone();

        public void ShowInfo()
        {
            Console.WriteLine($"Shape: {Type}, Id: {Id}");
        }
    }

    public class Circle : Shape
    {
        public Circle()
        {
            Type = "Circle";
        }

        public override Shape Clone()
        {
            return (Shape)this.MemberwiseClone();
        }
    }

    public class Square : Shape
    {
        public Square()
        {
            Type = "Square";
        }

        public override Shape Clone()
        {
            return (Shape)this.MemberwiseClone();
        }
    }

    public class ShapeCache
    {
        private static Dictionary<string, Shape> shapeMap = new Dictionary<string, Shape>();

        public static Shape GetShape(string shapeId)
        {
            Shape cachedShape = shapeMap[shapeId];
            return cachedShape.Clone();
        }

        public static void LoadCache()
        {
            Circle circle = new Circle { Id = "1" };
            shapeMap.Add(circle.Id, circle);

            Square square = new Square { Id = "2" };
            shapeMap.Add(square.Id, square);
        }
    }
}

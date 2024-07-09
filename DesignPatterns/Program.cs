using static System.Console;

namespace DesignPatterns
{


    public class Program
    {
        static void Main(string[] args)
        {
            // SINGLE RESPONSIBILITY
            #region
            //var j = new SingleResponsibility.Journal();
            //j.AddEntry("Suck one");
            //j.AddEntry("Suck two");
            //Console.WriteLine((j));
            #endregion

            // OPEN-CLOSED PRINCIPLE
            #region
            var apple = new Product("Apple", Color.Red, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);
            var hat = new Product("Hat", Color.Green, Size.Small);

            Product[] products = { apple, tree, house, hat };
            var productFilter = new ProductFilter();

            WriteLine("Green products (old):");
            foreach (var product in productFilter.FilterByColor(products, Color.Green))
            {
                WriteLine($"{product.Name} is {product.Color}");
            }

            var betterFilter = new BetterFilter();
            WriteLine("Green products (new):");
            foreach(var product in betterFilter.Filter(products, new ColorSpecification(Color.Green)))
            {
                WriteLine($"{product.Name} is {product.Color}");
            }

            WriteLine("Large green items");
            foreach (var product in betterFilter.Filter(products, 
                new AndSpecification<Product>(
                    new ColorSpecification(Color.Green), 
                    new SizeSpecification(Size.Large)
                    )))
            {
                WriteLine($"{product.Name} is {product.Size} and {product.Color}");
            }
            #endregion

        }
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Order order1 = new Order(new Customer("John Doe", new Address("New York", "NY", "USA")));
        order1.AddProduct(new Product("Laptop", "P001", 1200, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25, 2));
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: {order1.CalculateTotalPrice()}\n");

        Order order2 = new Order(new Customer("Jane Smith", new Address("Toronto", "ON", "Canada")));
        order2.AddProduct(new Product("Phone", "P003", 800, 1));
        order2.AddProduct(new Product("Headphones", "P004", 50, 3));
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: {order2.CalculateTotalPrice()}\n");

    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        // Create some products
        Product product1 = new Product("Laptop", 101, 999.99, 1);
        Product product2 = new Product("Headphones", 102, 199.99, 2);

        // Create an address and customer
        Address address = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer = new Customer("John Doe", address);

        // Create an order and add products
        Order order = new Order(customer);
        order.AddProduct(product1);
        order.AddProduct(product2);

        // Display order details
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Order Price: ${order.CalculateTotalOrderPrice():0.00}");
    }
}
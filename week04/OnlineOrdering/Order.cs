using System;

public class Order
{
    public List<Product> Products { get; set; }
    public List<Customer> Customers { get; set; }

    public TotalCost()
    {
        double totalCost = 0;
        foreach (Product product in Products)
        {
            totalCost += product.Price;
        }
        return totalCost;
    }

    public PackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in Products)
        {
            packingLabel += product.Name + "\n";
        }
        return packingLabel;
    }
}
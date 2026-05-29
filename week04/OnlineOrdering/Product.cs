using System;

public class Product
{
    public string Name { get; set; }
    public int ProductID { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public CostOfProduct()
    {
        return Price * Quantity;
    }
}
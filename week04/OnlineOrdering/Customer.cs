using System;

public class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public callAddress()
    {
        return Address.GetFullAddress();
    }
}
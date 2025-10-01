class Order
{
    public List<Product> products = new List<Product>();
    private Customer _customer;
    public Order(Customer customer)
    {
        _customer = customer;
    }
    public void AddProduct(Product product)
    {
        products.Add(product);
    }
    public double CalculateTotalPrice()
    {
        double total = 0;
        foreach (Product product in products)
        {
            total += product.GetTotalCost();
        }
        if (_customer.IsInUSA())
        {
            total += 5; // add $5 shipping for USA
        }
        else
        {
            total += 35; // add $35 shipping for international
        }
        return total;
    }
    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (Product product in products)
        {
            packingLabel += $" - {product.Display()}\n";
        }
        return packingLabel;
    }
    public string GetShippingLabel()
    {
        return $"Shipping Label: \n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}
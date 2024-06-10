namespace Northwind.Shared.Models;

public class Product
{
    public string Name { get; set; }

    public string QuantityPerUnit { get; set; }

    public decimal UnitPrice { get; set; }

    public int UnitsInStock { get; set; }

    public ProductStatus Status { get; set; }

    public Category Category { get; set; }

    public List<string> Values { get; set; }

    public Product()
    {
        Name = string.Empty;
        QuantityPerUnit = string.Empty;
        Category = null!;
        Values = [];
    }
}

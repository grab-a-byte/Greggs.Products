namespace Greggs.Products.Api.Models;

public sealed class Product
{
    public required string Name { get; set; }
    public decimal PriceInPounds { get; set; }
}
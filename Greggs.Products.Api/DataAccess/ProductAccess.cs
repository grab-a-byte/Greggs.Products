using System.Collections.Generic;
using System.Linq;
using Greggs.Products.Api.Models;

namespace Greggs.Products.Api.DataAccess;

/// <summary>
/// DISCLAIMER: This is only here to help enable the purpose of this exercise, this doesn't reflect the way we work!
/// </summary>
public sealed class ProductAccess : IDataAccess<Product>
{
    private static readonly Product[] ProductDatabase = 
    [
        new() { Name = "Sausage Roll", PriceInPounds = 1.45m },
        new() { Name = "Vegan Sausage Roll", PriceInPounds = 1.45m },
        new() { Name = "Steak Bake", PriceInPounds = 2.40m },
        new() { Name = "Yum Yum", PriceInPounds = 0.9m },
        new() { Name = "Pink Jammie", PriceInPounds = 1.5m },
        new() { Name = "Mexican Baguette", PriceInPounds = 4.0m },
        new() { Name = "Bacon Sandwich", PriceInPounds = 2.90m },
        new() { Name = "Coca Cola", PriceInPounds = 2.2m }
    ];

    public IEnumerable<Product> List(int? pageStart, int? pageSize)
        => ProductDatabase.Skip(pageStart ?? 0).Take(pageSize ?? 5);
}
using System;
using System.Collections.Generic;
using System.Linq;
using Greggs.Products.Api.DataAccess;
using Greggs.Products.Api.Dto;
using Greggs.Products.Api.Models;
using Greggs.Products.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Greggs.Products.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ProductController(
    IDataAccess<Product> productRepository,
    ICurrencyConversionService currencyConversionService,
    ILogger<ProductController> logger) : ControllerBase
{
    [HttpGet]
    public IEnumerable<ProductDto> Get(int pageStart = 0, int pageSize = 5, string? currencyCode = null)
    {
        logger.LogInformation("Call to {endpoint} started at {time} for currencyCode {currencyCode}", "Get Products", DateTime.Now, currencyCode);

        var products = productRepository.List(pageStart, pageSize).ToArray();
        if (currencyCode is null or "GBP")
        {
            return products.Select(p => new ProductDto(p.Name, p.PriceInPounds));
        }

        return products.Select(x =>
        {
            var convertedPrice = currencyConversionService.ConvertCurrency(x.PriceInPounds, currencyCode);
            return new ProductDto(x.Name, convertedPrice);
        });
    }
}
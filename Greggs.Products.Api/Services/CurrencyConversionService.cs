namespace Greggs.Products.Api.Services;

public sealed class CurrencyConversionService : ICurrencyConversionService
{
    public decimal ConvertCurrency(decimal amount, string? currencyCode)
        => currencyCode switch
        {
            "EUR" => amount * 1.1M,
            _ => amount
        };
}
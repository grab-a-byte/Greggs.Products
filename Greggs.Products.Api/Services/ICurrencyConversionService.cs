namespace Greggs.Products.Api.Services;

public interface ICurrencyConversionService
{
    public decimal ConvertCurrency(decimal amount, string currencyCode);
}
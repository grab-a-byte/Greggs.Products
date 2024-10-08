using System;
using Greggs.Products.Api.Services;
using Xunit;

namespace Greggs.Products.UnitTests.Services;

public sealed class CurrencyConversionServiceTests
{
    private readonly CurrencyConversionService _currencyConversionService = new();
    [Theory]
    [InlineData(1, null, 1)]
    [InlineData(1, "EUR", 1.1)]
    [InlineData(1, "UNKNOWN", 1)]
    public void Convert_GivenAmountAndCurrencyCode_ReturnsValue(int value, string? currencyCode, float expected)
    {
        decimal result = _currencyConversionService.ConvertCurrency(value, currencyCode);
        var decimalExpected = Convert.ToDecimal(expected);
        Assert.True(decimalExpected == result);

    }
}
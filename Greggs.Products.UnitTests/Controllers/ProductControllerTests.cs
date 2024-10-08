using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using Greggs.Products.Api.Controllers;
using Greggs.Products.Api.DataAccess;
using Greggs.Products.Api.Dto;
using Greggs.Products.Api.Models;
using Greggs.Products.Api.Services;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Greggs.Products.UnitTests.Controllers;

public sealed class ProductControllerTests
{
    private readonly IDataAccess<Product> _mockDataAccess;
    private readonly ICurrencyConversionService _mockCurrencyConversionService;

    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        _mockDataAccess = A.Fake<IDataAccess<Product>>();
        _mockCurrencyConversionService = A.Fake<ICurrencyConversionService>();
        _controller = new(_mockDataAccess, _mockCurrencyConversionService, NullLogger<ProductController>.Instance);
    }

    [Fact]
    public void Get_GivenARequestWithNoCurrencyCode_DoesNotCallCurrencyConversion()
    {    
        //Arrange
        A.CallTo(() => _mockDataAccess.List(A<int>._, A<int>._)).Returns([new Product() { Name = "Test", PriceInPounds = 1 }]);

        //Act
        IEnumerable<ProductDto> result = _controller.Get(0, 5, null);

        //Assert
        A.CallTo(() => _mockCurrencyConversionService.ConvertCurrency(A<decimal>._, A<string>._)).MustNotHaveHappened();
    }

    [Fact]
    public void Get_GivenARequestWithACurrencyCode_CallsCurrencyConversion()
    {
        //Arrange
        A.CallTo(() => _mockDataAccess.List(A<int>._, A<int>._)).Returns([new Product() { Name = "Test", PriceInPounds = 1 }]);

        //Act
        List<ProductDto> result = _controller.Get(0, 5, "EUR").ToList();

        //Assert
        A.CallTo(() => _mockCurrencyConversionService.ConvertCurrency(A<decimal>._, A<string>._)).MustHaveHappened();
    }
}

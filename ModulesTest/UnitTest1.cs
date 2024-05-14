namespace Modules;

public class SumModuleTests
{
	[Fact]
	public void Sum_ValidInput_ReturnsCorrectResult()
	{
		// Arrange

		// Act
		long result = SumModule.Sum("10", "20");

		// Assert
		Assert.Equal(30, result);
	}

	[Theory]
	[InlineData("abc", "20")]
	[InlineData("10", "def")]
	[InlineData("", "123")]
	[InlineData("456", "")]
	[InlineData("", "")]
	public void Sum_InvalidInputFormat_ThrowsArgumentException(string param1, string param2)
	{
		// Arrange

		// Act

		// Assert
		Assert.Throws<ArgumentException>(() => SumModule.Sum(param1, param2));
	}

	[Theory]
	[InlineData("2147483648", "1")]
	[InlineData("1", "2147483648")]
	[InlineData("-2147483649", "1")]
	[InlineData("1", "-2147483649")]
	public void Sum_OutOfRange_ThrowsArgumentException(string param1, string param2)
	{
		Assert.Throws<ArgumentException>(() => SumModule.Sum(param1, param2));
	}

	[Theory]
	[InlineData("0", "0")]
	[InlineData("-1", "-1")]
	[InlineData("2147483647", "0")]
	[InlineData("0", "2147483647")]
	[InlineData("-2147483648", "0")]
	[InlineData("0", "-2147483648")]
	public void Sum_EdgeCases_ReturnsCorrectResult(string param1, string param2)
	{
		// Arrange
		long expected = long.Parse(param1) + long.Parse(param2);

		// Act
		long result = SumModule.Sum(param1, param2);

		// Assert
		Assert.Equal(expected, result);
	}
}
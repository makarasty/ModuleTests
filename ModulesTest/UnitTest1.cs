using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;

namespace Modules;

public class SumModuleTests
{

	[Fact]
	public void SumRandomNumber_ValidInput_ReturnsCorrectResult()
	{
		// Arrange
		var random = new Random();
		var r1 = random.Next(int.MinValue, int.MaxValue).ToString();
		var r2 = random.Next(int.MinValue, int.MaxValue).ToString();
		long trueSum = long.Parse(r1) + long.Parse(r2);

		// Act
		long result = SumModule.Sum(r1, r2);

		// Assert
		Assert.Equal(trueSum, result);
	}

	[Theory]
	[InlineData("abc", "123", "param1")]
	[InlineData("", "123", "param1")]
	[InlineData("123", "abc", "param2")]
	[InlineData("123", "", "param2")]
	public void Sum_InvalidInputFormat_ThrowsArgumentExceptionForParam1(string param1, string param2, string invalidParamName)
	{
		// Arrange
		var param1ErrorText = $"Не вірний формат числа для параметра {invalidParamName}";

		// Act
		var ex = Assert.Throws<ArgumentException>(() => SumModule.Sum(param1, param2));

		// Assert
		Assert.Contains(param1ErrorText, ex.Message);
	}

	[Theory]
	[InlineData("param1")]
	[InlineData("param2")]
	public void OutOfMaxRange_ThrowsArgumentException_WithCurrentText(string paramName)
	{
		// Arrange
		var paramErrorText = $"Перевищено максимальне значення для параметра {paramName}";

		var param1 = "0";
		var param2 = "0";

		if (paramName == "param1")
		{
			param1 = ((long)int.MaxValue + 1).ToString();
		}
		else
		{
			param2 = ((long)int.MaxValue + 1).ToString();
		}

		// Act
		var ex = Assert.Throws<ArgumentException>(() => SumModule.Sum(param1, param2));

		// Assert
		Assert.Contains(paramErrorText, ex.Message);
	}

	[Theory]
	[InlineData("param1")]
	[InlineData("param2")]
	public void OutOfMinRange_ThrowsArgumentException_WithCurrentText(string paramName)
	{
		// Arrange
		var paramErrorText = $"Перевищено мінімальне значення для параметра {paramName}";

		var param1 = "0";
		var param2 = "0";

		if (paramName == "param1")
		{
			param1 = ((long)int.MinValue - 1).ToString();
		}
		else
		{
			param2 = ((long)int.MinValue - 1).ToString();
		}

		// Act
		var ex = Assert.Throws<ArgumentException>(() => SumModule.Sum(param1, param2));

		// Assert
		Assert.Contains(paramErrorText, ex.Message);
	}
}
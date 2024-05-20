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
	[InlineData("abc", "20")]
	[InlineData("", "123")]
	public void Sum_InvalidInputFormat_ThrowsArgumentExceptionForParam1(string param1, string param2)
	{
		// Arrange
		var param1ErrorText = "Не вірний формат числа для параметра param1";

		// Act
		var ex = Assert.Throws<ArgumentException>(() => SumModule.Sum(param1, param2));

		// Assert
		Assert.Contains(param1ErrorText, ex.Message);
	}
	[Theory]
	[InlineData("10", "def")]
	[InlineData("456", "")]
	public void Sum_InvalidInputFormat_ThrowsArgumentExceptionForParam2(string param1, string param2)
	{
		// Arrange
		var param2ErrorText = "Не вірний формат числа для параметра param2";

		// Act
		var ex = Assert.Throws<ArgumentException>(() => SumModule.Sum(param1, param2));

		// Assert
		Assert.Contains(param2ErrorText, ex.Message);
	}

	[Fact]
	public void Param1_OutOfMaxRange_ThrowsArgumentException_WithCurrentText()
	{
		// Arrange
		var param1ErrorText = "Перевищено максимальне значення для параметра param1";
		var param1 = ((long)int.MaxValue + 1).ToString();
		var param2 = "0";

		// Act
		var ex = Assert.Throws<ArgumentException>(() => SumModule.Sum(param1, param2));

		// Assert
		Assert.Contains(param1ErrorText, ex.Message);
	}

	[Fact]
	public void Param2_OutOfMaxRange_ThrowsArgumentException_WithCurrentText()
	{
		// Arrange
		var param1 = "0";
		var param2ErrorText = "Перевищено максимальне значення для параметра param2";
		var param2 = ((long)int.MaxValue + 1).ToString();

		// Act
		var ex = Assert.Throws<ArgumentException>(() => SumModule.Sum(param1, param2));

		// Assert
		Assert.Contains(param2ErrorText, ex.Message);
	}

	[Fact]
	public void Param1_OutOfMinRange_ThrowsArgumentException_WithCurrentText()
	{
		// Arrange
		var param1ErrorText = "Перевищено мінімальне значення для параметра param1";
		var param1 = ((long)int.MinValue - 1).ToString();
		var param2 = "0";

		// Act
		var ex = Assert.Throws<ArgumentException>(() => SumModule.Sum(param1, param2));

		// Assert
		Assert.Contains(param1ErrorText, ex.Message);
	}
	[Fact]
	public void Param2_OutOfMinRange_ThrowsArgumentException_WithCurrentText()
	{
		// Arrange
		var param1 = "0";
		var param2ErrorText = "Перевищено мінімальне значення для параметра param2";
		var param2 = ((long)int.MinValue - 1).ToString();

		// Act
		var ex = Assert.Throws<ArgumentException>(() => SumModule.Sum(param1, param2));

		// Assert
		Assert.Contains(param2ErrorText, ex.Message);
	}
}
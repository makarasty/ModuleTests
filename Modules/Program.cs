namespace Modules;

class Program
{
	static void Main()
	{
		string f = "2";
		string s = "2";
		long r = SumModule.Sum(f, s);

		System.Console.WriteLine($"{f}+{s}={r}");
	}
}

public class SumModule
{
	public static long Sum(string param1, string param2)
	{
		if (!long.TryParse(param1, out long value1))
			throw new ArgumentException($"Не вірний формат числа для параметра {nameof(param1)}");

		if (!long.TryParse(param2, out long value2))
			throw new ArgumentException($"Не вірний формат числа для параметра {nameof(param2)}");

		// перевірка макс мін для парам1
		if (value1 > int.MaxValue)
			throw new ArgumentException($"Перевищено максимальне значення для параметра {nameof(param1)}");
		if (value1 < int.MinValue)
			throw new ArgumentException($"Перевищено мінімальне значення для параметра {nameof(param1)}");

		// перевірка макс мін для парам2
		if (value2 > int.MaxValue)
			throw new ArgumentException($"Перевищено максимальне значення для параметра {nameof(param2)}");
		if (value2 < int.MinValue)
			throw new ArgumentException($"Перевищено мінімальне значення для параметра {nameof(param2)}");

		return value1 + value2;
	}
}

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
	public static long MyTryParse(string p)
	{
		if (!long.TryParse(p, out long value1))
			throw new ArgumentException($"Не вірний формат числа для параметра зі значенням {p}");
		return value1;
	}

	public static int MyLongToInt(long l)
	{
		if (l > int.MaxValue || l < int.MinValue)
			throw new ArgumentException($"Перевищено максимальне/мінімальне значення для параметра зі значенням {l}");
		return (int)l;
	}

	public static long Sum(string param1, string param2)
	{
		int v1 = MyLongToInt(MyTryParse(param1));
		int v2 = MyLongToInt(MyTryParse(param2));

		return (long)(v1 + v2);
	}
}

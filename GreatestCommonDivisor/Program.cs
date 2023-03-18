using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			int a = 1071;
			int b = 462;

			Console.WriteLine("GCD0: " + GreatestCommonDivisor(1071, 462).ToString());
			Console.WriteLine("GCD1: " + GreatestCommonDivisor(20, 30, 40).ToString());
			Console.WriteLine("GCD2: " + GreatestCommonDivisor(21, 24, 27).ToString());
			Console.WriteLine("GCD3: " + GreatestCommonDivisor(20, 30, 40, 45).ToString());
			Console.WriteLine("GCD4: " + GreatestCommonDivisor(23, 31, 79, 83, 89, 97).ToString());
			Console.ReadLine();
		}

		//public static int GreatestCommonDivisor(int a, int b)
		//{
		//    int divisor = (a < b) ? a : b;
		//    int mod = (a < b) ? b % a : a % b;

		//    //check if zero
		//    if (mod == 0)
		//        return divisor;

		//    //divide by divisor (implicit cast to ushort)
		//    if (a != divisor)
		//        a = mod;
		//    if(b != divisor)
		//        b = mod;

		//    return GreatestCommonDivisor(a, b);
		//}

		public static int GreatestCommonDivisor(params int[] values)
		{
			//validate, return 0 on no inputs
			if (!values.Any())
				return 0;

			//find divisor which is the min value of non zeros
			int divisor = values.Where(f => f != 0).Min(f => Math.Abs(f));

			//divide values by divisor if it is not the divisor
			//(would cause automatic 0 which would give a false positive)
			for(int i = 0; i < values.Length; i++)
				if (values[i] != divisor)
					values[i] = values[i] % divisor;

			//return divisor if all other remainders are zero
			if (values.Count(f => f == 0) == (values.Length - 1))
				return divisor;

			//run again until we find an answer
			return GreatestCommonDivisor(values);
		}
	}
}

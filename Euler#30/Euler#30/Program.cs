/*
Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

1634 = 14 + 64 + 34 + 44
	8208 = 84 + 24 + 04 + 84
	9474 = 94 + 44 + 74 + 44
	As 1 = 14 is not a sum it is not included.

	The sum of these numbers is 1634 + 8208 + 9474 = 19316.

	Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
*/

using System;
using System.Diagnostics;
using System.Threading;
using System.Text;

namespace Euler30
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			int power = 5;
			int terms = 0;
			double LOWER_BOUND = Math.Pow (2, power) + Math.Pow(2, power);
			double UPPER_BOUND = Math.Pow (10, power + 1);

			double bigSum = 0;
			double number = LOWER_BOUND;
			while (number <= UPPER_BOUND) {
				double sum = 0;
				string digits = number.ToString ();
				foreach (char c in digits) {
					int digit = (int) Char.GetNumericValue (c);
					sum += Math.Pow (digit, power);
				}
				if (sum == number) {
					Console.WriteLine ("Found {0}!", number);
					bigSum += number;
					terms++;
				}
				number++;
			}

			stopWatch.Stop ();
			Console.WriteLine ("{0} found from {1} terms in {2} milliseconds", bigSum, terms, 
				stopWatch.ElapsedMilliseconds);
		}
	}
}

//145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
//Find the sum of all numbers which are equal to the sum of the factorial of their digits.
//Note: as 1! = 1 and 2! = 2 are not sums they are not included.

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace Euler34
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			int facSum = 0;

			int UPPER_BOUND = 0;
			List<int> factorials = new List<int> ();
			for (int i = 0; i <= 9; i++) {
				int val = Factorial (i);
				factorials.Add (val);
				UPPER_BOUND += val;
			}

			for (int n = 10; n <= UPPER_BOUND; n++) {
				int number = n;
				int sum = 0;
				while (number > 0) {
					int digit = number % 10;
					number = (int)number / 10;
					sum += factorials [digit];
				}
				if (sum == n) {
					facSum += n;
				}
			}

			stopWatch.Stop ();
			Console.WriteLine ("{0} found in {1} milliseconds", facSum, stopWatch.ElapsedMilliseconds);
				
		}

		public static int Factorial (int num_) {
			int number = num_;
			if (number == 0) {
				return 1;
			} else {
				for (int m = number - 1; m > 1; m--) {
					number *= m;
				}
				return number;
			}
		}
	}
}

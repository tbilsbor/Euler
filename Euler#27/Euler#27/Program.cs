/*
 * Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n=0. 
*/

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace Euler27
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			int UPPER_BOUND = 10000;
			int aMax = -999;
			int bMax = -1000;
			int primesFound = -1;
			int product = -1;

			//prime bootstrapper
			List<int> primes = new List<int> ();
			primes.Add(2);
			bool divisible = false;
			for (int i = 3; i <= UPPER_BOUND; i += 2) {
				for (int p = 0; p * p <= i && p < primes.Count; p++) {
					if (i % primes [p] == 0) {
						divisible = true;
						break;
					}
				}
				if (!divisible) {
					primes.Add (i);
				}
				divisible = false;
			}

			//brute force
			int n = 0;
			for (int a = -999; a < 1000; a++) {
				for (int b = -1000; b <= 1000; b++) {
					while (primes.Contains ((n * n) + (a * n) + b)) {
						n++;
					}
					n -= 1;
					if (n > primesFound) {
						primesFound = n + 1;
						aMax = a;
						bMax = b;
					}
					n = 0;
				}
			}

			product = aMax * bMax;

			stopWatch.Stop ();
			Console.WriteLine ("{0} is the product of {1} and {2}; n^2 + {1}n + {2} produces {3} consecutive primes", product, aMax, bMax, primesFound);
			Console.WriteLine ("Answer found in {0} milliseconds", stopWatch.ElapsedMilliseconds);
		}
	}
}

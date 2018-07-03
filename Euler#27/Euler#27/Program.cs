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
			/*
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
			*/

			//optimized brute force
			int n = 0;
			for (int a = -999; a < 1000; a += 2) { // a must be odd so that n^2 + an + b produces a prime when n = 1; 
			// Except for the even prime 2, but that would have to be the first prime produced 
			// so n would = 0 and n = 0 cancels out a and the formula can = 2 if b = 2;
				for (int bIndex = 0; primes [bIndex] <= 1000; bIndex++) { // b must be prime so that n^2 + an + b produces a prime when n = 0
					int b = primes [bIndex]; 
					for (int iteration = 0; iteration <= 1; iteration++) { // Run code once each for positive and negative value of b
						if (iteration == 1) {
							b *= -1;
						}
						while (n != b && n != b * -1 && primes.Contains ((n * n) + (a * n) + b)) {
							n++;
						}
						n -= 1;
						if (n > primesFound) {
							primesFound = n + 1;
							aMax = a;
							bMax = b;
						}
						n = 0;
						b = primes [bIndex] * -1; // ...then the negative value of b
					}
				}
			}

			product = aMax * bMax;

			stopWatch.Stop ();
			Console.WriteLine ("{0} is the product of {1} and {2}\nn^2 + {1}n + {2} produces {3} consecutive primes", product, aMax, bMax, primesFound);
			Console.WriteLine ("Answer found in {0} milliseconds", stopWatch.ElapsedMilliseconds);
		}
	}
}

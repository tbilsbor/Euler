// The number, 197, is called a circular prime because all rotations of the digits: 
// 197, 971, and 719, are themselves prime.
// There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
// How many circular primes are there below one million?

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace Euler35
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			int UPPER_BOUND = 1000000;
			int cPrimesCount = 0;

			List<int> primes = new List<int> ();
			primes.Add (2);
			for (int i = 3; i < UPPER_BOUND; i += 2) {
				Boolean isPrime = true;
				for (int p = 0; primes [p] * primes [p] <= i; p++) {
					if (i % primes [p] == 0) {
						isPrime = false;
						break;
					}
				}
				if (isPrime) {
					primes.Add (i);
				}
			}

			List<int> primesCopy = new List<int> (primes);

			foreach (int prime in primesCopy) {
				int number = prime;
				int digitSum = 0;
				while (number > 0) {
					int digit = number % 10;
					number = (int)number / 10;
					digitSum += digit;
					if ((digit % 2 == 0 && prime != 2) || (digit == 5 && prime != 5) || digit == 0) {
						primes.Remove (prime);
						continue;
					}
				}
				if ((digitSum % 3 == 0 && prime != 3) || digitSum % 9 == 0) {
					primes.Remove (prime);
				}
			}
				
			foreach (int prime in primes) {
				int rotation = prime;
				int digits = (int) Math.Floor (Math.Log10 (rotation) + 1);
				Boolean circular = true;
				do {
					int digit = rotation % 10;
					rotation = (int)rotation / 10;
					rotation += digit * (int) Math.Pow (10, digits - 1);
					if (!primes.Contains (rotation)) {
						circular = false;
						break;
					}
				} while (rotation != prime);
				if (circular) {
					cPrimesCount += 1;
				}
			}

			stopWatch.Stop ();
			Console.WriteLine ("{0} found in {1} milliseconds", cPrimesCount, stopWatch.ElapsedMilliseconds);
		}
	}
}

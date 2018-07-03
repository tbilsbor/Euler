/*
A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:

1/2	= 	0.5
1/3	= 	0.(3)
1/4	= 	0.25
1/5	= 	0.2
1/6	= 	0.1(6)
1/7	= 	0.(142857)
1/8	= 	0.125
1/9	= 	0.(1)
1/10	= 	0.1
Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.

Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
*/

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;

namespace Euler26
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			/* Investigation

			List<double> reciprocals = new List<double> ();

			reciprocals.Add (-1);
			reciprocals.Add (-1);

			for (int d = 2; d < 100; d++) {
				reciprocals.Add ((double) 1 / (double) d);
				Console.WriteLine (d + ": {0:F28}", reciprocals [d]);
			}
			
			*/

			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			int UPPER_BOUND = 1000; // Check reciprocals up to this number
			List<int> primes = new List<int> ();

			//prime bootstrapper
			primes.Add(2);
			primes.Add (3);
			bool divisible = false;
			for (int n = 3; n <= UPPER_BOUND; n += 2) {
				for (int p = 4; p * p <= n; p++) {
					if (n % p == 0) {
						divisible = true;
						break;
					}
				}
				if (!divisible) {
					primes.Add (n);
				}
				divisible = false;
			}
				
			int longest = -1; // Denominator of the reciprocal with the longest cycle
			int longestVal = -1; // Cycle length of the reciprocal with the longest cycle
			int l = -1;
			foreach (int p in primes) {
				l = CycleLength (p);
				if (l > longestVal) {
					longestVal = l;
					longest = p;
				}
			}

			stopWatch.Stop ();
			Console.WriteLine (longest + " found with a cycle of " + longestVal + " in " + 
				stopWatch.ElapsedMilliseconds + " milliseconds");
		}

		private static int CycleLength (int denominator) {
			BigInteger pTen = 1;
			// Cycle of a decimal of a fraction in lowest terms with prime denominator = 
			// lowest k s.t. 10^k % denominator = 1
			for (int k = 1; k < denominator; k++) {
				pTen *= 10;
				if (pTen % denominator == 1) {
					return k;
				}
			}
					
			return -1;
		}

		/*
		private static int CycleLength (int denominator) {
			BigInteger pTen = 1;
			for (int k = 1; k < denominator; k++) {
				for (int exp = 1; exp <= k; exp++) {
					pTen *= 10;
				}
				// Cycle of a decimal of a fraction in lowest terms with prime denominator = 
				// lowest k s.t. 10^k % denominator = 1
				if (pTen % denominator == 1) {
					return k;
				}
				pTen = 1;
			}

			return -1;
		}
		*/

		/*
		private static int CycleLength (int denominator) {
			if (denominator % 2 == 0 || denominator % 5 == 0) { // fast test for divisibility by 2 or 5
				return -1;
			}
			StringBuilder s = new StringBuilder ();
			List <int> digits = new List<int> ();
			int numerator = 10;
			int quotient = -1;
			int cycleLength = -1;
			for (int digit = 0; digit < 2000; digit++) { // Manual long division
				quotient = numerator / denominator;
				s.Append (quotient);
				digits.Add (quotient);
				numerator -= digits [digit] * denominator;
				if (numerator == 0) {
					return -1;
				}
				numerator *= 10;
			}
				
			string pattern = @"(\d{2,}?)\1";
			Regex re = new Regex (pattern);
			MatchCollection matches = re.Matches (s.ToString ());
			if (matches.Count == 0) {
				return -1;
			} else {
				cycleLength = (matches [0].Length) / 2;
			}

			return cycleLength;

		}
		*/
	}
}

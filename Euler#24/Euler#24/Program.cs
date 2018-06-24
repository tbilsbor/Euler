//A permutation is an ordered arrangement of objects. 
//For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. 
//If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. 
//The lexicographic permutations of 0, 1 and 2 are:
//
//012   021   102   120   201   210
//
//What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Euler24
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			int PERMUTATION = 1000000; //nth permutation to find
			int DIGITS = 10; //number of digits in the set

			List<int> permutation = new List<int> ();
			StringBuilder permutationString = new StringBuilder ();
			int sum = 0; // Running sum of factorials
			int d = 0; // Digit being tested
			int p = 0; // Position being tested
			int factorialValue = 0;

			//Add the number of permutations given a set digit in the first position until it exceeds PERMUTATION
			//then set the digit, walk the sum back, and repeat with the next position
			for (p = 0; p < DIGITS; p++) {
				permutation.Add (-1);
				for (d = 0; d < DIGITS; d++) {
					if (permutation.Contains (d)) { // Numbers already set are no longer available
						continue;
					}
					if (DIGITS - p - 1 > 0) {
						factorialValue = factorial (DIGITS - p - 1);
						sum += factorialValue;
						if (sum >= PERMUTATION) {
							sum -= factorial (DIGITS - p - 1); // Walk it back
							permutation [p] = (d);
							permutationString.Append (d);
							break;
						}
					} else {
						permutation [p] = (d);
						permutationString.Append (d);
						break;
					}
				}
			}

			stopWatch.Stop ();
			Console.WriteLine (permutationString + " found in " + stopWatch.ElapsedMilliseconds + " milliseconds");

		}

		private static int factorial (int i) {
			int result = 1;
			for (int m = i; m > 1; m--) {
				result *= m;
			}
			return result;
		}
	}
}

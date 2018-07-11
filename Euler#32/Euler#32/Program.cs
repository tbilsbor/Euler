/*
We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; 
for example, the 5-digit number, 15234, is 1 through 5 pandigital.

The product 7254 is unusual, as the identity, 39 × 186 = 7254, 
containing multiplicand, multiplier, and product is 1 through 9 pandigital.

Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.

HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
*/

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Euler32
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			int M1_LOWER_BOUND = 1;
			int M2_LOWER_BOUND = 1;
			int M1_UPPER_BOUND = 999;
			int M2_UPPER_BOUND = 9999;

			List<int> pandigital = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			List<int> productsFound = new List<int> ();
			int sum = 0;

			for (int m1 = M1_LOWER_BOUND; m1 <= M1_UPPER_BOUND; m1++) {
				for (int m2 = M2_LOWER_BOUND; m2 <= M2_UPPER_BOUND; m2++) {
					int product = m1 * m2;
					int productSlice = product;
					int m1Slice = m1;
					int m2Slice = m2;
					List<int> identity = new List<int> ();
					while (productSlice > 0) {
						int digit = productSlice % 10;
						productSlice = (int)productSlice / 10;
						identity.Add (digit);
					}
					while (m1Slice > 0) {
						int digit = m1Slice % 10;
						m1Slice = (int)m1Slice / 10;
						identity.Add (digit);
					}
					while (m2Slice > 0) {
						int digit = m2Slice % 10;
						m2Slice = (int)m2Slice / 10;
						identity.Add (digit);
					}
					identity.Sort ();
					if (identity.SequenceEqual (pandigital) && !productsFound.Contains (product)) {
						sum += product;
						productsFound.Add (product);
					}
				}
			}

			stopWatch.Stop ();
			Console.WriteLine ("{0} found in {1} milliseconds", sum, stopWatch.ElapsedMilliseconds);
		}
	}
}

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace Euler32b
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			const int PAN_THROUGH = 4;
			List<int> sequence = new List<int> { 1, 2, 3 };
			List<List<int>> permutations = new List<List<int>> ();
			List<List<int>> configs = new List<List<int>> ();

			Console.WriteLine ("There are no pandigital products of 1-3 digits");

			for (int p = 4; p <= PAN_THROUGH; p++) {

				Console.WriteLine ("The pandigital products of {0} digits are as follows", p);

				// Add the new digit to the sorted pandigital sequence

				sequence.Add (p);

				// Generate its permutations

				// Determine viable digital configurations of the identities
				// The product must have no fewer digits than either the multiplicand or the multiplier

				int pCount = p;
				for (int m1 = 1; m1 < p; m1++) {
					pCount -= m1;
					for (int m2 = 1; m2 < pCount; m2++) {
						pCount -= m2;
						int prod = pCount;
						if (prod < m1 || prod < m2) {
							continue;
						}  else {
							configs.Add (new List<int> { m1, m2, prod });
						}
					}
					pCount = p - m1;
				}

				// For each configuration, test all permutations

				permutations = GetPermutations (sequence, permutations, null);

			}
		}

		public static List<List<int>> GetPermutations (List<int> seq_, List<List<int>> p_, List<int> b_) {



			return null;

		}
	}
}



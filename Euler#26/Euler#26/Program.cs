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

			int UPPER_BOUND = 1000;

			int longest = -1;
			int longestVal = -1;
			int l = -1;
			for (int d = 2; d < UPPER_BOUND; d++) {
				l = CycleLength (d);
				if (l > longestVal) {
					longestVal = l;
					longest = d;
				}
			}

			stopWatch.Stop ();
			Console.WriteLine (longest + " found with a cycle of " + longestVal + " in " + 
				stopWatch.ElapsedMilliseconds + " milliseconds");
		}

		private static int CycleLength (int denominator) {
			List<int> digits = new List<int> ();
			StringBuilder s = new StringBuilder ();
			int numerator = 10;
			int quotient = -1;
			for (int digit = 0; digit < 1000; digit++) {
				quotient = numerator / denominator;
				digits.Add (quotient);
				s.Append (quotient);
				numerator -= digits [digit] * denominator;
				numerator *= 10;
			}

			return 0;
		}
	}
}

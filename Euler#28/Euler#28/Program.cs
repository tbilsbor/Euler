/*
Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:

21 22 23 24 25
20  7  8  9 10
19  6  1  2 11
18  5  4  3 12
17 16 15 14 13

It can be verified that the sum of the numbers on the diagonals is 101.

What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
*/

using System;
using System.Diagnostics;
using System.Threading;

namespace Euler28
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			double sum = 1;
			int UPPER_BOUND = 501;
			for (int n = 1; n < UPPER_BOUND; n++) {
				sum += Math.Pow (2 * n + 1, 2);
				sum += (4 * Math.Pow (n, 2)) - (10 * n) + 7;
				sum += (4 * Math.Pow (n, 2)) + 1;
				sum += (4 * Math.Pow (n, 2)) - (6 * n) + 3;
			}

			stopWatch.Stop ();
			Console.WriteLine ("{0} found in {1} milliseconds", sum, stopWatch.ElapsedMilliseconds);
		}
	}
}

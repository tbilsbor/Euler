//If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, 
//there are exactly three solutions for p = 120.
//
//{20,48,52}, {24,45,51}, {30,40,50}
//
//For which value of p ≤ 1000, is the number of solutions maximised?

// For all values of a and b less than 334, find the hypotenuse and see if it's an integer
// If it is, calculate the perimeter and add it to a list
// Parse the list for the mode

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace Euler39
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			List<int> perimeterCounts = new List<int> (1000);
			for (int i = 0; i <= 1000; i++) {
				perimeterCounts.Add (0);
			}

			for (double a = 1; a <= 1000; a++) {
				for (double b = a; b <= 1000; b++) {
					double c = Math.Sqrt (Math.Pow (a, 2) + Math.Pow (b, 2));
					if (c == (int)c) {
						int sum = (int)a + (int)b + (int)c;
						if (sum > 1000) {
							continue;
						}
						perimeterCounts [sum] += 1;
					}
				}
			}

			int largest = -1;
			int largestVal = -1;
			for (int i = 0; i <= 1000; i++) {
				if (perimeterCounts [i] > largestVal) {
					largest = i;
					largestVal = perimeterCounts [i];
				}
			}

			stopWatch.Stop ();
			Console.WriteLine ("{0} found with {1} solutions in {2} milliseconds", 
				largest, largestVal, stopWatch.ElapsedMilliseconds);
		}
	}
}

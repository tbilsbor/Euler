/*
The Fibonacci sequence is defined by the recurrence relation:

Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
	Hence the first 12 terms will be:

	F1 = 1
	F2 = 1
	F3 = 2
	F4 = 3
	F5 = 5
	F6 = 8
	F7 = 13
	F8 = 21
	F9 = 34
	F10 = 55
	F11 = 89
	F12 = 144
	The 12th term, F12, is the first term to contain three digits.

What is the index of the first term in the Fibonacci sequence to contain 1000 digits?
*/

using System;
using System.Diagnostics;
using System.Threading;
using System.Numerics;
using System.Collections.Generic;

namespace Euler25
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			int DIGITS = 1000; // Find the first Fibonacci number with this many digits

			List<BigInteger> fibonacci = new List<BigInteger> (5000); // List of Fibonacci numbers
			List<int> fibDigits = new List<int> (5000); // Digits in Fibonacci numbers

			// Initialize Fibonacci numbers and their digits

			fibonacci.Add (1);
			fibonacci.Add (1);
			fibDigits.Add (1);
			fibDigits.Add (1);

			int d = 0;
			int index = -1;
			for (int i = 2; d <= DIGITS; i++) {
				fibonacci.Add (fibonacci [i - 1] + fibonacci [i - 2]);
				d = fibonacci [i].ToString ().Length;
				if (d >= 1000) {
					index = i + 1; // +1 because the index of the first Fibonacci number is 0
					break;
				}
			}

			stopWatch.Stop ();
			Console.WriteLine (index + " found in " + stopWatch.ElapsedMilliseconds + " milliseconds");

		}
	}
}

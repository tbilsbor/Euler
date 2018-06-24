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

			//double PHI = (1 + Math.Sqrt (5)) / 2;

			int ANALYSIS_DIGITS = 2000;
			int DIGITS = 1000; // Find the first Fibonacci number with this many digits

			List<BigInteger> fibonacci = new List<BigInteger> (); // List of Fibonacci numbers
			List<int> fibDigits = new List<int> (); // Digits in Fibonacci numbers

			// Initialize Fibonacci numbers and their digits

			fibonacci.Add (1);
			fibonacci.Add (1);
			fibDigits.Add (1);
			fibDigits.Add (1);

			// Generate the first 100 Fibonacci numbers for purposes of analysis

			for (int i = 2; i <= ANALYSIS_DIGITS; i++) {
				fibonacci.Add (fibonacci [i - 1] + fibonacci [i - 2]);
				fibDigits.Add (fibonacci [i].ToString ().Length);
			}

			// Calculate the floor of the average number of Fibonacci numbers between increase in
			// orders of magnitude

			double sum = 0; // Sum of the number of steps between digit increases
			int currentValue = 0;
			double increaseCount = 0;
			int steps = 0; // Number of steps between each increase
			//List<int> stepsBetweenIncreases = new List<int> ();
			foreach (int digits in fibDigits) {
				steps++;
				if (digits > currentValue) {
					currentValue = digits;
					increaseCount++;
					sum += steps;
					//stepsBetweenIncreases.Add (steps);
					steps = 0;
				}
			}
			double average = sum / increaseCount;
			//double averageFloor = Math.Floor (average);

			// Multiply the floor of the average by the number of digits to get a lower bound

			//double lowerBound = averageFloor * DIGITS;

			// Actually, just use the average directly, it gets even closer and doesn't go over
			double lowerBound = Math.Floor (average * DIGITS);

			// Not solving the problem, just analyzing the sequence for patterns
			// The number of digits increases every 4 or 5 numbers
			// This block reveals that there are always 3 or 4 sequences of 5 between every sequence of 4

			/*
			int fiveCount = 0;
			List<int> intervals = new List<int> ();
			foreach (int sB in stepsBetweenIncreases) {
				if (sB == 5) {
					fiveCount++;
				} else if (sB == 4) {
					intervals.Add (fiveCount);
					fiveCount = 0;
				} else {
					continue;
				}
			}

			// And this block reveals that there are always 1 or 2 sequences of 4 in that sequence
			// between every sequence of 3

			int fourCount = 0;
			List<int> intervals2 = new List<int> ();
			for (int i = 0; i < intervals.Count; i++) {
				if (intervals [i] == 4) {
					fourCount++;
				} else if (intervals [i] == 3) {
					intervals2.Add (fourCount);
					fourCount = 0;
				}
			}
			*/

			// Add that many digits to the Fibonacci array

			/*
			for (int i = 101; i <= lowerBound; i++) {
				fibonacci.Add (-1);
			}
			*/

			// Brute force the solution: add Fibonacci numbers and start checking the number of digits
			// once the lower bound is exceeded

			int d = 0;
			int index = -1;
			for (int i = ANALYSIS_DIGITS + 1; d <= 1000; i++) {
				fibonacci.Add (fibonacci [i - 1] + fibonacci [i - 2]);
				if (i > lowerBound) {
					d = fibonacci [i].ToString ().Length;
					if (d >= 1000) {
						index = i + 1; // +1 because the index of the first Fibonacci number is 0
						break;
					}
				}
			}

			stopWatch.Stop ();
			Console.WriteLine (index + " found in " + stopWatch.ElapsedMilliseconds + " milliseconds");

		}
	}
}

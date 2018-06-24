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

			double PHI = (1 + Math.Sqrt (5)) / 2;

			int ANALYSIS_DIGITS = 100;
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

			int sum = 0; // Sum of the number of steps between digit increases
			int currentValue = 0;
			int increaseCount = 0;
			int steps = 0; // Number of steps between each increase
			foreach (int digits in fibDigits) {
				steps++;
				if (digits > currentValue) {
					currentValue = digits;
					increaseCount++;
					sum += steps;
					steps = 0;
				}
			}
			double average = sum / increaseCount;
			double averageFloor = Math.Floor (average);

			// Multiply the floor of the average by the number of digits to get a lower bound

			double lowerBound = averageFloor * DIGITS;

			// Add that many digits to the Fibonacci array

			for (int i = 101; i <= lowerBound; i++) {
				fibonacci.Add (-1);
			}

			// Calculate that Fibonacci number and the next one using Binet's formula

			stopWatch.Stop ();
			//Console.WriteLine ( + " found in " + stopWatch.ElapsedMilliseconds + " milliseconds");

		}
	}
}

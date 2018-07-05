﻿/*
Consider all integer combinations of ab for 2 ≤ a ≤ 5 and 2 ≤ b ≤ 5:

	22=4, 23=8, 24=16, 25=32
	32=9, 33=27, 34=81, 35=243
	42=16, 43=64, 44=256, 45=1024
	52=25, 53=125, 54=625, 55=3125
	If they are then placed in numerical order, with any repeats removed, we get the following sequence of 15 distinct terms:

4, 8, 9, 16, 25, 27, 32, 64, 81, 125, 243, 256, 625, 1024, 3125

How many distinct terms are in the sequence generated by ab for 2 ≤ a ≤ 100 and 2 ≤ b ≤ 100?
*/

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Numerics;

namespace Euler29
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			int UPPER_BOUND = 100;
			List<BigInteger> terms = new List<BigInteger> ();

			//investigation
			/*

			for (int a = 2; a <= UPPER_BOUND; a++) {
				for (int b = 2; b <= UPPER_BOUND; b++) {
					BigInteger term = a;
					for (int m = 1; m < b; m++) {
						term *= a;
					}
					if (terms.Contains (term)) {
						Console.WriteLine ("Duplicate: {0} to the {1} is {2}", a, b, term);
					} else {
						Console.WriteLine ("{0} to the {1} is {2}", a, b, term);
					}
					terms.Add (term);
				}
			}

			*/

			// elegant?
			/*
			 
			for (int a = 2; a <= UPPER_BOUND; a++) {
				if (terms.Contains (a)) {
					continue;
				}
				for (int b = 2; b <= UPPER_BOUND; b++) {
					BigInteger term = a;
					for (int m = 1; m < b; m++) {
						term *= a;
					}
					if (!terms.Contains (term)) {
						terms.Add (term);
					}
					if (term <= UPPER_BOUND) {
						for (int c = (UPPER_BOUND / b) + 1; c <= UPPER_BOUND; c++) {
							BigInteger subterm = term;
							for (int m = 1; m < c; m++) {
								subterm *= term;
							}
							if (!terms.Contains (subterm)) {
								terms.Add (subterm);
							}
						}
					}
				}
			}

			stopWatch.Stop ();
			Console.WriteLine ("{0} terms found in {1} milliseconds", terms.Count, stopWatch.ElapsedMilliseconds);
			stopWatch.Restart ();

			*/

			// brute force

			List<BigInteger> terms2 = new List<BigInteger> ();

			for (int a = 2; a <= UPPER_BOUND; a++) {
				for (int b = 2; b <= UPPER_BOUND; b++) {
					BigInteger term = a;
					for (int m = 1; m < b; m++) {
						term *= a;
					}
					if (!terms2.Contains (term)) {
						terms2.Add (term);
					}
				}
			}

			stopWatch.Stop ();
			Console.WriteLine ("{0} terms found in {1} milliseconds", terms2.Count, stopWatch.ElapsedMilliseconds);
		}
	}
}

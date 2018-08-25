//The number, 1406357289, is a 0 to 9 pandigital number 
//because it is made up of each of the digits 0 to 9 in some order, 
//but it also has a rather interesting sub-string divisibility property.
//
//Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:
//
//d2d3d4=406 is divisible by 2
//d3d4d5=063 is divisible by 3
//d4d5d6=635 is divisible by 5
//d5d6d7=357 is divisible by 7
//d6d7d8=572 is divisible by 11
//d7d8d9=728 is divisible by 13
//d8d9d10=289 is divisible by 17
//
//Find the sum of all 0 to 9 pandigital numbers with this property.

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace Euler43
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			// Get all the pandigital permutations of nine digits
			int digits = 9;
			Permutations permutations = new Permutations (digits);
			permutations.GetPermutations ();

			// Generate the primes up to 17
			List<int> primes = new List<int> ();
			primes.Add (2);
			Boolean isPrime;
			for (int p = 3; p <= 17; p++) {
				isPrime = true;
				for (int i = 0; primes [i] * primes [i] <= p; i++) {
					if (p % primes [i] == 0) {
						isPrime = false;
						break;
					}
				}
				if (isPrime) {
					primes.Add (p);
				}
			}

			List<int> permutation = new List<int> ();
			int offset;
			int value;
			bool isDivisible;
			double sum = 0;
			double permutationValue;
			double multiple;
			for (int i = 0; i < permutations.Count; i++) {
				permutation = permutations.GetPermutation (i);
				isDivisible = true;
				// Quick test for divisibility by 2 and 5
				if (permutation [3] % 2 != 0) {
					continue;
				}
				if (permutation [5] != 5 && permutation [5] != 0) {
					continue;
				}
				for (int p = 6; p >= 0; p--) {
					offset = 6 - p;
					value = permutation [9 - offset] + 
						(10 * permutation [8 - offset]) + 
						(100 * permutation [7 - offset]);
					if (value % primes [p] == 0) {
						continue;
					} else {
						isDivisible = false;
						break;
					}
				}
				if (isDivisible) {
					permutationValue = 0;
					for (int o = 1; o <= 10; o++) {
						multiple = (int)Math.Pow (10, o - 1);
						permutationValue += permutation [10 - o] * multiple;
					}
					sum += permutationValue;
				}
			}

			stopWatch.Stop ();
			Console.WriteLine ("{0} found in {1} milliseconds", sum, 
				stopWatch.ElapsedMilliseconds);
		}

		public class Permutations
		{
			private List<int> panSeq = new List<int> (); // The pandigital sequence
			private List<List<int>> permutations = new List<List<int>> (); // List of permutations

			// Constructor
			public Permutations (List<int> s_) {
				foreach (int digit in s_) { // Copy sequence from argument to local list
					panSeq.Add (digit);
				}
			}

			public Permutations (int digits) {
				for (int i = 0; i <= digits; i++) {
					panSeq.Add (i);
				}
			}

			// Get the number of permutations
			public int Count { 
				get {
					return permutations.Count;
				}
			}

			// Get a permutation specified by index
			public List<int> GetPermutation (int i_) { 
				return permutations [i_];
			}

			// Initial call to GetPermutations
			public void GetPermutations () { 
				GetPermutations (panSeq, null);
			}

			// Generate permutations
			private void GetPermutations (List<int> s_, List<int> p_) {
				List<int> sequence = new List<int> (); // Subset of the pandigital sequence, or subset of a subset
				foreach (int d in s_) { // Copy argument to subset list
					sequence.Add (d);
				}
				List<int> permutation = new List<int> (); // Holds the current permutation as it's generated
				if (p_ != null) { // If a new permutation has already been started...
					foreach (int d in p_) { // Copy it over from the argument
						permutation.Add (d);
					}
				}
				foreach (int d in sequence) { // Iterate over the subset sequence
					permutation.Add (d); // Grab the number and add it to the permutation
					// Holds the new subset, which is the old subset minus the number grabbed
					List<int> subSeq = new List<int> (); 
					foreach (int d2 in sequence) { // Copy over the numbers that aren't in the permutation builder
						if (d2 != d) {
							subSeq.Add (d2);
						}
					}
					if (subSeq.Count == 0) { // If that runs the list out of numbers
						permutations.Add (new List<int> ()); 
						foreach (int d3 in permutation) { // Add the finalized permutation to the big list
							permutations [permutations.Count - 1].Add (d3);
						}
						break;
					} else { // Otherwise...
						GetPermutations (subSeq, permutation); // Recurse!
						// Pop the last number off the sequence so that it can be replaced in the next iteration
						permutation.RemoveAt (permutation.Count - 1); 
					}
				}
			}
		}
	}
}

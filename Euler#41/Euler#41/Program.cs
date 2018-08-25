//We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. 
//For example, 2143 is a 4-digit pandigital and is also prime.
//What is the largest n-digit pandigital prime that exists?

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace Euler41
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			// prime bootstrapper
			List<int> primes = new List<int> ();
			primes.Add (2);
			primes.Add (3);
			Boolean isPrime;
			for (int p = 5; p <= Math.Sqrt(987654321); p += 2) {
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

			List<List<int>> allPan = new List<List<int>> ();
			for (int digits = 1; digits <= 9; digits++) { // Number of digits in the sequence
				List<int> panSeq = new List<int> (digits); // The pandigital sequence
				for (int n = 1; n <= digits; n++) { // Populate based on number of digits
					panSeq.Add (n);
				}
				Permutations permutations = new Permutations (panSeq); // Instantiate object
				permutations.GetPermutations (); // Generate the permutations
				allPan.AddRange(permutations.GetAll ());
			}

			int largest = -1;
			for (int i = allPan.Count - 1; i >= 0; i--) {
				isPrime = true;
				List<int> permutation = allPan [i];
				int pInt = 0;
				foreach (int digit in permutation)
				{
					pInt = 10 * pInt + digit;
				}
				for (int p = 0; primes [p] * primes [p] <= pInt; p++) {
					if (pInt % primes [p] == 0) {
						isPrime = false;
						break;
					}
				}
				if (isPrime) {
					largest = pInt;
					break;
				}
			}
				
			stopWatch.Stop ();
			Console.WriteLine ("{0} found in {1} milliseconds", largest, stopWatch.ElapsedMilliseconds);
		}
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

		public int Count { // Get the number of permutations
			get {
				return permutations.Count;
			}
		}

		public List<List<int>> GetAll () {
			return permutations;
		}

		public List<int> GetPermutation (int i_) { // Get a permutation specified by index
			return permutations [i_];
		}

		public void GetPermutations () { // Initial call to GetPermutations
			GetPermutations (panSeq, null);
		}

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

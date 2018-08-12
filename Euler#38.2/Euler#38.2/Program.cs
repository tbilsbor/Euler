//Take the number 192 and multiply it by each of 1, 2, and 3:
//192 × 1 = 192
//192 × 2 = 384
//192 × 3 = 576
//By concatenating each product we get the 1 to 9 pandigital, 192384576. 
//We will call 192384576 the concatenated product of 192 and (1,2,3)
//The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, giving the pandigital, 918273645, 
//which is the concatenated product of 9 and (1,2,3,4,5).
//What is the largest 1 to 9 pandigital 9-digit number that can be formed 
//as the concatenated product of an integer with (1,2, ... , n) where n > 1?

// Generate all of the permutations of the nine digits
// Sort them from largest to smallest, or from smallest to largest and start at the end
// Start at the largest one (987654321) and dividing it into 
// {1, 2, 2, 2, 2}, {2, 3, 4}, {3, 3, 3}, {4, 5}
// Take the first number, multiply it by 2 and see if you get the second, 
// then by 3 and see if you get the third, and so on

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Euler38
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			int largest = 1; // Index referencing largest (i.e. first) value found
			int digits = 9; // Number of digits in the sequence
			List<int> panSeq = new List<int> (digits); // The pandigital sequence
			for (int n = 1; n <= digits; n++) { // Populate based on number of digits
				panSeq.Add (n);
			}
			Permutations permutations = new Permutations (panSeq); // Instantiate object
			permutations.GetPermutations (); // Generate the permutations

			for (int i = permutations.Count - 1; i >= 0; i--) { // For each permutation, starting at the end
				List<int> permutation = permutations.GetPermutation (i); // Grab it from the object
				if (!TestOne (permutation) // Test all the configurations
					&& !TestTwo (permutation)
					&& !TestThree (permutation)
					&& !TestFour (permutation)) {
					continue; // Didn't pass any; move onto the next
				} else { // One of them passed
					largest = i; // Set the index that passed
					break;
				}
			}

			// Grab the permutation using the index and turn it into an integer for printout
			List<int> largestPermutation = permutations.GetPermutation (largest);
			StringBuilder largestString = new StringBuilder ();
			foreach (int digit in largestPermutation) {
				largestString.Append (digit);
			}
			int largestVal = Int32.Parse (largestString.ToString ());

			stopWatch.Stop ();
			Console.WriteLine ("{0} found in {1} milliseconds", largestVal, 
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

			public int Count { // Get the number of permutations
				get {
					return permutations.Count;
				}
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

		// Test the first number against the second and third, fourth and fifth, etc.
		public static Boolean TestOne (List<int> permutation) 
		{
			int testVal = permutation [0];
			int compareTo;
			int product;
			for (int m = 2; m <= 5; m++) {
				compareTo = permutation [m - 1] * 10;
				compareTo += permutation [m];
				product = testVal * m;
				if (product != compareTo) {
					return false;
				}
			}
			return true;
		}

		public static Boolean TestTwo (List<int> permutation) 
		{
			int testVal = permutation [0] * 10;
			testVal += permutation [1];
			int compareTo = permutation [2] * 100;
			compareTo += permutation [3] * 10;
			compareTo += permutation [4];
			int product = testVal * 2;
			if (product != compareTo) {
				return false;
			} 
			compareTo = permutation [5] * 1000;
			compareTo += permutation [6] * 100;
			compareTo += permutation [7] * 10;
			compareTo += permutation [8];
			product = testVal * 3;
			if (product != compareTo) {
				return false;
			} 
			return true;
		}

		public static Boolean TestThree (List<int> permutation) 
		{
			int testVal = permutation [0] * 100;
			testVal += permutation [1] * 10;
			testVal += permutation [2];
			int compareTo = permutation [3] * 100;
			compareTo += permutation [4] * 10;
			compareTo += permutation [5];
			int product = testVal * 2;
			if (product != compareTo) {
				return false;
			} 
			compareTo += permutation [6] * 100;
			compareTo += permutation [7] * 10;
			compareTo += permutation [8];
			product = testVal * 3;
			if (product != compareTo) {
				return false;
			} 
			return true;
		}

		public static Boolean TestFour (List<int> permutation) 
		{
			int testVal = permutation [0] * 1000;
			testVal += permutation [1] * 100;
			testVal += permutation [2] * 10;
			testVal += permutation [3];
			int compareTo = permutation [4] * 10000;
			compareTo += permutation [5] * 1000;
			compareTo += permutation [6] * 100;
			compareTo += permutation [7] * 10;
			compareTo += permutation [8];
			int product = testVal * 2;
			if (product != compareTo) {
				return false;
			} 
			return true;
		}
	}
}

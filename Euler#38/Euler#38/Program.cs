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

// -Generate all of the permutations of the nine digits
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

			int largest = 1;
			int digits = 9;
			List<int> panSeq = new List<int> (digits);
			for (int n = 1; n <= digits; n++) {
				panSeq.Add (n);
			}
			Permutations permutations = new Permutations (panSeq);
			permutations.GetPermutations ();

			for (int i = permutations.Count - 1; i >= 0; i--) {
				List<int> permutation = permutations.GetPermutation (i);
				if (!TestOne (permutation)
					&& !TestTwo (permutation)
					&& !TestThree (permutation)
					&& !TestFour (permutation)) {
					continue;
				} else {
					largest = i;
					break;
				}
			}
				
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
			private List<int> panSeq = new List<int> ();
			private List<List<int>> permutations = new List<List<int>> ();

			public Permutations (List<int> s_) {
				foreach (int digit in s_) {
					panSeq.Add (digit);
				}
			}

			public int Count {
				get {
					return permutations.Count;
				}
			}

			private int Factorial (int n_) {
				int number = n_;
				for (int m = number; m >= 2; m--) {
					number *= m;
				}
				return number;
			}

			public List<int> GetPermutation (int i_) {
				return permutations [i_];
			}

			public void GetPermutations () {
				GetPermutations (panSeq, null);
			}

			private void GetPermutations (List<int> s_, List<int> p_) {
				List<int> sequence = new List<int> ();
				foreach (int d in s_) {
					sequence.Add (d);
				}
				List<int> permutation = new List<int> ();
				if (p_ != null) {
					foreach (int d in p_) {
						permutation.Add (d);
					}

				}
				foreach (int d in sequence) {
					permutation.Add (d);
					List<int> subSeq = new List<int> ();
					foreach (int d2 in sequence) {
						if (d2 != d) {
							subSeq.Add (d2);
						}
					}
					if (subSeq.Count == 0) {
						permutations.Add (new List<int> ());
						foreach (int d3 in permutation) {
							permutations [permutations.Count - 1].Add (d3);
						}
						break;
					} else {
						GetPermutations (subSeq, permutation);
						permutation.RemoveAt (permutation.Count - 1);
					}
				}
			}
		}

		public static Boolean TestOne (List<int> permutation) 
		{
			int testVal = permutation [0];
			int compareTo = permutation [1] * 10;
			compareTo += permutation [2];
			int product = testVal * 2;
			if (product != compareTo) {
				return false;
			} 
			compareTo = permutation [3] * 10;
			compareTo += permutation [4];
			product = testVal * 3;
			if (product != compareTo) {
				return false;
			} 
			compareTo = permutation [5] * 10;
			compareTo += permutation [6];
			product = testVal * 4;
			if (product != compareTo) {
				return false;
			}
			compareTo = permutation [7] * 10;
			compareTo += permutation [8];
			product = testVal * 5;
			if (product != compareTo) {
				return false;
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

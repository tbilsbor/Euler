//The nth term of the sequence of triangle numbers is given by, 
//tn = ½n(n+1); so the first ten triangle numbers are:

//1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

//By converting each letter in a word to a number corresponding to its alphabetical position 
//and adding these values we form a word value. 
//For example, the word value for SKY is 19 + 11 + 25 = 55 = t10. 
//If the word value is a triangle number then we shall call the word a triangle word.
//Using words.txt (right click and 'Save Link/Target As...'), 
//a 16K text file containing nearly two-thousand common English words, how many are triangle words?

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Euler42
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			// Read in file
			String wordString = "";
			using (StreamReader wordStream = new StreamReader ("words.txt")) {
				wordString = wordStream.ReadLine ();
			}

			// Parse the words into an array using regular expressions
			List<String> words = new List<String> ();
			Regex rx = new Regex (@"(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
			MatchCollection matches = rx.Matches (wordString);
			foreach (Match match in matches) {
				words.Add (match.ToString ());
			}

			// Generate triangle numbers up to 300
			// A 10-letter word that is all z's would have a value of 26 * 10 = 260
			// So that plus some overhead
			List<int> triangleNumbers = new List<int> ();
			triangleNumbers.Add (-1);
			triangleNumbers.Add (1);
			double newNumber;
			for (double n = 2; triangleNumbers [(int)n - 1] <= 300; n++) {
				newNumber = (n / 2.0) * (n + 1.0); // Formula for the nth triangle number
				triangleNumbers.Add ((int)newNumber);
			}

			// Parse the words, convert to numerical values, sum, and compare to triangle numbers
			int wordSum;
			int total = 0;
			foreach (String word in words) {
				wordSum = 0;
				foreach (char c in word) {
					wordSum += (int)c - 64;
				}
				if (triangleNumbers.Contains (wordSum)) {
					total += 1;
				}
			}

			stopWatch.Stop ();
			Console.WriteLine ("{0} found in {1} milliseconds", total, stopWatch.ElapsedMilliseconds);
		}
	}
}

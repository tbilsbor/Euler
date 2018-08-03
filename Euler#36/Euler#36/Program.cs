//The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.

//Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

//(Please note that the palindromic number, in either base, may not include leading zeros.)

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Euler36
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			List<String> palindromes = new List <String> (); // All palindromes under 1000000
			// Binary representations of those palindromes, 
			// may or may not be themselves palindromes
			List<String> binary = new List<String> (); 

			// Build the palindromes list
			for (int n = 1; n < 1000; n ++) {
				StringBuilder palindrome = new StringBuilder ();
				palindrome.Append (n); // Start with the number itself
				int digits = (int) Math.Floor (Math.Log10 (n) + 1);
				for (int i = digits - 2; i >= 0; i--) { // odd palindrome (# of digits)
					palindrome.Append (palindrome [i]);
				}
				palindromes.Add (palindrome.ToString ());
				palindrome.Clear ();
				palindrome.Append (n);
				for (int i = digits - 1; i >= 0; i--) { // even palindrome
					palindrome.Append (palindrome [i]);
				}
				palindromes.Add (palindrome.ToString ());
			}

			// Get the binary representations of those numbers
			foreach (String palindrome in palindromes) {
				binary.Add (GetBinary (Int32.Parse(palindrome)));
			}

			int sum = 0;

			// Go through the binaries and check to see if they're palindromes
			// by comparing each character from the beginning of the string
			// to a corresponding character at the end of the string
			for (int i = 0; i < binary.Count; i++) {
				String number = binary [i];
				int digits = number.Length;
				Boolean isPalindrome = true;
				for (int c = 0; c < (int) digits / 2; c++) {
					if (number [c] != number [digits - 1 - c]) {
						isPalindrome = false;
						break;
					}
				}
				if (isPalindrome) {
					sum += Int32.Parse (palindromes [i]);
				}
			}

			stopWatch.Stop ();
			Console.WriteLine ("{0} found in {1} milliseconds", sum, stopWatch.ElapsedMilliseconds);
		}

		public static String GetBinary (int p_) {
			StringBuilder palindrome = new StringBuilder ();
			while (p_ > 0) {
				int binDigit = p_ % 2;
				palindrome.Insert (0, binDigit.ToString ());
				p_ = p_ / 2;
			}
			return palindrome.ToString ();
		}
	}
}

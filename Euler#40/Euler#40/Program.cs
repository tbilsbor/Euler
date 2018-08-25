//An irrational decimal fraction is created by concatenating the positive integers:
//
//0.123456789101112131415161718192021...
//
//It can be seen that the 12th digit of the fractional part is 1.
//
//If dn represents the nth digit of the fractional part, find the value of the following expression.
//
//d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000

// d1 through d9 are going to be the digits; 
// Each number after that takes up 2 digits and there are 90 of those for a total of 180
// Add that to the first 10 for 190 digits
// That value can be used to calculate the index of individual numbers
// Calculate the values for those changes in orders of magnitude
// A two-digit number is going to take up two indices, a three-digit number three indices, and so on
// Use that to calculate the full number of which a given index is a part
// The remainder of the order of magnitude minus the lower order digits mod the number of digits
// ...indicates which digit of the full number a given n-value represents

// Example: d10000: 10000 is magnitude 4 (10^4)
// The first calculation says that there are 2890 numbers in orders 1-3
// 10000 - 2890 = 7110, integer division by the order (4) = 1777
// Index 10000 is going to be part of the 1777th 4-digit number, which is 2777, but which part?
// 1777 is a 4 digit number; 1777 mod 4 = 1, so d10000 will be the second digit from the left
// The second digit of 2777 is 7. d10000 = 7.

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace Euler40
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			// intervals at which the order of magnitude increases
			// orders [i] is the first n for an i-digit number
			List<int> orders = new List<int> ();
			orders.Add (-1);
			orders.Add (1);
			int n;
			for (int i = 2; i <= 7; i++) {
				n = 9 * (int)Math.Pow (10, i - 2) * (i - 1) + orders [i - 1];
				orders.Add (n);
			}

			// Calculate the value of the index for each order of magnitude and multiply by the product
			int product = 1; // The solution; d1 = 1 so product starts at 1
			int number; // The full number of which the digit is a part
			int place; // The place value of the digit in that number (0 = leftmost, 1 = 1 to the right)
			int digits = -1; // The number of digits in the number
			int digit; // The digit we're looking for
			for (int m = 1; m < 7; m++) { // For each order of magnitude...
				// Calculate the number and place value
				number = (((int)Math.Pow (10, m) - orders [m]) / m) + (int)Math.Pow (10, m - 1);
				place = (((int)Math.Pow (10, m) - orders [m]) % m);
				// Extract the digit from the number
				for (int i = 2; i <= 7; i++) {
					if ((int)Math.Pow (10, m) >= orders [i]) {
						digits = i;
					}
				}
				digit = (int)number / (int)Math.Pow (10, digits - place - 1);
				if (digit > 10) {
					digit = digit % 10;
				}
				// Multiply the product by the digit
				product *= digit;
			}

			stopWatch.Stop ();
			Console.WriteLine ("{0} found in {1} milliseconds", product, stopWatch.ElapsedMilliseconds);
		}
	}
}

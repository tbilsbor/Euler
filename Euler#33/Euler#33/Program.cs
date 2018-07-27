//The fraction 49/98 is a curious fraction, 
//as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, 
//which is correct, is obtained by cancelling the 9s.
//We shall consider fractions like, 30/50 = 3/5, to be trivial examples.
//There are exactly four non-trivial examples of this type of fraction, 
//less than one in value, and containing two digits in the numerator and denominator.
//If the product of these four fractions is given in its lowest common terms, 
//find the value of the denominator.

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace Euler33
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			int UPPER_BOUND = 99;
			List<int> numerators = new List<int> ();
			List<int> denominators = new List<int> ();

			for (int d = 12; d <= UPPER_BOUND; d++) {
				for (int n = 11; n < d; n++) {
					if (n % 10 == 0 && d % 10 == 0) {
						continue;
					}
					int n2 = n % 10;
					int n1 = (int)n / 10;
					int d2 = d % 10;
					int d1 = (int)d / 10;
					float quotient = (float)n / d;
					float xQuotient = -1;
					if (n1 == d1) {
						xQuotient = (float)n2 / d2;
					}
					if (n2 == d2) {
						xQuotient = (float)n1 / d1;
					}
					if (n1 == d2) {
						xQuotient = (float)n2 / d1;
					}
					if (n2 == d1) {
						xQuotient = (float)n1 / d2;
					}
					if (quotient == xQuotient) {
						numerators.Add (n);
						denominators.Add (d);
					}
				}
			}

			int numerator = 1;
			int denominator = 1;
			for (int i = 0; i < 4; i++) {
				numerator *= numerators [i];
				denominator *= denominators [i];
			}

			if (denominator % numerator == 0) {
				denominator /= numerator;
				numerator = 1;
			}

			stopWatch.Stop ();
			Console.WriteLine ("{0} found in {1} milliseconds", denominator, stopWatch.ElapsedMilliseconds);
		}
	}
}

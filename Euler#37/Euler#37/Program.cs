//The number 3797 has an interesting property. 
//Being prime itself, it is possible to continuously remove digits from left to right, 
//and remain prime at each stage: 3797, 797, 97, and 7. 
//Similarly we can work from right to left: 3797, 379, 37, and 3.
//Find the sum of the only eleven primes that are both truncatable from left to right and right to left.
//NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Euler37
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			int truncCount = 0;
			int sum = 0;
			List<int> primes = new List<int> ();
			primes.Add (2);
			int n = 3;
			while (truncCount < 11) {
				
				Boolean isPrime = true;
				for (int p = 0; primes [p] * primes [p] <= n; p++) {
					if (n % primes [p] == 0) {
						isPrime = false;
						break;
					}
				}

				if (isPrime) {
					
					primes.Add (n);
					if (n < 10) {
						n += 2;
						continue;
					}

					Boolean isTruncatable = true;
					StringBuilder primeS = new StringBuilder ();
					foreach (char c in n.ToString ()) {
						primeS.Append (c);
					}
					int firstDigit = Int32.Parse (primeS [0].ToString ());
					int lastDigit = Int32.Parse (primeS [primeS.Length - 1].ToString ());
					if (!primes.Contains (firstDigit) || !primes.Contains (lastDigit)) {
						isTruncatable = false;
						n += 2;
						continue;
					}

					while (primeS.Length > 1) {
						primeS.Remove (0, 1);

						int prime = Int32.Parse (primeS.ToString ());
						if (!primes.Contains (prime)) {
							isTruncatable = false;
							break;
						}
					}
					if (!isTruncatable) {
						n += 2;
						continue;
					}

					primeS.Clear ();
					foreach (char c in n.ToString ()) {
						primeS.Append (c);
					}
					while (primeS.Length > 1) {
						primeS.Remove (primeS.Length - 1, 1);
						int prime = Int32.Parse (primeS.ToString ());
						if (!primes.Contains (prime)) {
							isTruncatable = false;
							break;
						}
					}

					if (isTruncatable) {
						sum += n;
						truncCount += 1;
					}
				}

				n += 2;
			}

			stopWatch.Stop ();
			Console.WriteLine ("{0} found in {1} milliseconds", sum, stopWatch.ElapsedMilliseconds);
		}
	}
}

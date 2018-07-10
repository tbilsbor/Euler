/*
In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:

1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
It is possible to make £2 in the following way:

1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
How many different ways can £2 be made using any number of coins?
*/

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Euler31
{
	class MainClass
	{
		public class Obama
		{

			private List<int> values = new List<int> {  0, 0, 0, 0, 0, 0, 0, 0 }; // current tabulated values
			private List<int> coins = new List<int> { 1, 2, 5, 10, 20, 50, 100, 200 }; // constant values of coins

			private int combinations; // calculated number of combinations
			private int maxCoin; // Largest coin value

			// Constructor: set the first value in the values array, find the max coin, set starting combinations

			public Obama (int pence) {
				values [0] = pence;
				if (pence >= 200) {
					maxCoin = 7;
				} else {
					for (int i = 0; i < coins.Count; i++) {
						if (coins [i] > pence) {
							maxCoin = i - 1;
							break;
						}
					}
				}
				combinations = 0;
			}

			// Retrieve combinations value

			public int Combinations {
				get {
					return combinations;
				}
			}

			// Do the thing

			public void Count () {
				for (int c = 0; c <= maxCoin; c++) {
					Count (c);
				}
			}

			private void Count (int coin) {

				if (coin == 0) {
					combinations += 1;
				}

				if (coin == 1) {
					int q = values [0] / 2;
					if (q > 0) {
						values [0] -= q * 2;
						values [1] += q;
						combinations += q;
						values [1] -= q;
						values [0] += q * 2;
					}
				}

				if (coin >= 2) {
					int cv = coins [coin];
					int q = (int)values [0] / cv;
					for (int d = 1; d <= q; d++) {
						values [0] -= cv;
						values [coin] += 1;
						for (int c = 0; c < coin; c++) {
							Count (c);
						}
					}
					values [0] += cv * q;
					values [coin] = 0;
				}
			}
		}

		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");

			while (true) {
				Console.WriteLine ("Pence to count: ");
				string rs = Console.ReadLine ();
				if (rs == "exit") {
					break;
				}

				int STARTING_AMOUNT = int.Parse (rs);

				Stopwatch stopWatch = new Stopwatch ();
				if (stopWatch.IsRunning) {
					stopWatch.Restart ();
				} else {
					stopWatch.Start ();
				}

				Obama obama = new Obama (STARTING_AMOUNT);
				obama.Count ();

				stopWatch.Stop ();
				Console.WriteLine ("{0} combinations found in {1} milliseconds", obama.Combinations, 
					stopWatch.ElapsedMilliseconds);
			}
		}
	}
}

/*
		public class Obama
		{

			private List<int> values = new List<int> {  0, 0, 0, 0, 0, 0, 0, 0 }; // current tabulated values
			private List<int> maxValues = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
			private List<int> coins = new List<int> { 1, 2, 5, 10, 20, 50, 100, 200 }; // constant values of coins

			private int combinations; // calculated number of combinations
			private int maxCoin;

			public Obama (int pence) {
				values [0] = pence;
				if (pence >= 200) {
					maxCoin = 7;
				} else {
					for (int i = 0; i < coins.Count; i++) {
						if (coins [i] > pence) {
							maxCoin = i - 1;
							break;
						}
					}
				}
				this.maxCount ();
				combinations = 0;
			}

			public int Combinations {
				get {
					return combinations;
				}
			}

			private void maxCount () {
				int pence = values [0];
				for (int i = maxCoin; i >= 0; i--) {
					int q = (int)pence / coins [i];
					maxValues [i] += q;
					pence -= q * coins [i];
					if (pence == 0) {
						break;
					}
				}
			}

			public void Count () {
				this.Ones ();
				this.Twos ();
				this.Fives ();
				this.Tens ();
				this.Twenties ();
				this.Fifties ();
				this.Hundreds ();
				this.Twohundreds ();
			}

			private void Ones () {
				combinations += 1;
			}

			private void Twos () {
				int q = values [0] / 2;
				if (q > 0) {
					values [0] -= q * 2;
					values [1] += q;
					combinations += q;
					values [1] -= q;
					values [0] += q * 2;
				}
			}

			private void Fives () {
				int q = (int)values [0] / 5;
				for (int d = 1; d <= q; d++) {
					values [0] -= 5;
					values [2] += 1;
					this.Ones ();
					this.Twos ();
				}
				values [0] += 5 * q;
				values [2] = 0;
			}

			private void Tens () {
				int q = (int)values [0] / 10;
				for (int d = 1; d <= q; d++) {
					values [0] -= 10;
					values [3] += 1;
					this.Ones ();
					this.Twos ();
					this.Fives ();
				}
				values [0] += 10 * q;
				values [3] = 0;
			}

			private void Twenties () {
				int q = (int)values [0] / 20;
				for (int d = 1; d <= q; d++) {
					values [0] -= 20;
					values [4] += 1;
					this.Ones ();
					this.Twos ();
					this.Fives ();
					this.Tens ();
				}
				values [0] += 20 * q;
				values [4] = 0;
			}

			private void Fifties () {
				int q = (int)values [0] / 50;
				for (int d = 1; d <= q; d++) {
					values [0] -= 50;
					values [4] += 1;
					this.Ones ();
					this.Twos ();
					this.Fives ();
					this.Tens ();
					this.Twenties ();
				}
				values [0] += 50 * q;
				values [5] = 0;
			}

			private void Hundreds () {
				int q = (int)values [0] / 100;
				for (int d = 1; d <= q; d++) {
					values [0] -= 100;
					values [6] += 1;
					this.Ones ();
					this.Twos ();
					this.Fives ();
					this.Tens ();
					this.Twenties ();
					this.Fifties ();
				}
				values [0] += 100 * q;
				values [6] = 0;
			}

			private void Twohundreds () {
				int q = (int)values [0] / 200;
				for (int d = 1; d <= q; d++) {
					values [0] -= 200;
					values [7] += 1;
					this.Ones ();
					this.Twos ();
					this.Fives ();
					this.Tens ();
					this.Twenties ();
					this.Fifties ();
					this.Hundreds ();
				}
				values [0] += 200 * q;
				values [7] = 0;
			}
		}
		*/
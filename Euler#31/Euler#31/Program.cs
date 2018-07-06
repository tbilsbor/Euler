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

namespace Euler31
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Running!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			int AMOUNT = 10;
			List<int> coins = new List<int> { 1, 2, 5, 10, 20, 50, 100, 200 };
			List<int> combination = new List<int> ();
			int combinations = 0;

			stopWatch.Stop ();
			Console.WriteLine ("{0} combinations found in {1} milliseconds", combinations.Count, 
				stopWatch.ElapsedMilliseconds);

		}
	}
}

using System;

namespace Smallworld
{
	public class Dice
	{
		public const int MaxValue = 3;
		
		private static int[] values = { 0, 0, 0, 1, 2, 3};
		private readonly Random _random;
		
		public Dice(Random random) 
		{
			_random = random;
		}
		
		public int Roll()
		{
			return values[_random.Next(0, 6)];
		}
	}
}
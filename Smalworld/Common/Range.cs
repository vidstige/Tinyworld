using System;

namespace Smallworld
{
	public class Range
	{
		private readonly int _min;
		private readonly int _max;
		
		public Range(int min, int max)
		{
			_min = min;
			_max = max;
		}
		
		public int Min { get { return _min; } }
		public int Max { get { return _max; } }
	}
}
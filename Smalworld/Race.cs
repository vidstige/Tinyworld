using System;

namespace Smallworld
{
	public class Race
	{
		public static Race Joes = new Race(5); // used for testing purposes.
		
		private readonly int _startingTokens;
		
		public Race(int startingTokens)
		{
			_startingTokens = startingTokens;
		}
		
		public int StartingTokens
		{
			get { return _startingTokens; }
		}
	}
}
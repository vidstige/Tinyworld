using System;

namespace Smallworld
{
	public class Ability
	{
		public static Ability Plain = new Ability(3); // used for testing purposes
		
		private readonly int _startingTokens;
		
		private Ability(int startingTokens)
		{
			_startingTokens = startingTokens;
		}
		
		public int StartingTokens
		{
			get { return _startingTokens; }
		}
	}
}
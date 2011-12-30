using System;

namespace Smallworld
{
	public class Race
	{
		public static Race Joes = new Race("Joes", 5); // used for testing purposes.
		public static Race Ratmen = new Race("Ratmen", 8); // used for testing purposes.
		
		private readonly string _name;
		private readonly int _startingTokens;
		
		public Race(string name, int startingTokens)
		{
			_name = name;
			_startingTokens = startingTokens;
		}
		
		public int StartingTokens
		{
			get { return _startingTokens; }
		}
		
		public string Name { get { return _name; }  }
	}
}
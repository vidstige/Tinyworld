using System;

namespace Smallworld
{
	public class Race
	{	
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
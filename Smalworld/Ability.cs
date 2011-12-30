using System;

namespace Smallworld
{
	public class Ability
	{
		public static Ability Plain = new Ability("Plain", 3); // used for testing purposes
		
		private readonly string _desciption;
		private readonly int _startingTokens;
		
		private Ability(string description, int startingTokens)
		{
			_desciption = description;
			_startingTokens = startingTokens;
		}
		
		public string Description { get { return _desciption; } }
		
		public int StartingTokens
		{
			get { return _startingTokens; }
		}
	}
}
using System;

namespace Smallworld
{
	// This class represents a ability + race combo.
	public class Tribe
	{
		private readonly Ability _ability;
		private readonly Race _race;
		
		public Tribe(Ability ability, Race race)
		{
			_ability = ability;
			_race = race;
		}
		
		public Race Race { get { return _race; } }
		
		public int StartingTokens
		{
			get { return _ability.StartingTokens + _race.StartingTokens; }
		}
		
		public override string ToString ()
		{
			return string.Format ("{0} {1}", _ability.Description, Race.Name);
		}
	}
}
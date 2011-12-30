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
	}
}
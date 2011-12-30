using System;
using System.Collections.Generic;

namespace Smallworld
{
	public class AvailableTribes
	{
		private IList<Ability> _abilities = new List<Ability>();
		private IList<Race> _races = new List<Race>();
			
		public AvailableTribes()
		{
			_abilities.Add(Ability.Plain);
		}
		
		public IEnumerable<Tribe> Tribes
		{
			get { return null; }
		}
	}
}
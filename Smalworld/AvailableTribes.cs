using System;
using System.Collections.Generic;
using System.Linq;

namespace Smallworld
{
	public class AvailableTribes
	{
		private List<Tribe> _tmp =  new List<Tribe> { 
			new Tribe(Ability.Plain, new Race("Ratmen", 8)),
			new Tribe(Ability.Plain, new Race("Ratmen", 8)),
			new Tribe(Ability.Plain, new Race("Ratmen", 8)),
			new Tribe(Ability.Plain, new Race("Ratmen", 8)),
			new Tribe(Ability.Plain, new Race("Ratmen", 8)),
			new Tribe(Ability.Plain, new Race("Ratmen", 8)),
			new Tribe(Ability.Plain, new Race("Ratmen", 8)),
			new Tribe(Ability.Plain, new Race("Ratmen", 8))
		};
		
		public IEnumerable<Tribe> Tribes
		{
			get { return _tmp.Take(6); }
		}

		public void Remove(Tribe tribe)
		{
			_tmp.Remove(tribe);
		}
	}
}
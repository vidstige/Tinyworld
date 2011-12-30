using System;
using System.Collections.Generic;
using System.Linq;

namespace Smallworld
{
	public class AvailableTribes
	{
		private List<Tribe> _tmp =  new List<Tribe> { 
			new Tribe(Ability.Plain, Race.Joes),
			new Tribe(Ability.Plain, Race.Ratmen)
		};
		
		public IEnumerable<Tribe> Tribes
		{
			get { return _tmp; }
		}

		public void Remove(Tribe tribe)
		{
			_tmp.Remove(tribe);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smallworld
{
	public class AvailableTribes
	{
		private List<Tribe> _tmp = new List<Tribe> { new Tribe(Ability.Plain, Race.Joes) };
		public IEnumerable<Tribe> Tribes
		{
			get
			{
				return _tmp;
			}
		}
	}
}
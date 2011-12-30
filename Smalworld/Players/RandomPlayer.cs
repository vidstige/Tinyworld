using System;
using System.Collections.Generic;
using System.Linq;

namespace Smallworld
{
	public class RandomPlayer: IPlayer
	{
		public Tribe SelectTribe(IEnumerable<Tribe> availableTribes)
		{
			return availableTribes.First();
		}
	}
}
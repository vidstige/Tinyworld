using System;
using System.Collections.Generic;
using System.Linq;

namespace Smallworld
{
	public class RandomPlayer: IPlayer
	{
		private Random r;
		
		public RandomPlayer(string name)
		{
			Name = name;
			r = new Random(name.GetHashCode());
		}
		
		public string Name { get; private set; }
		
		public Tribe SelectTribe(IEnumerable<Tribe> availableTribes)
		{
			return r.One(availableTribes);
		}
		
		public Region Conquer(IEnumerable<Region> availibleForConquer)
		{
			return r.One(availibleForConquer);
		}
	}
}
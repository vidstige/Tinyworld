using System;
using System.Collections.Generic;

namespace Smallworld
{
	public interface IPlayer
	{
		// Called when the player has no active tribe and needs to select a tribe.
		Tribe SelectTribe(IEnumerable<Tribe> availableTribes);

		Region Conquer(IEnumerable<Region> availibleForConquer);
	}
}
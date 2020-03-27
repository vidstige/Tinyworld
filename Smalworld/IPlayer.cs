using System;
using System.Collections.Generic;

namespace Smallworld
{
	public interface IPlayer
	{
		string Name { get; }
		
		// Called when the player has no active tribe and needs to select a tribe.
		Tribe SelectTribe(IEnumerable<Tribe> availableTribes);
		
		bool Declines();

		Region Conquer(IEnumerable<Region> availibleForConquer);

        void GatherTokens();
        void SelectNewIfNeeded();
	}
}
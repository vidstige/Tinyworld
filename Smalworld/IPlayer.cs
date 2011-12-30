using System;
using System.Collections.Generic;

namespace Smallworld
{
	public interface IPlayer
	{
		// Called when the player has no active tribe and needs to select a tribe.
		Tribe SelectTribe(IEnumerable<Tribe> availableTribes);
		
		// called on the start of each turn to check if the players wants to make its current active 
		// tribe go into decline
		//bool Decline();
		
		// Called each turn allowing the player to conquest regions if desired
		//void Conquest();
		
		// Called when no more conquests are made to allow the player to regroup
		//void Regroup();
	}
}
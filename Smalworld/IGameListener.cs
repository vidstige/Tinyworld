using System;

namespace Smallworld
{
	public interface IGameListener
	{
		void TurnStarts(int turn);
		void PlayerSelectedTribe(IPlayer player, Tribe tribe);
	}
}
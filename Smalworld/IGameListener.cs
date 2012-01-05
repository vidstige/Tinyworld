using System;

namespace Smallworld
{
	public interface IGameListener
	{
		void PlayerSelectedTribe(IPlayer player, Tribe tribe);
	}
}
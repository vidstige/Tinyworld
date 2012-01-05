using System;

namespace Smallworld
{
	public class NoListener: IGameListener
	{
		public NoListener()
		{
		}
		
		public void TurnStarts(int turn)
		{
		}
		
		public void PlayerSelectedTribe (IPlayer player, Tribe tribe)
		{
		}
	}
}
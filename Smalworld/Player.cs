using System;

namespace Smallworld
{
	internal class Player
	{
		private int _coins;
		private IPlayer _player;
		private Tribe _inDecline;
		private Tribe _active;
		
		public Player(IPlayer player)
		{
			_player = player;
		}
		
		public void SelectNewIfNeeded()
		{ 
			if (_active != null) return;
			_active = _player.SelectTribe(null);
		}
		
		public Tribe Active { get { return _active; } }
		public Tribe InDecline { get { return _inDecline; } }
		public int Coins { get { return _coins; } }
	}
}
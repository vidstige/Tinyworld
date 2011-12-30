using System;
using System.Linq;

namespace Smallworld
{
	internal class Player
	{
		private readonly IPlayer _player;
		private readonly Board _board;
		private readonly AvailableTribes _availableTribes;
		
		private int _coins;	
		//private Tribe _inDecline;
		private Tribe _active;
		
		private int _tokensInHand;
		
		public Player(IPlayer player, Board board, AvailableTribes availableTribes)
		{
			_player = player;
			_board = board;
			_availableTribes = availableTribes;
		}
		
		public void SelectNewIfNeeded()
		{ 
			if (_active != null) return;
			_active = _player.SelectTribe(_availableTribes.Tribes);
			_tokensInHand = _active.StartingTokens;
		}
		
		public void GatherTokens()
		{
			Console.WriteLine("# regions: " + _board.Regions.Count());
		}
		
		public Tribe Active { get { return _active; } }
		public int Coins { get { return _coins; } }
	}
}
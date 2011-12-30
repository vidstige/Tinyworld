using System;
using System.Collections.Generic;
using System.Linq;

namespace Smallworld
{
	public class Game
	{
		private readonly Board _board;
		private readonly int _numberOfTurns;
		private readonly IList<Player> _players;
		
		public Game(IEnumerable<IPlayer> players)
		{
			if (players.Count() != 2) throw new ArgumentException("players must contain 2 elements", "players");
			_board = BoardBuilder.CreateTwoPlayer();
			_numberOfTurns = 10;
			_players = new List<Player>(2);
			var at = new AvailableTribes();
			foreach (var p in players) _players.Add(new Player(p, _board, at));
		}
		
		public void Run()
		{
			for (int turn = 1; turn <= _numberOfTurns; turn++)
			{
				Console.WriteLine("--- Turn: " + turn + " starting ---");
				foreach (var p in _players)
				{
					p.SelectNewIfNeeded();
					p.GatherTokens();
					// TODO: Allow the player to abandon regions
					p.Conquer();
				}
			}
		}
		
	}
}
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
			var dice = new Dice(new Random(88));
			foreach (var p in players) _players.Add(new Player(p, _board, at, dice));
		}
		
		public void Run()
		{
			for (int turn = 1; turn <= _numberOfTurns; turn++)
			{
				Console.WriteLine("--- Turn: " + turn + " starting ---");
				foreach (var p in _players)
				{
					if (p.Declines())
					{
						Console.WriteLine("{0} declines", p.Name);
						p.Decline();
					}
					else
					{
						p.SelectNewIfNeeded();
						p.GatherTokens();
						// TODO: Allow the player to abandon regions
						p.Conquer();
						// TODO: Allow player to distribute tokens
					}
					p.GainCoins();
				}
			}
			Console.WriteLine("Game Over");
			foreach (var p in _players)
			{
				Console.WriteLine("{0}: {1}", p.Name, p.Coins);
			}
		}
	}
}
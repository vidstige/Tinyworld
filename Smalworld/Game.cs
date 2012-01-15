using System;
using System.Collections.Generic;
using System.Linq;

namespace Smallworld
{
	public class Game
	{
		private readonly List<string> _names;
		private readonly Board _board;
		private readonly int _numberOfTurns;
		//private readonly IList<Player> _players;
		private readonly AvailableTribes _availableTribes;
		private readonly Dictionary<string, IGameInterface> _players =
			new Dictionary<string, IGameInterface>(2);
		
		public Game(IEnumerable<string> names, Action<string, IGameInterface> inject)
		{
			if (names.Count() != 2) throw new ArgumentException("names must contain 2 elements", "names");
			_names = new List<string>(names);
			_board = BoardBuilder.CreateTwoPlayer();
			_numberOfTurns = 10;
			//_players = new List<Player>(2);
			_availableTribes = new AvailableTribes();
			var dice = new Dice(new Random(88));
			foreach (var name in _names)
			{
				var gi = new GameInterface(this);
				_players[name] = gi;
				inject(name, gi);
			}
		}

		public AvailableTribes AvailableTribes
		{
			get { return _availableTribes; }
		}		

		public void Run()
		{
			/*
			for (int turn = 1; turn <= _numberOfTurns; turn++)
			{
				_listener.TurnStarts(turn);
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
			*/
		}
	}
}
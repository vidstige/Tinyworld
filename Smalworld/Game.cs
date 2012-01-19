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
		private readonly AvailableTribes _availableTribes;
		private readonly List<GameInterface> _players;
		
		private int _currentTurn;
		private int _currentPlayerIndex = 0;
		
		public Game(IEnumerable<string> names, Action<string, IGameInterface> inject)
		{
			if (names.Count() != 2) throw new ArgumentException("names must contain 2 elements", "names");
			_names = new List<string>(names);
			_board = BoardBuilder.CreateTwoPlayer();
			_numberOfTurns = 10;
			_players = new List<GameInterface>(2);
			_availableTribes = new AvailableTribes();
			var dice = new Dice(new Random(88));
			foreach (var name in _names)
			{
				var gi = new GameInterface(name, this);
				_players.Add(gi);
				inject(name, gi);
			}
		}

		public AvailableTribes AvailableTribes
		{
			get { return _availableTribes; }
		}
		
		public string CurrentPlayer
		{
			get { return _names[_currentPlayerIndex]; }
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
		
		// TODO: Rename to "Player"?
		public class GameInterface: IGameInterface
		{
			private readonly Game _game;
			private readonly string _name;
			private readonly Tribe _active;
			private readonly Tribe _declining;
			
			private int _tokens;
				
			public GameInterface(string name, Game game)
			{
				_name = name;
				_game = game;
			}
			
			private Board Board { get { return _game._board; } }
	
			#region IGameInterface implementation
			public event Action TurnStarting;
	
			public bool CanSelectTribe { get { throw new NotImplementedException (); } }

			public void SelectTribe(Tribe tribe)
			{
				// TODO: Check so tribe exist in available tribes
				_active = tribe;
				// TODO: Remove tribe
			}
	
			public bool CanAbandon {
				get
				{
					throw new NotImplementedException ();
				}
			}

			public void Abandon(Region region)
			{
				throw new NotImplementedException();
			}
			
			public bool CanConquer {
				get
				{
					throw new NotImplementedException ();
				}
			}

			public void Conquer(Region region)
			{
				throw new NotImplementedException();
			}
	
			public void Regroup(Region region, int tokens)
			{
				throw new NotImplementedException();
			}
	
			public int TurnNumber { get { return _game._currentTurn;  } }
	
			public int TokensInHand { get { throw new NotImplementedException (); } }
	
			public Tribe Active { get { return _active; } }
	
			public Tribe Declining { get { return _declining; } }
	
			public IEnumerable<Tribe> AvailibleTribes {
				get
				{
					throw new NotImplementedException ();
				}
			}
	
			public IEnumerable<Region> AbandonableRegions {
				get
				{
					throw new NotImplementedException ();
				}
			}
	
			public IEnumerable<Region> ConquerableRegions {
				get
				{
					throw new NotImplementedException ();
				}
			}
	
			public bool CanRegroup {
				get {
					throw new NotImplementedException ();
				}
			}
	
			public IEnumerable<Region> RegroupableRegions {
				get {
					throw new NotImplementedException ();
				}
			}
			#endregion
		}
	}
	
}
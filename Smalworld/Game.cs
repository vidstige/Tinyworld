using System;
using System.Collections.Generic;
using System.Linq;

namespace Smallworld
{
	public class Game
	{
		private readonly Board _board;
		private readonly int _numberOfTurns;
		private readonly AvailableTribes _availableTribes;
        private readonly IList<IPlayer> _players = new List<IPlayer>();
        private readonly IList<GameInterface> _gis = new List<GameInterface>();

        private readonly IGameListener _listener;

		private int _currentTurn;
		private int _currentPlayerIndex = 0;
		
		public Game(IEnumerable<IPlayer> players, Action<string, IGameInterface> inject)
		{
            if (players.Count() != 2) throw new ArgumentException("names must contain 2 elements", "names");
			_board = BoardBuilder.CreateTwoPlayer();
			_numberOfTurns = 10;
			_availableTribes = new AvailableTribes();
			var dice = new Dice(new Random(88));
            foreach (var player in players)
			{
				var gi = new GameInterface(player.Name, this);
				_players.Add(player);
                _gis.Add(gi);
				inject(player.Name, gi);
			}
		}

		public AvailableTribes AvailableTribes
		{
			get { return _availableTribes; }
		}
		
		public string CurrentPlayer
		{
			get { return _players[_currentPlayerIndex].Name; }
		}

		public void Run()
		{
			for (int turn = 1; turn <= _numberOfTurns; turn++)
			{
				_listener.TurnStarts(turn);
				foreach (var p in _players)
				{
                    var gi = _gis.Where(g => g.Name == p.Name);
					if (p.Declines())
					{
						Console.WriteLine("{0} declines", p.Name);
                        //gi.Decline();
					}
					else
					{
                        p.SelectNewIfNeeded();
                        p.GatherTokens();
						// TODO: Allow the player to abandon regions
                        p.Conquer();
						// TODO: Allow player to distribute tokens
					}
					gi.GainCoins();
				}
			}
			Console.WriteLine("Game Over");
			foreach (var g in _gis)
			{
				Console.WriteLine("{0}: {1}", g.Name, g.Coins);
			}
		}
		
		// TODO: Rename to "Player"?
		public class GameInterface: IGameInterface
		{
			private readonly Game _game;
			private readonly string _name;
			private Tribe _active;
			private Tribe _declining;

            private int _coins;
			private int _tokens;
				
			public GameInterface(string name, Game game)
			{
				_name = name;
				_game = game;
                _coins = 0;
			}
			
			public string Name { get { return _name; }}
			
			private Board Board { get { return _game._board; } }
	
			#region IGameInterface implementation
	
			public bool CanSelectTribe { get { throw new NotImplementedException (); } }

			public void SelectTribe(Tribe tribe)
			{
				// TODO: Check so tribe exist in available tribes
				_active = tribe;
				_game.AvailableTribes.Remove(tribe);
				_tokens = tribe.StartingTokens;
			}
	
			public bool CanAbandon
			{
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
            
            public int Coins
            {
                get { return _coins; }
            }
			#endregion
		}
	}
	
}
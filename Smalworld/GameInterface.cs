using System;

namespace Smallworld
{
	public class GameInterface: IGameInterface
	{
		private readonly Game _game;
		
		public GameInterface(Game game)
		{
			_game = game;
		}

		#region IGameInterface implementation
		public event Action TurnStarting;

		public void SelectTribe (Tribe tribe)
		{
			throw new NotImplementedException ();
		}

		public void Abandon (Region region)
		{
			throw new NotImplementedException ();
		}

		public void Conquer (Region region)
		{
			throw new NotImplementedException ();
		}

		public void Regroup (Region region, int tokens)
		{
			throw new NotImplementedException ();
		}

		public int TurnNumber {
			get {
				throw new NotImplementedException ();
			}
		}

		public int TokensInHand {
			get {
				throw new NotImplementedException ();
			}
		}

		public Tribe Active {
			get {
				throw new NotImplementedException ();
			}
		}

		public Tribe Declining {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool CanSelectTribe {
			get {
				throw new NotImplementedException ();
			}
		}

		public System.Collections.Generic.IEnumerable<Tribe> AvailibleTribes {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool CanAbandon {
			get {
				throw new NotImplementedException ();
			}
		}

		public System.Collections.Generic.IEnumerable<Region> AbandonableRegions {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool CanConquer {
			get {
				throw new NotImplementedException ();
			}
		}

		public System.Collections.Generic.IEnumerable<Region> ConquerableRegions {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool CanRegroup {
			get {
				throw new NotImplementedException ();
			}
		}

		public System.Collections.Generic.IEnumerable<Region> RegroupableRegions {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
	}
}
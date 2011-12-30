using System;

namespace Smallworld
{
	public class Board
	{
		private Region _edge;
		
		internal Board(Region edge)
		{
			_edge = edge;
		}
		
		public Region Edge
		{
			get { return _edge; }
		}
	}
}
using System;
using Smallworld;

namespace Tinyworld
{
	public class WebPlayer
	{
		public WebPlayer(string name, IGameInterface gameInterface)
		{
			Interface = gameInterface;
		}
		
		public IGameInterface Interface
		{
			get; private set;
		}
	}
}
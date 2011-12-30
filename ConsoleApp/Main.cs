using System;
using Smallworld;

namespace ConsoleApp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var players = new [] { new RandomPlayer(), new RandomPlayer() };
			var game = new Game(players);
			game.Run();
		}
	}
}
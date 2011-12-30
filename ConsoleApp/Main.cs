using System;
using Smallworld;

namespace ConsoleApp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var players = new [] { new RandomPlayer() { Name = "Player 1"}, new RandomPlayer() { Name = "Player 2" } };
			var game = new Game(players);
			game.Run();
		}
	}
}
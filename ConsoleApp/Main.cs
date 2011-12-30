using System;
using Smallworld;

namespace ConsoleApp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var players = new [] { new RandomPlayer() { Name = "Samuel"}, new RandomPlayer() { Name = "Lisa" } };
			var game = new Game(players);
			game.Run();
		}
	}
}
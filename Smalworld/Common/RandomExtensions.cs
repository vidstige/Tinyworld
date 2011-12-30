using System;
using System.Linq;
using System.Collections.Generic;

namespace Smallworld
{
	public static class RandomExtensions
	{
		public static T One<T>(this Random random, IEnumerable<T> all)
		{
			int index = random.Next(all.Count());
			return all.ElementAt(index);
		}
	}
}
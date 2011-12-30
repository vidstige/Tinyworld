using System;
using System.Collections.Generic;
using System.Linq;

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
		
		public IEnumerable<Region> Regions
		{
			get { return AllRegions(Edge); }
		}
		
		private IEnumerable<Region> AllRegions(Region root)
		{
			var visited = new List<Region>();
			var nodes = new Stack<Region>(new[] {root});
        	while (nodes.Any())
        	{
	            Region node = nodes.Pop();
				if (!visited.Contains(node)) 
				{
        			yield return node;
					visited.Add(node);
				}
				
            	foreach (var n in node.Adjecent) 
				{
					if (!visited.Contains(n)) nodes.Push(n);
				}
        	}		
		}
	}
}
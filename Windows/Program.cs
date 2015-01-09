using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AStar;
using Microsoft.Xna.Framework;

namespace AStarTest.Windows
{
	class Program
	{
		static void Main(string[] args)
		{
			//create the map
			var map = new Map(1);

			//get a path thourgh the map
			var walker = new Pathfinder(map);

			var path = walker.FindPath(map.Start, map.End);

			//add all the map points
			for (int i = 0; i < path.Count; i++)
			{
				map.Mark(path[i], 2);
			}

			map.Mark(map.Start, 3);
			map.Mark(map.End, 4);

			map.DrawMap();
		}
	}
}

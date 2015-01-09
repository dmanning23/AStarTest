using System.Text;
using AStar;
using System;
using Microsoft.Xna.Framework;

namespace AStarTest
{
	/// <summary>
	/// This is the actual 2d map as loaded from file or whatever.
	/// </summary>
	public class Map : IMap
	{
		public int Width { get; private set; }

		public int Height { get; private set; }

		private int[,] map;

		public Point Start { get; private set; }

		public Point End { get; private set; }

		public Map(int map)
		{
			SetMap(map);
		}

		public void SetMap(int id)
		{
			switch (id)
			{
				case 0:
					{
						map = new[,] {{0,0,0,0,1,0,0},
                                      {1,1,1,1,1,1,0},
                                      {0,1,0,0,0,1,0},
                                      {0,1,0,1,0,1,0},
                                      {0,0,0,1,0,0,0}};

						Width = 7;
						Height = 5;
						Start = new Point(0, 2);
						End = new Point(1, 4);
						break;
					}
				default:
					{
						map = new[,] {{0,1,0,0,0,0,0,0,0,0,0,0,0,1,0},
                                      {0,1,1,1,1,1,0,1,0,0,0,0,0,1,0},
                                      {0,1,0,0,0,1,0,1,0,0,0,0,0,1,0},
                                      {0,1,0,1,0,1,0,1,0,0,0,0,0,1,0},
                                      {0,1,0,1,1,1,0,1,0,0,0,0,0,1,0},
                                      {0,0,0,0,0,0,0,1,0,0,0,0,0,1,0},
                                      {1,1,1,1,1,1,0,1,0,0,0,0,0,1,0},
                                      {0,0,0,0,0,0,0,1,0,0,0,0,0,1,0},
                                      {0,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};

						Width = 15;
						Height = 10;
						Start = new Point(0, 0);
						End = new Point(10, 5);
						break;
					}
			}
		}

		public void Mark(Point input, int val)
		{
			map[input.Y, input.X] = val;
		}

		public void DrawMap()
		{
			StringBuilder str = new StringBuilder();
			for (int x = 0; x < Width; x++)
			{
				for (int y = 0; y < Height; y++)
				{
					switch (map[y, x])
					{
						case 0: { str.Append("."); } break;
						case 1: { str.Append("X"); } break;
						case 2: { str.Append("O"); } break;
						case 3: { str.Append("S"); } break;
						case 4: { str.Append("G"); } break;
					}
				}
				str.Append("\n");
			}

			Console.Write(str.ToString());
		}

		public bool GetWalkable(int x, int y)
		{
			return map[y, x] == 0;
		}
	}
}

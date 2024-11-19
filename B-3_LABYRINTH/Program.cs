// See https://aka.ms/new-console-template for more information
using AStar;
using AStar.Options;
using Involved.HTF.Common;
using Involved.HTF.Common.Dto;
using System.Drawing;

Console.WriteLine("Hello, World!");
HackTheFutureClient client = new HackTheFutureClient();
await client.Login("segfault", "b6fedc0f-4008-42ca-9982-538e129a5e35");
MazeDTO dto = await client.GetMaze();
var pathfinderOptions = new PathFinderOptions
{
    HeuristicFormula = AStar.Heuristics.HeuristicFormula.Euclidean,
    PunishChangeDirection = true,
    UseDiagonals = false,
    SearchLimit = 9999999
};
var tiles = dto.MapMazeToshortArray();
var worldGrid = new WorldGrid(tiles);
var pathfinder = new PathFinder(worldGrid, pathfinderOptions);

// The following are equivalent:

// matrix indexing
int[] start = dto.getStart();
int[] end = dto.getEnd();
Position[] path = pathfinder.FindPath(new Position(start[0], start[1]), new Position(end[0], end[1]));

// point indexing
//Point[] path = pathfinder.FindPath(new Point(0, 0), new Point(2, 0));
Console.WriteLine(path.Length - 1);
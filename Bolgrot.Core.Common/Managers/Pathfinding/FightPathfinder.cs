using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Bolgrot.Core.Common.Entity.Data;

namespace Bolgrot.Core.Common.Managers.Pathfinding
{
    public class FightPathfinder
    {
	    private Map map;
		private Dictionary<string, int> mapPointToCellId = new Dictionary<string, int>();

		public FightPathfinder(Map map, Dictionary<string, int> mapPointToCellId)
		{
			this.map = map;
			this.mapPointToCellId = mapPointToCellId;
		}

		private Point getMapPointFromCellId(int cellId)
		{
			var row = cellId % 14 - ~~(cellId / 28);
			var x = row + 19;
			var y = row + ~~(cellId / 14);
			return new Point(x, y);
		}

		private int getCellIdFromMapPoint(int x, int y)
		{
			if (!mapPointToCellId.ContainsKey(x.ToString() + '_' + y.ToString()))
				return 0;

			var cellId = mapPointToCellId[x.ToString() + '_' + y.ToString()];
			return cellId;
		}


		private List<int> getNeighbourCells(int cellId, bool allowDiagonal)
		{
			allowDiagonal = allowDiagonal || false;
			var coord = getMapPointFromCellId(cellId);
			var x = coord.X;
			var y = coord.Y;
			var neighbours = new List<int>();
			if (allowDiagonal) { neighbours.Add(getCellIdFromMapPoint(x + 1, y + 1)); }
			neighbours.Add(getCellIdFromMapPoint(x, y + 1));
			if (allowDiagonal) { neighbours.Add(getCellIdFromMapPoint(x - 1, y + 1)); }
			neighbours.Add(getCellIdFromMapPoint(x - 1, y));
			if (allowDiagonal) { neighbours.Add(getCellIdFromMapPoint(x - 1, y - 1)); }
			neighbours.Add(getCellIdFromMapPoint(x, y - 1));
			if (allowDiagonal) { neighbours.Add(getCellIdFromMapPoint(x + 1, y - 1)); }
			neighbours.Add(getCellIdFromMapPoint(x + 1, y));

			return neighbours;
		}


		// private int getTackleRatio(Fighter actor, Fighter tackler)
		// {
		// 	var evade = Math.Max(0, actor.stats.tackleEvade);
		// 	var block = Math.Max(0, tackler.stats.tackleBlock); //@TODO tackler = Fighter
		// 	return (evade + 2) / (block + 2) / 2;
		// }

		// private Cost getTackleCost(Fighter actor, List<Fighter> tacklers, int mp, int ap)
		// {
		// 	mp = Math.Max(0, mp);
		// 	ap = Math.Max(0, ap);
		//
		// 	var cost = new Cost(0, 0);
		//
		// 	if (!canBeTackled(actor)) { return cost; }
		// 	if (tacklers.Count == 0) { return cost; }
		//
		// 	for (var i = 0; i < tacklers.Count; i++)
		// 	{
		// 		var tackler = tacklers[i];
		// 		if (tackler == null) { continue; } // tackler may have die at this point
		// 		//if (!canBeTackler(tackler, actor)) { continue; }
		//
		//
		// 		var tackle = getTackleRatio(actor, tackler);
		// 		if (tackle >= 1) { continue; }
		// 		cost.mp += ~~Convert.ToInt32(mp * (1 - tackle) + 0.5);
		// 		cost.ap += ~~Convert.ToInt32(ap * (1 - tackle) + 0.5);
		// 	}
		//
		// 	return cost;
		// }


		// private bool canBeTackled(Fighter fighter)
		// {
		// 	if (fighter == null)
		// 	{
		// 		return false;
		// 	}
		//
		// 	/*
		// 	if (fighter.data.stats.invisibilityState === INVISIBLE) { return false; }
		// 	if (fighter.data.stats.invisibilityState === DETECTED) { return false; }
		// 	if (fighter.data.isCarryied) { return false; }
		// 	if (fighter.hasState(UNTACKLABLE)) { return false; }
		// 	if (fighter.hasState(ROOTED)) { return false; }
		// 	*/
		//
		// 	return false;
		// }



		// public void displayInFight(Fighter fighter, int targetCellId, List<Fighter> occupiedCells)
		// {
		// 	var fightMovementReachableZone = GetReachableZone(fighter, fighter.CellId, occupiedCells);
		// 	var target = targetCellId;
		//
		//
		//
		// }


		public Node getPath(int source, int target, Dictionary<int, MoveNode> zone)
		{
			if (!zone.ContainsKey(target))
				return null;


			var node = zone[target];

			if (node.path == null)
			{
				var current = target;
				var reachable = new List<int>();
				var reachableMap = new Dictionary<int, int>();
				var unreachable = new List<int>();
				var unreachableMap = new Dictionary<int, int>();
				var mp = 0;
				var ap = 0;
				var distance = 0;

				while (current != source)
				{
					var cell = zone[current];
					if (cell.reachable)
					{
						reachable.Insert(0, current);
						reachableMap[current] = distance;
					}
					else
					{
						unreachable.Insert(0, current);
						unreachableMap[current] = distance;
					}
					mp += cell.mp;
					ap += cell.ap;
					current = cell.from;
					distance += 1;
				}


				node.path = new Node(reachable, unreachable, mp, ap, reachableMap.Select(x => x.Value).ToList(), unreachableMap.Select(x => x.Value).ToList());
			}

			return node.path;
		}


		// public Dictionary<int, MoveNode> GetReachableZone(Fighter fighter, int currentCellId, List<Fighter> occupiedCells)
		// {
		// 	var maxDistance = fighter.MovementPoints;
		//
		//
		// 	List<PathNode> opened = new List<PathNode>();
		// 	Dictionary<int, PathNode> closed = new Dictionary<int, PathNode>();
		// 	Dictionary<int, MoveNode> movementZone = new Dictionary<int, MoveNode>();
		//
		// 	if (maxDistance <= 0)
		// 		return movementZone;
		//
		//
		// 	var node = new PathNode(currentCellId, fighter.MovementPoints, fighter.ActionPoints, 0, 0, 1);
		// 	opened.Add(node);
		//
		// 	closed.Add(currentCellId, node);
		//
		// 	//TODO markedCellIds
		//
		// 	while (opened.Count > 0)
		// 	{
		// 		var current = opened[opened.Count - 1];
		//
		// 		opened.Remove(current);
		//
		// 		var cellId = current.cellId;
		// 		var neighbours = getNeighbourCells(cellId, false);
		//
		// 		// get tacklers list
		// 		var tacklers = new List<Fighter>();
		// 		var i = 0;
		// 		var neighbour = 0;
		// 		while (i < neighbours.Count)
		// 		{
		// 			neighbour = neighbours[i];
		// 			var tackler = occupiedCells.FirstOrDefault(x => x.CellId == neighbour);
		// 			if (neighbour != 0 && tackler == null)
		// 			{
		// 				i++;
		// 				continue;
		// 			}
		// 			neighbours.RemoveAt(i); // cell is not walkable
		// 			if (tackler != null) { tacklers.Add(tackler); }
		//
		//
		// 		}
		//
		// 		var tackleCost = getTackleCost(fighter, tacklers, current.availableMp, current.availableAp);
		// 		var availableMp = current.availableMp - tackleCost.mp - 1; // tackle cost + 1 mp to move
		// 		var availableAp = current.availableAp - tackleCost.ap;
		// 		var tackleMp = current.tackleMp + tackleCost.mp;
		// 		var tackleAp = current.tackleAp + tackleCost.ap;
		// 		var distance = current.distance + 1;
		// 		var reachable = availableMp >= 0;
		//
		// 		for (i = 0; i < neighbours.Count; i++)
		// 		{
		// 			neighbour = neighbours[i];
		//
		// 			// this cell has already been checked.
		// 			// see if new cost is better than previous one.
		// 			if (closed.ContainsKey(neighbour))
		// 			{
		// 				var previous = closed[neighbour];
		// 				// don't consider this path to this neighbour if available mp are less than previous path
		// 				if (previous.availableMp > availableMp) { continue; }
		// 				// if mp costs are the same, then test available ap
		// 				if (previous.availableMp == availableMp && previous.availableAp >= availableAp) { continue; }
		// 			}
		//
		// 			// cell is not walkable in fight
		// 			if (!map.IsWalkable(neighbour, true)) { continue; }
		//
		// 			movementZone[neighbour] = new MoveNode(tackleCost, cellId, reachable);
		// 			node = new PathNode(neighbour, availableMp, availableAp, tackleMp, tackleAp, distance);
		// 			closed[neighbour] = node;
		//
		//
		// 			if (current.distance < maxDistance)
		// 				opened.Add(node);
		// 		}
		//
		// 		foreach (short cellKey in movementZone.Keys)
		// 		{
		// 			movementZone[cellKey].path = getPath(currentCellId, cellKey, movementZone);
		// 		}
		// 	}
		//
		// 	return movementZone;
		// }
    }
}

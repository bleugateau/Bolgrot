using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Data;
using Bolgrot.Core.Ankama.Protocol.Enums;
using Bolgrot.Core.Common.Entity.Data;

namespace Bolgrot.Core.Common.Managers.Pathfinding
{
    public interface IPathfinderManager
    {
        public Task<int[]> GetPath(Map map, int startCellId, int destCellId, List<int> occupiedCells,
            bool allowDiagonals = false,
            bool stopNextToTarget = false);

        public List<Cell> DecompressKeyMovements(Map map, int[] keyMovements);

        public int GetOppositeCellId(Map map, int cellId);
    }

    public class PathfinderManager : IPathfinderManager
    {
        const int WIDTH = 33 + 2;
        const int HEIGHT = 34 + 2;
        const double ELEVATION_TOLERANCE = 11.825;
        const int OCCUPIED_CELL_WEIGHT = 10;
        const int CHANGE_MAP_MASK_RIGHT = 1 | 2 | 128;
        const int CHANGE_MAP_MASK_BOTTOM = 2 | 4 | 8;
        const int CHANGE_MAP_MASK_LEFT = 8 | 16 | 32;
        const int CHANGE_MAP_MASK_TOP = 32 | 64 | 128;

        //public Map Map { get; set; }

        public Dictionary<int, CellPathData[]> Grid = new Dictionary<int, CellPathData[]>();

        //public List<CellChangeMap> CellChangeMaps = new List<CellChangeMap>();

        public Dictionary<string, int> MapPointToCellId = new Dictionary<string, int>();

        private int firstCellZone;
        private bool oldMovementSystem = false;

        public PathfinderManager()
        {
            //init grid
            for (var i = 0; i < WIDTH; i += 1)
            {
                var cellPathDatas = new CellPathData[HEIGHT];
                for (var j = 0; j < HEIGHT; j += 1)
                {
                    cellPathDatas[j] = new CellPathData(i, j);
                }

                Grid[i] = cellPathDatas;
            }

            //build map points
            constructMapPoints();
        }


        private OrientationEnum getChangeMapFlags(Map map, int cellId)
        {
            var mapChangeData = map.Cells[cellId].C;
            if (mapChangeData == 0)
                return OrientationEnum.NONE;

            //left
            if ((mapChangeData & CHANGE_MAP_MASK_LEFT) != 0 && (cellId % 14 == 0))
                return OrientationEnum.LEFT;

            if ((mapChangeData & CHANGE_MAP_MASK_RIGHT) != 0 && (cellId % 14 == 13))
                return OrientationEnum.RIGHT;


            if ((mapChangeData & CHANGE_MAP_MASK_TOP) != 0 && (cellId < 28))
                return OrientationEnum.TOP;

            if ((mapChangeData & CHANGE_MAP_MASK_BOTTOM) != 0 && (cellId > 531))
                return OrientationEnum.BOTTOM;


            return OrientationEnum.NONE;
        }

        public List<Cell> DecompressKeyMovements(Map map, int[] keyMovements)
        {
            var decompressedCells = new List<Cell>();

            foreach (var cell in keyMovements)
            {
                int cellId = cell & 4095;
                decompressedCells.Add(map.Cells.ToList().FirstOrDefault(x => x.Id == cellId));
            }

            return decompressedCells;
        }

        /**
         * Get opposite cell Id
         */
        public int GetOppositeCellId(Map map, int cellId)
        {
            int oppositeCellId = 0;
            
            if (cellId % 14 == 0)
            {
                oppositeCellId = (cellId + 13);
            }
            else if ((cellId + 1) % 14 == 0)
            {
                oppositeCellId = (cellId - 13);
            }
            else if (cellId < 28)
            {
                oppositeCellId = (cellId + 532);
            }
            else if (cellId > 531)
            {
                oppositeCellId = (cellId - 532);
            }

            if (map.Cells.FirstOrDefault(x => x.IsWalkable() && x.Id == cellId) == null)
            {
                //need to find nearest cell
                var nearestCell = FindNearestCellFromCellId(map, oppositeCellId);

                if (nearestCell != null)
                {
                    oppositeCellId = nearestCell.Id;
                }
            }

            return oppositeCellId;
        }

        private Cell FindNearestCellFromCellId(Map map, int cellId)
        {
            int nearestDistance = -1;
            Cell nearestDistanceCell = null;
            
            foreach (var cell in map.Cells.ToList().Where(x => x.IsWalkable()))
            {
                var distance = (int)this.getDistance(cellId, cell.Id);
                if (nearestDistance == -1 || (distance < nearestDistance))
                {
                    nearestDistanceCell = cell;
                    nearestDistance = distance;
                }
            }

            return null;
        }

        public Task<int[]> GetPath(Map map, int startCellId, int destCellId, List<int> occupiedCells,
            bool allowDiagonals = false,
            bool stopNextToTarget = false)
        {
            CellPath candidate = null;

            fillPathGrid(map, map.CellChangeMaps.Count == 0);

            var srcPos = getMapPoint(startCellId); // source index
            var dstPos = getMapPoint(destCellId); // source index

            var si = srcPos.X + 1;
            var sj = srcPos.Y + 1;

            var srcCell = Grid[si][sj];

            if (srcCell.zone == -1)
            {
                // Searching for accessible cell around source
                CellPathData bestFit = null;
                var bestDist = Math.Pow(10, 1000);
                var bestFloorDiff = Math.Pow(10, 1000);
                for (var i = -1; i <= 1; i += 1)
                {
                    for (var j = -1; j <= 1; j += 1)
                    {
                        if (i == 0 && j == 0)
                        {
                            continue;
                        }

                        var cell = Grid[si + i][sj + j];
                        if (cell.zone == -1)
                        {
                            continue;
                        }

                        var floorDiff = Math.Abs(cell.floor - srcCell.floor);
                        var dist = Math.Abs(i) + Math.Abs(j);
                        if (bestFit == null || floorDiff < bestFloorDiff ||
                            (floorDiff <= bestFloorDiff && dist < bestDist))
                        {
                            bestFit = cell;
                            bestDist = dist;
                            bestFloorDiff = floorDiff;
                        }
                    }
                }

                if (bestFit != null)
                {
                    return Task.FromResult(new int[2] {startCellId, getCellId(bestFit.i - 1, bestFit.j - 1)});
                }

                Console.WriteLine("[pathFinder.getPath] Player is stuck in {0}/{1}", si, sj);

                return Task.FromResult(new int[1] {startCellId});
            }

            var di = dstPos.X + 1; // destination i
            var dj = dstPos.Y + 1; // destination j

            // marking cells as occupied
            Point cellPos;
            //var cellId = 0;

            foreach (var cellId in occupiedCells)
            {
                cellPos = getMapPoint(cellId);
                Grid[cellPos.X + 1][cellPos.Y + 1].weight += OCCUPIED_CELL_WEIGHT;
            }

            // First cell in the path
            var distSrcDst = Math.Sqrt((si - di) * (si - di) + (sj - dj) * (sj - dj));
            var selection = new CellPath(si, sj, 0, (int) distSrcDst, null);


            List<CellPath> candidates = new List<CellPath>();
            List<CellPath> selections = new List<CellPath>();

            // Adding cells to path until destination has been reached
            CellPath reachingPath = null;
            var closestPath = selection;

            while (selection.i != di || selection.j != dj)
            {
                addCandidates(selection, di, dj, candidates, allowDiagonals);

                // Looking for candidate with the smallest additional length to path
                // in O(number of candidates)
                var n = candidates.Count;
                if (n == 0)
                {
                    // No possible path
                    // returning the closest path to destination
                    selection = closestPath;
                    break;
                }

                var minPotentialWeight = Math.Pow(10, 1000);
                var selectionIndex = 0;
                for (int c = 0; c < n; c += 1)
                {
                    candidate = candidates[c];
                    if (candidate.w + candidate.d < minPotentialWeight)
                    {
                        selection = candidate;
                        minPotentialWeight = candidate.w + candidate.d;
                        selectionIndex = c;
                    }
                }

                selections.Add(selection);
                candidates.RemoveAt(selectionIndex);

                // If stopNextToTarget
                // then when reaching a distance of less than Math.sqrt(2) the destination is considered as reached
                // (the threshold has to be bigger than sqrt(2) but smaller than 2, to be safe we use the value 1.5)
                if (selection.d == 0 || (stopNextToTarget && selection.d < 1.5))
                {
                    // Selected path reached destination
                    if (reachingPath == null || selection.w < reachingPath.w)
                    {
                        reachingPath = selection;
                        closestPath = selection;

                        // Clearing candidates dominated by current solution to speed up the algorithm
                        List<CellPath> trimmedCandidates = new List<CellPath>();
                        for (int c = 0; c < candidates.Count; c += 1)
                        {
                            candidate = candidates[c];
                            if (candidate.w + candidate.d < reachingPath.w)
                            {
                                trimmedCandidates.Add(candidate);
                            }
                            else
                            {
                                Grid[candidate.i][candidate.j].candidateRef = null;
                            }
                        }

                        candidates = trimmedCandidates;
                    }
                }
                else
                {
                    if (selection.d < closestPath.d)
                    {
                        // 'selection' is the new closest path to destination
                        closestPath = selection;
                    }
                }
            }

            // Removing candidate reference in each cell in selections and active candidates
            for (int c = 0; c < candidates.Count; c += 1)
            {
                candidate = candidates[c];
                Grid[candidate.i][candidate.j].candidateRef = null;
            }

            for (var s = 0; s < selections.Count; s += 1)
            {
                selection = selections[s];
                Grid[selection.i][selection.j].candidateRef = null;
            }

            // Marking cells as unoccupied
            foreach (var cell in occupiedCells)
            {
                cellPos = getMapPoint(cell);
                Grid[cellPos.X + 1][cellPos.Y + 1].weight -= OCCUPIED_CELL_WEIGHT;
            }

            List<int> shortestPath = new List<int>();
            while (closestPath != null)
            {
                shortestPath.Add(getCellId(closestPath.i - 1, closestPath.j - 1));
                closestPath = closestPath.path;
            }


            return Task.FromResult(shortestPath.ToArray());
        }

        public List<int> CompressPath(int[] path)
        {
            var compressedPath = new List<int>();
            var prevCellId = path[0];
            var prevDirection = -1;

            var prevX = 0;
            var prevY = 0;

            for (var i = 0; i < path.Length; i++)
            {
                var cellId = path[i];

                int direction;
                var coord = getMapPoint(cellId);

                // get direction
                if (i == 0)
                {
                    direction = -1;
                }
                else
                {
                    if (coord.Y == prevY)
                    {
                        // move horizontaly
                        direction = coord.X > prevX ? 7 : 3;
                    }
                    else if (coord.X == prevX)
                    {
                        // move verticaly
                        direction = coord.Y > prevY ? 1 : 5;
                    }
                    else
                    {
                        // move in diagonal
                        if (coord.X > prevX)
                        {
                            direction = coord.Y > prevY ? 0 : 6;
                        }
                        else
                        {
                            direction = coord.Y > prevY ? 2 : 4;
                        }
                    }
                }

                if (direction != prevDirection)
                {
                    compressedPath.Add(prevCellId + (direction << 12));
                    prevDirection = direction;
                }

                prevCellId = cellId;
                prevX = coord.X;
                prevY = coord.Y;
            }

            compressedPath.Add(prevCellId + (prevDirection << 12));

            return compressedPath;
        }

        private void fillPathGrid(Map map, bool fillCellsChangeMap = false)
        {
            firstCellZone = map.Cells[0].Z;
            oldMovementSystem = true;

            for (var i = 0; i < WIDTH; i += 1)
            {
                var row = Grid[i];
                for (var j = 0; j < HEIGHT; j += 1)
                {
                    var cellId = getCellId(i - 1, j - 1);

                    if (cellId == 0)
                    {
                        continue;
                    }

                    var cellPath = row[j];
                    var cell = map.Cells[cellId];
                    row[j] = updateCellPath(cell, cellPath);


                    if (!fillCellsChangeMap)
                    {
                        continue;
                    }

                    var changeMapFlag = getChangeMapFlags(map, cellId);

                    if (changeMapFlag != OrientationEnum.NONE)
                    {
                        map.CellChangeMaps.Add(new CellChangeMap(cellId, changeMapFlag));
                    }
                }

                Grid[i] = row;
            }
        }

        public List<AccessibleCell> getAccessibleCells(int i, int j)
        {
            i += 1;
            j += 1;
            var c = Grid[i][j];

            // Adjacent cells
            var c01 = Grid[i - 1][j];
            var c10 = Grid[i][j - 1];
            var c12 = Grid[i][j + 1];
            var c21 = Grid[i + 1][j];

            var accessibleCells = new List<AccessibleCell>();

            if (areCommunicating(c, c01))
                accessibleCells.Add(new AccessibleCell(c01.i - 1, c01.j - 1));

            if (areCommunicating(c, c21))
                accessibleCells.Add(new AccessibleCell(c21.i - 1, c21.j - 1));

            if (areCommunicating(c, c10))
                accessibleCells.Add(new AccessibleCell(c10.i - 1, c10.j - 1));

            if (areCommunicating(c, c12))
                accessibleCells.Add(new AccessibleCell(c12.i - 1, c12.j - 1));

            return accessibleCells;
        }

        private void addCandidate(CellPathData c, int w, int di, int dj, List<CellPath> candidates, CellPath path)
        {
            var i = c.i;
            var j = c.j;

            // The total weight of the candidate is the weight of previous path
            // plus its weight (calculated based on occupancy and speed factor)
            var distanceToDestination = Math.Sqrt((di - i) * (di - i) + (dj - j) * (dj - j));
            w = w / c.speed + c.weight;

            if (c.candidateRef == null)
            {
                var candidateRef = new CellPath(i, j, path.w + w, (int) distanceToDestination, path);
                //candidates.push(candidateRef);
                candidates.Add(candidateRef);
                c.candidateRef = candidateRef;
            }
            else
            {
                var currentWeight = c.candidateRef.w;
                var newWeight = path.w + w;
                if (newWeight < currentWeight)
                {
                    c.candidateRef.w = newWeight;
                    c.candidateRef.path = path;
                }
            }
        }

        private void addCandidates(CellPath path, int di, int dj, List<CellPath> candidates,
            bool allowDiagonals = false)
        {
            var i = path.i;
            var j = path.j;
            var c = Grid[i][j];


            // Searching whether adjacent cells can be candidates to lengthen the path

            // Adjacent cells
            var c01 = Grid[i - 1][j];
            var c10 = Grid[i][j - 1];
            var c12 = Grid[i][j + 1];
            var c21 = Grid[i + 1][j];

            // weight of path in straight line = 1
            var weightStraight = 1;

            if (areCommunicating(c, c01))
            {
                addCandidate(c01, weightStraight, di, dj, candidates, path);
            }

            if (areCommunicating(c, c21))
            {
                addCandidate(c21, weightStraight, di, dj, candidates, path);
            }

            if (areCommunicating(c, c10))
            {
                addCandidate(c10, weightStraight, di, dj, candidates, path);
            }

            if (areCommunicating(c, c12))
            {
                addCandidate(c12, weightStraight, di, dj, candidates, path);
            }


            // Searching whether diagonally adjacent cells can be candidates to lengthen the path

            // Diagonally adjacent cells
            var c00 = Grid[i - 1][j - 1];
            var c02 = Grid[i - 1][j + 1];
            var c20 = Grid[i + 1][j - 1];
            var c22 = Grid[i + 1][j + 1];

            // weight of path in diagonal = Math.sqrt(2)
            var weightDiagonal = Math.Sqrt(2);

            if (allowDiagonals)
            {
                if (canMoveDiagonallyTo(c, c00, c01, c10))
                {
                    addCandidate(c00, (int) weightDiagonal, di, dj, candidates, path);
                }

                if (canMoveDiagonallyTo(c, c20, c21, c10))
                {
                    addCandidate(c20, (int) weightDiagonal, di, dj, candidates, path);
                }

                if (canMoveDiagonallyTo(c, c02, c01, c12))
                {
                    addCandidate(c02, (int) weightDiagonal, di, dj, candidates, path);
                }

                if (canMoveDiagonallyTo(c, c22, c21, c12))
                {
                    addCandidate(c22, (int) weightDiagonal, di, dj, candidates, path);
                }
            }
        }

        public void constructMapPoints()
        {
            for (var cellId = 0; cellId < 560; cellId++)
            {
                var coord = getMapPoint(cellId);
                MapPointToCellId[coord.X.ToString() + '_' + coord.Y.ToString()] = cellId;
            }
        }

        public Point getMapPoint(int cellId)
        {
            var row = cellId % 14 - ~~(cellId / 28);
            var x = row + 19;
            var y = row + ~~(cellId / 14);
            return new Point(x, y);
        }


        public double getDistance(int cellId, int destinationCellId)
        {
            var coordA = getMapPoint(cellId);
            var coordB = getMapPoint(destinationCellId);
            var dx = coordA.X - coordB.X;
            var dy = coordA.Y - coordB.Y;
            var distance = Math.Sqrt(dx * dx + dy * dy);
            return distance;
        }

        private int getCellId(int x, int y)
        {
            if (!MapPointToCellId.ContainsKey(x.ToString() + '_' + y.ToString()))
            {
                return 0;
            }


            var cellId = MapPointToCellId[x.ToString() + '_' + y.ToString()];

            return cellId;
        }

        private CellPathData updateCellPath(Cell cell, CellPathData cellPath)
        {
            if ((cell.L & 1) != 0)
            {
                cellPath.floor = cell.F;
                cellPath.zone = cell.Z;
                cellPath.speed = 1 + cell.S / 10;

                if (cellPath.zone != firstCellZone)
                {
                    oldMovementSystem = false;
                }
            }
            else
            {
                cellPath.floor = -1;
                cellPath.zone = -1;
            }

            return cellPath;
        }

        private bool areCommunicating(CellPathData c1, CellPathData c2)
        {
            // Cells are compatible only if they either have the same floor height...
            if (c1.floor == c2.floor)
            {
                // Same height
                return true;
            }

            // ... or the same zone, different from 0
            // ... or a zone of 0 and a floor difference smaller than ELEVATION_TOLERANCE
            if (c1.zone == c2.zone)
            {
                return oldMovementSystem || (c1.zone != 0) || (Math.Abs(c1.floor - c2.floor) <= ELEVATION_TOLERANCE);
            }

            return false;
        }

        private bool canMoveDiagonallyTo(CellPathData c1, CellPathData c2, CellPathData c3, CellPathData c4)
        {
            // Can move between c1 and c2 diagonally only if c1 and c2 are compatible and if c1 is compatible either with c3 or c4
            return areCommunicating(c1, c2) && (areCommunicating(c1, c3) || areCommunicating(c1, c4));
        }
    }

    public class AccessibleCell
    {
        public int i { get; set; }

        public int j { get; set; }

        public AccessibleCell(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }

    public class CellChangeMap
    {
        public int cellId { get; set; }

        public OrientationEnum orientation { get; set; }

        public CellChangeMap(int cellId, OrientationEnum orientation)
        {
            this.cellId = cellId;
            this.orientation = orientation;
        }
    }
}
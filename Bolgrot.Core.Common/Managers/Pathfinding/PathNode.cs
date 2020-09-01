using System.Collections.Generic;

namespace Bolgrot.Core.Common.Managers.Pathfinding
{
    public class PathNode
    {
        public int cellId;
        public int availableMp;
        public int availableAp;
        public int tackleMp;
        public int tackleAp;
        public int distance;

        public PathNode(int cellId, int availableMp, int actionPoints, int tackleMp, int tackleAp, int distance)
        {
            this.cellId = cellId;
            this.availableMp = availableMp;
            this.availableAp = actionPoints;
            this.tackleMp = tackleMp;
            this.tackleAp = tackleAp;
            this.distance = distance;
        }
    }


    public class Node
    {
        public List<int> reachable;
        public List<int> unreachable;
        public int mp;
        public int ap;
        public List<int> reachableMap;
        public List<int> unreachableMap;

        public Node(List<int> reachable, List<int> unreachable, int mp, int ap, List<int> reachableMap, List<int> unreachableMap)
        {
            this.reachable = reachable;
            this.unreachable = unreachable;
            this.mp = mp;
            this.ap = ap;
            this.reachableMap = reachableMap;
            this.unreachableMap = unreachableMap;
        }
    }

    public class MoveNode
    {

        public int ap;
        public int mp;
        public int from;
        public bool reachable;
        public Node path;

        public MoveNode(Cost tackleCost, int cellId, bool reachable)
        {
            this.ap = tackleCost.ap;
            this.mp = tackleCost.mp;
            this.from = cellId;
            this.reachable = reachable;
        }
    }

    public class Cost
    {
        public int mp;
        public int ap;

        public Cost(int mp, int ap)
        {
            this.mp = mp;
            this.ap = ap;
        }
    }
}
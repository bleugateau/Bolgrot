namespace Bolgrot.Core.Common.Managers.Pathfinding
{
    public class CellPathData
    {
        public int i;
        public int j;
        public int floor;
        public int speed;
        public int weight;
        public int zone;
        public CellPath candidateRef;

        public CellPathData(int i, int j)
        {

            this.i = i;
            this.j = j;

            this.floor = -1;
            this.zone = -1;
            this.speed = 1;

            this.weight = 0;
            this.candidateRef = null;
        }
    }
}

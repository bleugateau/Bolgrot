namespace Bolgrot.Core.Common.Managers.Pathfinding
{
	public class CellPath
	{
		public int i { get; set; }

		public int j { get; set; }

		public int w { get; set; }

		public int d { get; set; }

		public CellPath path { get; set; }

		public CellPath(int i, int j, int w, int d, CellPath path)
		{
			this.i = i; // position i in the grid
			this.j = j; // position j in the grid
			this.w = w; // weight of the path
			this.d = d; // remaining distance to destination

			// positions previously taken in the path
			this.path = path;
		}
	}
}

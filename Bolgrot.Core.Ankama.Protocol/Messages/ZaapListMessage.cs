using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ZaapListMessage : NetworkMessage
    {

	    public int teleporterType;
	    public int[] mapIds;
	    public int[] subAreaIds;
	    public int[] costs;
	    public int[] destTeleporterType;
	    public int spawnMapId;
	    public int[] _subAreas;
	    public int[] _maps;
	    public int[] _hints;


        public ZaapListMessage()
        {
        }

        public ZaapListMessage(int teleporterType, int[] mapIds, int[] subAreaIds, int[] costs, int[] destTeleporterType, int spawnMapId, int[] _subAreas, int[] _maps, int[] _hints)
        {
            this.teleporterType = teleporterType;
            this.mapIds = mapIds;
            this.subAreaIds = subAreaIds;
            this.costs = costs;
            this.destTeleporterType = destTeleporterType;
            this.spawnMapId = spawnMapId;
            this._subAreas = _subAreas;
            this._maps = _maps;
            this._hints = _hints;

        }
    }
}
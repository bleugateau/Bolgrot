using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class MapComplementaryInformationsDataMessage : NetworkMessage
    {

	    public int subAreaId;
	    public long mapId;
	    public int[] houses;
	    public GameRolePlayInformations[] actors;
	    public InteractiveElement[] interactiveElements;
	    public StatedElement[] statedElements;
	    public int[] obstacles;
	    public int[] fights;


        public MapComplementaryInformationsDataMessage()
        {
        }

        public MapComplementaryInformationsDataMessage(int subAreaId, long mapId, int[] houses, GameRolePlayInformations[] actors, InteractiveElement[] interactiveElements, StatedElement[] statedElements, int[] obstacles, int[] fights)
        {
            this.subAreaId = subAreaId;
            this.mapId = mapId;
            this.houses = houses;
            this.actors = actors;
            this.interactiveElements = interactiveElements;
            this.statedElements = statedElements;
            this.obstacles = obstacles;
            this.fights = fights;

        }
    }
}
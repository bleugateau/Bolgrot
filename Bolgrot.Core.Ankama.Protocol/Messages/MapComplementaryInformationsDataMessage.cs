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
	    public int mapId;
	    public int[] houses;
	    public GameRolePlayCharacterInformations[] actors;
	    public int[] interactiveElements;
	    public int[] statedElements;
	    public int[] obstacles;
	    public int[] fights;


        public MapComplementaryInformationsDataMessage()
        {
        }

        public MapComplementaryInformationsDataMessage(int subAreaId, int mapId, int[] houses, GameRolePlayCharacterInformations[] actors, int[] interactiveElements, int[] statedElements, int[] obstacles, int[] fights)
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
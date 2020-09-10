using System;
using System.Linq;
using Bolgrot.Core.Ankama.Protocol.Types;

namespace Bolgrot.Core.Ankama.Protocol.Utils
{
    public static class EntityLookHelper
    {
        public static EntityLook DecodeStringLook(string look)
        {
            EntityLook decodedEntityLook = new EntityLook();

            string[] splittedLook = look.Replace("{", "").Replace("}", "").Split("|");

            decodedEntityLook.bonesId = Convert.ToInt32(splittedLook[0]);
            decodedEntityLook.skins = splittedLook[1].Length > 0
                ? splittedLook[1].Split(',').Select(x => Convert.ToInt32(x)).ToArray()
                : new int[] { };
            decodedEntityLook.indexedColors = splittedLook[2].Length > 0
                ? splittedLook[2].Split(',').Select(x => int.Parse(x.Split("=")[1].Replace("#", ""), System.Globalization.NumberStyles.HexNumber)).ToArray()
                : new int[] { };
            decodedEntityLook.scales = new int[] {Convert.ToInt32(splittedLook[3])};


            return decodedEntityLook;
        }
    }
}
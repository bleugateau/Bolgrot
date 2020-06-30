namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class SubEntity
    {

        public int bindingPointCategory { get; set; }

        public int bindingPointIndex { get; set; }

        public EntityLook subEntityLook { get; set; }

        public SubEntity(){ }

        public SubEntity(int bindingPointCategory, int bindingPointIndex, EntityLook subEntityLook)
        {
            this.bindingPointCategory = bindingPointCategory;
            this.bindingPointIndex = bindingPointIndex;
            this.subEntityLook = subEntityLook;
        }
    }
}

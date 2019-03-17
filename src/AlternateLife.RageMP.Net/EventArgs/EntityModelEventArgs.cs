using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class EntityModelEventArgs : EntityEventArgs
    {
        public uint OldModel { get; }

        internal EntityModelEventArgs(IEntity entity, uint oldModel) : base(entity)
        {
            OldModel = oldModel;
        }
    }
}

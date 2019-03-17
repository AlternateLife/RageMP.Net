using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class EntityEventArgs : System.EventArgs
    {
        public IEntity Entity { get; }

        internal EntityEventArgs(IEntity entity)
        {
            Entity = entity;
        }
    }
}

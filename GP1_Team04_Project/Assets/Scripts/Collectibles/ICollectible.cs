using UnityEngine;

namespace FG.Collectibles
{
    public interface ICollectible
    {
        public void Collect(GameObject other = default);
    }
}

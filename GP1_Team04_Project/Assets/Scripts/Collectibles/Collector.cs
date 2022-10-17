using UnityEngine;

namespace FG.Collectibles
{
    public class Collector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICollectible collectible))
            {
                collectible.Collect(gameObject);
            }
        }
    }
}

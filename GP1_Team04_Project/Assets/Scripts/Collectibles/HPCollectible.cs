using UnityEngine;

namespace FG.Collectibles
{
    public class HPCollectible : MonoBehaviour, ICollectible
    {
        [SerializeField]
        private float _health = 1f;

        public void Collect(GameObject other = null)
        {
            if (other != null)
            {
                Health health = other.GetComponent<Health>();
                if (health.CurrentHealth >= health.MaxHealth) return;
                else
                {
                    AudioManager.instance.HPCollectSFX();
                    health.Heal(_health);
                    Destroy(gameObject);
                }
            }
        }
    }
}

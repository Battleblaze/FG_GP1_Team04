using UnityEngine;

namespace FG.Other
{
    public class DamageBox : MonoBehaviour
    {
        [SerializeField]
        private float _damage = 1;

        private Health _health;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out _health))
            {
                _health.Damage(_damage);
            }
        }
    }
}

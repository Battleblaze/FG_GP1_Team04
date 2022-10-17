using UnityEngine;

namespace FG.Other
{
    public class DamageBox : MonoBehaviour
    {
        [SerializeField]
        private float _damage = 1;
        public AudioClip _hurtSound;

        private Health _health;


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out _health))
            {
                _health.Damage(_damage);
            }
            if(other.gameObject.tag == "Player")
            {
                AudioManager.instance.HurtSoundSFX(); //game restarts too quick to play sound when 1hp
                Debug.Log("Hit");

            }
        }
    }
}

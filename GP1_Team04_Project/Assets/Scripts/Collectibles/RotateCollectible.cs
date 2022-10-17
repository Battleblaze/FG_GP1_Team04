using UnityEngine;

namespace FG.Collectibles
{
    public class RotateCollectible : MonoBehaviour
    {
        [SerializeField]
        private float _rotateSpeed;

        private Renderer _renderer;

        private void Start()
        {
            _renderer = GetComponentInChildren<Renderer>();
        }

        void Update()
        {
            if (_renderer.isVisible) transform.Rotate(0, _rotateSpeed * Time.deltaTime, 0, Space.Self);
        }
    }
}

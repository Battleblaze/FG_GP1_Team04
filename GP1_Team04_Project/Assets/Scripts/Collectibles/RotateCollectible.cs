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
			transform.Rotate(new Vector3(0.0f, Random.Range(0f, 360f), 0.0f));

			this._rotateSpeed *= Random.Range(0.75f, 1.5f);

			_renderer = GetComponentInChildren<Renderer>();
		}

		void Update()
		{
			if (_renderer.isVisible) transform.Rotate(0, _rotateSpeed * Time.deltaTime, 0, Space.Self);
		}
	}
}

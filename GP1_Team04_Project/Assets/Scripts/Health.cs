using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using FG.Managers;

namespace FG
{
	public class Health : MonoBehaviour
	{
		private enum OnDeath { nothing, disable, destroy };

		[HideInInspector] public float CurrentHealth;
		[HideInInspector] public bool Dead;

		[SerializeField]
		[Tooltip("Game object start health")]
		private float _startHealth = 1;

		[Tooltip("Game object max health (same as start health if 0)")]
		public float MaxHealth;

		[SerializeField]
		[Tooltip("What to do when game object dies")]
		private OnDeath _onDeath = OnDeath.destroy;

		[SerializeField]
		[Tooltip("Unity event called on damage")]
		private UnityEvent _onDamageEvent;

		[SerializeField]
		[Tooltip("Unity event called on death")]
		private UnityEvent _onDeathEvent;

		[SerializeField]
		[Tooltip("Optional text mesh pro text")]
		private TextMeshProUGUI _text;

		[SerializeField]
		[Tooltip("Invulnerability frames in seconds")]
		private float invulnerabilityFrames = 5.0f;

		private float lastDamageTime = 0f;

		private void Start()
		{
			CurrentHealth = _startHealth;
			if (MaxHealth == 0)
				MaxHealth = _startHealth;

			if (_text) _text.text = "Health: " + CurrentHealth.ToString();
		}

		public void Damage(float damageAmount)
		{
			var currentTime = Time.time;

			Debug.Log((this.lastDamageTime).ToString() + " " + currentTime.ToString());
			if (this.lastDamageTime >= currentTime)
			{
				Debug.Log("skipped");
				return;
			}

			this.lastDamageTime = currentTime + this.invulnerabilityFrames;

			_onDamageEvent.Invoke();

			CurrentHealth -= damageAmount;

			if (CurrentHealth <= 0 && !Dead)
			{
				_onDeathEvent.Invoke();
				Dead = true;

				switch (_onDeath)
				{
					case OnDeath.nothing:
						break;
					case OnDeath.disable:
						gameObject.SetActive(false);
						break;
					case OnDeath.destroy:
						Destroy(gameObject);
						break;

				}
				Debug.Log("dead");
				GameObject.Find("GameManager").GetComponent<GameManager>().UpdateGameState(GameManager.GameState.GameOver);
			}

			if (_text) _text.text = CurrentHealth.ToString();
		}

		public void Heal(float healAmount = 0f)
		{
			CurrentHealth += healAmount;

			if (CurrentHealth > MaxHealth) // Don't heal over maxHealth
				CurrentHealth = MaxHealth;

			if (Dead && CurrentHealth > 0)
				Dead = false;

			if (_text) _text.text = "Health: " + CurrentHealth.ToString();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
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

		[SerializeField] private Material normalColor;
		[SerializeField] private Material collideColor;
		[SerializeField] private GameObject character;

		private void Start()
		{
			CurrentHealth = _startHealth;
			if (MaxHealth == 0)
				MaxHealth = _startHealth;

			if (_text) _text.text = "Health: " + CurrentHealth.ToString();

			//renderer.gameObject.GetComponent<Material>();
		}

		public void Damage(float damageAmount)
		{
			var currentTime = Time.time;

			if (this.lastDamageTime >= currentTime)
			{
				Debug.Log("skipped");
				return;
			}

			this.lastDamageTime = currentTime + this.invulnerabilityFrames;

			_onDamageEvent.Invoke();
			StartCoroutine("Flasher");

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

			if (_text) _text.text = "Health: " + CurrentHealth.ToString();
		}

		public void Heal(float healAmount = 0f)
		{
			CurrentHealth += healAmount;

			if (CurrentHealth > MaxHealth) // Don't heal over maxHealth
			{
				CurrentHealth = MaxHealth;
				if (_text) _text.text = "Max Health" + CurrentHealth.ToString();
				return;
			}

			if (Dead && CurrentHealth > 0)
				Dead = false;


			if (_text) _text.text = "Health: " + CurrentHealth.ToString();
		}
		
		IEnumerator Flasher() 
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 23; j++)
				{
					character.transform.GetChild(j).GetComponent<Renderer>().material = collideColor;
				}
				yield return new WaitForSeconds(.1f);

				for (int j = 0; j < 23; j++)
				{
					character.transform.GetChild(j).GetComponent<Renderer>().material = normalColor;
				}
				yield return new WaitForSeconds(.1f);
				
			}
		}
		
		
	}
}

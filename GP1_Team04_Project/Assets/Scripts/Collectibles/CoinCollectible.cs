using System;
using UnityEngine;
using TMPro;

namespace FG.Collectibles
{
    public class CoinCollectible : MonoBehaviour, ICollectible
    {
        [SerializeField]
        private float _scoreAmount = 100f;

        [SerializeField] private GameObject GameManager;
        private Score _score;

        private void Awake()
        {
            GameManager = GameObject.Find("GameManager");
            _score = GameManager.GetComponent<Score>();
        }

        public void Collect(GameObject other = null)
        {
            if (other != null)
            {
                /*
                GameVariables.Score += _scoreAmount;

                print("Coin collected! New score: " + GameVariables.Score);*/
                _score.score += 100;
                Destroy(gameObject);
                AudioManager.instance.CoinCollectSFX();
            }
        }
    }
}

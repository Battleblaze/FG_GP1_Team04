using UnityEngine;
using UnityEngine.Events;

namespace FG.Managers
{
    public class GameManager : MonoBehaviour
    {
        
        public bool pasuedgame = false;
        
        public enum GameState
        {
            Setup,
            Game,
            GameOver,
        };

        public static GameState State;

        [Header("Events")]
        [SerializeField]
        private UnityEvent _onSetup;

        [SerializeField]
        private UnityEvent _onGameStart;

        [SerializeField]
        private UnityEvent _onGameOver;


        void Awake()
        {
            UpdateGameState(GameState.Setup);
        }

        public void UpdateGameState(GameState newState)
        {
            State = newState;

            switch (newState)
            {
                case GameState.Setup:
                    Setup();
                    break;
                case GameState.Game:
                    Game();
                    break;
                case GameState.GameOver:
                    GameOver();
                    break;
                default:
                    break;
            }
        }


        private void Setup()
        {
            _onSetup.Invoke();

            // Setup game
            print("Setup");
            GameVariables.Score = 0f;

            UpdateGameState(GameState.Game);
        }

        private void Game()
        {
            _onGameStart.Invoke();

            // Game loop
            print("Game");
        }
        
        private void GameOver()
        {
            _onGameOver.Invoke();

            // Show or load GameOver screen
            print("GameOver Score: " + GameVariables.Score);
        }

    }
}
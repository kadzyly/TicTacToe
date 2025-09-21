using System;
using Constants;
using UnityEngine;


namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public static event Action<GameStatus> OnGameStatusChanged;

        private GameStatus _gameStatus = GameStatus.InGame;
        public GameStatus GameStatus => _gameStatus;
        
        [SerializeField] private Board.BoardController _boardController;
        
        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
        }
        
        public void SetGameMode(GameStatus status)
        {
            _gameStatus = status;
            OnGameStatusChanged?.Invoke(status);
        }

        public void StartNewGame()
        {
            PlayerTurnManager.Instance.Reset();
            _boardController.ResetBoard();
            _boardController.Init();
            SetGameMode(GameStatus.InGame);
        }
    }
}

using System;
using UnityEngine;


namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public static event Action<bool> OnGameOverChanged;
        
        private bool _isGameInProcess = true;
        public bool IsGameInProcess => _isGameInProcess;

        [SerializeField] private Board.BoardController _boardController;
        
        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
        }
        
        
        public void GameOver()
        {
            _isGameInProcess = false;
            OnGameOverChanged?.Invoke(false);
        }

        public void StartNewGame()
        {
            PlayerTurnManager.Instance.Reset();
            _boardController.ResetBoard();
            _boardController.Init();
            
            _isGameInProcess = true;
            OnGameOverChanged?.Invoke(true);
        }
    }
}

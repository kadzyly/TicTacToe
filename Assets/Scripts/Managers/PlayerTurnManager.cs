using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class PlayerTurnManager : MonoBehaviour
    {
        public static PlayerTurnManager Instance;
        public static event Action<bool> OnTurnChanged;
        
        private bool _crossUserTurn = true;
        public bool CrossUserTurn => _crossUserTurn;

        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
        }


        public void SetTurn(bool crossTurn)
        {
            _crossUserTurn = crossTurn;
            OnTurnChanged?.Invoke(crossTurn);
        }
    }
}

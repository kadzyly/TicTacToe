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
            Instance = this;
        }


        public void ChangeTurn()
        {
            bool newValue = !_crossUserTurn;
            _crossUserTurn = newValue;
            OnTurnChanged?.Invoke(newValue);
        }
    }
}

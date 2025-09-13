using System;
using UnityEngine;

namespace Managers
{
    public class TurnManager : MonoBehaviour
    {
        public static TurnManager Instance;
        public static event Action<bool> OnTurnChanged;
        
        public bool xUserTurn = true;

        private void Awake()
        {
            Instance = this;
        }


        public void ChangeTurn()
        {
            bool newValue = !xUserTurn;
            xUserTurn = newValue;
            OnTurnChanged?.Invoke(newValue);
        }
    }
}

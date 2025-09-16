using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class TurnManager : MonoBehaviour
    {
        public static TurnManager Instance;
        public static event Action<bool> OnTurnChanged;
        
        public bool crossUserTurn = true;

        private void Awake()
        {
            Instance = this;
        }


        public void ChangeTurn()
        {
            bool newValue = !crossUserTurn;
            crossUserTurn = newValue;
            OnTurnChanged?.Invoke(newValue);
        }
    }
}

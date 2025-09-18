using System;
using System.Collections.Generic;
using UnityEngine;

namespace Board
{
    public class BoardManager : MonoBehaviour
    {
        public event Action OnReset;
        private BoardBuilder _boardBuilder;


        private void Start()
        {
            _boardBuilder = GetComponent<BoardBuilder>();
            
            ResetGame();
            _boardBuilder.CreateBoard();
        }

        
        public void ResetGame()
        {
            OnReset?.Invoke();
        }
    }
}

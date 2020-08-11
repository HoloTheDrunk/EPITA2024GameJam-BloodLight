using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Cheats : MonoBehaviour
    {
        private GameManager _gameManager;
        private PlayerController _playerController;
        

        public void Start()
        {
            _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
            if (!_gameManager.IsCheating)
                enabled = false;
            _playerController = GetComponent<PlayerController>();
        }
        
        public void Update()
        {
            // Manual bleed
            if (Input.GetKeyDown(KeyCode.B))
                _playerController.Bleed();
        }
    }
}

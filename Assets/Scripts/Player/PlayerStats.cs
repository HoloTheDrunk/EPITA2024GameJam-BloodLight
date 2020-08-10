using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerStats : MonoBehaviour
    {
        private int _deaths;

        public int DeathCount => _deaths;

        public void Start()
        {
            _deaths = 0;
        }

        public void AddDeath() => _deaths++;
    }
}

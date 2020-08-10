using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerStats : MonoBehaviour
    {
        private int _deaths = 0;

        public int DeathCount => _deaths;

        public void AddDeath() => _deaths++;
    }
}

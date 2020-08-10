using System;
using Assets.Scripts.Player;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.UI_and_Camera
{
    public class GameUI : MonoBehaviour
    {
        public PlayerStats playerStats;
        public TextMeshProUGUI deathCounter;

        public void Start()
        {
            deathCounter.text = $"DEATHS: {playerStats.DeathCount.ToString()}";
        }
        
        public void Update()
        {
            if (playerStats.DeathCount != Int16.Parse(deathCounter.text.Substring(8)))
            {
                Debug.Log("coucou1");
                deathCounter.text = $"DEATHS: {playerStats.DeathCount.ToString()}";
            }
        }
    }
}

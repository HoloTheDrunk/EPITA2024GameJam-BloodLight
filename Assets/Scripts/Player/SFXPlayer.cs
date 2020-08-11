using UnityEngine;

namespace Assets.Scripts.Player
{
	public class SFXPlayer : MonoBehaviour
	{
		// Audio sources
		[SerializeField] private AudioSource _jumpSound = null;
		[SerializeField] private AudioSource _deathSound = null;

		public void PlayJumpSound() => _jumpSound.Play();
		public void PlayDeathSound() => _deathSound.Play();
	}
}
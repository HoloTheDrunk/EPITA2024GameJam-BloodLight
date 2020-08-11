using UnityEngine;

namespace Assets.Scripts.UI_and_Camera.Menus
{
	public class OptionsMenu : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource = null;
		public Animator mainMenuAnimator;
		public Animator optionsMenuAnimator;

		public void Back()
		{
			_audioSource.Play();
			Camera.main.GetComponent<MenuState>().SetState(0);
		}
	}
}
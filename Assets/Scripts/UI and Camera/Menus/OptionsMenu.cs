using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI_and_Camera.Menus
{
	public class OptionsMenu : MonoBehaviour
	{
		private GameManager _gameManager;
		public ToggleScript cheatToggle;
		
		[SerializeField] private AudioSource _audioSource = null;

		public void Start()
		{
			_gameManager = GameManager.instance;
			if(cheatToggle.State != _gameManager.IsCheating)
				cheatToggle.Toggle();
		}

		public void Back()
		{
			_audioSource.Play();
			Camera.main.GetComponent<MenuState>().SetState(0);
		}

		public void ToggleCheating()
		{
			_audioSource.Play();
			_gameManager.ToggleCheating();
			cheatToggle.Toggle();
		}
	}
}
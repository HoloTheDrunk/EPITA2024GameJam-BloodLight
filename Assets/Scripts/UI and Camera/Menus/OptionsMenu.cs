using UnityEngine;

namespace Assets.Scripts.UI_and_Camera.Menus
{
	public class OptionsMenu : MonoBehaviour
	{
		public Animator mainMenuAnimator;
		public Animator optionsMenuAnimator;

		public void Back()
		{
			Camera.main.GetComponent<MenuState>().SetState(0);
		}
	}
}
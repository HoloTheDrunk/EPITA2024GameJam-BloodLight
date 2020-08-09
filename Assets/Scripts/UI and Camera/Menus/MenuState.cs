using UnityEngine;

namespace Assets.Scripts.UI_and_Camera.Menus
{
	public class MenuState : MonoBehaviour
	{
		public Animator mainMenuAnimator;
		public Animator optionsMenuAnimator;

		private int _state = 0;
		public int State => _state;

		public void SetState(int state)
		{
			_state = state;
			mainMenuAnimator.SetInteger("MenuState", State);
			optionsMenuAnimator.SetInteger("MenuState", State);
		}
	}
}
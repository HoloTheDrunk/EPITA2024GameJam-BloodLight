using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI_and_Camera.Menus
{
    public class MainMenu : MonoBehaviour
    {
        public Animator mainMenuAnimator;
        public Animator optionsMenuAnimator;

        public void Play()
        {
            SceneManager.LoadScene("Level 1");
        }

        public void Options()
        {
            Camera.main.GetComponent<MenuState>().SetState(1);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI_and_Camera.Menus
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject mainMenu;
        public GameObject optionsMenu;

        public void Play()
        {
            SceneManager.LoadScene("Level 1");
        }

        public void Options()
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}

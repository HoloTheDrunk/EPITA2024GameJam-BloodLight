using UnityEngine;

namespace Assets.Scripts.UI_and_Camera.Menus
{
    public class OptionsMenu : MonoBehaviour
    {
        public GameObject mainMenu;
        public GameObject optionsMenu;
        
        public void Back()
        {
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}

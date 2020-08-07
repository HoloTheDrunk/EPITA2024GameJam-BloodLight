using UnityEngine;

namespace Assets.Scripts.UI_and_Camera
{
    public class CursorScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Cursor.visible = false;
        }
        
        void Update()
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 98));
            transform.position = worldPos;
        }
    }
}

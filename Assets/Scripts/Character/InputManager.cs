using UnityEngine;

namespace Character
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private KeyCode inventoryKey = KeyCode.Q;

        private void Update()
        {
            if (Input.GetKeyDown(inventoryKey))
            {
            }
        }
    }
}
using UnityEngine;

namespace Views
{
    public class InventoryView : MonoBehaviour
    {
        private bool IsOpened => gameObject.activeSelf;

        public void Show()
        {
            gameObject.SetActive(true);
            Refresh();
        }

        public void Hide() => gameObject.SetActive(false);

        public void Toggle()
        {
            if (!IsOpened)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        private void Refresh()
        {
            if (!IsOpened) return;
        }
    }
}
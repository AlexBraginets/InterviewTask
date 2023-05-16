using Data.Maps;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ItemIconView : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private ItemSpriteMap map;

        public void Show(int itemID)
        {
            icon.sprite = map.GetSprite(itemID);
        }
    }
}

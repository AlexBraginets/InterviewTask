using Data;
using Data.Maps;
using Shop;
using UnityEngine;

namespace Views
{
    public class ClothesItemView : MonoBehaviour
    {
        [SerializeField] private ItemID itemID;
        [SerializeField] private Basket _basket;
        [SerializeField] private ItemPriceLabel _priceLabel;
        [SerializeField] private ItemIconView _iconView;
        public int ID => itemID.ID;
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _priceLabel.Show(ID);
            _iconView.Show(ID);
        }

        public void Purchase() => _basket.Add(ID);
    }
}

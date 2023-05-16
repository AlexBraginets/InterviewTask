using System;
using TMPro;
using UnityEngine;

namespace Views
{
    public class ItemGroupView : MonoBehaviour
    {
        [SerializeField] private TMP_Text amountLabel;
        [SerializeField] private ItemPriceLabel priceLabel;
        [SerializeField] private ItemIconView iconView;
        private ItemGroup _itemGroup;
        public event Action OnDestroyed;
        public int ItemID => _itemGroup.itemID;

        public void Show(ItemGroup itemGroup)
        {
            _itemGroup = itemGroup;
            priceLabel.Show(ItemID);
            iconView.Show(ItemID);
            amountLabel.text = itemGroup.itemAmount.ToString();
        }

        private void OnDestroy() => OnDestroyed?.Invoke();
    }
}
using Data.Maps;
using TMPro;
using UnityEngine;
using Utils;

namespace Views
{
    public class ItemPriceLabel : MonoBehaviour
    {
        [SerializeField] private TMP_Text priceLabel;
        [SerializeField] private ItemPriceMap priceMap;
        public void Show(int itemID)
        {
            int price = priceMap.GetPrice(itemID);
            priceLabel.text = price.ToPriceLabelText();
        }
    }
}

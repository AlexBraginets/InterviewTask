using System.Collections.Generic;
using Character;
using Data.Maps;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Views;

namespace Shop
{
    public class Basket : MonoBehaviour
    {
        [SerializeField] private ItemGroupView itemGroupViewPrefab;
        private Dictionary<int, ItemGroup> itemGroups = new Dictionary<int, ItemGroup>();
        private Dictionary<int, ItemGroupView> itemGroupViews = new Dictionary<int, ItemGroupView>();
        private int _totalPrice;
        [SerializeField] private ItemPriceMap priceMap;
        [SerializeField] private TMP_Text totalPriceLabel;
        [SerializeField] private TMP_Text balanceLabel;
        [SerializeField] private Button purchaseButton;
        [SerializeField] private PlayerBalance playerBalance;
        [SerializeField] private Inventory inventory;

        private void Awake()
        {
            purchaseButton.onClick.AddListener(Purchase);
        }

        private void OnEnable()
        {
            UpdateTotalPriceLabel();
            UpdateBalanceLabel();
        }

        public void Add(int itemID)
        {
            if (itemGroups.ContainsKey(itemID))
            {
                int price = priceMap.GetPrice(itemID);
                itemGroups[itemID].itemAmount++;
                itemGroupViews[itemID].Show(itemGroups[itemID]);
                _totalPrice += price;
                UpdateTotalPriceLabel();
            }
            else
            {
                itemGroups.Add(itemID, new ItemGroup()
                {
                    itemID = itemID
                });
                var itemGroupView = CreateItemGroupView();
                itemGroupViews.Add(itemID, itemGroupView);
                Add(itemID);
                itemGroupView.OnDestroyed += () =>
                {
                    itemGroups.Remove(itemID);
                    itemGroupViews.Remove(itemID);
                };
            }
        }

        private void UpdateBalanceLabel() => balanceLabel.text = playerBalance.Balance.ToPriceLabelText();
        private void UpdateTotalPriceLabel() => totalPriceLabel.text = _totalPrice.ToPriceLabelText();

        private ItemGroupView CreateItemGroupView()
        {
            var instance = Instantiate(itemGroupViewPrefab, transform);
            return instance;
        }

        private void Purchase()
        {
            if (playerBalance.Balance < _totalPrice)
            {
                return;
            }

            playerBalance.Balance -= _totalPrice;
            _totalPrice = 0;
            AddItemsToInventory();
            Clear();
        }

        private void Clear()
        {
            foreach (var itemGroupView in itemGroupViews.Values)
            {
                Destroy(itemGroupView.gameObject);
            }
        }

        private void AddItemsToInventory()
        {
            foreach (var itemGroup in itemGroups.Values)
            {
                inventory.AddItemGroup(itemGroup);
            }
        }
    }
}
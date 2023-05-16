using System.Collections.Generic;
using UnityEngine;

namespace Data.Maps
{
    [CreateAssetMenu]
    public class ItemPriceMap : ScriptableObject
    {
        [SerializeField] private ItemPricePair[] data;
        [System.NonSerialized] private Dictionary<int, int> _quickMap;
        [System.NonSerialized] private bool _isInited;

        private void Init()
        {
            _quickMap = new Dictionary<int, int>();
            foreach (var itemPricePair in data)
            {
                _quickMap.Add(itemPricePair.ID, itemPricePair.Price);
            }
            _isInited = true;
        }

        public int GetPrice(int itemID)
        {
            if (!_isInited)
            {
                Init();
            }

            return _quickMap[itemID];
        }
    }
}
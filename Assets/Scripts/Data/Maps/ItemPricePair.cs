using UnityEngine;

namespace Data.Maps
{
    [System.Serializable]
    public class ItemPricePair
    {
        [SerializeField] private ItemID itemID;
        public int Price;
        public int ID => itemID.ID;
    }
}

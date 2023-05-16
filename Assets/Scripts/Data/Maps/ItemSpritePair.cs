using UnityEngine;

namespace Data.Maps
{
    [System.Serializable]
    public class ItemSpritePair
    {
        [SerializeField] private ItemID itemID;
        public Sprite Sprite;
        public int ID => itemID.ID;
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Data.Maps
{
    [CreateAssetMenu]
    public class ItemSpriteMap : ScriptableObject
    {
        [SerializeField] private ItemSpritePair[] data;
        [System.NonSerialized] private Dictionary<int, Sprite> quickMap = new Dictionary<int, Sprite>();
        [System.NonSerialized] private bool _isInited;

        private void Init()
        {
            foreach (var itemSpritePair in data)
            {
                quickMap.Add(itemSpritePair.ID, itemSpritePair.Sprite);
            }
            _isInited = true;
        }

        public Sprite GetSprite(int itemID)
        {
            if (!_isInited)
            {
                Init();
            }

            return quickMap[itemID];
        }
    }
}

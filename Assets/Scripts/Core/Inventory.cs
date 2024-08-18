using System.Collections.Generic;

namespace DefaultNamespace
{
    [UnityEngine.CreateAssetMenu(fileName = "New Inventory", menuName = "Player/Inventory", order = 0)]
    public class Inventory : UnityEngine.ScriptableObject
    {
        [System.Serializable]
        public class ItemInfo
        {
            public int Count;
            // other stuff?

            public static ItemInfo Empty() => new() { Count = 0 };
        }

        [System.Serializable]
        public struct Pair<A, B>
        {
            public A Key;
            public B Value;

            public static Pair<A, B> Of(A key, B value)
            {
                return new Pair<A, B>() { Key = key, Value = value };
            }
        }

        // tfw still no serializable dictionary in unity
        public List<Pair<Gatherable, ItemInfo>> items;

        public void AddGatherable(Gatherable gatherable)
        {
            var gather = this.GetItemInfo(gatherable);
            if (gather != null)
            {
                gather.Count += 1;
            }
            else
            {
                this.items.Add(Pair<Gatherable, ItemInfo>.Of(gatherable, new ItemInfo()
                {
                    Count = 1,
                }));
            }
        }

        public bool TryTakeGatherable(Gatherable gatherable)
        {
            var gather = this.GetItemInfo(gatherable);
            if (gather != null)
            {
                if (gather.Count <= 0)
                    return false;

                gather.Count--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public ItemInfo GetItemInfo(Gatherable gatherable)
        {
            foreach (var g in items)
                if (g.Key == gatherable)
                    return g.Value;

            return ItemInfo.Empty();
        }
    }
}
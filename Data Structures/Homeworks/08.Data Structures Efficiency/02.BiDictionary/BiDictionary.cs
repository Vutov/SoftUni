namespace _02.BiDictionary
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class BiDictionary<TKey1, TKey2, TValue>
    {
        private readonly MultiDictionary<TKey1, TValue> firstKeyAndValue;
        private readonly MultiDictionary<TKey2, TValue> secondKeyAndValue;
        private readonly MultiDictionary<string, TValue> bothKeysAndValue;

        public BiDictionary()
        {
            this.bothKeysAndValue = new MultiDictionary<string, TValue>(true);
            this.firstKeyAndValue = new MultiDictionary<TKey1, TValue>(true);
            this.secondKeyAndValue = new MultiDictionary<TKey2, TValue>(true);
        }

        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            this.firstKeyAndValue.Add(key1, value);
            this.secondKeyAndValue.Add(key2, value);
            this.bothKeysAndValue.Add(key1 + "_" + key2, value);
        }

        public IEnumerable<TValue> Find(TKey1 key)
        {
            return this.firstKeyAndValue[key];
        }

        public IEnumerable<TValue> Find(TKey2 key)
        {
            return this.secondKeyAndValue[key];
        }

        public IEnumerable<TValue> Find(TKey1 key1, TKey2 key2)
        {
            return this.bothKeysAndValue[key1 + "_" + key2];
        }
    }
}

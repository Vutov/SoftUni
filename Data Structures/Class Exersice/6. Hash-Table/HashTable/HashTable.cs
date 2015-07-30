using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    private const int InitialCapacity = 16;

    private LinkedList<KeyValue<TKey, TValue>>[] slots;

    public HashTable()
    {
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[InitialCapacity];
    }

    public HashTable(int capacity)
    {
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
    }

    public int Count { get; private set; }

    public int Capacity
    {
        get
        {
            return this.slots.Length;
        }
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            var keys = new TKey[this.Count];
            var index = 0;
            foreach (var element in this.slots)
            {
                if (element != null)
                {
                    foreach (var keyValue in element)
                    {
                        keys[index] = keyValue.Key;
                        index++;
                    }
                }
            }

            return keys;
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            var values = new TValue[this.Count];
            var index = 0;
            foreach (var element in this.slots)
            {
                if (element != null)
                {
                    foreach (var keyValue in element)
                    {
                        values[index] = keyValue.Value;
                        index++;
                    }
                }
            }

            return values;
        }
    }

    public TValue this[TKey key]
    {
        get
        {
            var pair = this.Find(key);
            if (pair == null)
            {
                throw new KeyNotFoundException("No such key found.");
            }

            return pair.Value;
        }

        set
        {
            this.AddOrReplace(key, value);
        }
    }

    public void Add(TKey key, TValue value)
    {
        if (((float)this.Count + 1) / this.Capacity > 0.75)
        {
            this.Grow();
        }

        var slotNumber = this.FindSlotNumber(key);
        if (this.slots[slotNumber] == null)
        {
            this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var element in this.slots[slotNumber])
        {
            if (element.Key.Equals(key))
            {
                var message = "Key already exists" + key;
                throw new ArgumentException(message);
            }
        }

        this.slots[slotNumber].AddLast(new KeyValue<TKey, TValue>(key, value));

        this.Count++;
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        if (((float)this.Count + 1) / this.Capacity > 0.75)
        {
            this.Grow();
        }

        var slotNumber = this.FindSlotNumber(key);
        if (this.slots[slotNumber] == null)
        {
            this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var element in this.slots[slotNumber])
        {
            if (element.Key.Equals(key))
            {
                element.Value = value;
                return false;
            }
        }

        this.slots[slotNumber].AddLast(new KeyValue<TKey, TValue>(key, value));

        this.Count++;

        return true;
    }

    public TValue Get(TKey key)
    {
        var slotNum = this.FindSlotNumber(key);
        var element = this.slots[slotNum];
        if (element == null)
        {
            throw new KeyNotFoundException();
        }

        foreach (var keyValue in element)
        {
            if (keyValue.Key.Equals(key))
            {
                return keyValue.Value;
            }
        }

        return default(TValue);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var slotNum = this.FindSlotNumber(key);
        var element = this.slots[slotNum];
        if (element != null)
        {
            foreach (var keyValue in element)
            {
                if (keyValue.Key.Equals(key))
                {
                    value = keyValue.Value;
                    return true;
                }
            }
        }

        value = default(TValue);
        return false;
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        var slotNum = this.FindSlotNumber(key);
        var element = this.slots[slotNum];
        if (element != null)
        {
            foreach (var keyValue in element)
            {
                if (keyValue.Key.Equals(key))
                {
                    return keyValue;
                }
            }
        }

        return null;
    }

    public bool ContainsKey(TKey key)
    {
        var slotNum = this.FindSlotNumber(key);
        var element = this.slots[slotNum];
        if (element != null)
        {
            foreach (var keyValue in element)
            {
                if (keyValue.Key.Equals(key))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool Remove(TKey key)
    {
        var slotNum = this.FindSlotNumber(key);
        var element = this.slots[slotNum];
        if (element != null)
        {
            foreach (var keyValue in element)
            {
                if (keyValue.Key.Equals(key))
                {
                    this.slots[slotNum].Remove(keyValue);
                    this.Count--;
                    return true;
                }
            }
        }

        return false;
    }

    public void Clear()
    {
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[InitialCapacity];
        this.Count = 0;
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var element in this.slots)
        {
            if (element != null)
            {
                foreach (var keyValue in element)
                {
                    yield return keyValue;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void Grow()
    {
        var newSlots = new HashTable<TKey, TValue>(this.Capacity * 2);

        foreach (var element in this.slots)
        {
            if (element != null)
            {
                foreach (var keyValue in element)
                {
                    newSlots.Add(keyValue.Key, keyValue.Value);
                }
            }
        }

        this.slots = newSlots.slots;
        this.Count = newSlots.Count();
    }

    private int FindSlotNumber(TKey key)
    {
        var slotNumber = Math.Abs(key.GetHashCode()) % this.slots.Length;
        return slotNumber;
    }
}

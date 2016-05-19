using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Utils
{
    public class HashDictionary<K, V> : IDictionary<K, V>
    {
        private readonly int DEFAULT_INITIAL_CAPACITY = 16;
        private readonly int MAXIMUM_CAPACITY = 1 << 30;

        private int count;

        private KeyValuePair<K, V>[] table;

        public V this[K key]
        {
            /*if (key == null)
            return getForNullKey();
        int hash = hash(key.hashCode());
        for (Entry<K,V> e = table[indexFor(hash, table.length)];
             e != null;
             e = e.next) {
            Object k;
            if (e.hash == hash && ((k = e.key) == key || key.equals(k)))
                return e.value;
        }
        return null;*/

            get
            {
                int hash = Hash(key.GetHashCode());
                for (KeyValuePair<K, V> e = table[IndexFor(hash, table.Length)]; e != null)
                {

                }
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<K> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<V> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(KeyValuePair<K, V> item)
        {
            throw new NotImplementedException();
        }

        public void Add(K key, V value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<K, V> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(K key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<K, V> item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(K key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(K key, out V value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private int Hash(int h)
        {
            uint uh = (uint)h;
            uh ^= (uh >> 20) ^ (uh >> 12);
            return (int)(uh ^ (uh >> 7) ^ (uh >> 4));
        }

        private int IndexFor(int h, int len)
        {
            return h & (len - 1);
        }


        //    static class Entry<K, V> implements Map.Entry<K,V> {
        //        final K key;
        //        V value;
        //        Entry<K,V> next;
        //        final int hash;

        //    public final V setValue(V newValue)
        //    {
        //        V oldValue = value;
        //        value = newValue;
        //        return oldValue;
        //    }

        //    public final boolean equals(Object o)
        //    {
        //        if (!(o instanceof Map.Entry))
        //            return false;
        //        Map.Entry e = (Map.Entry)o;
        //        Object k1 = getKey();
        //        Object k2 = e.getKey();
        //        if (k1 == k2 || (k1 != null && k1.equals(k2)))
        //        {
        //            Object v1 = getValue();
        //            Object v2 = e.getValue();
        //            if (v1 == v2 || (v1 != null && v1.equals(v2)))
        //                return true;
        //        }
        //        return false;
        //    }

        //    public final int hashCode()
        //    {
        //        return (key == null ? 0 : key.hashCode()) ^
        //               (value == null ? 0 : value.hashCode());
        //    }

        //    public final String toString()
        //    {
        //        return getKey() + "=" + getValue();
        //    }

        //    /**
        //     * This method is invoked whenever the value in an entry is
        //     * overwritten by an invocation of put(k,v) for a key k that's already
        //     * in the HashMap.
        //     */
        //    void recordAccess(HashMap<K, V> m)
        //    {
        //    }

        //    /**
        //     * This method is invoked whenever the entry is
        //     * removed from the table.
        //     */
        //    void recordRemoval(HashMap<K, V> m)
        //    {
        //    }
        //}
    }

    internal class Entity<K, V>
    {
        private readonly int hash;
        private readonly K key;
        private V value;
        private Entity<K, V> next;

        private Entity(int h, K k, V v, Entity<K, V> n)
        {
            value = v;
            key = k;
            hash = h;
            next = n;
        }

        public K Key
        {
            get
            {
                return key;
            }
        }

        public V Value
        {
            get
            {
                return value;
            }
            set
            {
                V oldValue = this.value;
                this.value = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity<K, V>))
            {
                return false;
            }

            Entity<K, V> e = (Entity<K, V>)obj;
            K k1 = Key;
            K k2 = e.Key;
            if (k1 == k2 || (k1 != null && k1.Equals(k2)))
            {
                V v1 = Value;
                V v2 = e.Value;
                if (v1 == v2 || (v1 != null && v1.Equals(v2)))
                {
                    return true;
                }
                Dictionary<string, string> dd;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (key == null ? 0 : key.GetHashCode()) ^
                (value == null ? 0 : value.GetHashCode());
        }
    }
}

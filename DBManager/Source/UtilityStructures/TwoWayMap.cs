using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.UtilityStructures
{
    internal class TwoWayMap<TKEY, TVALUE>
    {
        private Dictionary<TKEY, TVALUE> _baseMap = new Dictionary<TKEY, TVALUE>();
        private Dictionary<TVALUE, TKEY> _reverseMap = new Dictionary<TVALUE, TKEY>();

        public void Add(TKEY key, TVALUE value)
        {
            _baseMap.Add(key, value);
            _reverseMap.Add(value, key);
        }

        public TVALUE Get(TKEY key) => _baseMap[key];

        public TKEY GetKey(TVALUE value) => _reverseMap[value];

        public void Remove(TKEY key)
        {
            _reverseMap.Remove(_baseMap[key]);
            _baseMap.Remove(key);
        }

        public void RemoveByValue(TVALUE value)
        {
            _baseMap.Remove(_reverseMap[value]);
            _reverseMap.Remove(value);
        }

        public bool ContainsKey(TKEY key) => _baseMap.ContainsKey(key);

        public bool ContainsValue(TVALUE value) => _reverseMap.ContainsKey(value);
    }
}

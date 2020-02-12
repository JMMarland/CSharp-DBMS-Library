using DBManager.Source.Cells;
using DBManager.Source.Tables;
using DBManager.Source.UtilityStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.TableStructures.Attributes
{
    internal class KeyAttribute<T> : IAttribute
    {
        private TwoWayMap<T, KeyCell<T>> _cellMap = new TwoWayMap<T, KeyCell<T>>();
        private Attribute<T> _baseAttribute;

        public bool IsKeyAttribute => true;

        public bool IsPrimaryKey => true;

        public KeyAttribute(Table containerTable) => _baseAttribute = new Attribute<T>(containerTable);

        private void CheckIfValueAlreadyExists(T value)
        {
            if (!_cellMap.ContainsKey(value))
                return;
            throw new NotImplementedException();
        }

        public void Add(KeyCell<T> cell)
        {
            CheckIfValueAlreadyExists(cell.Value);

            _baseAttribute.Add(cell);
            _cellMap.Add(cell.Value, cell);
        }

        public void Insert(int index, KeyCell<T> cell)
        {
            CheckIfValueAlreadyExists(cell.Value);

            _baseAttribute.Insert(index, cell);
            _cellMap.Add(cell.Value, cell);
        }

        public KeyCell<T> Get(T value) => _cellMap.Get(value);

        public Cell<T> GetAt(int index) => _baseAttribute.GetAt(index);

        public void RemoveAt(int index)
        {
            _cellMap.RemoveByValue((KeyCell<T>)_baseAttribute.GetAt(index));
            _baseAttribute.RemoveAt(index);
        }

        public void Remove(KeyCell<T> cell)
        {
            _baseAttribute.Remove(cell);
            _cellMap.RemoveByValue(cell);
        }

        public void Remove(T value)
        {
            _baseAttribute.Remove(_cellMap.Get(value));
            _cellMap.Remove(value);
        }
    }
}

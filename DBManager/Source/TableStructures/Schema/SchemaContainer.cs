using DBManager.Source.Cells;
using DBManager.Source.Tables;
using DBManager.Source.TableStructures.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.TableStructures.Schema
{
    internal class SchemaContainer
    {
        private SchemaAttributeContainer _attributes = new SchemaAttributeContainer();
        private SchemaRecordContainer _records = new SchemaRecordContainer();

        private int _maxRecordLength = 0;

        private bool _hasPrimaryKey = false;
        private const int _primaryKeyIndex = 0;

        public SchemaContainer(int maxRecordLength) => SetMaxRecordLength(maxRecordLength);

        public void SetMaxRecordLength(int maxRecordLength) => _maxRecordLength = maxRecordLength;

        public int AddPrimaryKeyAttr<T>(Table table)
        {
            if (_hasPrimaryKey)
                throw new NotImplementedException();

            if (_attributes.Count == 0)
                _attributes.Insert(_primaryKeyIndex, new KeyAttribute<T>(table));
            else
                _attributes.Add(new KeyAttribute<T>(table));

            _hasPrimaryKey = true;

            return _primaryKeyIndex;
        }

        public int AddAttribute<T>(Table table)
        {
            _attributes.Add(new Attribute<T>(table));
            return _attributes.Count - 1;
        }

        public void InsertAttribute<T>(int index, Table table) => _attributes.Insert(index, new Attribute<T>(table));

        public bool RemoveAttribute(IAttribute attribute)
        {
            if (attribute.IsPrimaryKey)
                _hasPrimaryKey = false;

            return _attributes.Remove(attribute);
        }
        
        public void RemoveAttributeAt(int index)
        {
            if (_hasPrimaryKey && index == _primaryKeyIndex)
                _hasPrimaryKey = false;

            _attributes.RemoveAt(index);
        }

        public IAttribute GetAttributeAt(int index) => _attributes.Get(index);

        public IAttribute GetPrimaryKeyAttr() => _attributes.Get(_primaryKeyIndex);
    }
}

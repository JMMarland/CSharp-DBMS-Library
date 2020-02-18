using DBManager.Source.Cells;
using DBManager.Source.Tables;
using DBManager.Source.TableStructures.Attributes;
using DBManager.Source.TableStructures.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.TableStructures.Schema
{
    internal class SchemaContainer
    {
        private SchemaOwners _owners;
        
        private SchemaAttributeContainer _attributes;
        private SchemaRecordContainer _records;

        private int _maxRecordLength = 0;

        private bool _hasPrimaryKey = false;
        private const int _primaryKeyIndex = 0;

        public SchemaContainer(SchemaOwners owners, int maxRecordLength)
        {
            SetMaxRecordLength(maxRecordLength);
            _owners = owners;
            _attributes = new SchemaAttributeContainer(_owners);
            _records = new SchemaRecordContainer();
        }

        public void SetMaxRecordLength(int maxRecordLength) => _maxRecordLength = maxRecordLength;

        private void CheckPrimaryKeyException()
        {
            if (_hasPrimaryKey)
                throw new NotImplementedException();
        }

        public int AddAttribute(IAttribute attribute)
        {
            _attributes.Add(attribute);
            return _attributes.Count - 1;
        }

        public int AddPrimaryKeyAttribute<T>(KeyAttribute<T> attribute)
        {
            CheckPrimaryKeyException();

            _attributes.Insert(_primaryKeyIndex, attribute);
            return _primaryKeyIndex;
        }

        public void InsertAttribute(int index, IAttribute attribute)
        {
            if (index == _primaryKeyIndex)
                CheckPrimaryKeyException();

            _attributes.Insert(index, attribute);
        }

        // NEED TO ADD FUNCTIONS TO REMOVE ATTRIBUTES
    }
}

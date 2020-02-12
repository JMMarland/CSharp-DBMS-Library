using DBManager.Source.TableStructures.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.TableStructures.Schema
{
    internal class SchemaRecordContainer
    {
        private List<Record> _records = new List<Record>();

        public int Count => _records.Count;

        public void Add(Record record) => _records.Add(record);

        public void Insert(int index, Record record) => _records.Insert(index, record);

        public Record Get(int index) => _records[index];

        public bool Remove(Record record) => _records.Remove(record);

        public void RemoveAt(int index) => _records.RemoveAt(index);
    }
}
